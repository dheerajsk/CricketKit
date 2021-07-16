using System;
using System.Collections.Generic;
using System.Text;

namespace CricketKit
{
    public class PurchaseDetail
    {
        public PurchaseDetail()
        {
            this.Items = new List<PurchaseItem>();
        }
        public int PurchaseID { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string User { get; set; }

        public List<PurchaseItem> Items { get; set; }
    }

    public class PurchaseItem
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int Quantity { get; set; }
    }
}
