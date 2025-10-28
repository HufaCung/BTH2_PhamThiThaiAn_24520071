using System;

namespace BTH2_Bai03
{
    class Program
    {
        // Ham hien thi menu
        static void ShowMenu()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Nhap ma tran");
            Console.WriteLine("2. Xuat ma tran");
            Console.WriteLine("3. Tim kiem mot phan tu trong ma tran");
            Console.WriteLine("4. Xuat cac phan tu la so nguyen to");
            Console.WriteLine("5. Dong co nhieu so nguyen to nhat");
            Console.WriteLine("0. Thoat");
        }

        // Ham kiem tra so nguyen to
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }

        // Cau a: Nhap ma tran
        static int[,] InputMatrix(out int rows, out int cols)
        {
            rows = 0;
            cols = 0;

            while (true)
            {
                Console.Write("Nhap so dong: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out rows) && rows > 0)
                    break;
                Console.WriteLine("Gia tri khong hop le. Vui long nhap lai.");
            }

            while (true)
            {
                Console.Write("Nhap so cot: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out cols) && cols > 0)
                    break;
                Console.WriteLine("Gia tri khong hop le. Vui long nhap lai.");
            }

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    while (true)
                    {
                        Console.Write($"Nhap phan tu [{i},{j}]: ");
                        string? input = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out matrix[i, j]))
                            break;
                        Console.WriteLine("Gia tri khong hop le. Vui long nhap lai.");
                    }
                }
            }

            return matrix;
        }

        // Cau a: Xuat ma tran
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            Console.WriteLine("Ma tran:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        // Cau b: Tim kiem phan tu
        static void SearchElement(int[,] matrix, int value)
        {
            bool found = false;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == value)
                    {
                        Console.WriteLine($"Tim thay tai vi tri [{i},{j}]");
                        found = true;
                    }
                }
            }

            if (!found)
                Console.WriteLine("Khong tim thay phan tu trong ma tran");
        }

        // Cau c: Xuat cac so nguyen to
        static void PrintPrimes(int[,] matrix)
        {
            Console.WriteLine("Cac phan tu la so nguyen to:");
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool hasPrime = false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (IsPrime(matrix[i, j]))
                    {
                        Console.Write($"{matrix[i, j]} ");
                        hasPrime = true;
                    }
                }
            }

            if (!hasPrime)
                Console.WriteLine("Khong co so nguyen to nao");

            Console.WriteLine();
        }

        // Cau d: Dong co nhieu so nguyen to nhat
        static void RowWithMostPrimes(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maxCount = 0;
            int maxRow = -1;

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (IsPrime(matrix[i, j]))
                        count++;
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxRow = i;
                }
            }

            if (maxRow != -1)
            {
                Console.WriteLine($"Dong co nhieu so nguyen to nhat la dong {maxRow} voi {maxCount} so nguyen to:");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[maxRow, j]} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Khong co dong nao chua so nguyen to");
            }
        }

        // Ham main
        static void Main()
        {
            int[,]? matrix = null;
            int rows = 0, cols = 0;
            int choice = -1;

            ShowMenu();
            do
            {
                Console.Write("Chon chuc nang: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            matrix = InputMatrix(out rows, out cols);
                            break;

                        case 2:
                            if (matrix != null)
                                PrintMatrix(matrix);
                            else
                                Console.WriteLine("Chua nhap ma tran");
                            break;

                        case 3:
                            if (matrix != null)
                            {
                                Console.Write("Nhap gia tri can tim: ");
                                string? valInput = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(valInput) && int.TryParse(valInput, out int value))
                                    SearchElement(matrix, value);
                                else
                                    Console.WriteLine("Gia tri khong hop le.");
                            }
                            else
                                Console.WriteLine("Chua nhap ma tran");
                            break;

                        case 4:
                            if (matrix != null)
                                PrintPrimes(matrix);
                            else
                                Console.WriteLine("Chua nhap ma tran");
                            break;

                        case 5:
                            if (matrix != null)
                                RowWithMostPrimes(matrix);
                            else
                                Console.WriteLine("Chua nhap ma tran");
                            break;

                        case 0:
                            Console.WriteLine("Ket thuc chuong trinh.");
                            break;

                        default:
                            Console.WriteLine("Lua chon khong hop le!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le!");
                }

                Console.WriteLine();

            } while (choice != 0);
        }
    }
}