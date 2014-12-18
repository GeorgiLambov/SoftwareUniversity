using System.Collections.Generic;

namespace Company.Data
{
    using System.Collections;
    public interface ISalesEmployee : IRegularEmployee
    {
        IList<ISale> Sales { get; set; }
    }
}
