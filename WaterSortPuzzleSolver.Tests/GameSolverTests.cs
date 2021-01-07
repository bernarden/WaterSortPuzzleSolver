using System.Collections.Generic;
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
            // Arrange (Level 5)
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
            PrintVials("Result: ", vials);
            Assert.Equal(result.Count, vials.Count);
            foreach (var vial in result)
            {
                Assert.True(vial.IsEmpty || vial.IsComplete);
            }
        }

        [Fact]
        public void MediumScenario()
        {
            // Arrange (Level 50)
            var vials = new List<Vial>
            {
                new(new[] { 1, 2, 3, 4 }),
                new(new[] { 5, 5, 5, 6 }),
                new(new[] { 2, 3, 2, 7 }),
                new(new[] { 4, 1, 7, 8 }),
                new(new[] { 8, 3, 7, 4 }),
                new(new[] { 5, 9, 7, 8 }),
                new(new[] { 2, 3, 6, 1 }),
                new(new[] { 9, 4, 9, 6 }),
                new(new[] { 9, 1, 8, 6 }),
                new(new int[4]),
                new(new int[4]),
            };

            // Act
            var result = GameSolver.Solve(vials);

            // Assert
            PrintVials("Result: ", vials);
            Assert.Equal(result.Count, vials.Count);
            foreach (var vial in result)
            {
                Assert.True(vial.IsEmpty || vial.IsComplete);
            }
        }

        private void PrintVials(string title, IEnumerable<Vial> vials)
        {
            _testOutputHelper.WriteLine(title);

            foreach (var vial in vials)
            {
                _testOutputHelper.WriteLine(vial.ToString());
            }
        }
    }
}