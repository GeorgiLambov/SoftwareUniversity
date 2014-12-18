

namespace Company.Data
{
    using System.Collections.Generic;
    public interface IDeveloper : IRegularEmployee
    {
        IList<Projects> Projects { get; set; }
    }
}
