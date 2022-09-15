namespace Leetcode_Solutions.Easy
{
    using System;

    class No_13_Roman_to_Integer
    {
        public static void RomanToInt()
        {
            Console.WriteLine("Enter valid roman numeral in the range [1, 3999]: ");

            string romanNumeral = Console.ReadLine();

            romanNumeral += "*";

            char[] arr = romanNumeral.ToCharArray();

            int res = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '*')
                {
                    break;
                }

                if (arr[i] == 'M')
                {
                    res += 1000;
                }

                if (arr[i] == 'D')
                {
                    res += 500;
                }

                if (arr[i] == 'C')
                {
                    if (arr[i + 1] == 'M')
                    {
                        res += 900;
                        i++;
                    }
                    else if (arr[i + 1] == 'D')
                    {
                        res += 400;
                        i++;
                    }
                    else
                        res += 100;
                }

                if (arr[i] == 'L')
                {
                    res += 50;
                }

                if (arr[i] == 'X')
                {
                    if (arr[i + 1] == 'C')
                    {
                        res += 90;
                        i++;
                    }
                    else if (arr[i + 1] == 'L')
                    {
                        res += 40;
                        i++;
                    }
                    else
                        res += 10;
                }

                if (arr[i] == 'V')
                {
                    res += 5;
                }

                if (arr[i] == 'I')
                {
                    if (arr[i + 1] == 'X')
                    {
                        res += 9;
                        i++;
                    }
                    else if (arr[i + 1] == 'V')
                    {
                        res += 4;
                        i++;
                    }
                    else
                        res += 1;
                }
            }

            Console.WriteLine("Your roman numeral, converted into an integer is equal to: {0}", res);
        }
    }
}
