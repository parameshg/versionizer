using System;

namespace Versionizer.Server
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Host host = new Host();

            try
            {
                host.Start();
                Console.WriteLine("Listening...");
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