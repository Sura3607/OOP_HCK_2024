﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class User
{
    private static List<User> _users = new List<User>();
    private static Dictionary<string, string> account = new Dictionary<string, string>();
    private static int CreateID = 1;
    private string user_id;
    private string user_name;
    private string name;
    private string password;
    private string email;
    private string phone_number;
    private Dictionary<Book, int> borrow;
    public User(string user_name,string name, string password, string email ="None", string phone_number = "None")
    {
        if (account.ContainsKey(user_name))
        {
            Console.WriteLine("Ten nguoi dung da ton tai moi nhap ten khac");
            return;
        }
        user_id = $"{CreateID:D4}";
        this.user_name = user_name ;
        this.name = name;
        this.password = password;
        this.email = email;
        this.phone_number = phone_number;
        borrow = new Dictionary<Book, int>();

        account[user_name] = password;
        _users.Add(this);
        Console.WriteLine("Tai khoang da duoc tao vui long dang nhap");
    }
    public List<Book> Find(string keyword, Library lib)
    {
        return lib.find(keyword);
    }
    public List<Book> GetBorrowed()
    {
        return new List<Book>(borrow.Keys);
    }
    public bool Borrow(int position, List<Book> books, Library lib, bool state = true, byte sl = 1)
    {
        if(position < 0 || position >= books.Count)
        {
            Console.WriteLine("Nhap khong hop le");
            return false;
        }
        if (lib.Borrow(books[position], state, sl))
        {     
            if (!borrow.ContainsKey(books[position]))
                borrow[books[position]] = 0;
            borrow[books[position]] = state ? borrow[books[position]] + sl : borrow[books[position]] - sl;
            return true;
        }
        return false;
    }
    public string GetInfo()
    {
        return $"TK: {user_name}\nMK: {password}\nHo Ten: {name}\nEmail: {email}\nPhone number: {phone_number}";
    }
    public bool UpdateName(string name)
    {
        this.name = name;
        return true;
    }
    public bool UpdateEmai(string email)
    {
        this.email = email;
        return true;
    }
    public bool UpdatePhone(string phone)
    {
        this.phone_number = phone;
        return true;
    }
    public bool UpdatePass(string ole_pass, string new_pass)
    {
        if (CorrectPass(ole_pass))
        {
            this.password = new_pass;
            account[this.user_name] = new_pass;
            return true;
        }
        return false;
    }
    private bool CorrectPass(string pass)
    {
        return password == pass;
    }
    public static User Login(string username, string password)
    {
        if(account.ContainsKey(username))
        {
            if(account[username] != password)
            {
                Console.WriteLine("Mat khau khong dunng");
                return null;
            }                
            foreach (User user in _users)
            {
                if(username == user.user_name)
                {
                    Console.WriteLine($"Chao {user.user_name}");
                    return user;
                }                
            }
            return null;
        }
        else
        {
            Console.WriteLine("Chua co tai khoan");
            return null;
        }
            
    }
    
}


