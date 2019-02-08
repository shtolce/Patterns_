using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.State
{
    public abstract class State
    {
        public abstract void Handle(Classes.State.Context context);
    }
    public class StateA : State
    {
        public override void Handle(Classes.State.Context context)
        {
            context.state = new StateB();
        }
    }

    public class StateB : State
    {
        public override void Handle(Classes.State.Context context)
        {
            context.state = new StateA();
        }
    }


    public class Context
    {
        public State state;
        public Context(State state)
        {
            this.state = state;
        }

        public void Request()
        {
            state.Handle(this);
        }



    }




}
