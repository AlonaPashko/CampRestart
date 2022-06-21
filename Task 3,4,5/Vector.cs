using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3And4And5
{
    internal class Vector
    {
        private int[] array;
        public int[] ArrayProp
        {
            get { return array; }
            set { array = value; }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                {
                    return array[index];
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
            set
            {
                array[index] = value;
            }
        }
        public Vector() : this(0) { }

        public Vector(int n)
        {
            array = new int[n];
        }

        public override string ToString()
        {
            string line = "";
            for (int i = 0; i < array.Length; i++)
            {
                line += array[i] + " ";
            }
            return line;
        }

        public void InitRandom(int a, int b)
        {
            Random random1 = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random1.Next(a, b);
            }
        }
        public void ManualInitialisation()
        {
            Console.WriteLine("Enter amount of numbers:");
            int amount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter numbers:");
            array = new int[amount];
            for (int i = 0; i < array.Length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                array[i] = number;
            }
        }

        public void Bubble()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j + 1] > array[j])
                    {
                        int item = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = item;
                    }
                }
            }
        }

        public void Counting()
        {
            int max = array[0];
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            int[] temp = new int[max - min + 1];
            for (int i = 0; i < array.Length; i++)
            {
                temp[array[i] - min]++;
            }
            int count = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp[i]; j++)
                {
                    array[count] = i + min;
                    count++;

                }

            }
        }

        public void InitShuffle()
        {
            int number;
            int count = 0;
            Random random1 = new Random();

            while (count < array.Length)
            {
                number = random1.Next(1, array.Length + 1);
                if (Array.IndexOf(array, number) == -1)
                {
                    array[count] = number;
                    count++;
                }
            }
        }
        public void InitShuffleFirst()
        {
            int number;
            Random random1 = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    number = random1.Next(1, array.Length + 1);
                    bool isExist = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (array[j] == number)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        array[i] = number;
                        break;
                    }

                }
            }

        }

        public Pair[] CalcFrequency()
        {
            Pair[] pairs = new Pair[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                pairs[i] = new Pair(0, 0);
            }
            int countDifference = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (array[i] == pairs[j].Number)
                    {
                        pairs[j].Frequency++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Frequency++;
                    pairs[countDifference].Number = array[i];
                    countDifference++;
                }
            }
            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }
            return result;
        }
        public Pair LongestFrequency(Pair[] pairs)
        {
            int maxFrequency = 0;
            Pair result = new Pair(0, 0);
            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i].Frequency > maxFrequency)
                {
                    maxFrequency = pairs[i].Frequency;
                }
            }
            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i].Frequency == maxFrequency)
                {
                    result = pairs[i];
                }
            }
            return result;
        }

        public bool IsPalindrom(string input)
        {
            {
                string equalStr1 = "";
                string equalStr2 = "";
                for (int i = 0; i < input.Length / 2; i++)
                {
                    equalStr1 = equalStr1 + input[i];
                }
                for (int i = (input.Length - 1) / 2; i >= 0; i--)
                {
                    equalStr2 = input[i] + equalStr2;
                }

                if (equalStr1 == equalStr2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool IsIntPalindrom(string input) //also for enjoyment
        {
            string[] strArray = input.Split(' ');
            int[] result = new int[strArray.Length];

            for (int i = 0; i < result.Length; i++)
            {
                int number = int.Parse(strArray[i]);
                result[i] = number;
            }
            int count = 0;
            for (int i = 0; i < result.Length / 2; i++)
            {
                if (result[i] == result[result.Length - 1 - i])
                {
                    count++;
                }
                else
                {
                    count = 0;
                    break;
                }
            }
            if (count > 0 || result.Length == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ManualReverse()
        {
            int[] temp = new int[array.Length];
            for (int i = array.Length, j = 0; i > 0; i--, j++)
            {

                int number = array[i - 1];
                temp[j] = number;
            }
            array = temp;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        public void StandartReverse()
        {
            Array.Reverse(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        public int[] QuickSort()
        {
            return QuickSort(0, array.Length - 1);
        }
        public int[] QuickSort(int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            ////int pivot = array[leftIndex]; //for a first element as a pivot
            //int pivot = array[rightIndex]; //for a last element as a pivot
            int pivot = array[(leftIndex + rightIndex) / 2]; //for a middle element as a pivot

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }

            }
            if (leftIndex < j)
            {
                QuickSort(leftIndex, j);
            }
            if (i < rightIndex)
            {
                QuickSort(i, rightIndex);
            }
            return array;
        }

        public void Merge(int left, int right, int separator)
        {
            int i = left;
            int j = separator;
            int count = 0; //count for temp[]
            int[] temp = new int[right - left];
            while (i < separator && j < right)
            {
                if (this.array[i] < this.array[j])
                {
                    temp[count] = this.array[i];
                    i++;
                }
                else
                {
                    temp[count] = this.array[j];
                    j++;
                }
                count++;
            }
            if (i == separator)
            {
                for (int k = j; k < right; k++)
                {
                    temp[count] = this.array[k];
                    count++;
                }
            }
            else
            {
                while (i < separator)
                {
                    temp[count] = this.array[i];
                    i++;
                    count++;
                }
            }
            for (int m = 0; m < temp.Length; m++)
            {
                this.array[m + left] = temp[m];
            }
        }

        public void SplitMergeSort()
        {
            SplitMergeSort(0, array.Length);
        }
        public void SplitMergeSort(int start, int end)
        {
            if (end - start <= 1)
            {
                return;
            }
            int middle = (end + start) / 2;
            SplitMergeSort(start, middle);
            SplitMergeSort(middle, end);
            this.Merge(start, end, middle);
        }
        public void HeapStorage(int start, int end)
        {
            int max = end;
            int left = 2 * end + 1;
            int right = 2 * end + 2;

            if (left <= start && array[left] >= array[max])
            {
                max = left;
            }
            if (right <= start && array[right] > array[max])
            {
                max = right;
            }
            if (max != end)
            {
                int temp = array[end];
                array[end] = array[max];
                array[max] = temp;
                HeapStorage(start, max);
            }
        }
        public void HeapSort()
        {
            int temp;
            for (int i = array.Length / 2; i >= 0; i--)
            {
                HeapStorage(array.Length - 1, i);
            }
            for (int i = array.Length - 1; i >= 0; i--)
            {
                temp = array[i];
                array[i] = array[0];
                array[0] = temp;

                HeapStorage(i - 1, 0);
            }
        }

        public int[] Parse(string line)
        {
            string[] strArr = line.Split(' ');
            int[] numbArray = new int[strArr.Length];

            for (int i = 0; i < strArr.Length; i++)
            {
                numbArray[i] = int.Parse(strArr[i]);
            }
            return numbArray;
        }
        public void WriteArrayToFile(int[] array)
        {
            StreamWriter fileOut = new StreamWriter("ArrayFile.txt");
            for (int i = 0; i < array.Length; i++)
            {
                fileOut.Write(array[i] + " ");
            }
            fileOut.Close();
        }

        public string ReadFromFile(string path)
        {
            string str = File.ReadAllText(path);
            string line = "";
            int position = str.Length / 2;

            while (!char.IsSeparator(str[position]))
            {
                Console.WriteLine(char.IsSeparator(str[position]));
                position--;
            }
            for (int i = 0; i < position; i++)
            {
                line += str[i];
            }
            Console.WriteLine(line);
            return line;
        }

        //public static Vector operator +(Vector a, Vector b)
        //{
        //    if (a.array.Length > b.array.Length)
        //    {
        //        (a, b) = (b, a);
        //    }
        //    Vector c = new Vector(b.array.Length);

        //    for (int i = 0; i < a.array.Length; i++)
        //    {
        //        c.array[i] = a.array[i] + b.array[i];
        //    }
        //    for (int i = a.array.Length; i < b.array.Length; i++)
        //    {
        //        c.array[i] = b.array[i];
        //    }
        //    return c;
        //}
        public static Vector operator +(Vector a, int b)
        {
            Vector c = new Vector(a.array.Length);
            for (int i = 0; i < a.array.Length; i++)
            {
                c.array[i] = a.array[i] + b;
            }
            return c;
        }

        public static int operator+(Vector a, Vector b)
        {
            return a.Sum() + b.Sum();
        }
        public int Sum()
        {
            int sum = 0;
            foreach (int i in array)
            {
                sum += i;
            }
            return sum;
        }

        public static bool operator >(Vector a, Vector b)
        {
            return a.array.Length > b.array.Length;
        }
        public static bool operator <(Vector a, Vector b)
        {
            return a.array.Length < b.array.Length;
        }
        public static implicit operator Vector(int t)
        {
            Vector a = new Vector(1);
            a[0] = t;
            return a;
        }
        public static implicit operator int(Vector a)
        {
            return a[0];
        }
    }
}