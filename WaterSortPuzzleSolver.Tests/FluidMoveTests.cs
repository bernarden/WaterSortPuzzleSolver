using System.Collections.Generic;
using Xunit;

namespace WaterSortPuzzleSolver.Tests
{
    public class FluidMoveTests
    {
        [Fact]
        public void ExecuteShouldMoveTheFluid()
        {
            // Arrange
            var from = new Vial(new List<int> { 0, 1, 2, 3 });
            var to = new Vial(new List<int> { 0, 1, 2, 3 });
            var move = new FluidMove(from, to);

            // Act
            move.Execute();

            // Assert
            Assert.Equal(2, from.AvailableSpace);
            Assert.Equal(2, from.TopFluid);
            Assert.Equal(0, to.AvailableSpace);
            Assert.Equal(1, to.TopFluid);
            Assert.Equal(2, to.TopFluidAmount);
        }

        [Fact]
        public void ReverseShouldMoveTheFluid()
        {
            // Arrange
            var from = new Vial(new List<int> { 0, 1, 2, 3 });
            var to = new Vial(new List<int> { 0, 1, 2, 3 });
            var move = new FluidMove(from, to);
            move.Execute();

            // Act
            move.Reverse();

            // Assert
            Assert.Equal(1, from.AvailableSpace);
            Assert.Equal(1, from.TopFluid);
            Assert.Equal(1, to.AvailableSpace);
            Assert.Equal(1, to.TopFluid);
            Assert.Equal(1, to.TopFluidAmount);
        }
    }
}