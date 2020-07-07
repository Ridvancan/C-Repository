using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesign
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class CarBase
    {
        public abstract string Model { get; set; }
        public abstract string Make { get; set; }
        public abstract int HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Model { get; set; }
        public override string Make { get; set; }
        public override int HirePrice { get; set; }
    }
    class CommericalCar : CarBase
    {
        public override string Model { get; set; }
        public override string Make { get; set; }
        public override int HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
    
        }
        public override string Model { get ; set ; }
        public override string Make { get; set; }
        public override int HirePrice { get; set; }
    }
}
