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
    public class PostDataCountV2Handler : IRequestHandler<PostDataCount, VMoutcount>
    {
        private readonly IAppConfig _appCfg;
        private readonly ICoaMapRepository _coamapRepository;

        public PostDataCountV2Handler(IAppConfig appCfg, ICoaMapRepository coaMapRepository)
        {
            _coamapRepository = coaMapRepository;
            _appCfg = appCfg;
            URLStatic.APIClientURL = appCfg.GetData().URLSource;
        }

        public async Task<VMoutcount> Handle(PostDataCount request, CancellationToken cancellationToken)
        {
            //create input parameter for API Client 
            var inputModel = new ParamRaport(_appCfg.GetData().uname, _appCfg.GetData().pass, _appCfg.GetData().key, request._startDate, request._endDate, "N");
            //get data
            var result = await ApiClientFactory.Instance.PostReport<VMoutcount, ParamRaport>(inputModel);
            return result;
        }
    }
}
