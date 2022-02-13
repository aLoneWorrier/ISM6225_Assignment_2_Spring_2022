/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections.Generic;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is :{0}", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[][] grid = {new[]{ 0, 1, 2, 3, 4 }, new[]{ 24, 23, 22, 21, 5 }, new[]{ 12, 13, 14, 15, 16 }, new[]{ 11, 17, 18, 19, 20 }, new[]{ 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int left, right;
                left = 0;
                right = nums.Length - 1;
                // this is a simple binary search implementation by spliting the array into half and proceeding with it and repeating the same until the array 
                // is sorted.
                while(left <= right)
                {
                    int mid = (left + right) / 2;
                    if (nums[mid] == target)
                    {
                        return mid;
                    }
                    if (nums[mid] > target)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                // this regex is to remove every character other than alphabets
                string trimmed_paragraph = System.Text.RegularExpressions.Regex.Replace(paragraph, @"[^a-zA-Z]", " ");
                // this regex is to remove the extra whitespaces in the earlier trimmed_paragraph
                trimmed_paragraph = System.Text.RegularExpressions.Regex.Replace(trimmed_paragraph, @"\s+", " ");
                //Console.WriteLine(trimmed_paragraph);
                string[] words = trimmed_paragraph.ToLower().Split(" ");
                // created a dictionary to store the words inside the given string and getting the count of it.
                Dictionary<string, int> dict = new Dictionary<string, int>();
                for (int i = 0; i < words.Length; i++)
                {
                    if (!dict.ContainsKey(words[i]))
                    {
                        dict[words[i]] = 1;
                    }
                    else
                    {
                        dict[words[i]] += 1;
                    }
                }
                // removing the banned words from the dictionary
                for (int i = 0; i < banned.Length; i++)
                {
                    if (dict.ContainsKey(banned[i]))
                    {
                        dict.Remove(banned[i]);
                    }
                }
                /*foreach (KeyValuePair<string, int> ele in dict)
                {
                    Console.WriteLine("{0} and {1}",ele.Key, ele.Value);
                }*/
                // getting the max value and the max word from the dictionary
                int max = 0;
                string word = "";
                foreach (KeyValuePair<string,int> ele in dict)
                {
                    if (ele.Value > max)
                    {
                        max = ele.Value;
                        word = ele.Key;
                    }
                }
                return word;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                // created a dictionary to store the values of the array
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!dict.ContainsKey(arr[i]))
                    {
                        dict[arr[i]] = 1;
                    }
                    else
                    {
                        dict[arr[i]] += 1;
                    }
                }
                int max = 0;
                foreach (KeyValuePair<int, int> ele in dict)
                {
                    // checking if the luvky number and the count of the lucky number is equal or not
                    // if equal storing it to compare which is the maximum among them.
                    if (ele.Key == ele.Value)
                    {
                        if (ele.Value > max)
                        {
                            max = ele.Value;
                        }
                    }
                }
                // if there are no lucky numbers then max will be 0
                if (max == 0)
                    return -1;
                return max;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int x = 0;
                int y = 0;
                string str = "";
                int position = int.MaxValue;
                // created a for loop to get the position of the character in the string which is same.
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i])
                    {
                        x += 1;
                        position = i;
                    }
                }
                // created a dictionary to store the values of secret and make a count of it except the bulls.
                Dictionary<char, int> dict1 = new Dictionary<char, int>();
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i])
                    {
                        continue;
                    }
                    else
                    {
                        if (!dict1.ContainsKey(secret[i]))
                        {
                            dict1[secret[i]] = 1;
                        }
                        else
                        {
                            dict1[secret[i]] += 1;
                        }
                    }
                }
                // created a dictionary to store the values of guess and make a count of it except the bulls.
                Dictionary<char, int> dict2 = new Dictionary<char, int>();
                for (int i = 0; i < guess.Length; i++)
                {
                    if (secret[i] == guess[i])
                    {
                        continue;
                    }
                    else
                    {
                        if (!dict2.ContainsKey(guess[i]))
                        {
                            dict2[guess[i]] = 1;
                        }
                        else
                        {
                            dict2[guess[i]] += 1;
                        }
                    }
                }
                /*foreach (KeyValuePair<char, int> ele in dict1)
                {
                    Console.WriteLine("{0} and {1}",ele.Key, ele.Value);
                }
                Console.WriteLine();
                foreach (KeyValuePair<char, int> ele in dict2)
                {
                    Console.WriteLine("{0} and {1}", ele.Key, ele.Value);
                }
                Console.WriteLine();*/
                // looping through the loop to get the value of the cows that are in the given guess and secret string
                foreach (KeyValuePair<char, int> ele in dict1)
                {
                    if (dict2.ContainsKey(ele.Key))
                    {
                        // if the key is in 2 dicts then if the value is same then adding the value to y.
                        if (dict2[ele.Key] == ele.Value)
                        {
                            y += ele.Value;
                        }
                        // if dict 2 contains a lesser value we are considering the lower value to store in y.
                        else if (dict2[ele.Key] < ele.Value)
                        {
                            y += dict2[ele.Key];
                        }
                        // if dict 1 contains a greater value we are considering the lower value to store in y.
                        else
                        {
                            y += ele.Value;
                        }
                    }
                }
                str = x + "A" + y + "B";
                return str;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                List<int> list = new List<int>();
                // created a dictionary to get the max location of each character present in the string.
                Dictionary<char, int> dict = new Dictionary<char, int>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (!dict.ContainsKey(s[i]))
                    {
                        dict[s[i]] = i;
                    }
                    else
                    {
                        dict[s[i]] = i;
                    }
                }
                int cnt = 0;
                int max = int.MinValue;
                int j = 0;
                // we are looping through each element and incrementing the count to get the count of the substring splits.
                for (int i = 0; i < s.Length; i++)
                {
                    cnt += 1;
                    // checking and updating if the count(character) is greater than max
                    if (dict[s[i]] > max)
                    {
                        max = dict[s[i]];
                    }
                    // if the iteration is equal to max which is the end location we are adding it to the list and making the count to 0 to restart the new sub string.
                    if (i == max)
                    {
                        list.Add(cnt);
                        cnt = 0;
                    }
                }
                return new List<int>(list) { };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int sum = 0;
                int cnt = 1;
                // looping through the string and getting the sum of each character pixel from the widths array.
                for (int i = 0; i < s.Length; i++)
                {
                    sum += widths[s[i] - 'a'];
                    // since max is 100, if the sum is greater than 100 we are incrementing the count and assigning the sum to the current value.
                    if (sum > 100)
                    {
                        cnt += 1;
                        sum = widths[s[i] - 'a'];
                    }
                }
                return new List<int>() { cnt, sum};
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                // here i am using stack to implement this concept.
                Stack<char> stack = new Stack<char>();
                char x = ' ';
                // if there is any open bracket in will insert it in to the stack
                for (int i = 0; i < bulls_string10.Length; i++)
                {
                    if (bulls_string10[i] == '(' || bulls_string10[i] == '{' || bulls_string10[i] == '[')
                    {
                        stack.Push(bulls_string10[i]);
                    }
                    // if stack is not empty and
                    else if (stack.Count != 0)
                    {
                        x = Convert.ToChar(stack.Peek());
                        Console.WriteLine(x);
                        // if the top of stack is equal to its closing bracket we will pop the element from the stack.
                        if (bulls_string10[i] == ')' && x == '(')
                        {
                            stack.Pop();
                        }
                        else if (bulls_string10[i] == '}' && x == '{')
                        {
                            stack.Pop();
                        }
                        else if (bulls_string10[i] == ']' && x == '[')
                        {
                            stack.Pop();
                        }
                        // if not the same then it is not balanced we will return false
                        else
                            return false;
                    }
                    // return false if none of the above case is satisfied.
                    else
                        return false;
                }
                // we we didn't empty the stack and if the length of string is not even they are not balanced we return false, else true.
                if (stack.Count == 0 && bulls_string10.Length % 2 == 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                string[] mc = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                Dictionary<string, int> dict = new Dictionary<string, int>();
                Dictionary<string, int> dict1 = new Dictionary<string, int>();
                // created a dictionary to get the count of each word.
                for (int i = 0; i < words.Length; i++)
                {
                    if (dict.ContainsKey(words[i]))
                    {
                        dict[words[i]] += 1;
                    }
                    else
                    {
                        dict[words[i]] = 1;
                    }
                }
                // for each character in the dictionary we are changing the value of it and updating it with the morse code and adding it into the dictionary 
                // again to get the count.
                foreach (KeyValuePair<string, int> ele in dict)
                {
                    string s = "";
                    for (int i = 0; i < ele.Key.Length; i++)
                    {
                        s += mc[ele.Key[i] - 'a'];
                    }
                    if (dict1.ContainsKey(s))
                    {
                        dict1[s] += 1;
                    }
                    else
                    {
                        dict1[s] = 1;
                    }
                }
                return (dict1.Count);
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        public static int SwimInWater(int[][] grid)
        {
            // i have refrenced geeks for geeks and some other online sources for dfs and binary search in tree.
            try
            {
                // binary search implementation to divide and loop through each row,col.
                int low = grid[0][0];
                int high = low;
                for (int i = 0; i < grid.Length; i++)
                {
                    int[] row = grid[i];
                    for (int j = 0; j < row.Length; j++)
                    {
                        high = Math.Max(row[j], high);
                    }
                }

                while (low < high)
                {
                    int mid = low + (high - low) / 2;
                    // created an object to call the method.
                    Program obj = new Program();
                    if (obj.PathExists(grid, mid, 0, 0, new bool[grid.Length, grid[0].Length]))
                        high = mid;
                    else
                        low = mid + 1;
                }

                return low;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // this pathExists method checks if there is a path exist i.e., if the time is less than the value of its next node.
        public bool PathExists(int[][] grid, int waterLevel, int row, int col, bool[,] visited)
        {
            if (row > grid.Length - 1 || row < 0 || col > grid[0].Length - 1 || col < 0)
                return false;

            if (grid[row][col] > waterLevel || visited[row, col] == true)
                return false;

            if (row == grid.Length - 1 && col == grid[0].Length - 1)
                return true;

            visited[row, col] = true;

            var directions = new (int x, int y)[] { (1, 0), (0, 1), (-1, 0), (0, -1) };

            foreach (var dir in directions)
            {
                if (PathExists(grid, waterLevel, row + dir.x, col + dir.y, visited))
                    return true;
            }

            return false;
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                // created a new 2d array
                int[,] arr = new int[word1.Length + 1, word2.Length + 1];
                for (int i = 0; i < word1.Length + 1; i++)
                {
                    for (int j = 0; j < word2.Length + 1; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            arr[i, j] = 0;
                        }
                        else if (j == 0)
                        {
                            arr[i, j] = i;
                        }
                        else if (i == 0)
                        {
                            arr[i, j] = j;
                        }
                        else
                        {
                            int w1ind = i - 1;
                            int w2ind = j - 1;
                            // if the character of each words is equal we will update it with the previous diagonal element.
                            if (word1[w1ind] == word2[w2ind])
                            {
                                arr[i, j] = arr[i - 1, j - 1];
                            }
                            // else we will take the minimum of it and then update it will one ans assign it to the arr[i,j].
                            else
                            {
                                arr[i, j] = Math.Min(arr[i - 1, j - 1], Math.Min(arr[i, j - 1], arr[i - 1, j])) + 1;
                            }
                        }
                    }
                }
                // we return the location of the word1 length and word2 length from the array.
                return arr[word1.Length, word2.Length];
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}