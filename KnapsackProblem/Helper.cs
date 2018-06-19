using System;

namespace KnapsackProblem
{
    public class Helper
    {
        public static void Print(int[][] Matrix, string Message = "")
        {
            Print(Message);

            for (int i = 0; i < Matrix.Length; i++)
            {
                Print(Matrix[i]);
            }
        }

        public static void Print(int[] List, string Message = "")
        {
            Print(Message);

            for (int i = 0; i < List.Length; i++)
            {
                Console.Write(List[i] + " ");
            }
            Console.WriteLine();
        }

        public static void Print(int[] List1, int[] List2, string Message = "")
        {
            Print(Message);

            for (int i = 0; i < List1.Length; i++)
            {
                Console.Write(string.Format("{0}:{1} ", List1[i], List2[i]));
            }
            Console.WriteLine();
        }

        public static void Print(int value, string Message = "")
        {
            Print(Message);

            Console.WriteLine(value);
        }

        public static void Print(string Message)
        {
            if (Message != string.Empty)
                Console.WriteLine(Message);
        }

        public static int[] RandomTable(int size, int min = 1, int max = 50)
        {
            int[] values = new int[size];

            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                values[i] = rand.Next(max) + min;
            }
            return values;
        }
    }
}
