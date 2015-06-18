using System;
using System.Collections.Generic;
using Versionizer.Shared;
using System.IO;

namespace Versionizer.Server.Data
{
    public class XmlRepository : IRepository
    {
        public List<AssemblyInfo> Items { get; set; }

        public XmlRepository()
        {
            Load();
        }

        public List<AssemblyInfo> List()
        {
            return Items;
        }

        public AssemblyInfo Get(Guid id)
        {
            AssemblyInfo result = null;

            foreach (AssemblyInfo i in Items)
            {
                if (i.ID.Equals(id))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public void Create(AssemblyInfo o)
        {
            if (Get(o.ID) == null)
            {
                Items.Add(o);
                Save();
            }
        }

        public void Update(AssemblyInfo o)
        {
            if (Get(o.ID) == null)
            {
                Delete(o.ID);
                Items.Add(o);
                Save();
            }
        }

        public void Delete(Guid id)
        {
            foreach (AssemblyInfo i in Items)
            {
                if (i.ID.Equals(id))
                {
                    Items.Remove(i);
                    Save();
                }
            }
        }

        private void Load()
        {
            string xml = string.Empty;

            using (StreamReader reader = new StreamReader("data.xml"))
                xml = reader.ReadToEnd();

            XmlRepository temp = Serializer<XmlRepository>.Current.Deserialize(xml);

            if (temp != null)
                Items = temp.Items;
        }

        private void Save()
        {
            using (StreamWriter writer = new StreamWriter("data.xml"))
            {
                writer.Write(Serializer<XmlRepository>.Current.Serialize(this));
                writer.Flush();
            }
        }
    }
}