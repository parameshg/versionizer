using System;
using System.Collections.Generic;
using Versionizer.Shared;

namespace Versionizer.Server.Data
{
    public interface IRepository
    {
        List<AssemblyInfo> List();

        AssemblyInfo Get(Guid id);

        void Create(AssemblyInfo o);

        void Update(AssemblyInfo o);

        void Delete(Guid id);
    }
}