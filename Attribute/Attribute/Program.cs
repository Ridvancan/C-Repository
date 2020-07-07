using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { id = 1, FirstName = "Rıdvan", LastName = "Kıran", age = 25 };
            CustormerDal csdal = new CustormerDal();
            csdal.Add(customer);
        }
        [ToTable("tblCustomers")]
        [ToTable("Customers")]
        class Customer
        {
            public int id { get; set; }
            [RequiredProperty]
            public string FirstName { get; set; }
            [RequiredProperty]
            public string LastName { get; set; }
            [RequiredProperty]
            public int age { get; set; }
        }
        class CustormerDal
        {
            [Obsolete("Dont use Add,instead use AddNew Method")]
            public void Add(Customer customer)
            {
                Console.WriteLine("Added!");
            }

            public void AddNew(Customer customer)
            {

            }
        }
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
        class RequiredPropertyAttribute:Attribute
        {

        }
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        class ToTableAttribute:Attribute
        {
            private string _tableName;
            public  ToTableAttribute(string tableName)
            {
                _tableName = tableName;
            }
        }

        
        
        
    }
}
