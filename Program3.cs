using System.Text;
interface IPrice
{
    double GetPrice();
}

interface IGaranty
{
    int GetGaranty();
}

class Phone : IPrice, IGaranty
{
    private double price;
    public double Price { get; set; }
    private int garanty;
    public int Garanty { get; set; }
    public Phone(double price, int garanty)
    {
        Price = price;
        Garanty = garanty;
    }

    public double GetPrice()
    {
        return Price;
    }
    public int GetGaranty()
    {
        return Garanty;
    }
}

class Laptop : IPrice
{
    private double price;
    public double Price { get; set; }

    public Laptop(double price)
    {
        Price = price;
    }
    public double GetPrice()
    {
        return Price;
    }

}

internal class Program
{
    public static void Main(string[] args)
    {
        IPrice[] products = { new Phone(23000, 12), new Laptop(60000), new Phone(120000, 24) };
        double totalPrice = 0;
        for (int i = 0; i < products.Length; i++)
        {
            totalPrice += products[i].GetPrice();
            if (products[i] is IGaranty GarantyProduct)
            {
                Console.WriteLine($"Телефон с гарантией {GarantyProduct.GetGaranty()} месяцев");
            }
        }
        Console.WriteLine($"Общая стоимость всех товаров: {totalPrice}");
        Console.WriteLine($"Количество товаров: {products.Length}");
    }
}