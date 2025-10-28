using System;
using System.Collections.Generic;

namespace BTH2_Bai04
{
    class PhanSo
    {
        public int Tu { get; set; }
        public int Mau { get; set; }

        // Ham khoi tao phan so, tu dong rut gon
        public PhanSo(int tu, int mau)
        {
            if (mau == 0) throw new ArgumentException("Mau so khong duoc bang 0");
            Tu = tu;
            Mau = mau;
            RutGon();
        }

        // Ham rut gon phan so
        public void RutGon()
        {
            int ucln = UCLN(Math.Abs(Tu), Math.Abs(Mau));
            Tu /= ucln;
            Mau /= ucln;
            if (Mau < 0)
            {
                Tu = -Tu;
                Mau = -Mau;
            }
        }
    
        // UCLN
        private int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }
        // Toan tu cong hai phan so
        public static PhanSo operator +(PhanSo a, PhanSo b) =>
            new PhanSo(a.Tu * b.Mau + b.Tu * a.Mau, a.Mau * b.Mau);
        // Toan tru cong hai phan so
        public static PhanSo operator -(PhanSo a, PhanSo b) =>
            new PhanSo(a.Tu * b.Mau - b.Tu * a.Mau, a.Mau * b.Mau);
        // Toan tu nhan hai phan so
        public static PhanSo operator *(PhanSo a, PhanSo b) =>
            new PhanSo(a.Tu * b.Tu, a.Mau * b.Mau);
        // Toan tu chia hai phan so
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.Tu == 0) throw new DivideByZeroException("Khong the chia cho phan so 0");
            return new PhanSo(a.Tu * b.Mau, a.Mau * b.Tu);
        }
        // Ham tra ve gia tri so thuc cua phan so
        public double GiaTri() => (double)Tu / Mau;
        // Ham tra ve chuoi bieu dien phan so
        public override string ToString() => $"{Tu}/{Mau}";
    }

    class Program
    {
        static void Main()
        {
            // Hien thi menu
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Tinh toan voi 2 phan so");
            Console.WriteLine("2. Xu ly day phan so");
            Console.WriteLine("0. Thoat");

            // Doc lua chon
            while (true)
            {
                Console.Write("Chon chuc nang: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CalculateTwoFractions();
                        break;
                    case "2":
                        ProcessFractionList();
                        break;
                    case "0":
                        Console.WriteLine("Ket thuc chuong trinh.");
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
            }
        }
        // Tinh toan 2 phan so
        static void CalculateTwoFractions()
        {
            Console.WriteLine("\nNhap phan so thu nhat:");
            PhanSo ps1 = InputFraction();
            Console.WriteLine("Nhap phan so thu hai:");
            PhanSo ps2 = InputFraction();

            Console.WriteLine($"Tong: {ps1 + ps2}");
            Console.WriteLine($"Hieu: {ps1 - ps2}");
            Console.WriteLine($"Tich: {ps1 * ps2}");
            Console.WriteLine($"Thuong: {ps1 / ps2}");
        }
        // Xu ly day phan so
        static void ProcessFractionList()
        {
            Console.Write("\nNhap so luong phan so: ");
            int n = int.Parse(Console.ReadLine());
            List<PhanSo> list = new List<PhanSo>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Phan so thu {i + 1}:");
                list.Add(InputFraction());
            }

            PhanSo max = list[0];
            foreach (var ps in list)
                if (ps.GiaTri() > max.GiaTri()) max = ps;

            Console.WriteLine($"\nPhan so lon nhat: {max}");

            list.Sort((a, b) => a.GiaTri().CompareTo(b.GiaTri()));
            Console.WriteLine("\nDay phan so sau khi sap xep tang dan:");
            foreach (var ps in list)
                Console.WriteLine(ps);
        }
        // Nhap phan so
        static PhanSo InputFraction()
        {
            while (true)
            {
                try
                {
                    Console.Write("Tu so: ");
                    int tu = int.Parse(Console.ReadLine());
                    Console.Write("Mau so: ");
                    int mau = int.Parse(Console.ReadLine());

                    return new PhanSo(tu, mau); // se throw neu mau = 0
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}. Vui long nhap lai phan so.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du lieu khong hop le. Vui long nhap lai.");
                }
            }
        }
    }
}