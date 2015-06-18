using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Versionizer.Shared
{
    [ServiceContract]
    public interface IApi
    {
        [OperationContract]
        List<AssemblyInfo> List();

        [OperationContract]
        AssemblyInfo Get(Guid id);

        [OperationContract]
        void Create(AssemblyInfo o);

        [OperationContract]
        void Update(AssemblyInfo o);

        [OperationContract]
        void Delete(Guid id);
    }
}