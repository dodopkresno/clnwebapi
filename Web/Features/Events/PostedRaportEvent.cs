using System;
using System.Globalization;
using MediatR;

namespace Web.Features.Events
{
    public class PostedRaportEvent : INotification
    {
        public bool _status { get; set; }
        public string _message { get;  }
        public string _startDate { get;  }
        public string _endDate { get; set; }
        public int _startNo { get; set; }
        public int _endNo { get; set; }

        public PostedRaportEvent(bool status, string message, string startDate, string endDate, int startNo, int endNo)
        {
            _status = status;
            _message = message;
            _startDate = startDate;
            _endDate = endDate;
            _startNo = startNo;
            _endNo = endNo;
        }
    }
}
