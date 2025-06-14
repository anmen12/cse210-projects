class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(string name, string id, double price, int quantity)
    {
        _products.Add(new Product(name, id, price, quantity));
    }
    public double GetTotalCost()
    {
        double totalPrice = 0;
        foreach (Product product in _products)
        {
            totalPrice += product.GetTotalPrice();
        }
        if (_customer.IsUSA())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }
        return totalPrice;
    }
    public List<string> GetPackingLabel()
    {
        List<string> packingLabel = new List<string>();
        foreach (Product product in _products)
        {
            packingLabel.Add($"{product.GetName()} - {product.GetId()}");
        }
        return packingLabel;
    }
    public string GetShippingLabel()
    {
        return $"{_customer.GetName()} - {_customer.GetAddress().GetDisplayText()}";
    }
}