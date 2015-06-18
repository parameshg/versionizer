using System;

namespace Versionizer.Server
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Host host = new Host();

            try
            {
                host.Start();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                host.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }
        }
    }
}