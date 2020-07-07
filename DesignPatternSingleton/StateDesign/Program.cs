using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace StateDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            ModifiedState modified = new ModifiedState();
            modified.DoAction(context);
        }
    }

    interface IState
    {
        void DoAction(Context context);
    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Modified!");
        }
    }
    class DeleteState:IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Deleted!");
        }
    }
    class AddState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Added!");
        }
    }
    
    class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}
