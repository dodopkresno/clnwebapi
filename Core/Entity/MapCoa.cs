using System;
using System.Collections.Generic;
using System.Text;
using Core.Interface;

namespace Core.Entity
{
    public class MapCoa : IEntity
    {
        public string CTYPE { get; set; }
        public string CSTS { get; set; }
        public string CLENGTH { get; set; }
        public string ACT { get; set; }
        public string ACT_DESC { get; set; }
        public bool? DG { get; set; }
        public string SERVICE { get; set; }
        public bool IS_INT { get; set; }
        public string COA_PROD { get; set; }
        public string COA_ARUS { get; set; }
    }
}
