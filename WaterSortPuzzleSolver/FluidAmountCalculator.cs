using System;

namespace WaterSortPuzzleSolver
{
    public static class FluidAmountCalculator
    {
        public static int HowMuchFluidCanBeMoved(Vial from, Vial to)
        {
            if (@from.IsEmpty)
                return 0;

            if (to.AvailableSpace == 0)
                return 0;

            if (to.IsEmpty)
            {
                return @from.TopFluidAmount == @from.TakenAmount ? 0 : @from.TopFluidAmount;
            }

            if (@from.TopFluid == to.TopFluid)
            {
                return Math.Min(@from.TopFluidAmount, to.AvailableSpace);
            }

            return 0;
        }
    }
}