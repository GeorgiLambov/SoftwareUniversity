using System;
class Component
{
    private string name;
    private string details;
    private decimal price;
    public string Name
    {
        get { return this.name; }
        set
        {
            Validation.CheckForNullOrEmptyString(value, "name");
            this.name = value;
        }
    }
    public string Details
    {
        get { return this.details; }
        set
        {
            Validation.CheckForEmptyString(value, "name");
            this.details = value;
        }

    }
    public decimal Price
    {
        get { return this.price; }
        set
        {
            Validation.CheckForNegative(value, "price");
            this.price = value;

        }
    }
    public Component(string name, decimal price, string details = null)
    {
        this.Name = name;
        this.Price = price;
        this.Details = details;
    }
    public override string ToString()
    {
        string compToString = string.Format(this.Name);
        if (null != this.Details)
        {
            compToString += string.Format(": {0}", this.Details);
        }
        compToString += string.Format(", Price: {0:C}", this.Price);
        return compToString;
    }
}

