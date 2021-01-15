using System.Collections.Generic;
using System.Linq;

namespace WaterSortPuzzleSolver
{
    public static class GameInputValidator
    {
        public static bool IsValidInput(List<Vial> vials)
        {
            return vials
                .SelectMany(v => v.Content.Select(f => f))
                .GroupBy(f => f)
                .All(f => f.Count() == 4);
        }
    }
}