using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi6
{
    internal class ATM
    {
        private Dictionary<string, Account> accounts = new Dictionary<string, Account>();
        private Account currentAccount;
        private Notifier notifier = new Notifier();
        public void AddAccount(Account account)
        {
            accounts[account.AccountNumber] = account;

            account.OnTransaction += notifier.SMS;
            account.OnTransaction += notifier.Email;
            account.OnTransaction += notifier.Banking;
        }
        public bool Login(string accountNumber, string password)
        {
            Account account = accounts.Values.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null && account.IsValidLogin(accountNumber,password))
            {
                currentAccount = account;
                Console.WriteLine("Đăng nhập thành công.");
                Console.WriteLine($"Số dư của {account.User.Name} là {account.Balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Đăng nhập không thành công.");
                return false;
            }
        }
        public bool Withdraw(decimal amount, string pin)
        {
            if (currentAccount != null)
            {
                return currentAccount.Withdraw(amount, pin);
            }
            else
            {
                Console.WriteLine("Vui lòng đăng nhập trước.");
                return false;
            }
        }
        public bool Transfer(decimal amount, string destination_accountNumber, string pin)
        {
            if (currentAccount != null)
            {
                if (accounts.TryGetValue(destination_accountNumber, out var destinationAccount))
                {
                    return currentAccount.Transfer(amount, destinationAccount, pin);
                }
                else
                {
                    Console.WriteLine("Tài khoản đích không hợp lệ.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Vui lòng đăng nhập trước.");
                return false;
            }
        }
        public decimal CheckBalance()
        {
            if (currentAccount != null)
            {
                return currentAccount.Balance;
            }
            else
            {
                Console.WriteLine("Vui lòng đăng nhập trước.");
                return 0;
            }
        }
        public bool ChangePassword(string currentPassword, string newPassword, string pin)
        {
            if (currentAccount != null)
            {
                return currentAccount.ChangePassword(currentPassword, newPassword, pin);
            }
            else
            {
                Console.WriteLine("Vui lòng đăng nhập trước.");
                return false;
            }
        }
    }
}
