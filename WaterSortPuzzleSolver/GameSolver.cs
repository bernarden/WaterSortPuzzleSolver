using System.Collections.Generic;

namespace WaterSortPuzzleSolver
{
    public static class GameSolver
    {
        public static List<Vial> Solve(List<Vial> vialState)
        {
            var moves = new List<FluidMove>();
            while (ShouldContinue(vialState) && moves.Count < 10000)
            {
                for (int i = 0; i < vialState.Count; i++)
                {
                    for (int j = 0; j < vialState.Count; j++)
                    {
                        if (i == j) continue;

                        Vial from = vialState[i];
                        Vial to = vialState[j];
                        int movableFluidAmount = FluidAmountCalculator.HowMuchFluidCanBeMoved(from, to);
                        if (movableFluidAmount != 0)
                        {
                            var move = new FluidMove(from, to);
                            moves.Add(move);
                            move.Execute();
                            Solve(vialState);
                        }
                    }
                }
            }

            return vialState;
        }

        public static (List<Vial> CurrentState, Stack<FluidMove> CurrentMoves, bool isSolved) RecursiveSolve(
            List<Vial> vialState, Stack<FluidMove> moves, HashSet<string> movesHashSet)
        {
            // Check if puzzle is solved.
            if (!ShouldContinue(vialState))
            {
                return (vialState, moves, true);
            }

            int numberOfMovesMadeInThisRecursionStep = 0;
            for (int i = 0; i < vialState.Count; i++)
            {
                for (int j = 0; j < vialState.Count; j++)
                {
                    if (i == j) continue;

                    Vial from = vialState[i];
                    Vial to = vialState[j];
                    int movableFluidAmount = FluidAmountCalculator.HowMuchFluidCanBeMoved(from, to);
                    if (movableFluidAmount != 0)
                    {
                        var move = new FluidMove(from, to);
                        if (movesHashSet.Contains(move.UniqueMoveIdentifier))
                        {
                            continue;
                        }

                        numberOfMovesMadeInThisRecursionStep++;
                        movesHashSet.Add(move.UniqueMoveIdentifier);
                        moves.Push(move);
                        move.Execute();
                        var result = RecursiveSolve(vialState, moves, movesHashSet);
                        if (result.isSolved)
                            return result;
                    }
                }
            }

            // No more moves to be made in this path. Revert back the steps that were taken in this recursion.
            for (int i = 0; i < numberOfMovesMadeInThisRecursionStep; i++)
            {
                var move = moves.Pop();
                move.Reverse();
                movesHashSet.Remove(move.UniqueMoveIdentifier);
            }

            return (vialState, moves, false);
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