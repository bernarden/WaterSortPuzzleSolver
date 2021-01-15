using System.Collections.Generic;
using System.Linq;

namespace WaterSortPuzzleSolver
{
    public class Vial
    {
        private static int _lastVialId = 1;
        private static int NextVialId => _lastVialId++;

        private readonly Stack<int> _content = new();

        public IReadOnlyCollection<int> Content => _content;

        public Vial(IEnumerable<int> content)
        {
            Id = NextVialId;
            var values = content.Reverse().ToList();
            MaxSize = values.Count;
            foreach (int value in values.Where(value => value != 0))
            {
                _content.Push(value);
            }
        }

        public int Id { get; private init; }

        public int MaxSize { get; }

        public int TakenAmount => _content.Count;

        public int TopFluid => _content.Peek();

        public int TopFluidAmount
        {
            get
            {
                int amount = 0;
                foreach (int fluid in _content)
                {
                    if (fluid != TopFluid)
                        return amount;

                    amount++;
                }

                return amount;
            }
        }

        public int AvailableSpace => MaxSize - _content.Count;

        public bool IsEmpty => _content.Count == 0;

        public bool IsComplete => _content.Sum(x => x) / TakenAmount == TopFluid && TakenAmount == MaxSize;

        public override string ToString()
        {
            var representation = Enumerable.Repeat(0, AvailableSpace).Concat(_content.ToArray());
            return $"{Id}: " + string.Join(", ", representation.ToArray());
        }

        public Vial Clone()
        {
            var values = Enumerable.Repeat(0, AvailableSpace).Concat(_content.ToArray());
            return new Vial(values) { Id = Id };
        }

        public List<int> TransferTopFluid(Vial other)
        {
            List<int> moved = new();
            int toMove = TopFluidAmount;
            while (other.AvailableSpace > 0 && toMove > 0)
            {
                int item = _content.Pop();
                moved.Add(item);
                other._content.Push(item);
                toMove--;
            }

            return moved;
        }

        public void ReverseFluidTransfer(Vial other, List<int> fluidToReverse)
        {
            for (int i = 0; i < fluidToReverse.Count; i++)
            {
                int item = other._content.Pop();
                _content.Push(item);
            }
        }
    }
}