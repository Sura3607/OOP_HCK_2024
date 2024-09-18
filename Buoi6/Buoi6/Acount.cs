using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Buoi6
{
    public delegate void NotificationHandler(string content);
    public class Account
    {
        public User User { get; private set; }
        public string AccountNumber { get; private set; }
        private string Pin { get; set; }
        public decimal Balance { get; private set; }

        public event NotificationHandler OnTransaction;
        public Account(User user,string accountNumber, string pin, decimal initialBalance)
        {
            User = user;
            AccountNumber = accountNumber;
            if (IsValidPinCreate(pin))
            {
                Pin = pin;
            }
            else
            {
                throw new ArgumentException("Mã PIN phải có chính xác 6 ký tự và chỉ chứa các chữ số.");
            }
            Balance = initialBalance;
        }
        internal bool IsValidLogin(string accountNumber, string password)
        {
            return AccountNumber == accountNumber && User.IsValidPassword(password);
        }
        public bool Withdraw(decimal amount, string pin)
        {

            if (Pin == pin && amount <= Balance)
            {
                Balance -= amount;
                string message = $"Rút tiền: {amount:C}. Số dư còn lại: {Balance:C}.";
                OnTransaction?.Invoke(message);
                return true;
            }
            else
            {
                Console.WriteLine("Số dư không đủ");
                return false;
            }
        }
        public bool Transfer(decimal amount, Account destinationAccount, string pin)
        {
            if (Pin == pin && amount <= Balance)
            {
                Balance -= amount;
                destinationAccount.Balance += amount;
                string message = $"Chuyển tiền: {amount:C} đến tài khoản {destinationAccount.AccountNumber}. Số dư còn lại: {Balance:C}.";
                OnTransaction?.Invoke(message);
                return true;
            }
            else
            {
                Console.WriteLine("Số dư không đủ");
                return false;
            }
        }
        private bool IsValidPinCreate(string pin)
        {
            return !string.IsNullOrEmpty(pin) &&
                   pin.Length == 6 &&
                   Regex.IsMatch(pin, @"^\d{6}$");
            //@"^\d{6}$" Biểu thức chính quy. ^ là bắt đầu chuỗi, \d Kí tự (0-9), {6} số kí tự là 6, $ kết thúc chuỗi
        }
        public bool IsValidPin(string pin)
        {
            return Pin == pin;
        }
        public bool ChangePassword(string currentPassword, string newPassword, string pin)
        {
            if (!IsValidPin(pin))
            {
                Console.WriteLine("Mã pin không đúng.");
                return false;
            }
            if(User.ChangePassword(currentPassword, newPassword))
            {
                string message = "Bạn vừa thay đổi mật khẩu thành công.";
                OnTransaction?.Invoke(message);
            }
            return true;
        }
    }
}
