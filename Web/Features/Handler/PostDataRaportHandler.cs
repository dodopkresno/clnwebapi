using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModel;
using Web.Features.Command;
using System.Threading;
using Web.Interface;
using Web.Helper;
using Web.Factory;
using Core.Interface;

namespace Web.Features.Handler
{
    public class PostDataRaportHandler : IRequestHandler<PostDataRaport,VMOutData>
    {
        private readonly IAppConfig _appCfg;
        private readonly ICoaMapRepository _coamapRepository;
        public PostDataRaportHandler(IAppConfig appCfg, ICoaMapRepository coaMapRepository)
        {
            _coamapRepository = coaMapRepository;
            _appCfg = appCfg;
            URLStatic.APIClientURL = appCfg.GetData().URLSource;
        }
        public async Task<VMOutData> Handle(PostDataRaport request, CancellationToken cancellationToken)
        {
            //create input parameter for API Client 
            var inputModel = new RaportInputInc(_appCfg.GetData().uname, _appCfg.GetData().pass, _appCfg.GetData().key, request._startDate, request._endDate, request._startNo, request._endNo);
            //get data
            var result = await ApiClientFactory.Instance.PostReport<VMOutData, RaportInputInc>(inputModel);
            //get data mapping
            var coamap = await _coamapRepository.GetListAsync(_appCfg.GetData().JSONDataLocation);
            //do action coa transform
            List<VMRaport> items = new List<VMRaport>();
            foreach (var data in result.data)
            {
                VMRaport item = new VMRaport();
                
                item.KD_CABANG = data.KD_CABANG;
                item.KD_TERMINAL = data.KD_TERMINAL;
                item.NAMA_TERMINAL = data.NAMA_TERMINAL;
                item.PROFIT_CTR = data.PROFIT_CTR;
                item.VOYAGE_NO = data.VOYAGE_NO;
                item.KODE_KAPAL = data.KODE_KAPAL;
                item.IMO = data.IMO;
                item.CALL_SIGN = data.CALL_SIGN;
                item.NAMA_KAPAL = data.NAMA_KAPAL;
                item.PPK1_NO = data.PPK1_NO;
                item.PKK_NO = data.PKK_NO;
                item.PPKB_NO = data.PPKB_NO;
                item.JENIS_KAPAL = data.JENIS_KAPAL;
                item.GRT_KAPAL = data.GRT_KAPAL;
                item.LOA_KAPAL = data.LOA_KAPAL;
                item.JENIS_PELAYARAN = data.JENIS_PELAYARAN;
                item.BENDERA = data.BENDERA;
                item.KD_DERMAGA = data.KD_DERMAGA;
                item.NAMA_DERMAGA = data.NAMA_DERMAGA;
                item.JNS_DERMAGA = data.JNS_DERMAGA;
                item.NO_APPROVAL = data.NO_APPROVAL;
                item.TGL_APPROVAL = data.TGL_APPROVAL;
                item.NO_PKEMAS = data.NO_PKEMAS;
                item.UKURAN_PKEMAS = data.UKURAN_PKEMAS;
                item.TIPE_PKEMAS = data.TIPE_PKEMAS;
                item.STATUS_PKEMAS = data.STATUS_PKEMAS;
                item.KATEGORI_PKEMAS = data.KATEGORI_PKEMAS;
                item.BERAT_PKEMAS = data.BERAT_PKEMAS;
                item.ISOCODE = data.ISOCODE;
                item.KD_SERVIS = data.KD_SERVIS;
                item.TL_NONTL = data.TL_NONTL;
                item.TRANS_YN = data.TRANS_YN;
                item.KD_AKTIVITAS = data.KD_AKTIVITAS;
                item.NAMA_AKTIVITAS = data.NAMA_AKTIVITAS;
                item.TGL_MULAI_AKTIVITAS = data.TGL_MULAI_AKTIVITAS;
                item.TGL_SELESAI_AKTIVITAS = data.TGL_SELESAI_AKTIVITAS;
                item.KD_BRG = data.KD_BRG;
                item.KLMPK_BRG = data.KLMPK_BRG;
                item.KOMODITI_BRG = data.KOMODITI_BRG;
                item.IMDG_CODE = data.IMDG_CODE;
                item.FCLLCL_PKEMAS = data.FCLLCL_PKEMAS;
                item.JNS_BM = data.JNS_BM;
                item.TAGIHAN = data.TAGIHAN;
                item.KURS = data.KURS;
                item.MATA_UANG = data.MATA_UANG;
                item.KD_ORIGIN_KAPAL = data.KD_ORIGIN_KAPAL;
                item.NAMA_ORIGIN_KAPAL = data.NAMA_ORIGIN_KAPAL;
                item.KD_DEST_KAPAL = data.KD_DEST_KAPAL;
                item.NAMA_DEST_KAPAL = data.NAMA_DEST_KAPAL;
                item.KD_POL = data.KD_POL;
                item.NAMA_POL = data.NAMA_POL;
                item.KD_POD = data.KD_POD;
                item.NAMA_POD = data.NAMA_POD;
                item.KD_FINAL_POD = data.KD_FINAL_POD;
                item.NAMA_FINAL_POD = data.NAMA_FINAL_POD;
                item.AGENT_CODE = data.AGENT_CODE;
                item.AGENT_NAME = data.AGENT_NAME;
                item.KD_TERTAGIH = data.KD_TERTAGIH;
                item.NAMA_TERTAGIH = data.NAMA_TERTAGIH;
                item.KD_PBM = data.KD_PBM;
                item.NAMA_PBM = data.NAMA_PBM;
                item.JNS_PBM = data.JNS_PBM;
                item.JUMLAH_PRODUKSI = data.JUMLAH_PRODUKSI;
                item.SATUAN_PRODUKSI = data.SATUAN_PRODUKSI;
                item.JUMLAH_ARUS = data.JUMLAH_ARUS;
                item.SATUAN_ARUS = data.SATUAN_ARUS;
                item.REC_STAT = data.REC_STAT;

                bool is_dg = true;
                bool is_i = false;

                if (data.JENIS_PELAYARAN.ToUpper() == "INTERNATIONAL")
                    is_i = true;
               
                if (data.IMDG_CODE == null || data.IMDG_CODE == "")
                    is_dg = false;

                var rData = coamap.Select(p => new
                {
                    ctype = p.CTYPE,
                    csts = p.CSTS,
                    clength = p.CLENGTH,
                    act = p.ACT,
                    dg = p.DG,
                    service = p.SERVICE,
                    is_int = p.IS_INT,
                    coa_prod = p.COA_PROD,
                    coa_arus = p.COA_ARUS //??= "-"
                }).Where(i => i.ctype == data.TIPE_PKEMAS && i.csts == data.STATUS_PKEMAS && 
                i.clength == data.UKURAN_PKEMAS && 
                i.act == data.KD_AKTIVITAS && 
                i.dg == is_dg && i.service == data.KD_SERVIS && i.is_int == is_i).FirstOrDefault();

                if (coamap is null)
                {
                    item.COA_ARUS = "Failed to load CoaMap";
                    item.COA_PROD = "Failed to load CoaMap";
                }
                else
                {
                    if (rData is null)
                    {
                        item.COA_ARUS = "-";
                        item.COA_PROD = "-";
                    }
                    else
                    {
                        item.JUMLAH_PRODUKSI = "1";
                        item.JUMLAH_ARUS = "1";
                        item.SATUAN_PRODUKSI = "BOX";
                        item.SATUAN_ARUS = "BOX";
                        item.COA_PROD = rData.coa_prod;
                        item.COA_ARUS = rData.coa_arus;
                    }
                }
                items.Add(item);
            }

            //disable publisher mediatR

            var output = new VMOutData(result.status, $"{result.message} get data raport from:{request._startDate} to {request._endDate}, start data no:{request._startNo} to {request._endNo}", items);
            return output;
        }
    }
}
