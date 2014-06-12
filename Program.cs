using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Versionizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                #region Variables

                string filename         = string.Empty;
                string title            = string.Empty;
                string description      = string.Empty;
                string configuration    = string.Empty;
                string company          = string.Empty;
                string product          = string.Empty;
                string copyright        = string.Empty;
                string trademark        = string.Empty;
                string culture          = string.Empty;
                string version          = string.Empty;
                string guid             = string.Empty;
                string com              = string.Empty;

                #endregion

                if (args.Length % 2 == 0)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i].StartsWith("-") || args[i].StartsWith("/"))
                        {
                            args[i] = args[i].Remove(0, 1);

                            #region Read Args

                            if (args[i].Equals("source"))
                            {
                                filename = args[++i];
                                continue;
                            }

                            if (args[i].Equals("title"))
                            {
                                title = args[++i];
                                continue;
                            }

                            if (args[i].Equals("description"))
                            {
                                description = args[++i];
                                continue;
                            }

                            if (args[i].Equals("configuration"))
                            {
                                configuration = args[++i];
                                continue;
                            }

                            if (args[i].Equals("company"))
                            {
                                company = args[++i];
                                continue;
                            }

                            if (args[i].Equals("product"))
                            {
                                product = args[++i];
                                continue;
                            }

                            if (args[i].Equals("copyright"))
                            {
                                copyright = args[++i];
                                continue;
                            }

                            if (args[i].Equals("trademark"))
                            {
                                trademark = args[++i];
                                continue;
                            }

                            if (args[i].Equals("culture"))
                            {
                                culture = args[++i];
                                continue;
                            }

                            if (args[i].Equals("version"))
                            {
                                version = args[++i];
                                continue;
                            }

                            if (args[i].Equals("com"))
                            {
                                com = args[++i];
                                continue;
                            }

                            if (args[i].Equals("guid"))
                            {
                                guid = args[++i];
                                continue;
                            }

                            #endregion
                        }
                    }
                
                    string text = string.Empty;

                    using (StreamReader reader = new StreamReader(filename))
                        text = reader.ReadToEnd();

                    #region Regular Expressions

                    // AssemblyTitle

                    if (!string.IsNullOrEmpty(title))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: AssemblyTitle([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                            text = text.Replace(i.Value, string.Format("[assembly: AssemblyTitle(\"{0}\")]", title));
                    }

                    // AssemblyDescription

                    if (!string.IsNullOrEmpty(description))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: AssemblyDescription([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                            text = text.Replace(i.Value, string.Format("[assembly: AssemblyDescription(\"{0}\")]", description));
                    }

                    // AssemblyConfiguration

                    if (!string.IsNullOrEmpty(configuration))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: AssemblyConfiguration([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                            text = text.Replace(i.Value, string.Format("[assembly: AssemblyConfiguration(\"{0}\")]", configuration));
                    }

                    // AssemblyCompany

                    if (!string.IsNullOrEmpty(company))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: AssemblyCompany([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                            text = text.Replace(i.Value, string.Format("[assembly: AssemblyCompany(\"{0}\")]", company));
                    }

                    // AssemblyProduct

                    if (!string.IsNullOrEmpty(product))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: AssemblyProduct([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                            text = text.Replace(i.Value, string.Format("[assembly: AssemblyProduct(\"{0}\")]", product));
                    }

                    // AssemblyCopyright

                    if (!string.IsNullOrEmpty(copyright))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: AssemblyCopyright([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                            text = text.Replace(i.Value, string.Format("[assembly: AssemblyCopyright(\"{0}\")]", copyright));
                    }

                    // AssemblyTrademark

                    if (!string.IsNullOrEmpty(trademark))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: AssemblyTrademark([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                            text = text.Replace(i.Value, string.Format("[assembly: AssemblyTrademark(\"{0}\")]", trademark));
                    }

                    // AssemblyCulture

                    if (!string.IsNullOrEmpty(culture))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: AssemblyCulture([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                            text = text.Replace(i.Value, string.Format("[assembly: AssemblyCulture(\"{0}\")]", culture));
                    }

                    // AssemblyVersion

                    if (!string.IsNullOrEmpty(version))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: AssemblyVersion([(])\"[0-9]*.[0-9]*.[0-9]*.[0-9]*\"([)]])", RegexOptions.IgnoreCase))
                        {
                            foreach (Match x in Regex.Matches(i.Value, "([0-9]*)([.])([0-9]*)([.])([0-9]*)([.])([0-9]*)", RegexOptions.IgnoreCase))
                                text = text.Replace(i.Value, string.Format("[assembly: AssemblyVersion(\"{0}\")]", UpdateVersion(x.Value, version)));
                        }
                    }

                    // AssemblyFileVersion

                    if (!string.IsNullOrEmpty(version))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: AssemblyFileVersion([(])\"[0-9]*.[0-9]*.[0-9]*.[0-9]*\"([)]])", RegexOptions.IgnoreCase))
                        {
                            foreach (Match x in Regex.Matches(i.Value, "([0-9]*)([.])([0-9]*)([.])([0-9]*)([.])([0-9]*)", RegexOptions.IgnoreCase))
                                text = text.Replace(i.Value, string.Format("[assembly: AssemblyFileVersion(\"{0}\")]", UpdateVersion(x.Value, version)));
                        }
                    }

                    // ComVisible

                    if (!string.IsNullOrEmpty(com))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: ComVisible([(])\"[a-zA-Z]*\"([)]])", RegexOptions.IgnoreCase))
                            text = text.Replace(i.Value, string.Format("[assembly: ComVisible(\"{0}\")]", com));
                    }

                    // Guid

                    if (!string.IsNullOrEmpty(guid))
                    {
                        foreach (Match i in Regex.Matches(text, "([[])assembly: Guid([(])\"^(\\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\\}{0,1})$\"([)]])", RegexOptions.IgnoreCase))
                            text = text.Replace(i.Value, string.Format("[assembly: Guid(\"{0}\")]", guid));
                    }

                    #endregion

                    using (StreamWriter writer = new StreamWriter(filename))
                        writer.Write(text);
                }
                else
                    DisplayHelp();
            }
            catch(Exception e)
            {
                Console.WriteLine(string.Empty);

                Console.WriteLine(e.Message);

                DisplayHelp();
            }
        }

        private static void DisplayHelp()
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

        private static string UpdateVersion(string version, string pattern)
        {
            string result = string.Empty;

            try
            {
                string[] param = version.Split('.');

                int major = int.Parse(param[0]);
                int minor = int.Parse(param[1]);
                int build = int.Parse(param[2]);
                int revision = int.Parse(param[3]);

                string[] args = pattern.Split('.');

                if (!args[0].Equals("*"))
                {
                    if (args[0].Equals("+"))
                        major++;
                    else if (args[0].Equals("-"))
                        major--;
                    else
                        major = int.Parse(args[0]);
                }

                if (!args[1].Equals("*"))
                {
                    if (args[1].Equals("+"))
                        minor++;
                    else if (args[1].Equals("-"))
                        minor--;
                    else
                        minor = int.Parse(args[1]);
                }

                if (!args[2].Equals("*"))
                {
                    if (args[2].Equals("+"))
                        build++;
                    else if (args[2].Equals("-"))
                        build--;
                    else if (args[2].Equals("h"))
                        build = int.Parse(DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString());
                    else if (args[2].Equals("d"))
                        build = int.Parse(DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString());
                    else
                        build = int.Parse(args[2]);
                }

                if (!args[3].Equals("*"))
                {
                    if (args[3].Equals("+"))
                        revision++;
                    else if (args[3].Equals("-"))
                        revision--;
                    else if (args[3].Equals("h"))
                        revision = int.Parse(DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString());
                    else if (args[3].Equals("d"))
                        revision = int.Parse(DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString());
                    else
                        revision = int.Parse(args[3]);
                }

                result = string.Format("{0}.{1}.{2}.{3}", major.ToString(), minor.ToString(), build.ToString(), revision.ToString());
            }
            catch
            {
            }

            return result;
        }
    }
}