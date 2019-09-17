using ArrayCalcAPI.Controllers;
using ArrayCalcAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ArrayCalcUnitTest
{
    public class ArrayCalcUnitTest
    {
        [Fact]
        public async Task ReverseArrayAsync_ShouldReturnReversedArray()
        {
            // Arrange
            int[] productIds = { 1, 2, 3, 4, 5 };
            var arrayCalcController = new ArrayCalcController(new ArrayCalcService());
            // Act
            var response = await arrayCalcController.Reverse(productIds);

            // Assert
            Assert.Null(response.Result);
            Assert.NotNull(response.Value);

            int[] expected = { 5, 4, 3, 2, 1 };
            Assert.Equal(expected.Length, response.Value.Length);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], response.Value[i]);
            }
        }

        [Fact]
        public async Task DeletePartOfArrayAsync_ShouldReturnRemainingArray()
        {
            // Arrange
            int[] productIds = { 1, 2, 3, 4, 5 };
            int position = 3;
            var arrayCalcController = new ArrayCalcController(new ArrayCalcService());
            // Act
            var response = await arrayCalcController.DeletePart(position, productIds);
            
            // Assert
            Assert.Null(response.Result);
            Assert.NotNull(response.Value);

            int[] expected = { 1, 2, 4, 5 };
            Assert.Equal(expected.Length, response.Value.Length);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], response.Value[i]);
            }
        }

        [Fact]
        public async Task DeletePartOfArrayAsync_ShouldReturnOutOfRangeError()
        {
            // Arrange
            int[] productIds = { 1, 2, 3, 4, 5 };
            int position = 0;
            var arrayCalcController = new ArrayCalcController(new ArrayCalcService());
            // Act
            var response = await arrayCalcController.DeletePart(position, productIds);
            // Assert
            Assert.NotNull(response.Result);
            Assert.Null(response.Value);
            Assert.IsType<BadRequestObjectResult>(response.Result);

            var errMsg = (response.Result as BadRequestObjectResult).Value;
            Assert.Equal("The position is out of range.", errMsg);
        }
    }
}
