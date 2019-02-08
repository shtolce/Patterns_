using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.Command
{
    public abstract class Command
    {
        public abstract void execute();
        public abstract void undo();
    }
    public class ConcreteCommand : Command
    {
        Receiver receiver;
        public ConcreteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public override void execute()
        {
            receiver.Operation();

        }

        public override void undo()
        {
            throw new NotImplementedException();
        }
    }

    public class Receiver
    {
        public void Operation()
        {
            Console.WriteLine("Операция1");
        }
    }

    public class Invoker
    {
        Command command;
        public void SetCommand(Command c)
        {
            command = c;
        }
        public void Run()
        {
            command.execute();
        }
        public void Cancel()
        {
            command.undo();
        }

    }




}
