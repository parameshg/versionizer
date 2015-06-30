using System;
using System.Collections.Generic;
using NDesk.Options;

namespace Versionizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                OptionSet o = new OptionSet();

                Updater x = new Updater();

                o.Add<string>("source=", "Path to AssemblyInfo.cs", i => { x.Filename = i; });
                o.Add<string>("title=", "AssemblyTitle", i => { x.Title = i; });
                o.Add<string>("description=", "AssemblyDescription", i => { x.Description = i; });
                o.Add<string>("configuration=", "AssemblyConfiguration", i => { x.Configuration = i; });
                o.Add<string>("company=", "AssemblyCompany", i => { x.Company = i; });
                o.Add<string>("product=", "AssemblyProduct", i => { x.Product = i; });
                o.Add<string>("copyright=", "AssemblyCopyright", i => { x.Copyright = i; });
                o.Add<string>("trademark=", "AssemblyTrademark", i => { x.Trademark = i; });
                o.Add<string>("culture=", "AssemblyCulture", i => { x.Culture = i; });
                o.Add<string>("version=", "AssemblyVersion", i => { x.Version = i; });
                o.Add<Guid>("id=", "AssemblyGuid", i => { x.ID = i; });
                o.Add<bool>("com=", "ComVisibility", i => { x.ComVisibility = i; });
                o.Add("!", "Disables fetching configuration settings from server", i => { x.Disabled = false; });
                o.Add("?", "Shows Usage Help", i => { Help(); });

                o.Parse(args);

                x.Load();

                x.Execute();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                Help();
            }
        }

        private static void Help()
        {
            Console.WriteLine(string.Empty);

            Console.WriteLine("versionizer.exe /source <full path to AssemblyInfo.cs> [/options: /title /description /configuration /company /product /copyright /trademark /culture /version /guid /com]");
            Console.WriteLine("version [x|*|+|-].[x|*|+|-].[x|*|+|-|h|d].[x|*|+|-|h|d]");
            Console.WriteLine("version x Replaces version number to x");
            Console.WriteLine("version * Leaves version number unchanged");
            Console.WriteLine("version + Increments version number by one");
            Console.WriteLine("version - Decrements version number by one");
            Console.WriteLine("version h Replaces version number with current hour and minute");
            Console.WriteLine("version d Replaces version number with month and day");
            Console.WriteLine("guid [xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx]");
            Console.WriteLine("com [true|false]");

            Console.WriteLine(string.Empty);
        }
    }
}