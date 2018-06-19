using System;
using System.Collections.Generic;
using System.Text;

namespace KnapsackProblem
{
    public class KnapsackProblem
    {
        public int Size;
        public int MaxWeight;
        public int[] Weights;
        public int[] Values;

        public KnapsackProblem(int Size, int MaxWeight)
        {
            this.Size = Size;
            this.MaxWeight = MaxWeight;
            Weights = Helper.RandomTable(Size, 1, MaxWeight);
            Values = Helper.RandomTable(Size);

            Helper.Print(MaxWeight, "Max weight:");
            if (Size < 50)
                Helper.Print(Values, Weights, "Value:Weight");
            else
                Helper.Print(Size, "Size:");
        }
    }
}
