using System.Collections.Generic;
using Web.ViewModel;
using MediatR;

namespace Web.Features.Queries
{
    public class GetCOAMap : IRequest<IEnumerable<VMCoaMap>>
    {
        public string _location { get; set; }

        public GetCOAMap(string location)
        {
            _location = location;
        }
    }
}
