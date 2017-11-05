using System.Threading.Tasks;

namespace Task_6
{
    public class FactorialDigitSumClass
    {
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
