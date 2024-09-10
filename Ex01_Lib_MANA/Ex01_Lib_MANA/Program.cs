using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class Program
{
    private static User user;
    private static Library library;
    public static void PrintBooks(List<Book> bks)
    {
        foreach (Book book in bks)
        {            
            Console.WriteLine(book);
            Console.WriteLine("--------------------");         
        }    
    }
    public static void PrintUser(List<User> users)
    {
        foreach (User us in users)
        {
            Console.WriteLine(us);
            Console.WriteLine("--------------------");
        }
    }
    public static void AddBooks()
    {
        library.addBook(new Book("B01", "Lap trinh HDT",
        "Nguyen Van At", new DateTime(2023, 12, 20),
        "NXB DHQG HN", 240, 210000, 23));
        library.addBook(new Book("B02", "Ly thuyet do thi",
        "Nguyen Van Mau", new DateTime(2022, 10, 12),
        "NXB DHBK HN", 250, 230000, 25));
        library.addBook(new Book("B03", "Ky nang song",
        "Nguyen Thi Hong", new DateTime(2000, 4, 12),
        "NXB Tre", 250, 140000, 5));
        library.addBook(new Book("B04", "Huong dan nau an",
        "Dinh Hoang", new DateTime(2005, 12, 12),
        "NXB Phu Nu", 250, 200000, 7));
        library.addBook(new Book("B05", "Naruto",
        "Kishimoto Masashi", new DateTime(1999, 9, 1),
        "NXB Phu Nu", 50, 250000, 10));
        library.addBook(new Book("B01", "Lap trinh HDT",
        "Nguyen Van At", new DateTime(2023, 12, 20),
        "NXB DHQG HN", 240, 210000, 23));
    }
    public static void Main(string[] args)
    {
        Console.Clear();

        library = new Library();
        AddBooks();

        user = new User("Sura", "Nhut", "123");

        userMenu();

        Console.ReadLine();
    }
    public static void userMenu()
    {
        Console.WriteLine("Bam phim bat ki de su dung");
        
        ConsoleKeyInfo key = Console.ReadKey(true);
        while (key.Key != ConsoleKey.Escape)
        {
            Console.Clear();
            Console.WriteLine("Login(Y)/Sign up(S)");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Y)
            {
                Console.Clear();
                if (Login())
                {
                    Console.Clear();
                    LibaryMenu(key);
                }
                else
                    Console.ReadLine();
                
            }
            else if (key.Key == ConsoleKey.S)
            {
                Console.Clear();
                SignUp();
                Console.ReadLine();
            }
      
        }
    }
    public static bool Login()
    {
        Console.WriteLine("Ten tai khoan:");
        string s = Console.ReadLine();
        Console.WriteLine("Mat khau:");
        string p = Console.ReadLine();
        user = User.Login(s, p);
        if (user != null) 
            return true;
        return false;
    }
    public static void SignUp()
    {
        Console.WriteLine("Ho ten");
        string name = Console.ReadLine();
        Console.WriteLine("Ten dang nhap:");
        string s = Console.ReadLine();
        Console.WriteLine("Mat khau:");
        string p = Console.ReadLine();
        user = new User(s, name, p);
        
    }
    public static void LibaryMenu(ConsoleKeyInfo key)
    {
        while (key.Key != ConsoleKey.Escape)
        {
            Console.WriteLine("1. Tim sach\n2. Muon sach\n3. Tra sach\n4. Them\nESC. Thoat");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Find();
                Console.ReadLine();
            }
            else if(key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Borrow();
                Console.ReadLine();
            }
            else if (key.Key == ConsoleKey.D3)
            {
                Console.Clear();
                ReturnBook();
                Console.ReadLine();
            }
            else if (key.Key == ConsoleKey.D4)
            {
                Console.Clear();
                More(key);               
            }
            Console.Clear();
        }
    }
    public static void Find()
    {
        Console.Write("Key Word: ");
        string s = Console.ReadLine();
        PrintBooks(user.Find(s, library));
    }
    public static void Borrow()
    {
        Console.Write("Key Word: ");
        string s = Console.ReadLine();
        List<Book> books = user.Find(s, library);

        Console.WriteLine("----------------------------------------");
        PrintBooks(books);
        Console.WriteLine("----------------------------------------");
        Console.Write("Nhap id sach muon muon: ");
        string id = Console.ReadLine();

        if (user.Borrow(id, books, library))
        {
            Console.WriteLine("Muon sach thanh cong");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Danh sach nhunng tai khoan dang muon sach");
            PrintUser(library.GetUserBarrowed());
        }

        else
            Console.WriteLine("Muon sach khong thanh cong");
    }
    public static void ReturnBook()
    {
        List<Book> books = user.GetBorrowed();
        Console.WriteLine("Sach ban da muon");
        Console.WriteLine("----------------------------------------");
        PrintBooks(books);
        Console.WriteLine("----------------------------------------");
        Console.Write("Nhap id sach muon tra: ");
        string id = Console.ReadLine();

        if (user.Borrow(id, books, library, false))
            Console.WriteLine("Tra sach thanh cong");
        else
            Console.WriteLine("Tra sach khong thanh cong");
    }
    public static void More(ConsoleKeyInfo key)
    {
        while (key.Key != ConsoleKey.Escape)
        {
            Console.Clear();
            Console.WriteLine("1. Thong tin ca nhan\n2. Sach da muon\nESC. Thoat");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                UserInfo(key);                
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                List<Book> books = user.GetBorrowed();
                Console.WriteLine("Sach ban da muon");
                Console.WriteLine("----------------------------------------");
                PrintBooks(books);
                Console.ReadLine();
            }
        }
        Console.Clear();
    }
    public static void UserInfo(ConsoleKeyInfo key)
    {
        Console.WriteLine(user);
        Console.WriteLine("---------------------");
        Console.WriteLine("1. Cap nhat thong tin\nPhim bat ki. Thoat");
        key = Console.ReadKey(true);
        if(key.Key == ConsoleKey.D1)
        {
            UpdateInfo(key);
        }
    }
    public static void UpdateInfo(ConsoleKeyInfo key)
    {
        while (key.Key != ConsoleKey.Escape)
        {
            Console.Clear();
            Console.WriteLine(user);
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Ho Ten\n2. Email\n3. Phone number\n4.Doi mat khau\n ESC. Thoat");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.D1)
            {
                Console.Write("Ho Ten moi: ");
                string s = Console.ReadLine();
                user.UpdateName(s);
            }
            else if(key.Key == ConsoleKey.D2)
            {
                Console.Write("Email: ");
                string s = Console.ReadLine();
                user.UpdateEmai(s);
            }
            else if (key.Key == ConsoleKey.D3)
            {
                Console.Write("Phone number: ");
                string s = Console.ReadLine();
                user.UpdatePhone(s);
            }
            else if (key.Key == ConsoleKey.D4)
            {
                Console.Write("Mat khau cu: ");
                string oldpass = Console.ReadLine();
                Console.Write("Mat khau moi: ");
                string newpass = Console.ReadLine();
                if(user.UpdatePass(oldpass, newpass))
                {
                    Console.WriteLine("Cap nhat mat khau thanh cong");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Xac minh that bai ko the doi mat khau");
                    Console.ReadLine();
                }            
            }
        }
    }
}

