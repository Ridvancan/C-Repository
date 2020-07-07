using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesign
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Before2020");
        }
    }
    class After2020CreditCalculator:CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("After2020");
        }

    }

    class CustomerManager
    {
        public CreditCalculatorBase _creditCalculatorBase { get; set; }
         
        public void SaveCredit()
        {
            _creditCalculatorBase.Calculate();
            Console.WriteLine("Buisness Codes.");

        }
    }
}
