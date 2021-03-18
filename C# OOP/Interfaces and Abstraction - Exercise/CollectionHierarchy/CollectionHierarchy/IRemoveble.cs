using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IRemoveble : IAddCollection
    {
        string Remove();
    }
}
