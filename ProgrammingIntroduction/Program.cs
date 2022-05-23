namespace ProgrammingIntroduction
{
    internal class Program
    {
        /// <summary>
        /// global integer representing responce from main menu input.
        /// </summary>
        static int Choice = -1;

        /// <summary>
        /// Main method and entry point to the program. Main from of interaction with the console interface.
        /// </summary>
        /// <param name="args">aguments passed with the executable. Currently not handled.</param>
        static void Main(string[] args)
        {
            try
            {
                Choice = MainMenu();
                while (Choice != 0)
                {
                    string str;
                    int i;
                    switch (Choice)
                    {
                        case 1:  // Problem #1. Find the initial and final index of a given target point’s value.
                            int[] targets = GetNumArray("Input an array of numbers as 'n,n,n,n,n...': ");
                            i = GetNum("Pick a number:  ");
                            int[] indexes = TargetRange(targets, i);
                            Console.Write("Answer:  [" + indexes[0] + "," + indexes[1] + "]");
                            break;
                        case 2: // Problem #2. Reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order. 
                            str = GetStr("Input a phrase to reorder:  ");
                            str = StringReverse(str);
                            Console.Write("Answer:  " + str);
                            break;
                        case 3: // Problem #3. Make the array elements distinct by increasing each value as needed, while minimizing and returning the array sum.
                            int[] arr = GetNumArray("Input an array of numbers as 'n,n,n,n,n...': ");
                            int sum = MinSum(arr);
                            Console.Write("Answer:  " + sum.ToString());
                            break;
                        case 4: // Problem #4. Sort the given string in decreasing order of frequency of occurrence of each character
                            str = GetStr("Input a phrase to reorder:  ");
                            str = FreqSort(str);
                            Console.Write("Answer:  " + str);
                            break;
                        case 5: // Problem #5. Given two arrays, write a function to compute their intersection.
                            int[] arrA = GetNumArray("Input an array of numbers as 'n,n,n,n,n...': ");
                            int[] arrB = GetNumArray("Input an array of numbers as 'n,n,n,n,n...': ");
                            int[] intercepts = Intersect(arrA, arrB);
                            Console.Write("Answer:  [" + intercepts[0] + "," + intercepts[1] + "]");
                            break;
                        case 6: // Problem #6. Find out whether there are two distinct indices less than a given distance.
                            str = GetStr("Input chars to add to array as 'ccccc...':  "); 
                            i = GetNum("Pick a number:  ");
                            bool b = ContainsDuplicate(str, i);
                            Console.Write("Answer:  " + b.ToString());
                            break;
                    }
                    Choice = MainMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Method to find the initial and final index of a given target point’s value within an array.
        /// </summary>
        /// <param name="marks">array of integers</param>
        /// <param name="target">interger if interest within an array</param>
        /// <returns>integer array of first and last index for a given target point's value within an array</returns>
        private static int[] TargetRange(int[] marks, int target)
        {
            try
            {
                int[] indexes = new int[2];
                for (int i = 0; i<marks.Length; i++)
                {
                    if (marks[i] == target)
                    {
                        indexes[0] = i;
                        break;
                    }
                    else
                    {
                        indexes[0] = -1;
                    }
                }

                for (int i = (marks.Length - 1); i >= 0; i--)
                {
                    if (marks[i] == target)
                    {
                        indexes[1] = i;
                        break;
                    }
                    else
                    {
                        indexes[1] = -1;
                    }
                }
                return indexes;
            }
            catch
            {
                int[] indexes = {-1, -1};
                return indexes;
            }
        }

        /// <summary>
        /// Method to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.
        /// </summary>
        /// <param name="str">string to reverse</param>
        /// <returns>reversed string</returns>
        private static string StringReverse(string str)
        {
            try 
            {
                int i = 0;
                int j = -1;
                string revStr = string.Empty;
                do
                {
                    j = str.IndexOf(' ', i);
                    if (j == -1)
                    {
                        j = str.Length;
                    }
                    string tempStr = str[i..j];
                    for (int k = (tempStr.Length - 1); k >= 0; k--)
                    {
                        revStr += tempStr[k];
                    }
                    i = j + 1;
                    revStr += " ";
                } 
                while (j < str.Length);

                revStr = revStr.TrimEnd();
                return revStr; 
            }
            catch 
            {
                return str;
            }
        }

        /// <summary>
        /// Method to make array elements distinct by increasing each value as needed, while minimizing and returning the array sum.
        /// </summary>
        /// <param name="arr">array to maninpulate and make values distinct</param>
        /// <returns>sum of new array</returns>
        private static int MinSum(int[] arr)
        {
            try
            {
                int sum = 0;
                int i = 1;
                for (i = 0; i < arr.Length; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] == arr[i])
                        {
                            arr[j]++;
                        }
                    }
                    sum += arr[i];
                }
                return sum;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Method to sort letters in an string in decreasing order of frequency of occurrence of each character
        /// </summary>
        /// <param name="s">string to sort</param>
        /// <returns>sorted string</returns>
        private static string FreqSort(string s)
        {
            try
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                foreach (char c in s)
                {
                    int ct = 0;
                    if (dict.ContainsKey(c))
                    {
                        ct = dict[c];
                    }
                    dict[c] = ct + 1;
                }
                var sorted = from entry in dict orderby entry.Value descending select entry;
                string str = string.Empty;
                foreach(KeyValuePair<char, int> pair in sorted)
                {
                    for (int i = 0; i < pair.Value; i++)
                    {
                        str += pair.Key;
                    }
                }
                return str;   
            }
            catch
            {
                return s;
            }
        }

        /// <summary>
        /// Method to find intersection of two arrays.
        /// </summary>
        /// <param name="arrA">Array One</param>
        /// <param name="arrB">Array Two</param>
        /// <returns>Array with Interept</returns>
        /// <exception cref="Exception">Exception thrown if array's do not intercept.</exception>
        private static int[] Intersect(int[] arrA, int[] arrB)
        {
            try
            {
                int [] result = new int[2];
                var intersect = arrA.Intersect(arrB);
                if (intersect.Count() > 0)
                {
                    result[0] = intersect.ElementAt(0);
                }
                
                if (intersect.Count() > 1)
                {
                    result[1] = intersect.ElementAt(1);
                }
                else
                {
                    result[1] = intersect.ElementAt(0);
                }
                return result;
            }
            catch
            {
                throw new Exception("No Intersect Point");
            }
        }

        /// <summary>
        /// Method to determine if there are two distinct indices in a given string seperated by less than a given distance.
        /// </summary>
        /// <param name="s">input string</param>
        /// <param name="k">comparison distance</param>
        /// <returns>boolean response if conparison condition was satisfied.</returns>
        private static bool ContainsDuplicate(string s, int k)
        {
            try
            {
                Dictionary<int, char> dict = new Dictionary<int, char>();
                int i = 0;
                foreach (char c in s)
                {
                    dict.Add(i, c);
                    i++;
                }
                var lookup = dict.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() > 1);
                foreach (var item in lookup)
                {
                    for (int j = 0; j < item.Max(); j++)
                    {
                        int sum = item.ElementAt(j + 1) - item.ElementAt(j);
                        if (sum <= k)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Main Menu. Queries input for which method to run.
        /// </summary>
        /// <returns>Interger representation of which case to exectute from the main menu.</returns>
        private static int MainMenu()
        {
            try
            {
                Console.WriteLine(Environment.NewLine + Environment.NewLine + "Assignment 1 - Main Menu -");
                Console.WriteLine("1) Find the initial and final index of a given target point's value");
                Console.WriteLine("2) Reverse the order of characters in each word within a sentence");
                Console.WriteLine("3) Make the array elements distinct by increasing each value as needed, then sum");
                Console.WriteLine("4) Sort the string in decreasing order of frequency of occurrence ");
                Console.WriteLine("5) Given two arrays, write a function to compute their intersection");
                Console.WriteLine("6) Find out whether there are two distinct indices less than a given distance");
                Console.WriteLine("0) Exit" + Environment.NewLine);
                Console.Write("Select one of the above options:  ");
                string? str = Console.ReadLine();

                if (!int.TryParse(str, out int i))
                {
                    throw new Exception("Error in input [" + str + "]. Not a number");
                }
                else if (i < 0 || i > 6)
                {
                    throw new Exception("Error in input [" + i.ToString() + "]. Number not between 1 and 6");
                }
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// Method quering console to input an integer number
        /// </summary>
        /// <param name="s">String to display on console.</param>
        /// <returns>integer from input.</returns>
        private static int GetNum(string s)
        {
            try
            {
                Console.Write(s);
                string? str = Console.ReadLine();

                if (!int.TryParse(str, out int i))
                {
                    throw new Exception("Error in input [" + str + "]. Not a number");
                }
                return i;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Method quering console to input a word or phrase
        /// </summary>
        /// <param name="s">String to display on console.</param>
        /// <returns>string from input.</returns>
        private static string GetStr(string s)
        {
            try
            {
                Console.Write(s);
                string? str = Console.ReadLine();
                if (str == null)
                {
                    throw new Exception("Error in input [" + str + "]. String is null");
                }
                return str;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Method quering console to input number array in coma delimited format
        /// </summary>
        /// <param name="s">String to display on console.</param>
        /// <returns>int array from input.</returns>
        private static int[] GetNumArray(string s)
        {
            try
            {
                Console.Write(s);
                string? str = Console.ReadLine();
                if (str == null)
                {
                    throw new Exception("Error in input [" + str + "]. String is null"); 
                }
                string[] nums = str.Split(',');
                int[] arr = new int[nums.Length];
                int i = 0;
                foreach(string num in nums)
                {
                    if (!int.TryParse(num, out arr[i]))
                    {
                        throw new Exception("Error in input [" + num + "]. Not a number");
                    }
                    i++;
                }
                return arr;
            }
            catch
            {
                throw;
            }
        }
    }
}