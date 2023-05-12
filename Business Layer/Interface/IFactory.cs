using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.Interface
{
    public interface IFactory
    {
        IFacade CreateFacade();
    }
}
