using System;
using System.Collections.Generic;
using Xunit;

namespace CricketKit.Tests
{
    public class PrinterTests
    {
        [Fact]
        public void TestCalculateTotal()
        {
            // Arrange
            List<PurchaseItem> items = new List<PurchaseItem>();
            items.Add(new PurchaseItem { Cost = 100, Quantity = 5 });
            items.Add(new PurchaseItem { Cost = 200, Quantity = 2 });
            items.Add(new PurchaseItem { Cost = 2000, Quantity = 4 });
            items.Add(new PurchaseItem { Cost = 500, Quantity = 3 });
            decimal expected = 10400;

            // Act
            decimal result = new Printer().CalculateTotal(items);

            // Assert
            Assert.Equal(result, expected);
        }
    }
}
