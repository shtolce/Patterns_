using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Classes.Singleton
{
    /// <summary>
    /// Based on the OS launch issue
    /// </summary>
    public class Os
    {
        private static Os instance;
        private static object syncRoot = new Object();
        public string Name { get; private set;}
        protected Os(string name)
        {
            this.Name = name;
        }
        public static Os getInstance(string name)
        {
            lock(syncRoot)
            if (instance == null)
                instance = new Os(name);
            return instance;
        }
    }
    public class Computer
    {
        public Os Os { get; set; }
        public void Launch(string osName)
        {
            Os = Os.getInstance(osName);
        }


    }




}
