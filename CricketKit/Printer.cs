using System;
using System.Collections.Generic;
using System.Text;

namespace CricketKit
{
    public class Printer
    {
        public void Print(PurchaseDetail detail)
        {
            Console.WriteLine($"{detail.PurchaseID} {detail.User} {CalculateTotal(detail.Items)}");
        }

        public decimal CalculateTotal(List<PurchaseItem> items)
        {
            decimal result = 0;
            foreach (PurchaseItem item in items)
            {
                result += item.Quantity * item.Cost;
            }
            return result;
        }
    }
}
