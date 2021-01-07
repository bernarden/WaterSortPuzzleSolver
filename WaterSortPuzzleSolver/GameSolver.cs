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
                foreach (var vial in vialState)
                {
                    foreach (var vial2 in vialState)
                    {
                        if (vial == vial2) continue;

                        int movableFluidAmount = FluidAmountCalculator.HowMuchFluidCanBeMoved(vial, vial2);
                        if (movableFluidAmount != 0)
                        {
                            var move = new FluidMove(vial, vial2);
                            moves.Add(move);
                            move.Execute();
                        }
                    }
                }
            }

            return vialState;
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