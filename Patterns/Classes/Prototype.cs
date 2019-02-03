using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.Prototype
{
    public abstract class Prototype
    {
        public int Id { get; private set; }
        public abstract Prototype Clone();
        public abstract Prototype Clone2();
        public Prototype(int id)
        {
            this.Id = id;
        }

    }
    public class ConcretePrototype : Prototype
    {
        public ConcretePrototype(int id) : base(id)
        {
        }
        public override Prototype Clone()
        {
            return new ConcretePrototype(Id);
        }
        /// <summary>
        /// for value type only,because if we apply this function to reference- reference
        /// property of the class will be shared for all instances
        /// </summary>
        /// <returns></returns>
        public override Prototype Clone2()
        {
            return this.MemberwiseClone() as ConcretePrototype;
        }



    }
    public class PrototypeClient
    {
        public void operation()
        {
            ConcretePrototype prototype = new ConcretePrototype(44);
            Prototype cloneprot = prototype.Clone();
            Console.WriteLine(cloneprot.Id);
            Console.WriteLine(prototype.Clone2().Id);


        }

    }





}
