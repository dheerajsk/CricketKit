using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CricketKit.Tests
{
    public class InputParserTests
    {
        [Fact]
        public void TestForInvalidPurchaseID()
        {
            // Arrange
            string input = "12-12-2012,Peter,Bat,1500,3,Ball,60,8,Stump,340,1";
            string expectedError = "Invalid PurchaseID";

            // Act
            InputParserResult result = new InputParser().TryParse(input);

            // Assert
            Assert.True(result.Errors.Count > 0);
            Assert.True(result.Errors.Contains(expectedError));
        }

        [Fact]
        public void TestForInvalidPurchaseDate()
        {
            // Arrange
            string input = "2,'Date',Peter,Bat,1500,3,Ball,60,8,Stump,340,1";
            string expectedError = "Invalid Purchase Date";

            // Act
            InputParserResult result = new InputParser().TryParse(input);

            // Assert
            Assert.True(result.Errors.Count > 0);
            Assert.True(result.Errors.Contains(expectedError));
        }

        [Fact]
        public void TestForInvalidItemCost()
        {
            // Arrange
            string input = "2,12-12-2012,Peter,Bat,Cost,3,Ball,60,8,Stump,340,1";
            string expectedError = "Invalid Item Cost for Bat";

            // Act
            InputParserResult result = new InputParser().TryParse(input);

            // Assert
            Assert.True(result.Errors.Count > 0);
            Assert.True(result.Errors.Contains(expectedError));
        }

        [Fact]
        public void TestForInvalidItemQuantity()
        {
            // Arrange
            string input = "2,12-12-2012,Peter,Bat,1500,3,Ball,60,8,Stump,340,Quantity";
            string expectedError = "Invalid Item Quantity for Stump";

            // Act
            InputParserResult result = new InputParser().TryParse(input);

            // Assert
            Assert.True(result.Errors.Count > 0);
            Assert.True(result.Errors.Contains(expectedError));
        }

        [Fact]
        public void TestForValidParsing()
        {
            // Arrange
            string input = "2,12-12-2012,Peter,Bat,1500,3,Ball,60,8,Stump,340,4";
            InputParserResult expecteResult = new InputParserResult();
            expecteResult.PurchaseDetail.PurchaseID = 2;
            expecteResult.PurchaseDetail.PurchaseDate = Convert.ToDateTime("12-12-2012");
            expecteResult.PurchaseDetail.User = "Peter";
            expecteResult.PurchaseDetail.Items.Add(new PurchaseItem { Name = "Bat", Cost = 1500, Quantity = 3 });
            expecteResult.PurchaseDetail.Items.Add(new PurchaseItem { Name = "Ball", Cost = 60, Quantity = 8 });
            expecteResult.PurchaseDetail.Items.Add(new PurchaseItem { Name = "Stump", Cost = 340, Quantity = 4 });

            // Act
            InputParserResult result = new InputParser().TryParse(input);

            // Assert
            Assert.True(result.Errors.Count == 0);
            Assert.True(result.PurchaseDetail.Items.Count == 3);
            Assert.Equal(result.PurchaseDetail.PurchaseDate, expecteResult.PurchaseDetail.PurchaseDate);
            Assert.Equal(result.PurchaseDetail.PurchaseID, expecteResult.PurchaseDetail.PurchaseID);
            Assert.Equal(result.PurchaseDetail.User, expecteResult.PurchaseDetail.User);
        }
    }
}
