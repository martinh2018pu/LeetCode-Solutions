namespace Leetcode_Solutions.Easy
{
    using System.Collections.Generic;

    class No_412_Fizz_Buzz
    {
        // TODO: Create test case and write to console methods. 

        public IList<string> FizzBuzz(int n)
        {
            string[] arr = new string[n];

            for (int i = 0; i < n; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    if ((i + 1) % 5 == 0)
                    {
                        arr[i] = "FizzBuzz";
                    }
                    else
                        arr[i] = "Fizz";
                }
                else if ((i + 1) % 5 == 0)
                {
                    arr[i] = "Buzz";
                }
                else
                    arr[i] = (i + 1).ToString();
            }

            return arr;
        }
    }
}
