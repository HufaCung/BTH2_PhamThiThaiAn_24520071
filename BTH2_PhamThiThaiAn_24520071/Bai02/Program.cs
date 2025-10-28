using System;
using System.IO;

namespace BTH2_Bai02
{
    class Program
    {
        // Ham hien thi menu chuc nang
        static void ShowMenu()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Nhap duong dan thu muc");
            Console.WriteLine("2. Xuat tat ca ten tap tin va thu muc con");
            Console.WriteLine("0. Thoat");
        }

        // Ham kiem tra duong dan co ton tai hay khong
        static bool IsValidDirectory(string? path)
        {
            return !string.IsNullOrWhiteSpace(path) && Directory.Exists(path);
        }

        // Ham xuat danh sach thu muc con va tap tin trong thu muc
        static void PrintDirectoryContents(string? path)
        {
            if (!IsValidDirectory(path))
            {
                Console.WriteLine("Thu muc khong ton tai hoac duong dan khong hop le.");
                return;
            }

            Console.WriteLine("=== Danh sach thu muc con ===");
            string[] subDirs = Directory.GetDirectories(path!);
            foreach (string dir in subDirs)
            {
                // Chi xuat ten thu muc, khong xuat duong dan day du
                Console.WriteLine(Path.GetFileName(dir));
            }

            Console.WriteLine("=== Danh sach tap tin ===");
            string[] files = Directory.GetFiles(path!);
            foreach (string file in files)
            {
                // Chi xuat ten tap tin, khong xuat duong dan day du
                Console.WriteLine(Path.GetFileName(file));
            }
        }

        // Ham chinh cua chuong trinh
        static void Main()
        {
            string? directoryPath = null; // Bien luu duong dan thu muc
            int choice; // Bien luu lua chon cua nguoi dung

            ShowMenu(); // Hien thi menu
            do
            {
                Console.Write("Chon chuc nang: ");
                string? input = Console.ReadLine(); // Doc lua chon tu ban phim

                // Kiem tra lua chon co phai so nguyen hay khong
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }

                // Xu ly lua chon cua nguoi dung
                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap duong dan thu muc: ");
                        string? pathInput = Console.ReadLine(); // Doc duong dan tu ban phim

                        // Kiem tra duong dan co ton tai hay khong
                        if (IsValidDirectory(pathInput))
                        {
                            directoryPath = pathInput;
                            Console.WriteLine("Duong dan da duoc luu.");
                        }
                        else
                        {
                            Console.WriteLine("Thu muc khong ton tai hoac duong dan khong hop le.");
                        }
                        break;

                    case 2:
                        // Kiem tra da nhap duong dan chua
                        if (string.IsNullOrWhiteSpace(directoryPath))
                        {
                            Console.WriteLine("Vui long nhap duong dan thu muc truoc.");
                        }
                        else
                        {
                            PrintDirectoryContents(directoryPath); // Xuat danh sach tap tin va thu muc
                        }
                        break;

                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                Console.WriteLine(); // Xuong dong sau moi lan thuc hien

            } while (choice != 0); // Lap lai cho den khi chon 0 de thoat
        }
    }
}