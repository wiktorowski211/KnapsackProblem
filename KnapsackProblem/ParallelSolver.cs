using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace KnapsackProblem
{
    class ParallelSolver : Solver
    {
        int ThreadCount;

        public ParallelSolver(KnapsackProblem problem, int threadCount) : base(problem)
        {
            this.ThreadCount = threadCount;
        }

        protected override void FillMatrix()
        {
            //this sollution just don't carry about memory:)
            Matrix = new int[Problem.Size + 1][];

            Matrix[0] = Enumerable.Repeat(0, Problem.MaxWeight + 1).ToArray();

            IEnumerable<int> init = Enumerable.Repeat(-1, Problem.MaxWeight + 1);

            for (int i = 1; i < Matrix.Length; i++)
            {
                Matrix[i] = init.ToArray();
                Matrix[i][0] = 0;
            }
        }

        protected override int Result()
        {
            Helper.Print(ThreadCount, "Thread count:");
            int result = 0;

            List<Thread> threads = new List<Thread>(ThreadCount);
            for (int i = 1; i <= ThreadCount; i++)
            {
                int row = i;

                Thread thread = new Thread(() =>
                {
                    while (row <= Problem.Size)
                    {
                        WriteRow(row);
                        if (row == Problem.Size)
                            result = Matrix[row][Problem.MaxWeight];
                        row += ThreadCount;
                    }
                });
                thread.Name = "Thread" + row;
                thread.Priority = ThreadPriority.Highest;
                thread.Start();

                threads.Add(thread);
            }
            foreach (Thread th in threads)
                th.Join();
            return result;
        }

        private void WriteRow(int row)
        {
            int previousIndex = row - 1;
            int waitOffset = 0;
            for (int w = 1; w <= Problem.MaxWeight; w++)
            {
                // sync - just wait until cell value of row above is computed, if we add waitOffset thread would not need to wait so often
                if (Matrix[previousIndex][w] < 0)
                {
                    waitOffset += w;
                    if (waitOffset > Problem.MaxWeight)
                        waitOffset = Problem.MaxWeight;
                    SpinWait.SpinUntil(() => Matrix[previousIndex][waitOffset] > -1);
                }

                if (Problem.Weights[previousIndex] > w)
                {
                    Matrix[row][w] = Matrix[previousIndex][w];
                }
                else
                {
                    Matrix[row][w] = Math.Max(Matrix[previousIndex][w], Matrix[previousIndex][w - Problem.Weights[previousIndex]] + Problem.Values[previousIndex]);
                }
            }
        }
    }
}
