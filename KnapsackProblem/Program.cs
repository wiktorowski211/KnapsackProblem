using System;

namespace KnapsackProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int Size = 500000;
            int MaxWeight = 3000;

            int ThreadCount = 4;

            KnapsackProblem Problem = new KnapsackProblem(Size, MaxWeight);

            Console.WriteLine();

            SequenceSolver Sequence = new SequenceSolver(Problem);
            ParallelSolver Parallel = new ParallelSolver(Problem, ThreadCount);

            Sequence.Solve();
            Parallel.Solve();

            Console.ReadLine();
        }
    }
}
