using System;
using System.Diagnostics;

namespace KnapsackProblem
{
    public abstract class Solver
    {
        protected KnapsackProblem Problem;
        protected int[][] Matrix;

        public Solver(KnapsackProblem problem)
        {
            this.Problem = problem;
        }

        public void Solve()
        {
            FillMatrix();
            Helper.Print("Matrix filled");
            Stopwatch Stoper = new Stopwatch();
            Stoper.Start();

            int result = Result();

            Stoper.Stop();

            string Message = String.Format("{0} Result: {1} Elapsed time: {2}ms", this.ToString(), result, Stoper.ElapsedMilliseconds);
            Console.WriteLine(Message);
        }

        protected abstract int Result();
        protected abstract void FillMatrix();
    }
}
