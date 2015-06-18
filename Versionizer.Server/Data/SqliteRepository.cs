using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Versionizer.Shared;

namespace Versionizer.Server.Data
{
    public class SqliteRepository : IRepository
    {
        private string _connection = "Data Source=versionizer.db;";

        public SqliteRepository()
        {
            
        } 

        public List<AssemblyInfo> List()
        {
            List<AssemblyInfo> result = new List<AssemblyInfo>();

            DataSet ds = Execute("SELECT * FROM AssemblyInfo");

            if (ds != null && ds.Tables != null && ds.Tables.Count.Equals(1))
            {
                AssemblyInfo o = null;

                foreach (DataRow i in ds.Tables[0].Rows)
                {
                    o = new AssemblyInfo();
                    
                    o.ID = Guid.Parse(i["ID"].ToString());
                    o.Name = i["Name"].ToString();
                    o.Title = i["Title"].ToString();
                    o.Description = i["Description"].ToString();
                    o.Configuration = i["Configuration"].ToString();
                    o.Company = i["Company"].ToString();
                    o.Product = i["Product"].ToString();
                    o.Copyright = i["Copyright"].ToString();
                    o.Trademark = i["Trademark"].ToString();
                    o.Culture = i["Culture"].ToString();
                    o.Version = i["Version"].ToString();
                    o.FileVersion = i["FileVersion"].ToString();
                    o.ComVisibility = bool.Parse(i["ComVisibility"].ToString());

                    result.Add(o);
                }
            }

            return result;
        }

        public AssemblyInfo Get(Guid id)
        {
            AssemblyInfo result = new AssemblyInfo();

            DataSet ds = Execute(string.Format("SELECT * FROM AssemblyInfo WHERE ID = '{0}'", id.ToString()));

            if (ds != null && ds.Tables != null && ds.Tables.Count.Equals(1) && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count.Equals(1))
            {
                foreach (DataRow i in ds.Tables[0].Rows)
                {
                    result.ID = Guid.Parse(i["ID"].ToString());
                    result.Name = i["Name"].ToString();
                    result.Title = i["Title"].ToString();
                    result.Description = i["Description"].ToString();
                    result.Configuration = i["Configuration"].ToString();
                    result.Company = i["Company"].ToString();
                    result.Product = i["Product"].ToString();
                    result.Copyright = i["Copyright"].ToString();
                    result.Trademark = i["Trademark"].ToString();
                    result.Culture = i["Culture"].ToString();
                    result.Version = i["Version"].ToString();
                    result.FileVersion = i["FileVersion"].ToString();
                    result.ComVisibility = bool.Parse(i["ComVisibility"].ToString());
                }
            }

            return result;
        }

        public void Create(AssemblyInfo o)
        {
            ExecuteNonQuery(string.Format("INSERT INTO AssemblyInfo(ID, Name, Title, Description, Configuration, Company, Product, Copyright, Trademark, Culture, Version, FileVersion, ComVisibility) VALUES('{0}', {1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}'",
                o.ID.ToString(), o.Name, o.Title, o.Description, o.Configuration, o.Company, o.Product, o.Copyright, o.Trademark, o.Culture, o.Version, o.FileVersion, o.ComVisibility));
        }

        public void Update(AssemblyInfo o)
        {
            ExecuteNonQuery(string.Format("UPDATE AssemblyInfo SET Name = '{0}', Title = '{1}', Description = '{2}', Configuration = '{3}', Company = '{4}', Product = '{5}', Copyright = '{6}', Trademark = '{7}', Culture = '{8}', Version = '{9}', FileVersion = '{10}', ComVisibility = '{11}' WHERE ID = '{12}'", 
                o.Name, o.Title, o.Description, o.Configuration, o.Company, o.Product, o.Copyright, o.Trademark, o.Culture, o.Version, o.FileVersion, o.ComVisibility, o.ID.ToString()));
        }

        public void Delete(Guid id)
        {
            ExecuteNonQuery(string.Format("DELETE FROM AssemblyInfo WHERE ID = '{0}'", id.ToString()));
        }

        private void ExecuteNonQuery(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connection))
            {
                connection.Open();
                
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                
                connection.Close();
            }
        }

        private DataSet Execute(string query)
        {
            DataSet result = new DataSet();

            using (SQLiteConnection connection = new SQLiteConnection(_connection))
            {
                connection.Open();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                adapter.Fill(result);

                connection.Close();
            }

            return result;
        }
    }
}