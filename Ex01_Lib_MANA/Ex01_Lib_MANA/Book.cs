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
        return new Book(id, title, authorname, publisheddate,
            publisher, numofpages, price, quantity);
    }

    public bool find(string keyword)
    {
        return title.IndexOf(keyword) >= 0 ||
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
    public string getId()
    {
        return id;
    }
    public bool BorrowBook(byte sl = 1)
    {
        if(quantity > 0)
        {
            quantity -= sl;
            return true;
        }
        return false;
    }
    public bool ReturnBook(byte sl = 1)
    {
        if (sl > 0)
        {
            quantity += sl;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"Id: {id}\nTitle: {title}\nAuthorname: {authorname}\nPublisheddate: {publisheddate}\nPublisher: {publisher}\nNumofpages: {numofpages}\nPrice: {price}\nQuantity: {quantity}";
    }
}