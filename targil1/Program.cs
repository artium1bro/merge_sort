using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace targil1
{
    class MergeSort
    {

        // (N)  משום שהמערך מתחלק בחצי בכל קריאה רקורסיבית, בנוסף קיים מעבר על כל איבר במערך-NLOGN זמן ריצה  

        void merge(int[] arr, int l, int m, int r)
        {
            
            //מציאת גודל של  המערכים לצורך איחוד
            int len1 = m - l + 1;
            int len2 = r - m;

            // הגדרת שני מערכים זמניים
            int[] arry_left = new int[len1];
            int[] arry_right = new int[len2];
            int i, j;

            // הכנסת האיברים מהמארך לתוך שני המארכים הזמניים
            for (i = 0; i < len1; ++i)
                arry_left[i] = arr[l + i];
            for (j = 0; j < len2; ++j)
                arry_right[j] = arr[m + 1 + j];

            

            // הגדרת שני אינדקסים לצורך איחוד 
            i = 0;
            j = 0;

            // איחוד המארכים על פי האינדקסים קודם , ברגע שאיבר אחד מוכנס למערך האינדקס מתקדם קדימה עד שכל האיברים מוכנסים על פי הסדר הנכון
            int k = l;
            while (i < len1 && j < len2)
            {
                if (arry_left[i] <= arry_right[j])
                {
                    arr[k] = arry_left[i];
                    i++;
                }
                else
                {
                    arr[k] = arry_right[j];
                    j++;
                }
                k++;
            }

          
            while (i < len1)
            {
                arr[k] = arry_left[i];
                i++;
                k++;
            }

            
            while (j < len2)
            {
                arr[k] = arry_right[j];
                j++;
                k++;
            }
        }

     
        void sort(int[] arr, int l, int r)
        {
            if (l < r) // כל עוד יש במערך יותר מאיבר אחד נקרא לפונקציה הרקורסיבית ונמשיך לפצל
            {
                
                // מציאת האמצע לצורך פיצול המערך
                //נבצע איחוד תתי המערכים על פי האינדקסים
                int m = l + (r - l) / 2;

                
                sort(arr, l, m);
                sort(arr, m + 1, r);

               
                merge(arr, l, m, r);
            }
        }

       
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

       
        public static void Main(String[] args)
        {
            int[] arr = { 10, -15, 1, 0, 60, 2 };
            Console.WriteLine("Given Array");
            printArray(arr);
            MergeSort ob = new MergeSort();
            ob.sort(arr, 0, arr.Length - 1);
            Console.WriteLine("\nSorted array");
            printArray(arr);
        }
    }

 
    }