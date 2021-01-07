using System;
using System.Linq;
using Xunit;

namespace WaterSortPuzzleSolver.Tests
{
    public class FluidAmountCalculatorTests
    {
        [Theory]
        [InlineData("0,0,0,0", "0,0,0,0", 0)]
        [InlineData("0,0,0,0", "0,0,1,1", 0)]
        [InlineData("0,0,0,1", "0,0,0,0", 0)]
        [InlineData("0,0,1,1", "0,0,0,0", 0)]
        [InlineData("0,0,1,1", "0,0,0,1", 2)]
        [InlineData("1,1,1,1", "0,0,0,0", 0)]
        [InlineData("0,1,1,1", "0,0,0,1", 3)]
        [InlineData("0,1,1,1", "0,0,0,2", 0)]
        [InlineData("0,1,1,1", "2,2,2,2", 0)]
        [InlineData("1,2,3,1", "0,0,0,1", 1)]
        public void Test(string from, string to, int expected)
        {
            // Arrange
            string[] fromValues = from.Split(new[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries);
            string[] toValues = to.Split(new[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries);
            var fromVial = new Vial(fromValues.Select(int.Parse));
            var toVial = new Vial(toValues.Select(int.Parse));

            // Act
            var result = FluidAmountCalculator.HowMuchFluidCanBeMoved(fromVial, toVial);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}