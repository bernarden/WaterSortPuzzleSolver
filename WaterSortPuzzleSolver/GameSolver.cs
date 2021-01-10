using System.Collections.Generic;
using System.Linq;

namespace WaterSortPuzzleSolver
{
    public static class GameSolver
    {
        public static GameSolution Solve(List<Vial> state)
        {
            return RecursiveSolve(state, new Stack<FluidMove>(), new HashSet<string>());
        }

        public static GameSolution RecursiveSolve(List<Vial> state, Stack<FluidMove> moves,
            HashSet<string> movesHashSet)
        {
            if (!ShouldContinue(state))
            {
                return new GameSolution(state.Select(x => x.Clone()).ToList(), moves.Select(x => x).ToList());
            }

            for (int i = 0; i < state.Count; i++)
            {
                for (int j = 0; j < state.Count; j++)
                {
                    if (i == j) continue;

                    Vial from = state[i];
                    Vial to = state[j];
                    int movableFluidAmount = FluidAmountCalculator.HowMuchFluidCanBeMoved(from, to);
                    if (movableFluidAmount != 0)
                    {
                        var move = new FluidMove(from, to);
                        if (movesHashSet.Contains(move.UniqueMoveIdentifier)) continue;

                        movesHashSet.Add(move.UniqueMoveIdentifier);
                        moves.Push(move);
                        move.Execute();
                        var result = RecursiveSolve(state, moves, movesHashSet);
                        if (result.IsSolved) return result;

                        var reverseMove = moves.Pop();
                        reverseMove.Reverse();
                        movesHashSet.Remove(reverseMove.UniqueMoveIdentifier);
                    }
                }
            }

            return GameSolution.Unsolved;
        }

        private static bool ShouldContinue(IEnumerable<Vial> vialState)
        {
            bool shouldContinue = false;
            foreach (var vial in vialState)
            {
                bool isVialComplete = vial.IsEmpty || vial.IsComplete;
                shouldContinue |= !isVialComplete;
            }

            return shouldContinue;
        }
    }
}