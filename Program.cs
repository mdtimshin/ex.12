using System;
using System.Collections.Generic;

namespace ex._12
{
    public class TreeNode
    {
        public static int transfer;
        public static int comparison;
        public TreeNode(int data)
        {
            Data = data;
        }

        //данные
        public int Data { get; set; }

        //левая ветка дерева
        public TreeNode Left { get; set; }

        //правая ветка дерева
        public TreeNode Right { get; set; }

        //рекурсивное добавление узла в дерево
        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                comparison++;
                if (Left == null)
                {
                    comparison++;
                    Left = node;
                    transfer++;
                }
                else
                {
                    comparison++;
                    Left.Insert(node);
                    transfer++;
                }
            }
            else
            {
                if (Right == null)
                {
                    comparison++;
                    Right = node;
                    transfer++;
                }
                else
                {
                    comparison++;
                    Right.Insert(node);
                    transfer++;
                }
            }
        }

        //преобразование дерева в отсортированный массив
        public int[] Transform(List<int> elements = null)
        {
            if (elements == null)
            {
                comparison++;
                elements = new List<int>();
                transfer++;
            }

            if (Left != null)
            {
                comparison++;
                Left.Transform(elements);
            }

            elements.Add(Data);

            if (Right != null)
            {
                comparison++;
                Right.Transform(elements);
            }

            return elements.ToArray();
        }
    }

    public class FastSort
    {
        public static int transfer;
        public static int comparison;
        public static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
            transfer++;
        }

        //метод возвращающий индекс опорного элемента
        public static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    comparison++;
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        public static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                comparison++;
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
    }

    class Program
    {
        //метод для сортировки с помощью двоичного дерева
        private static int[] TreeSort(int[] array)
        {
            TreeNode treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }

            return treeNode.Transform();
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int[] randomMas = new int[n];
            Random random = new Random();
            for (int i = 0; i < randomMas.Length; i++)
            {
                randomMas[i] = random.Next(0, 100);
            }

            int[] vozrMas = new int[n];
            randomMas.CopyTo(vozrMas, 0);
            Array.Sort(vozrMas);
            int[] ubMas = new int[n];
            vozrMas.CopyTo(ubMas, 0);
            Array.Reverse(ubMas);


            Console.WriteLine("Random Array: {0} ", string.Join(" ", TreeSort(randomMas)));
            Console.WriteLine($"Количество перестановок = {TreeNode.transfer}. Количество сравнений = {TreeNode.comparison}");
            TreeNode.transfer = 0; TreeNode.comparison = 0;

            Console.WriteLine("Vozrastanie Array: {0}", string.Join(" ", TreeSort(vozrMas)));
            Console.WriteLine($"Количество перестановок = {TreeNode.transfer}. Количество сравнений = {TreeNode.comparison}");
            TreeNode.transfer = 0; TreeNode.comparison = 0;

            Console.WriteLine("Ubivanie Array: {0}", string.Join(" ", TreeSort(ubMas)));
            Console.WriteLine($"Количество перестановок = {TreeNode.transfer}. Количество сравнений = {TreeNode.comparison}");
            TreeNode.transfer = 0; TreeNode.comparison = 0;

            Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");


            Console.WriteLine("Random Array: {0} ", string.Join(" ", FastSort.QuickSort(randomMas)));
            Console.WriteLine($"Количество перестановок = {FastSort.transfer}. Количество сравнений = {FastSort.comparison}");
            FastSort.transfer = 0; FastSort.comparison = 0;

            Console.WriteLine("Vozrastanie Array: {0}", string.Join(" ", FastSort.QuickSort(vozrMas)));
            Console.WriteLine($"Количество перестановок = {FastSort.transfer}. Количество сравнений = {FastSort.comparison}");
            FastSort.transfer = 0; FastSort.comparison = 0;

            Console.WriteLine("Ubivanie Array: {0}", string.Join(" ", FastSort.QuickSort(ubMas)));
            Console.WriteLine($"Количество перестановок = {FastSort.transfer}. Количество сравнений = {FastSort.comparison}");
            FastSort.transfer = 0; FastSort.comparison = 0;
        }
    }
}
