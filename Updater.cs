using System;
using System.IO;
using System.Text.RegularExpressions;
using Versionizer.Shared;

namespace Versionizer
{
    public class Updater
    {
        public Guid ID { get; set; }

        public string Title  { get; set; }
        
        public string Description  { get; set; }
        
        public string Configuration { get; set; }
        
        public string Company { get; set; }
        
        public string Product { get; set; }
        
        public string Copyright { get; set; }
        
        public string Trademark { get; set; }
        
        public string Culture { get; set; }
        
        public string Version { get; set; }

        public string FileVersion { get; set; }
        
        public bool ComVisibility { get; set; }

        public string Filename { get; set; }

        private string _text;

        private string Text
        {
            get
            {
                if (string.IsNullOrEmpty(_text))
                {
                    using (StreamReader reader = new StreamReader(Filename))
                        _text = reader.ReadToEnd();
                }

                return _text;
            }

            set { _text = value; }
        }

        public bool Disabled { get; set; }

        public Updater()
        {
            Filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Properties\AssemblyInfo.cs");
        }

        public void Load()
        {
            if (Disabled)
                return;

            if (File.Exists(Filename))
            {
                if (ID.Equals(Guid.Empty))
                {
                    foreach (Match i in Regex.Matches(Text, @"\b[A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12}\b", RegexOptions.IgnoreCase))
                        ID = Guid.Parse(i.Value);
                }

                if (!ID.Equals(Guid.Empty))
                {
                    AssemblyInfo o = new Api().Get(ID);

                    if (o != null)
                    {
                        Title = o.Name;
                        Description = o.Description;
                        Configuration = o.Configuration;
                        Company = o.Company;
                        Product = o.Product;
                        Copyright = o.Copyright;
                        Trademark = o.Trademark;
                        Culture = o.Culture;
                        Version = o.Version;
                        FileVersion = string.IsNullOrEmpty(o.FileVersion) ? o.Version : o.FileVersion;
                        ComVisibility = o.ComVisibility;
                    }
                }
            }
        }

        public void Execute()
        {
            if (File.Exists(Filename))
            {
                // AssemblyTitle

                if (!string.IsNullOrEmpty(Title))
                {
                    foreach (Match i in Regex.Matches(Text, "([[])assembly: AssemblyTitle([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                        Text = Text.Replace(i.Value, string.Format("[assembly: AssemblyTitle(\"{0}\")]", Title));
                }

                // AssemblyDescription

                if (!string.IsNullOrEmpty(Description))
                {
                    foreach (Match i in Regex.Matches(Text, "([[])assembly: AssemblyDescription([(])\":*;*,*.*\\d*\\w*\\s*\"([)]])", RegexOptions.IgnoreCase))
                        Text = Text.Replace(i.Value, string.Format("[assembly: AssemblyDescription(\"{0}\")]", Description));
                }

                // AssemblyConfiguration

                if (!string.IsNullOrEmpty(Configuration))
                {
                    foreach (Match i in Regex.Matches(Text, "([[])assembly: AssemblyConfiguration([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                        Text = Text.Replace(i.Value, string.Format("[assembly: AssemblyConfiguration(\"{0}\")]", Configuration));
                }

                // AssemblyCompany

                if (!string.IsNullOrEmpty(Company))
                {
                    foreach (Match i in Regex.Matches(Text, "([[])assembly: AssemblyCompany([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                        Text = Text.Replace(i.Value, string.Format("[assembly: AssemblyCompany(\"{0}\")]", Company));
                }

                // AssemblyProduct

                if (!string.IsNullOrEmpty(Product))
                {
                    foreach (Match i in Regex.Matches(Text, "([[])assembly: AssemblyProduct([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                        Text = Text.Replace(i.Value, string.Format("[assembly: AssemblyProduct(\"{0}\")]", Product));
                }

                // AssemblyCopyright

                if (!string.IsNullOrEmpty(Copyright))
                {
                    foreach (Match i in Regex.Matches(Text, "([[])assembly: AssemblyCopyright([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                        Text = Text.Replace(i.Value, string.Format("[assembly: AssemblyCopyright(\"{0}\")]", Copyright));
                }

                // AssemblyTrademark

                if (!string.IsNullOrEmpty(Trademark))
                {
                    foreach (Match i in Regex.Matches(Text, "([[])assembly: AssemblyTrademark([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                        Text = Text.Replace(i.Value, string.Format("[assembly: AssemblyTrademark(\"{0}\")]", Trademark));
                }

                // AssemblyCulture

                if (!string.IsNullOrEmpty(Culture))
                {
                    foreach (Match i in Regex.Matches(Text, "([[])assembly: AssemblyCulture([(])\"[0-9a-zA-Z ]*\"([)]])", RegexOptions.IgnoreCase))
                        Text = Text.Replace(i.Value, string.Format("[assembly: AssemblyCulture(\"{0}\")]", Culture));
                }

                // AssemblyVersion

                if (!string.IsNullOrEmpty(Version))
                {
                    foreach (Match i in Regex.Matches(Text, "([[])assembly: AssemblyVersion([(])\"[0-9]*.[0-9]*.[0-9]*.[0-9]*\"([)]])", RegexOptions.IgnoreCase))
                    {
                        foreach (Match x in Regex.Matches(i.Value, "([0-9]*)([.])([0-9]*)([.])([0-9]*)([.])([0-9]*)", RegexOptions.IgnoreCase))
                            Text = Text.Replace(i.Value, string.Format("[assembly: AssemblyVersion(\"{0}\")]", Generate(x.Value, Version)));
                    }
                }

                // AssemblyFileVersion

                if (!string.IsNullOrEmpty(Version))
                {
                    foreach (Match i in Regex.Matches(Text, "([[])assembly: AssemblyFileVersion([(])\"[0-9]*.[0-9]*.[0-9]*.[0-9]*\"([)]])", RegexOptions.IgnoreCase))
                    {
                        foreach (Match x in Regex.Matches(i.Value, "([0-9]*)([.])([0-9]*)([.])([0-9]*)([.])([0-9]*)", RegexOptions.IgnoreCase))
                            Text = Text.Replace(i.Value, string.Format("[assembly: AssemblyFileVersion(\"{0}\")]", Generate(x.Value, FileVersion)));
                    }
                }

                // ComVisible

                foreach (Match i in Regex.Matches(Text, "([[])assembly: ComVisible([(])\"[a-zA-Z]*\"([)]])", RegexOptions.IgnoreCase))
                    Text = Text.Replace(i.Value, string.Format("[assembly: ComVisible(\"{0}\")]", ComVisibility));

                // Guid

                foreach (Match i in Regex.Matches(Text, @"\b[A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12}\b", RegexOptions.IgnoreCase))
                    Text = Text.Replace(i.Value, ID.ToString());

                using (StreamWriter writer = new StreamWriter(Filename))
                    writer.Write(Text);
            }
        }

        private string Generate(string version, string pattern)
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
                result = string.Empty;
            }

            return result;
        }
    }
}