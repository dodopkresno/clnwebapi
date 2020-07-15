using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModel;

namespace Web.Features.Command
{
    public class PostData : commandBase<VMOutData>
    {
        public string _startDate { get; set; }
        public string _endDate { get; set; }

        public PostData(string startDate, string endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }
    }
}
