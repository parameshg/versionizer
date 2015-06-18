using System;
using Topshelf;

namespace Versionizer.Server
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            HostFactory.Run(i =>
            {
                i.Service<Host>();
                i.SetServiceName("Versionizer");
                i.SetDisplayName("Versionizer");
            });
        }
    }
}