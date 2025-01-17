﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleApp
{
    public class Task_2
    {
        // Дан размер квадратной матрицы (двумерного массива) и сама матрица.
        // Вывести, симметрична ли матрица относительно главной диагонали? (пример: 2 0 1 1 0 То да)
        public static void Start()
        {

            // O(n2) - Квадратичная сложность

            int sizeMatrix;
            Console.WriteLine("Введите размерность матрицы: ");
            while (!int.TryParse(Console.ReadLine(), out sizeMatrix) && sizeMatrix >= 2)
            {}

            int[,] Matrix = new int[sizeMatrix, sizeMatrix];
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    Console.Write($"Введите значение в ячейку[{i}][{j}] матрицы: ");
                    Matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            string Result = IsSymmetrical(Matrix, sizeMatrix) ? "симметричная" : "не симметричная";
            Console.WriteLine($"Результат: {Result}");
            Console.WriteLine($"Press the key...");
            Console.ReadKey();
        }
        public static bool IsSymmetrical(int[,] Matrix, int sizeMatrix)
        {
            for (int i = 0; i < sizeMatrix; i++)
                for (int j = i + 1; j < sizeMatrix; j++)
                    if (Matrix[j,i] != Matrix[i,j])
                        return false;
                return true;
        }
    }
}
