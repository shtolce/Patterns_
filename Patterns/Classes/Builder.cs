using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.Builder
{
    /// <summary>
    /// Builder pattern
    /// </summary>

    public class Director
    {
        public Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {
            this.builder.BuildPartA();
            this.builder.BuildPartB();
            this.builder.BuildPartC();
        }


    }

    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();

    }
    public class ConcreteBuilder:Builder
    {
        Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("partA");
        }
        public override void BuildPartB()
        {
            product.Add("partB");
        }
        public override void BuildPartC()
        {
            product.Add("partC");
        }
        public override Product GetResult()
        {
            return product;
        }


    }




    public class Product
    {
        public List<Object> parts=new List<object>();
        public void Add(object part)
        {
            parts.Add(part);
        }
    }



}
