using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Versionizer.Shared;
using Versionizer.Server.Data;
using System.ServiceModel.Discovery;
using System.ServiceModel.Channels;
using Topshelf;

namespace Versionizer.Server
{
    public class Host : ServiceControl
    {
        private ServiceHost _host;

        private int Port
        {
            get
            {
                return 8080;
            }
        }

        public bool Start(HostControl host)
        {
            bool result = false;

            try
            {
                Uri url = new Uri(string.Format("http://localhost:{0}/versionizer", Port));

                _host = new ServiceHost(typeof(Api), url);

                _host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });

                _host.Description.Behaviors.Add(new ServiceDiscoveryBehavior());

                _host.AddServiceEndpoint(typeof(IApi), new BasicHttpBinding(), string.Empty);

                _host.AddServiceEndpoint(new UdpDiscoveryEndpoint());

                EndpointDiscoveryBehavior o = new EndpointDiscoveryBehavior() { Enabled = true };

                o.Scopes.Add(new Uri("http://versionizer/"));

                _host.Description.Endpoints[0].Behaviors.Add(o);

                _host.Open();

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public bool Stop(HostControl host)
        {
            bool result = false;

            try
            {
                _host.Close();

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}