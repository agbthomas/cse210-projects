using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Othertown", "NY", "Canada");

        Customer customer1 = new Customer("Alice", address1);
        Customer customer2 = new Customer("Bob", address2);

        Product product1 = new Product("Widget", "W123", 10.99, 2);
        Product product2 = new Product("Gadget", "G456", 7.99, 3);

        List<Product> order1Products = new List<Product> { product1, product2 };
        Order order1 = new Order(order1Products, customer1);

        List<Product> order2Products = new List<Product> { product1 };
        Order order2 = new Order(order2Products, customer2);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalPrice());

        Console.WriteLine();

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalPrice());

        // Additional orders
        List<Product> order3Products = new List<Product> { product2 };
        Order order3 = new Order(order3Products, customer1);

        List<Product> order4Products = new List<Product> { product1, product2 };
        Order order4 = new Order(order4Products, customer2);

        Console.WriteLine();

        Console.WriteLine("Order 3:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order3.GetTotalPrice());

        Console.WriteLine();

        Console.WriteLine("Order 4:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order4.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order4.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order4.GetTotalPrice());
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }
}

class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFormattedAddress()
    {
        return $"{streetAddress}, {city}, {state}, {country}";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;
        foreach (Product product in products)
        {
            totalPrice += product.GetTotalCost();
        }
        if (customer.GetAddress().IsInUSA())
        {
            totalPrice += 5; // USA shipping cost
        }
        else
        {
            totalPrice += 35; // International shipping cost
        }
        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in products)
        {
            label += $"Name: {product.GetName()}, Product ID: {product.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Customer Name: {customer.GetName()}, Address: {customer.GetAddress().GetFormattedAddress()}";
    }
}