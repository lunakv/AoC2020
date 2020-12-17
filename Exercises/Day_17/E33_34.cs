using System.Collections.Generic;

namespace Exercises.Day_17
{
    public class E33 : Simulator<(int, int, int)>
    {
        protected override IEnumerable<(int, int, int)> Around((int, int, int) vector) =>
            Arounder.Around3D(vector);

        protected override (int, int, int) CreateVector(int i, int j) => (i, j, 0);
    }
    
    public class E34 : Simulator<(int, int, int, int)>
    {
        protected override IEnumerable<(int, int, int, int)> Around((int, int, int, int) vector) =>
            Arounder.Around4D(vector);

        protected override (int, int, int, int) CreateVector(int i, int j) => (i, j, 0, 0);
    }
}