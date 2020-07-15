using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Web.ViewModel;

namespace Web.Features.Command
{
    public class PostDataRaport : commandBase<VMOutData>
    {
        public string _startDate { get; set; }
        public string _endDate { get; set; }
        public int _startNo { get; set; }
        public int _endNo { get; set; }

        public PostDataRaport(string startDate, string endDate, int startNo, int endNo)
        {
            _startDate = startDate;
            _endDate = endDate;
            _startNo = startNo;
            _endNo = endNo;
        }
    }
}

