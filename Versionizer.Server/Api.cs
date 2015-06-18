using System;
using System.Collections.Generic;
using Versionizer.Shared;
using Versionizer.Server.Data;

namespace Versionizer.Server
{
    public class Api : IApi
    {
        private IRepository _repository;

        public Api()
        {
            _repository = new XmlRepository();
        }

        public List<AssemblyInfo> List()
        {
            return _repository.List();
        }

        public AssemblyInfo Get(Guid id)
        {
            return _repository.Get(id);
        }

        public void Create(AssemblyInfo o)
        {
            _repository.Create(o);
        }

        public void Update(AssemblyInfo o)
        {
            _repository.Update(o);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}
