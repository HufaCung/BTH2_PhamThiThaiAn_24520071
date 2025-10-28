using System;

namespace BTH2_Bai01
{
    class Program
    {
        // Hiển thị menu
        static void ShowMenu()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Nhap thang nam");
            Console.WriteLine("2. In ra lich cua thang do");
            Console.WriteLine("0. Thoat");
        }

        // Kiểm tra tháng năm có hợp lệ không

        static bool IsValidMonthYear(int month, int year)
        {
            return month >= 1 && month <= 12 && year >= 1;
        }

        // In ra lịch của tháng
        static void PrintCalendar(int month, int year)
        {
            if (!IsValidMonthYear(month, year))
            {
                Console.WriteLine("Thang nam khong hop le");
                return;
            }

            Console.WriteLine($"Lich thang {month} nam {year}");
            Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

            DateTime firstDay = new DateTime(year, month, 1);
            int startDay = (int)firstDay.DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            for (int i = 0; i < startDay; i++)
            {
                Console.Write("    ");
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                Console.Write($"{day,3} ");
                if ((startDay + day) % 7 == 0)
                    Console.WriteLine();
            }

            Console.WriteLine();
        }

        // Hàm main
        static void Main()
        {
            ShowMenu();

            int choice;
            int month = 0, year = 0;

            do
            {
                Console.Write("Chon chuc nang: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lua chon khong hop le!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap thang: ");
                        if (!int.TryParse(Console.ReadLine(), out month))
                            month = 0;

                        Console.Write("Nhap nam: ");
                        if (!int.TryParse(Console.ReadLine(), out year))
                            year = 0;

                        if (!IsValidMonthYear(month, year))
                            Console.WriteLine("Thang nam khong hop le");
                        break;

                    case 2:
                        PrintCalendar(month, year);
                        break;

                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

            } while (choice != 0);
        }
    }

}