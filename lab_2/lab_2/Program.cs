using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LabFirstPart firstPart = new LabFirstPart();

            Console.WriteLine("Enter the length of array:");
            int length = int.Parse(Console.ReadLine());
            int[] array = firstPart.generateArray(length);

            printArray(array);

            Console.WriteLine("\nNumber of three element progressions: " + firstPart.progressionsNumber(array));

            Console.WriteLine("=============================================");

            Console.WriteLine("Enter number of coordinates in vectors");
            int numberOfCord = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter vector a");
            double[] a = firstPart.inputVector(numberOfCord);

            Console.WriteLine("Enter vector b");
            double[] b = firstPart.inputVector(numberOfCord);

            Console.WriteLine(firstPart.perpendicularityCheck(a, b));

            Console.WriteLine("=============================================");

            Console.WriteLine("Start array:");
            printArray(array);

            Console.WriteLine("Transformed array:");
            printArray(firstPart.trnsformArray(array));

            Console.WriteLine("=============================================");
            Console.WriteLine("2D array part");
            Console.WriteLine("=============================================");

            LabSecondPart secondPart = new LabSecondPart();

            Console.WriteLine("Enter number of rows:");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of columns:");
            int y = int.Parse(Console.ReadLine());

            int[,] secondArray = secondPart.generateArray(x, y);

            Console.WriteLine("Start matrix:");

            print2DArray(secondArray);

            Console.WriteLine("=============================================");

            Console.WriteLine("Sorted matrix:");

            int[,] sortedDesc = secondPart.sortDesc(secondArray);

            print2DArray(sortedDesc);

            Console.WriteLine("=============================================");

            secondPart.matchingRowCol();

            Console.WriteLine("=============================================");

            List<int[]> sums = secondPart.sumInNegRow(secondArray);

            foreach(int[] sum in sums)
            {
                Console.WriteLine("In " + (sum[0] + 1) + " row sum = " + sum[1]);
            }
        }

        static void printArray<T>(T[] array)
        {
            foreach (T element in array)
            {
                Console.Write("[" + element + "] ");
            }
            Console.Write("\n");
        }

        static void print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] < 10 && array[i,j] > -10)
                    {
                        if(array[i, j] < 0)
                        {
                            Console.Write(" " + array[i, j] + ", ");
                        } else
                        {
                            Console.Write("  " + array[i, j] + ", ");
                        }
                        
                    } else
                    {
                        if (array[i, j] < 0)
                        {
                            Console.Write(array[i, j] + ", ");
                        }
                        else
                        {
                            Console.Write(" " + array[i, j] + ", ");
                        }
                    }
                }
                Console.Write("\n");
            }
        }
    }
}

public class LabFirstPart
{
    private Random random = new Random();

    public int[] generateArray(int length)
    {
        int[] array = new int[length];

        for(int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-10, 11);
        }

        return array;
    }

    public int progressionsNumber(int[] array)
    {
        int count = 0;

        for(int i = 0; i < array.Length - 2; i++)
        {
            if (array[i + 1] - array[i] == array[i + 2] - array[i + 1])
            {
                count++;
            }
        }

        return count;
    }

    public double[] inputVector(int numberOfCord)
    { 
        double[] vector = new double[numberOfCord];

        for(int i = 0; i < numberOfCord; i++)
        {
            vector[i] = double.Parse(Console.ReadLine());
        }

        return vector;
    }

    public string perpendicularityCheck(double[] a, double[] b)
    {
        double dotProduct = getDotProduct(a, b);

        if (dotProduct == 0)
        {
            return "Vectors are perpendicular";
        }
        else
        {
            return "Vectors are not perpendicular";
        }
    }

    double getDotProduct(double[] a, double[] b)
    {
        double dotProduct = 0;

        for (int i = 0; i < a.Length; i++)
        {
            dotProduct += a[i] * b[i];
        }

        return dotProduct;
    }

    public int[] trnsformArray(int[] array)
    {
        int[] result = new int[array.Length];
        int oddIndex = 0;
        int evenIndex = array.Length / 2;

        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0 || i == 0)
            {
                result[evenIndex] = array[i];
                evenIndex++;
            }
            else
            {
                result[oddIndex] = array[i];
                oddIndex++;
            }
        }

        return result;
    }
}

public class LabSecondPart
{
    private Random random = new Random();

    public int[,] generateArray(int sizeX, int sizeY)
    {
        int[,] array = new int[sizeX, sizeY];
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                array[i, j] = random.Next(-10, 11);
            }
        }

        return array;
    }

    public int[,] sortDesc(int[,] matrix)
    {
        int[,] result = matrix;
        int cols = result.GetLength(1);
        int rows = result.GetLength(0);

        for (int j = 1; j < cols; j += 2)
        {
            int[] columnArray = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                columnArray[i] = result[i, j];
            }

            quickSort(columnArray, 0, columnArray.Length - 1);


            for (int i = 0; i < rows; i++)
            {
                result[i, j] = columnArray[i];
            }
        }

        return result;
    }

    public void matchingRowCol()
    {
        int[,] matrix = new int[8, 8] {
            { 1, 2, 3, 4, 5, 6, 7, 8 },
            { 2, 1, 2, 3, 4, 5, 6, 7 },
            { 3, 2, 1, 2, 3, 4, 5, 6 },
            { 4, 3, 9, 1, 2, 3, 4, 5 },
            { 5, 4, 8, 9, 1, 2, 3, 4 },
            { 6, 5, 7, 8, 9, 1, 2, 3 },
            { 7, 6, 6, 7, 8, 9, 1, 2 },
            { 8, 7, 5, 6, 7, 8, 9, 1 }
        };

        List<int> matchingRows = new List<int>();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            bool isMatching = true;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] != matrix[j, i])
                {
                    isMatching = false;
                    break;
                }
            }

            if (isMatching)
            {
                matchingRows.Add(i);
            }
        }

        Console.WriteLine("Matching indexes of rows and cols: ");

        foreach (int row in matchingRows)
        {
            Console.WriteLine(row + 1);
        }
    }

    public List<int[]> sumInNegRow(int[,] matrix)
    {
        List<int[]> sums = new List<int[]>();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            bool hasNegative = false;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }

            if(hasNegative)
            {
                int sum = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }

                int[] result = { i, sum };
                sums.Add(result);
            }
        }

        return sums;
    }

    public void quickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = partition(arr, left, right);
            quickSort(arr, left, pivotIndex - 1);
            quickSort(arr, pivotIndex + 1, right);
        }
    }

    private int partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (arr[j] > pivot)
            {
                i++;
                swap(arr, i, j);
            }
        }
        swap(arr, i + 1, right);
        return i + 1;
    }

    private void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}

