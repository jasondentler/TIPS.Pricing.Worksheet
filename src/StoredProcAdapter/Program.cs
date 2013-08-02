using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace StoredProcAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var columnDefinitions = GetColumnDefinitions().ToList();
            GenerateClassDefinition(columnDefinitions);
            GetHibernateMapping(columnDefinitions);
        }

        private static IEnumerable<Tuple<Type, string>> GetColumnDefinitions()
        {
            var connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("COM_OptionPrerequisites_sel", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("SaleId", SqlDbType.BigInt) { Value = (long)210162 });
                cmd.Parameters.Add(new SqlParameter("CommunityId", SqlDbType.VarChar, 8) { Value = "18340000" });
                //cmd.Parameters.Add(new SqlParameter("JobNumber", SqlDbType.VarChar, 8) { Value = "18340039" });

                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    for (var idx = 0; idx < rdr.FieldCount; idx++)
                    {
                        var type = rdr.GetFieldType(idx);
                        var name = rdr.GetName(idx);
                        yield return Tuple.Create(type, name);
                    }
                }
            }
        }

        private static void GenerateClassDefinition(IEnumerable<Tuple<Type, string>> columnDefinitions)
        {
            foreach (var columnDefinition in columnDefinitions)
            {
                string typeString;
                switch (columnDefinition.Item1.ToString())
                {
                    case "System.String":
                        typeString = "string";
                        break;
                    case "System.Decimal":
                        typeString = "decimal";
                        break;
                    case "System.Boolean":
                        typeString = "bool";
                        break;
                    case "System.Int32":
                        typeString = "int";
                        break;
                    case "System.Int64":
                        typeString = "long";
                        break;
                    case "System.DateTime":
                        typeString = "DateTime";
                        break;
                    default:
                        typeString = columnDefinition.Item1.ToString();
                        break;
                }

                if (!columnDefinition.Item1.IsClass)
                    typeString += "?";

                Debug.WriteLine("public virtual {0} {1} {{ get; set; }}",
                                new object[] {typeString, columnDefinition.Item2});
            }
        }

        private static void GetHibernateMapping(IEnumerable<Tuple<Type, string>> columnDefinitions)
        {
            foreach (var columnDefinition in columnDefinitions)
            {
                Debug.WriteLine("<property name=\"{0}\" />", new object[] {columnDefinition.Item2});
            }
        }


    }
}
