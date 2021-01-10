using System.Collections.Generic;
using System.Linq;

namespace WaterSortPuzzleSolver
{
    public class GameSolution
    {
        public GameSolution(IEnumerable<Vial> state, IEnumerable<FluidMove> moves)
        {
            State = state.ToList();
            Moves = moves.ToList();
            Invalid = false;
        }

        public static GameSolution Unsolved => new(Enumerable.Empty<Vial>(), Enumerable.Empty<FluidMove>())
        {
            Invalid = true
        };

        private bool Invalid { get; init; }

        public List<Vial> State { get; set; }
        public List<FluidMove> Moves { get; set; }
        public bool IsSolved => !Invalid && State.All(x => x.IsEmpty || x.IsComplete);
    }
}