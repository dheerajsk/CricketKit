using System;
using System.Collections.Generic;
using System.Text;

namespace CricketKit
{
    public class InputParser
    {
        public InputParserResult TryParse(string input)
        {
            InputParserResult result = new InputParserResult();
            string[] inputFragments = input.Split(',');
            int purchaseID;
            bool hasPurchaseID = Int32.TryParse(inputFragments[0], out purchaseID);
            if (!hasPurchaseID)
            {
                result.Errors.Add("Invalid PurchaseID");
                return result;
            }
            result.PurchaseDetail.PurchaseID = purchaseID;
            DateTime purchaseDate;
            bool hasPurchaseDate = DateTime.TryParse(inputFragments[1], out purchaseDate);
            if (!hasPurchaseDate)
            {
                result.Errors.Add("Invalid Purchase Date");
                return result;
            }
            result.PurchaseDetail.PurchaseDate = purchaseDate;
            result.PurchaseDetail.User = inputFragments[2];
            return ParseItems(result, inputFragments);
        }

        private InputParserResult ParseItems(InputParserResult result, string[] input)
        {
            for (int i = 3; i < input.Length; i += 3)
            {
                PurchaseItem item = new PurchaseItem();
                item.Name = input[i];
                Decimal cost;
                bool isValidCost = Decimal.TryParse(input[i + 1], out cost);
                if (!isValidCost)
                {
                    result.Errors.Add("Invalid Item Cost for " + item.Name);
                    return result;
                }
                item.Cost = cost;
                int quantity;
                bool isValidQuantity = Int32.TryParse(input[i + 2], out quantity);
                if (!isValidQuantity)
                {
                    result.Errors.Add("Invalid Item Quantity for " + item.Name);
                    return result;
                }
                item.Quantity = quantity;
                result.PurchaseDetail.Items.Add(item);
            }

            return result;
        }
    }
}
