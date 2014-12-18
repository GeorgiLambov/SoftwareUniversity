using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Computer
{
    private string name;
    private List<Component> components = new List<Component>();
   // private decimal price;

    public string Name
    {
        get { return this.name; }
        set
        {
            Validation.CheckForNullOrEmptyString(value, "name");
            this.name = value;
        }
    }

    public decimal Price
    {
        get { return this.Components.Sum(a => a.Price); }
    }

    public List<Component> Components
    {
        get { return this.components; }
        set
        {
            if (null == value) throw new ArgumentNullException("Computer components can not be null!");
            this.components = value;
        }

    }


    public Computer(string name)
    {
        this.Name = name;
        this.Components = new List<Component>();
    }
    public Computer(string name, List<Component> components)
        : this(name)
    {
        this.Components = components;
    }


    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendFormat("Name: {0}\nTotal computer price: {1:c}\n", this.Name, this.Price);

        foreach (Component component in this.Components)
        {
            result.AppendLine(component.ToString());
        }
        return result.ToString();
    }
}
