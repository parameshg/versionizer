using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;

namespace Versionizer.Shared
{
    public class Api : IApi
    {
        private IApi _api;

        public Api()
        {
            FindResponse search = null;

            using (DiscoveryClient discovery = new DiscoveryClient(new UdpDiscoveryEndpoint()))
            {
                FindCriteria filter = new FindCriteria(typeof(IApi));

                filter.MaxResults = 1;

                search = discovery.Find(filter);
            }

            if (search != null)
            {
                if (search.Endpoints != null)
                {
                    if (search.Endpoints.Count.Equals(1))
                    {
                        ChannelFactory<IApi> factory = new ChannelFactory<IApi>(new NetTcpBinding(), search.Endpoints[0].Address);

                        _api = factory.CreateChannel();
                    }
                }
            }
        }

        public List<AssemblyInfo> List()
        {
            List<AssemblyInfo> result = new List<AssemblyInfo>();
            
            if (_api != null)
                result = _api.List();

            return result;
        }

        public AssemblyInfo Get(Guid id)
        {
            AssemblyInfo result = new AssemblyInfo();

            if (_api != null)
                result = _api.Get(id);

            return result;
        }

        public void Create(AssemblyInfo o)
        {
            if (_api != null)
                _api.Create(o);
        }

        public void Update(AssemblyInfo o)
        {
            if (_api != null)
                _api.Update(o);
        }

        public void Delete(Guid id)
        {
            if (_api != null)
                _api.Delete(id);
        }

        public void Close()
        {
            if (_api != null)
                ((IChannel)_api).Close();
        }
    }
}