using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            //For Performance. 
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

}
