namespace ProgrammingIntroduction
{
    internal class Program
    {
        /// <summary>
        /// global integer representing response from main menu input.
        /// </summary>
        static int Choice = -1;

        /// <summary>
        /// Main method and entry point to the program. Main form of interaction with the console interface.
        /// </summary>
        /// <param name="args">aguments passed with the executable. Currently not handled.</param>
        static void Main(string[] args)
        {
        // The Try and Catch block allow to run the program on trial, so if all goes well the catch block is ignored and the progrma continues BAU    
            try
            {
                Choice = MainMenu();
                while (Choice != 0)
                {
                    string str;
                    int i;
                    switch (Choice)
                    {
                        //The first line request and store the numbers in an array. 
                        //The second line request the number to return the index from the array
                        //TargetRange looks for the index of i in the targets array and writes it down in the console
                        //if the number in 'i' is not in the array, it will return [-1, -1}, if 'i' is only once in the array the index or position will be reported twice
                        //if the 'i' is twice it will result in the two indexes or positions. if 'i' is more than twice, the program will report the first and last index 
                        //where 'i' is found
                        case 1:  // Problem #1. Find the initial and final index of a given target point’s value.
                            int[] targets = GetNumArray("Input an array of numbers as 'n,n,n,n,n...': ");
                            i = GetNum("Pick a number:  ");
                            int[] indexes = TargetRange(targets, i);
                            Console.Write("Answer:  [" + indexes[0] + "," + indexes[1] + "]");
                            break;
                        //The first line is a request of a string or characters 
                       //Second line call reverse the order of each of the characters of the string which is call down below
                       //then the answer is wrote in the console. the break command returns the user to the MainMenu()
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
            //the Catch block is only call if the program in the try block is not ok so it allows to display an error to the user on the screen
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
        ///This is the code called in case 1
        ///In this try block we have two for loop blocks, the first one calculate the first index to display as an answer
        ///The second for loop block is for the second index to display as part of the answer
        /// first loop start with a value of zero and will run while the value is less than the lenght of the array  and will increase by one for the next run
        ///the second look starts with a value of the lenght minus one and will run as long the value is bigger or equal than zero and will decrease by one until zero
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
           ///if the target value is in the conditions that met the above for lopps, then the default error message is the index are -1,-1 and that value is added to indexes
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
        /// This is the program call by case 2, starts with the try and catch blocks and inside has a Do While loop, where execute first the code and then check if the condition is met.
        /// starts by defining two variables with value zero and minus one, defines also the variable revStre as a string and ensure it is empty
        /// then assigns to j the lenght of the string identifying de posion or index in the string or phrase per each spaces and charaters and asigned it to a temporary string
        /// where using a for loop does this per each character but by using -1 is being written in the oposite direction  and runs until the position or index of the character is zero,
        /// by decreasing by one the index. then assings the temporary string characters to the revString. it ends iwth a while loop once the Reverse String where it trimes any space at
        /// the end of the reverse string to display ony characters at the end of the new reverse string 
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
