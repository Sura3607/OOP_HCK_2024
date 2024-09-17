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

            atm.Login("31231022655", "Khoa@123");

            Console.WriteLine($"Số dư hiện tại: {atm.CheckBalance()}");
            Console.WriteLine("\n-----------------------------------------------\n");
            atm.Withdraw(10m, "111222");
            Console.WriteLine("\n-----------------------------------------------\n");
            Console.WriteLine($"Số dư hiện tại: {atm.CheckBalance()}");
            Console.WriteLine("\n-----------------------------------------------\n");
            atm.Transfer(200m, "31231022656", "111222");
            Console.WriteLine("\n-----------------------------------------------\n");
            Console.WriteLine($"Số dư hiện tại: {atm.CheckBalance()}");
            Console.WriteLine("\n-----------------------------------------------\n");

            if(atm.ChangePassword("Khoa@123", "123@Khoa", "111222"))
            {
                Console.WriteLine("\nThay đổi mật khẩu thành công.");
            }
            else 
            {
                Console.WriteLine("\nThay đổi mật khẩu không thành công.");
            }

            atm.Login("31231022655", "Khoa@123");
            atm.Login("31231022655", "123@Khoa");

            atm.Login("31231022656", "Nhut@123");
            Console.WriteLine("\n-----------------------------------------------\n");
            Console.WriteLine($"Số dư hiện tại: {atm.CheckBalance()}");
            Console.WriteLine("\n-----------------------------------------------\n");

            Console.ReadLine();
        }
    }
}
