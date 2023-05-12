using System;
using System.Collections.Generic;
using System.Text;
using Business_Layer.Interface;

namespace Business_Layer.Implemenation
{
    public class Factory : IFactory
    {
        private readonly IRepository _repo;

        public Factory(IRepository repo)
        {
            _repo = repo;
        }

        public IFacade CreateFacade()
        {
            return new Facade(_repo);
        }
    }
}
