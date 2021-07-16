using System;
using System.Collections.Generic;
using System.Text;

namespace CricketKit
{
    public class InputParserResult
    {
        public InputParserResult()
        {
            this.Errors = new List<string>();
            this.PurchaseDetail = new PurchaseDetail();
        }

        public PurchaseDetail PurchaseDetail { get; set; }

        public List<string> Errors { get; set; }
    }
}
