namespace Company.Data
{
    public abstract class RegularEmployee : Employee, IRegularEmployee
    {
        public RegularEmployee(string fname, string lname, string id, Department department, decimal salary)
            : base(fname, lname, id, department, salary)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
