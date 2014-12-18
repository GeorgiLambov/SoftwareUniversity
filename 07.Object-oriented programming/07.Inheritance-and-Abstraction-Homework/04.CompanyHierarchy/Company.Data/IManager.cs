
namespace Company.Data
{
    using System.Collections.Generic;
    public interface IManager
    {
        IList<Employee> Employees { get; set; }
    }
}
