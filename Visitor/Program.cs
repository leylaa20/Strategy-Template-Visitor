namespace Visitor;

interface ItemElement
{
    public int Accept(ShoppingCartVisitor visitor);
}

class Book : ItemElement
{
    private int _price;
    private string _isbnNumber;

    public Book(int cost, string isbn)
    {
        _price = cost;
        _isbnNumber = isbn;
    }

    public int GetPrice() => _price;
    public string GetIsbnNumber() => _isbnNumber;
    public int Accept(ShoppingCartVisitor visitor) => visitor.VisitBook(this);
}

class Fruit : ItemElement
{
    private int _priceKg;
    private int _weight;
    private string _name;

    public Fruit(int priceKg, int wt, string nm)
    {
        _priceKg = priceKg;
        _weight = wt;
        _name = nm;
    }

    public int GetPricePerKg() => _priceKg;
    public int GetWeight() => _weight;
    public string GetName() => _name;
    public int Accept(ShoppingCartVisitor visitor) => visitor.VisitFruit(this);
}

interface ShoppingCartVisitor
{
    int VisitBook(Book book);
    int VisitFruit(Fruit fruit);
}

class ShoppingCartVisitorImpl : ShoppingCartVisitor
{
    public int VisitBook(Book book)
    {
        int cost = 0;
        // qiymet 50$ dan boyukdurse 5% endirim edilir

        if (book.GetPrice() > 50)
            cost = book.GetPrice() - 5;

        else cost = book.GetPrice();

        Console.WriteLine("Book ISBN::" + book.GetIsbnNumber() + " cost =" + cost);
        return cost;
    }
    public int VisitFruit(Fruit fruit)
    {
        int cost = fruit.GetPricePerKg() * fruit.GetWeight();
        Console.WriteLine(fruit.GetName() + " cost = " + cost);
        return cost;
    }
}


class Program
{
    static void Main(string[] args)
    {
        ItemElement[] items = new ItemElement[]
        {
            new Book(20, "1234"),
            new Book(100, "5678"),
            new Fruit(10, 2, "Banana"),
            new Fruit(5, 5, "Apple")
        };

        int total = calculatePrice(items);
        Console.WriteLine("Total Cost = " + total);
    }

    private static int calculatePrice(ItemElement[] items)
    {
        ShoppingCartVisitor visitor = new ShoppingCartVisitorImpl();
        int sum = 0;

        foreach (ItemElement item in items)
            sum = sum + item.Accept(visitor);

        return sum;
    }
}