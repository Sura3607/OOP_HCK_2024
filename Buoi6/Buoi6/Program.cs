using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            User user1 = new User("Nhut", "Nhut@gmail.com", "0911943607", "Nhut@123");
            User user2 = new User("Khoa", "Khoa@gmail.com", "0911943607", "Khoa@123");

            Account acc1 = new Account(user1,"31231022656" ,"111111", 2000m);
            Account acc2 = new Account(user2, "31231022655", "111222", 1000m);

            ATM atm = new ATM();
            atm.AddAccount(acc1);
            atm.AddAccount(acc2);

            MenuLogin(atm);

            //atm.Login("31231022655", "Khoa@123");

            //Console.WriteLine($"Số dư hiện tại: {atm.CheckBalance()}");
            //Console.WriteLine("\n-----------------------------------------------\n");
            ////rut
            //atm.Withdraw(10m, "111222");
            //Console.WriteLine("\n-----------------------------------------------\n");
            //Console.WriteLine($"Số dư hiện tại: {atm.CheckBalance()}");
            //Console.WriteLine("\n-----------------------------------------------\n");
            ////chuyen
            //atm.Transfer(200m, "31231022656", "111222");
            //Console.WriteLine("\n-----------------------------------------------\n");
            //Console.WriteLine($"Số dư hiện tại: {atm.CheckBalance()}");
            //Console.WriteLine("\n-----------------------------------------------\n");
            ////doipass
            //if (atm.ChangePassword("Khoa@123", "123@Khoa", "111222"))
            //{
            //    Console.WriteLine("\nThay đổi mật khẩu thành công.");
            //}
            //else
            //{
            //    Console.WriteLine("\nThay đổi mật khẩu không thành công.");
            //}
            ////test thu sau khi doi pass
            //atm.Login("31231022655", "Khoa@123");
            //atm.Login("31231022655", "123@Khoa");
            ////dang nhap tk nay nhan tien
            //atm.Login("31231022656", "Nhut@123");
            //Console.WriteLine("\n-----------------------------------------------\n");
            //Console.WriteLine($"Số dư hiện tại: {atm.CheckBalance()}");
            //Console.WriteLine("\n-----------------------------------------------\n");

            Console.ReadLine();
        }
        static void MenuLogin(ATM atm)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            while(key.Key != ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("LOGIN");
                Console.Write("Số tài khoản: ");
                string accNumber = Console.ReadLine();
                Console.Write("Mật khẩu: ");
                string pass = Console.ReadLine();

                if(atm.Login(accNumber, pass))
                {
                    Console.ReadLine();
                    Menu(atm, key);
                }
                else
                {
                    Console.ReadLine();
                }
            }
        }
        static void Menu(ATM atm, ConsoleKeyInfo key)
        {
            while (key.Key != ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("1.Rút tiền\n2.Chuyển tiền\n3.Kiểm tra số dư\n4.Đổi mật khẩu\nESC.Thoát");
                key = Console.ReadKey(true);
         
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("Nhập số tiền: ");
                        decimal monney = decimal.Parse(Console.ReadLine());
                        Console.Write("Nhập mã pin: ");
                        string pin = Console.ReadLine();
                        atm.Withdraw(monney, pin);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.Write("Nhập số tiền: ");
                        monney = decimal.Parse(Console.ReadLine());
                        Console.Write("Nhập số tài khoản đích: ");
                        string distination = Console.ReadLine();
                        Console.Write("Nhập mã pin: ");
                        pin = Console.ReadLine();
                        atm.Transfer(monney,distination, pin);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine($"Số dư hiện tại: {atm.CheckBalance()}");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.Write("Mật khẩu hiện tại: ");
                        string current = Console.ReadLine();
                        Console.Write("Mật khẩu mới: ");
                        string newpass = Console.ReadLine();
                        Console.Write("Nhập mã pin: ");
                        pin = Console.ReadLine();

                        if (atm.ChangePassword(current,newpass,pin))
                        {
                            Console.WriteLine("\nThay đổi mật khẩu thành công.");
                        }
                        else
                        {
                            Console.WriteLine("\nThay đổi mật khẩu không thành công.");
                        }
                        Console.ReadLine();
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            }
        }
    }
}
