using System;
using System.Collections.Generic;
using System.Linq;

namespace BTH2_Bai05
{
    // Lop mo ta thong tin bat dong san
    class RealEstate
    {
        public string? Location { get; set; } // Dia diem
        public double Price { get; set; }     // Gia ban
        public double Area { get; set; }      // Dien tich

        // Ham nhap thong tin bat dong san
        public virtual void Input()
        {
            Console.Write("Dia diem: ");
            Location = Console.ReadLine();

            while (true)
            {
                Console.Write("Gia ban (VND): ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && double.TryParse(input, out double price))
                {
                    Price = price;
                    break;
                }
                Console.WriteLine("Gia khong hop le. Vui long nhap lai.");
            }

            while (true)
            {
                Console.Write("Dien tich (m2): ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && double.TryParse(input, out double area))
                {
                    Area = area;
                    break;
                }
                Console.WriteLine("Dien tich khong hop le. Vui long nhap lai.");
            }
        }

        // Ham xuat thong tin bat dong san
        public virtual void Output()
        {
            Console.WriteLine($"Dia diem: {Location}, Gia: {Price} VND, Dien tich: {Area} m2");
        }
    }

    // Lop mo ta nha pho
    class Townhouse : RealEstate
    {
        public int YearBuilt { get; set; } // Nam xay dung
        public int Floors { get; set; }    // So tang

        public override void Input()
        {
            base.Input();

            while (true)
            {
                Console.Write("Nam xay dung: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int year))
                {
                    YearBuilt = year;
                    break;
                }
                Console.WriteLine("Nam xay dung khong hop le. Vui long nhap lai.");
            }

            while (true)
            {
                Console.Write("So tang: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int floors))
                {
                    Floors = floors;
                    break;
                }
                Console.WriteLine("So tang khong hop le. Vui long nhap lai.");
            }
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Nam xay dung: {YearBuilt}, So tang: {Floors}");
        }
    }

    // Lop mo ta chung cu
    class Apartment : RealEstate
    {
        public int Floor { get; set; } // Tang cua can ho

        public override void Input()
        {
            base.Input();

            while (true)
            {
                Console.Write("Tang: ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int floor))
                {
                    Floor = floor;
                    break;
                }
                Console.WriteLine("Tang khong hop le. Vui long nhap lai.");
            }
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Tang: {Floor}");
        }
    }

    class Program
    {
        static List<RealEstate> list = new List<RealEstate>();

        static void Main()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Nhap danh sach bat dong san");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tinh tong gia ban");
            Console.WriteLine("4. Loc theo dien tich va nam xay dung");
            Console.WriteLine("5. Tim kiem theo tieu chi");
            Console.WriteLine("0. Thoat");

            while (true)
            {
                Console.Write("Chon chuc nang: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": NhapDanhSach(); break;
                    case "2": XuatDanhSach(); break;
                    case "3": TinhTongGia(); break;
                    case "4": LocTheoDieuKien(); break;
                    case "5": TimKiem(); break;
                    case "0":
                        Console.WriteLine("Ket thuc chuong trinh.");
                        return;
                    default: Console.WriteLine("Lua chon khong hop le."); break;
                }
            }
        }

        static void NhapDanhSach()
        {
            Console.Write("Nhap so luong bat dong san: ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int n))
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\n--- Bat dong san thu {i + 1} ---");
                    Console.Write("Loai (1: Khu dat, 2: Nha pho, 3: Chung cu): ");
                    string? type = Console.ReadLine();
                    RealEstate re;

                    switch (type)
                    {
                        case "1": re = new RealEstate(); break;
                        case "2": re = new Townhouse(); break;
                        case "3": re = new Apartment(); break;
                        default: Console.WriteLine("Loai khong hop le."); continue;
                    }

                    re.Input();
                    list.Add(re);
                }
            }
            else
            {
                Console.WriteLine("So luong khong hop le.");
            }
        }

        static void XuatDanhSach()
        {
            Console.WriteLine("\nDANH SACH BAT DONG SAN:");
            foreach (var re in list)
            {
                re.Output();
            }
        }

        static void TinhTongGia()
        {
            double total = list.Sum(re => re.Price);
            Console.WriteLine($"\nTong gia ban tat ca: {total} VND");
        }

        static void LocTheoDieuKien()
        {
            Console.WriteLine("\nLOC BAT DONG SAN:");
            bool found = false;

            foreach (var re in list)
            {
                if (re is RealEstate land && land.GetType() == typeof(RealEstate) && land.Area > 100)
                {
                    land.Output();
                    found = true;
                }
                else if (re is Townhouse th && th.Area > 60 && th.YearBuilt >= 2019)
                {
                    th.Output();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("Danh sach ket qua tim kiem rong");
        }

        static void TimKiem()
        {
            Console.Write("\nNhap dia diem can tim (chuoi): ");
            string? keyword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("Chuoi tim kiem khong hop le.");
                return;
            }

            Console.Write("Nhap gia toi da: ");
            string? priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput) && double.TryParse(priceInput, out double maxPrice))
            {
                Console.Write("Nhap dien tich toi thieu: ");
                string? areaInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(areaInput) && double.TryParse(areaInput, out double minArea))
                {
                    Console.WriteLine("\nKET QUA TIM KIEM:");
                    bool found = false;

                    foreach (var re in list)
                    {
                        if ((re is Townhouse || re is Apartment) &&
                            re.Location != null &&
                            re.Location.ToLower().Contains(keyword.ToLower()) &&
                            re.Price <= maxPrice &&
                            re.Area >= minArea)
                        {
                            re.Output();
                            found = true;
                        }
                    }

                    if (!found)
                        Console.WriteLine("Danh sach ket qua tim kiem rong");
                }
                else
                {
                    Console.WriteLine("Dien tich khong hop le.");
                }
            }
            else
            {
                Console.WriteLine("Gia khong hop le.");
            }
        }
    }
}