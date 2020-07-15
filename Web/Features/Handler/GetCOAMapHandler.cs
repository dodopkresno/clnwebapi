using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Web.Features.Queries;
using Web.ViewModel;
using System.Threading;
using Core.Interface;

namespace Web.Features.Handler
{
    public class GetCOAMapHandler : IRequestHandler<GetCOAMap, IEnumerable<VMCoaMap>>
    {
        private readonly ICoaMapRepository _coamapRepository;
        //private readonly ICoaMapProfile _VMCoaMapper;

        public GetCOAMapHandler(ICoaMapRepository coamapRepository/*, ICoaMapProfile VMCoaMapper*/)
        {
            _coamapRepository = coamapRepository ?? throw new ArgumentNullException();
            //_VMCoaMapper = VMCoaMapper;
        }

        public async Task<IEnumerable<VMCoaMap>> Handle(GetCOAMap request, CancellationToken cancellationToken)
        {
            var coamap = await _coamapRepository.GetListAsync(request._location);
            //manual mapp
            
            return coamap.Select(i => new VMCoaMap
            {
                contype = i.CTYPE,
                constatus = i.CSTS,
                conlength = i.CLENGTH,
                ACT = i.ACT,
                ACT_DESC = i.ACT_DESC,
                DG = i.DG,
                SERVICE = i.SERVICE,
                IS_INT = i.IS_INT,
                COA_PROD = i.COA_PROD,
                COA_ARUS = i.COA_ARUS
            });
        }
    }
}
