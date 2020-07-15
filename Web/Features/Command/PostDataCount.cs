using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Web.ViewModel;

namespace Web.Features.Command
{
    public class PostDataCount : commandBase<VMoutcount>
    {
        public string _startDate { get; set; }
        public string _endDate { get; set; }

        public PostDataCount(string startDate, string endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }
    }
}
