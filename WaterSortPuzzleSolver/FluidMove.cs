using System.Linq;

namespace WaterSortPuzzleSolver
{
    public record FluidMove
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
        private string Moved { get; set; }

        public void Execute()
        {
            var moved = ReferencedFrom.TransferTopFluid(ReferencedTo);
            Moved = string.Join(", ", moved);
        }
    }
}