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
        public void VeryEasyScenario()
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
            var result = GameSolver.RecursiveSolve(vials, new Stack<FluidMove>(), new HashSet<string>());

            // Assert
            PrintVials("Result: ", vials);
            Assert.Equal(result.CurrentState.Count, vials.Count);
            foreach (var vial in result.CurrentState)
            {
                Assert.True(vial.IsEmpty || vial.IsComplete);
            }
        }

        [Fact]
        public void EasyScenario()
        {
            // Arrange 
            var vials = new List<Vial>
            {
                new(new[] { 1, 2, 3, 4 }),
                new(new[] { 1, 2, 4, 3 }),
                new(new[] { 5, 3, 5, 1 }),
                new(new[] { 2, 5, 1, 3 }),
                new(new[] { 2, 5, 4, 4 }),
                new(new int[4]),
                new(new int[4]),
            };

            // Act
            var result = GameSolver.RecursiveSolve(vials, new Stack<FluidMove>(), new HashSet<string>());

            // Assert
            PrintVials("Result: ", vials);
            Assert.Equal(result.CurrentState.Count, vials.Count);
            foreach (var vial in result.CurrentState)
            {
                Assert.True(vial.IsEmpty || vial.IsComplete);
            }
        }

        [Fact]
        public void MediumScenario()
        {
            // Arrange https://www.youtube.com/watch?v=ez1Wo78TyfU
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
            var result = GameSolver.RecursiveSolve(vials, new Stack<FluidMove>(), new HashSet<string>());

            // Assert
            PrintVials("Result: ", vials);
            Assert.Equal(result.CurrentState.Count, vials.Count);
            foreach (var vial in result.CurrentState)
            {
                Assert.True(vial.IsEmpty || vial.IsComplete);
            }
        }

        [Fact]
        public void DifficultScenario()
        {
            // Arrange https://www.youtube.com/watch?v=J2bJ2TiQslk
            var vials = new List<Vial>
            {
                new(new[] { 1, 2, 3, 4 }),
                new(new[] { 2, 5, 3, 2 }),
                new(new[] { 5, 4, 6, 7, }),
                new(new[] { 8, 8, 9, 5, }),
                new(new[] { 6, 9, 9, 1 }),
                new(new[] { 10, 11, 4, 12 }),
                new(new[] { 6, 10, 4, 3 }),
                new(new[] { 12, 12, 7, 1 }),
                new(new[] { 8, 3, 1, 6 }),
                new(new[] { 11, 12, 10, 8 }),
                new(new[] { 7, 9, 10, 11 }),
                new(new[] { 5, 2, 11, 7 }),
                new(new int[4]),
                new(new int[4]),
            };

            // Act
            var result = GameSolver.RecursiveSolve(vials, new Stack<FluidMove>(), new HashSet<string>());

            // Assert
            PrintVials("Result: ", vials);
            Assert.Equal(result.CurrentState.Count, vials.Count);
            foreach (var vial in result.CurrentState)
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