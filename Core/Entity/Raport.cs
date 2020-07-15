using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Raport
    {
        public string KD_CABANG { get; private set; }
        public string KD_TERMINAL { get; private set; }
        public string NAMA_TERMINAL { get; private set; }
        public string PROFIT_CTR { get; private set; }
        public string VOYAGE_NO { get; private set; }
        public string KODE_KAPAL { get; private set; }
        public string IMO { get; private set; }
        public string CALL_SIGN { get; private set; }
        public string NAMA_KAPAL { get; private set; }
        public string PPK1_NO { get; private set; }
        public string PKK_NO { get; private set; }
        public string PPKB_NO { get; private set; }
        public string JENIS_KAPAL { get; private set; }
        public string GRT_KAPAL { get; private set; }
        public string LOA_KAPAL { get; private set; }
        public string JENIS_PELAYARAN { get; private set; }
        public string BENDERA { get; private set; }
        public string KD_DERMAGA { get; private set; }
        public string NAMA_DERMAGA { get; private set; }
        public string JNS_DERMAGA { get; private set; }
        public string NO_APPROVAL { get; private set; }
        public string TGL_APPROVAL { get; private set; }
        public string NO_PKEMAS { get; private set; }
        public string UKURAN_PKEMAS { get; private set; }
        public string TIPE_PKEMAS { get; private set; }
        public string STATUS_PKEMAS { get; private set; }
        public string KATEGORI_PKEMAS { get; private set; }
        public string BERAT_PKEMAS { get; private set; }
        public string ISOCODE { get; private set; }
        public string KD_SERVIS { get; private set; }
        public string TL_NONTL { get; private set; }
        public string TRANS_YN { get; private set; }
        public string KD_AKTIVITAS { get; private set; }
        public string NAMA_AKTIVITAS { get; private set; }
        public string TGL_MULAI_AKTIVITAS { get; private set; }
        public string TGL_SELESAI_AKTIVITAS { get; private set; }
        public string KD_BRG { get; private set; }
        public string KLMPK_BRG { get; private set; }
        public string KOMODITI_BRG { get; private set; }
        public string IMDG_CODE { get; private set; }
        public string FCLLCL_PKEMAS { get; private set; }
        public string JNS_BM { get; private set; }
        public string TAGIHAN { get; private set; }
        public string KURS { get; private set; }
        public string MATA_UANG { get; private set; }
        public string KD_ORIGIN_KAPAL { get; private set; }
        public string NAMA_ORIGIN_KAPAL { get; private set; }
        public string KD_DEST_KAPAL { get; private set; }
        public string NAMA_DEST_KAPAL { get; private set; }
        public string KD_POL { get; private set; }
        public string NAMA_POL { get; private set; }
        public string KD_POD { get; private set; }
        public string NAMA_POD { get; private set; }
        public string KD_FINAL_POD { get; private set; }
        public string NAMA_FINAL_POD { get; private set; }
        public string AGENT_CODE { get; private set; }
        public string AGENT_NAME { get; private set; }
        public string KD_TERTAGIH { get; private set; }
        public string NAMA_TERTAGIH { get; private set; }
        public string KD_PBM { get; private set; }
        public string NAMA_PBM { get; private set; }
        public string JNS_PBM { get; private set; }
        public string JUMLAH_PRODUKSI { get; private set; }
        public string SATUAN_PRODUKSI { get; private set; }
        public string JUMLAH_ARUS { get; private set; }
        public string SATUAN_ARUS { get; private set; }
        public string REC_STAT { get; private set; }
        public string COA_PROD { get; private set; }
        public string COA_ARUS { get; private set; }

        public Raport(string KD_CABANG, string KD_TERMINAL, string NAMA_TERMINAL, string PROFIT_CTR, string VOYAGE_NO, string KODE_KAPAL, string IMO, string CALL_SIGN, string NAMA_KAPAL, string PPK1_NO, string PKK_NO, string PPKB_NO, string JENIS_KAPAL, string GRT_KAPAL, string LOA_KAPAL, string JENIS_PELAYARAN, string BENDERA, string KD_DERMAGA, string NAMA_DERMAGA, string JNS_DERMAGA, string NO_APPROVAL, string TGL_APPROVAL, string NO_PKEMAS, string UKURAN_PKEMAS, string TIPE_PKEMAS, string STATUS_PKEMAS, string KATEGORI_PKEMAS, string BERAT_PKEMAS, string ISOCODE, string KD_SERVIS, string TL_NONTL, string TRANS_YN, string KD_AKTIVITAS, string NAMA_AKTIVITAS, string TGL_MULAI_AKTIVITAS, string TGL_SELESAI_AKTIVITAS, string KD_BRG, string KLMPK_BRG, string KOMODITI_BRG, string IMDG_CODE, string FCLLCL_PKEMAS, string JNS_BM, string TAGIHAN, string KURS, string MATA_UANG, string KD_ORIGIN_KAPAL, string NAMA_ORIGIN_KAPAL, string KD_DEST_KAPAL, string NAMA_DEST_KAPAL, string KD_POL, string NAMA_POL, string KD_POD, string NAMA_POD, string KD_FINAL_POD, string NAMA_FINAL_POD, string AGENT_CODE, string AGENT_NAME, string KD_TERTAGIH, string NAMA_TERTAGIH, string KD_PBM, string NAMA_PBM, string JNS_PBM, string JUMLAH_PRODUKSI, string SATUAN_PRODUKSI, string JUMLAH_ARUS, string SATUAN_ARUS, string REC_STAT, string COA_PROD, string COA_ARUS)
        {
            this.KD_CABANG = KD_CABANG;
            this.KD_TERMINAL = KD_TERMINAL;
            this.NAMA_TERMINAL = NAMA_TERMINAL;
            this.PROFIT_CTR = PROFIT_CTR;
            this.VOYAGE_NO = VOYAGE_NO;
            this.KODE_KAPAL = KODE_KAPAL;
            this.IMO = IMO;
            this.CALL_SIGN = CALL_SIGN;
            this.NAMA_KAPAL = NAMA_KAPAL;
            this.PPK1_NO = PPK1_NO;
            this.PKK_NO = PKK_NO;
            this.PPKB_NO = PPKB_NO;
            this.JENIS_KAPAL = JENIS_KAPAL;
            this.GRT_KAPAL = GRT_KAPAL;
            this.LOA_KAPAL = LOA_KAPAL;
            this.JENIS_PELAYARAN = JENIS_PELAYARAN;
            this.BENDERA = BENDERA;
            this.KD_DERMAGA = KD_DERMAGA;
            this.NAMA_DERMAGA = NAMA_DERMAGA;
            this.JNS_DERMAGA = JNS_DERMAGA;
            this.NO_APPROVAL = NO_APPROVAL;
            this.TGL_APPROVAL = TGL_APPROVAL;
            this.NO_PKEMAS = NO_PKEMAS;
            this.UKURAN_PKEMAS = UKURAN_PKEMAS;
            this.TIPE_PKEMAS = TIPE_PKEMAS;
            this.STATUS_PKEMAS = STATUS_PKEMAS;
            this.KATEGORI_PKEMAS = KATEGORI_PKEMAS;
            this.BERAT_PKEMAS = BERAT_PKEMAS;
            this.ISOCODE = ISOCODE;
            this.KD_SERVIS = KD_SERVIS;
            this.TL_NONTL = TL_NONTL;
            this.TRANS_YN = TRANS_YN;
            this.KD_AKTIVITAS = KD_AKTIVITAS;
            this.NAMA_AKTIVITAS = NAMA_AKTIVITAS;
            this.TGL_MULAI_AKTIVITAS = TGL_MULAI_AKTIVITAS;
            this.TGL_SELESAI_AKTIVITAS = TGL_SELESAI_AKTIVITAS;
            this.KD_BRG = KD_BRG;
            this.KLMPK_BRG = KLMPK_BRG;
            this.KOMODITI_BRG = KOMODITI_BRG;
            this.IMDG_CODE = IMDG_CODE;
            this.FCLLCL_PKEMAS = FCLLCL_PKEMAS;
            this.JNS_BM = JNS_BM;
            this.TAGIHAN = TAGIHAN;
            this.KURS = KURS;
            this.MATA_UANG = MATA_UANG;
            this.KD_ORIGIN_KAPAL = KD_ORIGIN_KAPAL;
            this.NAMA_ORIGIN_KAPAL = NAMA_ORIGIN_KAPAL;
            this.KD_DEST_KAPAL = KD_DEST_KAPAL;
            this.NAMA_DEST_KAPAL = NAMA_DEST_KAPAL;
            this.KD_POL = KD_POL;
            this.NAMA_POL = NAMA_POL;
            this.KD_POD = KD_POD;
            this.NAMA_POD = NAMA_POD;
            this.KD_FINAL_POD = KD_FINAL_POD;
            this.NAMA_FINAL_POD = NAMA_FINAL_POD;
            this.AGENT_CODE = AGENT_CODE;
            this.AGENT_NAME = AGENT_NAME;
            this.KD_TERTAGIH = KD_TERTAGIH;
            this.NAMA_TERTAGIH = NAMA_TERTAGIH;
            this.KD_PBM = KD_PBM;
            this.NAMA_PBM = NAMA_PBM;
            this.JNS_PBM = JNS_PBM;
            this.JUMLAH_PRODUKSI = JUMLAH_PRODUKSI;
            this.SATUAN_PRODUKSI = SATUAN_PRODUKSI;
            this.JUMLAH_ARUS = JUMLAH_ARUS;
            this.SATUAN_ARUS = SATUAN_ARUS;
            this.REC_STAT = REC_STAT;
            this.COA_PROD = COA_PROD;
            this.COA_ARUS = COA_ARUS;
        }
    }
}
