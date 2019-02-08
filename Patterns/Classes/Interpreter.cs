using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.Interpreter
{
    public class ContextI
    {
        Dictionary<string, object> variables;
        public ContextI()
        {
            variables = new Dictionary<string, object>();
        }

        public object GetVariable(string name)
        {
            return variables[name];
        }
        public void SetVariable(string name,object value)
        {
            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);
        }

    }
    public abstract class AbstractExpression
    {
        public abstract object Interpret(ContextI context);

    }
    public class TerminalExpression : AbstractExpression
    {
        string name;
        public TerminalExpression(string name)
        {
            this.name = name;
        }

        public override object Interpret(ContextI context)
        {
            return (int)context.GetVariable(this.name);
        }
    }
    public class NonterminalExpression : AbstractExpression
    {
        AbstractExpression expression1;
        AbstractExpression expression2;

        public NonterminalExpression(AbstractExpression expression1, AbstractExpression expression2)
        {
            this.expression1 = expression1;
            this.expression2 = expression2;
        }

        public override object Interpret(ContextI context)
        {
            return (int)this.expression1.Interpret(context) + (int)this.expression2.Interpret(context);
        }
    }





}
