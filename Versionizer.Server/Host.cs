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
                return new Random(DateTime.Now.Millisecond).Next(1025, 65535);
            }
        }

        public bool Start(HostControl host)
        {
            bool result = false;

            try
            {
                _host = new ServiceHost(typeof(Api));

                _host.AddServiceEndpoint(typeof(IApi), new NetTcpBinding(), new Uri(string.Format("net.tcp://localhost:{0}/versionizer", Port)));

                _host.AddServiceEndpoint(new UdpDiscoveryEndpoint());

                _host.Description.Behaviors.Add(new ServiceDiscoveryBehavior());

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