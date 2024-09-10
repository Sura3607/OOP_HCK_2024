using System.Collections.Generic;

public class Library
{
    private List<Book> books = new List<Book>();
    private Dictionary<User,int> user_borrows = new Dictionary<User, int>();
    public Library()
    {
        this.Books = books;
        this.User_borrows = user_borrows;
    }
    public void addBook(Book book)
    {
        foreach(Book b in books)
        {
            if(b == book)
            {
                b.UpdateQuanntiy(book.Quantity);
                return;
            }
        }
        books.Add(book);
    }
    public List<Book> find(string keyword)
    {
        List<Book> result = new List<Book>();
        foreach (Book b in books)
            if (b.find(keyword))
                result.Add(b);
        return result;
    }
    public bool Borrow(User user,Book book, bool state = true, byte sl = 1)
    {
        if (state)
        {
            if (!user_borrows.ContainsKey(user))
                user_borrows[user] = 1;
            else
                user_borrows[user]++;
            return book.UpdateQuanntiy(sl);
        }
        user_borrows[user]--;
        if(user_borrows[user] <= 0)
            user_borrows.Remove(user);
        return book.UpdateQuanntiy(sl,false);
    }
    public List<User> GetUserBarrowed()
    {
        return new List<User>(user_borrows.Keys);
    }
    public List<Book> Books { get => books; set => books = value; }
    public Dictionary<User,int> User_borrows { get => user_borrows; set => user_borrows = value; }
}