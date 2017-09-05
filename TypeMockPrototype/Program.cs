using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using TalentPool.Entities;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

namespace TypeMockPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadLine();
        }
   }

    public class TestableClass
    {
        public void PrintDatabaseValue()
        {
            var bl = new BusinessLogicClass();
            Console.WriteLine(bl.DataLoader());
        }
    }

    public class BusinessLogicClass
    {
        public string DataLoader()
        {
            return DBLayeClass.DBCall();
        }
    }
    public class DBLayeClass
    {
        public static string DBCall()
        {
            Console.WriteLine("DB Call Made");
            return "DB Data";
        }
    }
}