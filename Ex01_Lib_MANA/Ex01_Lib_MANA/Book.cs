/*mã sách, tên sách, tên tác giả, năm xuất bản,
 nhà xuất bản, số trang, giá và số lượng.*/
using System;
using System.Globalization;

public class Book : ICloneable
{
    private string id;
    private string title;
    private string authorname;
    private DateTime publisheddate;
    private string publisher;
    private int numofpages;
    private uint price;
    private byte quantity;
    public string Id { get => id; }

    public byte Quantity { get => quantity; }
    public string Title { get => title; }

    public Book(string id, string title, string authorname,
        DateTime publisheddate, string publisher,
        int numofpages, uint price, byte quantity)
    {
        this.id = id;
        this.title = title;
        this.authorname = authorname;
        this.publisheddate = publisheddate;
        this.publisher = publisher;
        this.numofpages = numofpages;
        this.price = price;
        this.quantity = quantity;
    }

    public object Clone()
    {
        return new Book(id, Title, authorname, publisheddate,
            publisher, numofpages, price, Quantity);
    }

    public bool find(string keyword)
    {
        return Title.IndexOf(keyword) >= 0 ||
            authorname.IndexOf(keyword) >= 0;
    }
    public void update(string title, string authorname,
          DateTime publisheddate, string publisher,
          int numofpages, uint price, byte quantity)
    {
        this.title = title;
        this.authorname = authorname;
        this.publisheddate = publisheddate;
        this.publisher = publisher;
        this.numofpages = numofpages;
        this.price = price;
        this.quantity = quantity;
    }
    public void UpdatePrice(uint price)
    {
        this.price = price;
    }
    public bool UpdateQuanntiy(byte sl = 1, bool state = true )
    {
        if (state)
        {
            if (sl > 0)
            {
                quantity += sl;
                return true;
            }
            return false;
        }
        else
        {
            if (quantity > 0)
            {
                quantity -= sl;
                return true;
            }
            return false;       
        }   
    }

    public override string ToString()
    {
        return $"Id: {id}\nTitle: {Title}\nAuthorname: {authorname}\nPublisheddate: {publisheddate}\nPublisher: {publisher}\nNumofpages: {numofpages}\nPrice: {price}\nQuantity: {Quantity}";
    }

    public static bool operator ==(Book book1, Book book2)
    {
        return book1.id == book2.id &&
               book1.Title == book2.Title &&
               book1.authorname == book2.authorname &&
               book1.publisheddate == book2.publisheddate &&
               book1.publisher == book2.publisher &&
               book1.numofpages == book2.numofpages &&
               book1.price == book2.price;
    }
    public static bool operator !=(Book book1, Book book2)
    {
        return !(book1 == book2);
    }
}