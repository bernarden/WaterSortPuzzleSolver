using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace WaterSortPuzzleSolver.Tests
{
    public class GameSolverTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public GameSolverTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void EasyScenario()
        {
            // Arrange
            var vials = new List<Vial>
            {
                new(new[] { 1, 2, 3, 1 }),
                new(new[] { 1, 2, 3, 3 }),
                new(new[] { 2, 3, 1, 2 }),
                new(new int[4]),
                new(new int[4]),
            };

            // Act
            var result = GameSolver.Solve(vials);

            // Assert
            _testOutputHelper.WriteLine("Result:");
            PrintVials(vials);
            Assert.Equal(result.Count, vials.Count);
            foreach (var vial in result)
            {
                Assert.True(vial.IsEmpty || vial.IsComplete);
            }
        }

        private void PrintVials(IEnumerable<Vial> vials)
        {
            foreach (var vial in vials)
            {
                _testOutputHelper.WriteLine(vial.ToString());
            }
        }
    }
}