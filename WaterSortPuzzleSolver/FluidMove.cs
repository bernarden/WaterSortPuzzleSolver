using System.Collections.Generic;

namespace WaterSortPuzzleSolver
{
    public class FluidMove
    {
        public FluidMove(Vial from, Vial to)
        {
            ReferencedFrom = from;
            OriginalFromState = from.Clone();

            ReferencedTo = to;
            OriginalToState = to.Clone();
        }

        private Vial ReferencedFrom { get; }
        private Vial ReferencedTo { get; }

        private Vial OriginalFromState { get; }
        private Vial OriginalToState { get; }

        private List<int> MovedFluid { get; set; } = new();
        
        public string UniqueMoveIdentifier => $"{OriginalFromState} => {OriginalToState}";

        public void Execute()
        {
            MovedFluid = ReferencedFrom.TransferTopFluid(ReferencedTo);
        }

        public void Reverse()
        {
            ReferencedFrom.ReverseFluidTransfer(ReferencedTo, MovedFluid);
        }
    }
}