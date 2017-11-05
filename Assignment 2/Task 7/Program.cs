using System;
using System.Threading.Tasks;

namespace Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethodAync());
            Console.Read();
        }

        private static async Task LetsSayUserClickedAButtonOnGuiMethodAync()
        {
            var result = await GetTheMagicNumberAsync();
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumberAsync()
        {
            return await IKnowIGuyWhoKnowsAGuyAsync();
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuyAsync()
        {
            return await IKnowWhoKnowsThisAsync(10) + await IKnowWhoKnowsThisAsync(5);
        }

        private static async Task<int> IKnowWhoKnowsThisAsync(int n)
        {
            return await FactorialDigitSumAsync(n);
        }

        ///<sumary>
        /// Method returns 0 for negative n or zero
        /// </sumary>
        public static async Task<int> FactorialDigitSumAsync(int n)
        {
            if (n > 0)
            {
                int factorial = 1;
                for (int i = 1; i <= n; i++)
                {
                    factorial *= i;
                }
                return factorial;
            }
            return 0;
        }
    }
}
