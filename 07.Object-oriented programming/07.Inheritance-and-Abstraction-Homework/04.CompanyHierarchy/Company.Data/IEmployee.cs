namespace Company.Data
{
    public interface IEmployee
    {
        decimal Salary { get; set; }

        Department Department { get; set; }

    }
}
