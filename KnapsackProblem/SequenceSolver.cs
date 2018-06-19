using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem
{
    public class SequenceSolver : Solver
    {
        public SequenceSolver(KnapsackProblem problem) : base(problem)
        {
        }

        protected override void FillMatrix()
        {
            Matrix = new int[Problem.Size + 1][];

            Matrix[0] = Enumerable.Repeat(0, Problem.MaxWeight + 1).ToArray();

            IEnumerable<int> init = Enumerable.Repeat(-1, Problem.MaxWeight + 1);

            for (int i = 1; i < Matrix.Length; i++)
            {
                Matrix[i] = init.ToArray();
            }
        }

        protected override int Result()
        {
            Matrix = new int[Problem.Size + 1][];

            IEnumerable<int> zeros = Enumerable.Repeat(0, Problem.MaxWeight + 1);

            for (int i = 0; i < Matrix.Length; i++)
            {
                Matrix[i] = zeros.ToArray();
            }

            for (int i = 1; i <= Problem.Size; i++)
            {
                int previousIndex = i - 1;

                for (int w = 1; w <= Problem.MaxWeight; w++)
                {
                    if (Problem.Weights[previousIndex] > w)
                    {
                        Matrix[i][w] = Matrix[previousIndex][w];
                    }
                    else
                    {
                        Matrix[i][w] = Math.Max(Matrix[previousIndex][w], Matrix[previousIndex][w - Problem.Weights[previousIndex]] + Problem.Values[previousIndex]);
                    }
                }
            }
            return Matrix[Problem.Size][Problem.MaxWeight];
        }
    }
}
