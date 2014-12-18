using System;
public class Battery
{
    private string description;
    private double life;
    public Battery(string description)
    {
        this.Description = description;
    }
    public Battery(string description, double life)
        : this(description)
    {
        this.Life = life;
    }
    public string Description
    {
        get { return this.description; }
        set
        {
            if (value != null && value.Length < 1) throw new ArgumentException("Invalid battery name!!!");
            this.description = value;
        }
    }
    public double Life
    {
        get { return this.life; }
        set
        {
            if (value < 0) throw new ArgumentException("Battery hours can not be negative!!!");
            this.life = value;
        }
    }
    public override string ToString()
    {
        string result = "";
        if (this.Description != null)
        {
            result += "Battery: " + this.Description;
        }
        if (this.Life > 0)
        {
            result += ", Battery life: " + this.Life + " hours";
        }
        return result;
    }
}

