using Task3And4And5;

//Vector vector1 = new Vector(20);
//vector1.InitRandom(1, 5);

//Console.WriteLine(vector1);

//Pair[] pairs = vector1.CalcFrequency();

//for (int i = 0; i < pairs.Length; i++)
//{
//    Console.WriteLine(pairs[i] + " ");
//}
//Console.WriteLine();
//Console.WriteLine("Longest frequency is: " + vector1.LongestFrequency(pairs));

//Vector vector2 = new Vector(6);
//vector2.InitShuffle();

//Console.WriteLine(vector2);

//Vector vector3 = new Vector(10);
//vector3.InitRandom(1, 20);
//Console.WriteLine(vector3);
//vector3.SplitMergeSort();
//Console.WriteLine(vector3);

//Vector vector4 = new Vector();
//vector4.ManualInitialisation();

//Console.WriteLine(vector4);
//vector4.HeapSort();

//Console.WriteLine(vector4);

//Vector vector6 = new Vector();
//vector6.ReadFromFile("Array.txt");

//Vector a = new Vector(3);
//a.InitRandom(1, 50);

//Vector b = new Vector(5);
//b.InitRandom(1, 50);

//Vector c = a + b;
//Vector d = a + 5;

//d += 5;

//int ai = a;
//Vector e = new Vector(10);
//e = 5;

//Console.WriteLine("a = "+ a);
//Console.WriteLine("b = " + b); 
//Console.WriteLine("c = " + c);

int[,] matr1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

Matrix matrix1 = new Matrix(matr1);

foreach(var item in matrix1)
{
    Console.WriteLine(item);
}

