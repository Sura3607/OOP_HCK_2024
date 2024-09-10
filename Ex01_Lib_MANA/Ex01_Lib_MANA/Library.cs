using System.Collections.Generic;

public class Library
{
    private List<Book> books = new List<Book>();

    public Library()
    {
        this.Books = books;
    }
    public void addBook(Book book)
    {
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
    public bool Borrow(Book book, bool state = true, byte sl = 1)
    {
        if (state)        
            return book.BorrowBook(sl);       
        return book.ReturnBook(sl);
    }

    public List<Book> Books { get => books; set => books = value; }
}