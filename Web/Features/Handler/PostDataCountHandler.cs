using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Web.Features.Command;
using Web.ViewModel;
using Web.Factory;
using Web.Interface;
using Web.Helper;

namespace Web.Features.Handler
{
    public class PostDataCountHandler : IRequestHandler<PostDataCount, VMoutcount>
    {
        private readonly IAppConfig _appCfg;
        public PostDataCountHandler(IAppConfig appCfg)
        {
            _appCfg = appCfg;
            URLStatic.APIClientURL = _appCfg.GetData().URLSource;
        }

        public async Task<VMoutcount> Handle(PostDataCount request, CancellationToken cancellationToken)
        {
            var inputModel = new RaportInputCount(_appCfg.GetData().uname, _appCfg.GetData().pass, _appCfg.GetData().key, request._startDate, request._endDate);
            var intResponse = await ApiClientFactory.Instance.PostReport<VMoutcount, RaportInputCount>(inputModel);

            return intResponse;
        }
    }
}
