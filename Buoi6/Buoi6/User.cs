using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi6
{
    public class User
    {
        private static int _nextId = 1;
        public string Id {  get; private set; }
        public string Name {  get; private set; }
        public string Email {  get; private set; }
        public string Phone_number {  get; private set; }
        private string Password { get; set; }

        public User(string name, string email, string phone_number, string password)
        {
            Id = GenerateId();
            Name = name;
            Email = email;
            Phone_number = phone_number;
            if (IsValidPasswordCreate(password))
            {
                Password = password;
            }
            else
            {
                throw new ArgumentException("Mật khẩu phải có ít nhất một ký tự viết hoa và một ký tự đặc biệt.");
            }
        }
        private string GenerateId()
        {
            string id = $"{_nextId:D4}";
            _nextId++;
            return id;
        }
        private bool IsValidPasswordCreate(string password)
        {
            return !string.IsNullOrEmpty(password) &&
                   password.Any(char.IsUpper) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch));
        }
        public bool IsValidPassword(string password)
        {
            return Password == password;
        }
        internal bool ChangePassword(string currentPassword, string newPassword)
        {
            if (IsValidPasswordCreate(newPassword) && IsValidPassword(currentPassword))
            {
                Password = newPassword;
                return true;
            }
            return false;
        }
    }
}
