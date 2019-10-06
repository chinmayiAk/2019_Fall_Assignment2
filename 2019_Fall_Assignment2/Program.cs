using System;
using System.Collections.Generic;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);
            

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");


            string s = "abca";
            if(ValidPalindrome(s)) {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach(int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for(int i=0;i<a.GetLength(0);i++)
            {
                for(int j=0;j<a.GetLength(1);j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int i = 0;
                int j = nums.Length - 1;

                while (i <= j)
                {
                    int mid = (i + j) / 2;

                    if (target > nums[mid])
                    {
                        i = mid + 1;
                    }
                    else if (target < nums[mid])
                    {
                        j = mid - 1;
                    }
                    else
                    {
                        Console.WriteLine(mid);
                        return mid;
                    }
                    continue;
                }

                Console.WriteLine(i);
                return i;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                int u = 0;
                int v = 0;
                Array.Sort(nums1);// Ascending order of array nums1
                Array.Sort(nums2); // Ascending order of array nums2
                int j = nums1.Length;     // Length of array nums1
                int k = nums2.Length;     // Lenghth of array nums2
                var num = new List<int>();// A list intiation to collect the common elements in both the arrays.

                while (u < j && v < k) //This loop ends if any of the array is empty
                {
                    if (nums1[u] == nums2[v])//if the elements are equal
                    {
                        num.Add(nums1[u]);//Common elementsadding to the list num
                        u++;              // position increment of nums1
                        v++;              // position increment of nums2
                    }// end of if
                    else if (nums1[u] < nums2[v])//if element in nums1 is less than element of nums2
                    {
                        u++;                     //position increment of nums 1.
                    }//end of else if
                    else
                    {
                        v++; //if element in nums1 is less than element of nums2,position increment of nums 2.
                    }//end of else
                }//end of while
                int[] ret = num.ToArray();//converting list num to array ret.
                return ret;// value returns to the method
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }//end of Intersect

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                int[] data = new int[26];
                for (int i = 0; i < keyboard.Length; ++i)
                {
                    data[keyboard[i] - 97] = i;
                }
                int r = data[word[0] - 97];
                for (int i = 1; i < word.Length; ++i)
                {
                    r = r + Math.Abs(data[word[i] - 97] - data[word[i - 1] - 97]);
                }
                Console.WriteLine(r);
                return r;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {

                int r = A.GetLength(0);//number of rows in binary matrix
                int c = A.GetLength(1); // number of columns

                for (int i = 0; i < r; i++)// to operate on the different the rows
                {
                    int k = 0;
                    int l = c - 1;// coloumns in the matrix

                    while (k <= l) // reversing the row of the matrix. 
                    {
                        int temp = A[i, k];
                        A[i, k] = A[i, l]; // swapping the elements
                        A[i, l] = temp;
                        k++;
                        l--;
                    }// end of while
                }// end of for

                for (int u = 0; u < r; u++) // this loop inverts the binary matrix.
                {
                    for (int v = 0; v < c; v++)
                    {
                        if (A[u, v] == 0)
                        {
                            A[u, v] = 1;
                        } // end of if
                        else
                        {
                            A[u, v] = 0;
                        }// end of else

                    }// end of for

                }// end of for

                return A;
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }// end of FlipAndInvertImage

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            return 0;
        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                //initializing array for storing values after sqauring them
                int[] after_sqaured = new int[A.Length];

                //loop to store squared value in the "after_sqaured" array
                for (int i = 0; i < A.Length; i++)
                {
                    after_sqaured[i] = A[i] * A[i];
                }

                //sorting the after_squared array
                Array.Sort(after_sqaured);

                //loop to display the contents of the squared loop
                for (int i = 0; i < after_sqaured.Length; i++)
                {
                    Console.Write(" " + after_sqaured[i]);
                }

                //returning the squared array
                return after_sqaured;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {
                string ls = s.ToLower();// converts all cases of string s to lower.
                int l = ls.Length; // length of string

                int k = l - 1; // variable intialisation to begin from the end of string
                int i = 0; // variable initialisation to begin from start of the string
                int count = 0;//counter to count  and stop if more than one unequal elements.

                while (i <= k) // loop terminates when begin<=end
                {
                    if (ls[i] == ls[k]) // if begining and end elemts are equal
                    {
                        i++;
                        k--;
                    }
                    //if beginning and end elements are not equal+ one element after biginning is equal to end end element+only once 
                    else if ((ls[i] != ls[k] && ls[i + 1] == ls[k]) && count < 1)
                    {
                        i++;
                        count = count + 1;
                    }
                    //if beginning and end elements are not equal+ one element before end is equal to end start element+only once
                    else if ((ls[i] != ls[k] && ls[i] == ls[k - 1]) && count < 1)
                    {
                        Console.Write(ls[k - 1]);
                        k--;
                        count = count + 1;
                    }
                    else
                    {
                        if (count < 1) // to break the loop if the above conditions are false
                            return false;// if none of the condition is trure then return false
                        count = count + 1;
                    }// end of else
                }//end of while
                return true; 
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }// end of ValidPalindrome
    }
}
