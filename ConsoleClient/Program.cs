using DataAccessors.Accessors;
using DataAccessors.Data;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleClient
{
    class Program
    {
        class SimpleTimer: IDisposable
        {
            private Stopwatch sw;

            public SimpleTimer()
            {
                sw = new Stopwatch();
                sw.Start();
            }

            public void Dispose()
            {
                sw.Stop();
                Console.WriteLine("Complete! elapsed: {0}ms", sw.ElapsedMilliseconds);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(
@"Select data accessor: 
orm accessor       - 1
ADO accessor       - 2
directory accessor - 3
file accessor      - 4
memory accessor    - 5");

            IAccessor<Person> accessor = null;
            int resp = int.Parse(Console.ReadLine());

            string appConfigConnectionString = "ServiceDB";

            switch (resp)
            {
                case 1:
                    accessor = new OrmPersonAccessor(appConfigConnectionString);
                    break;
                case 2:
                    accessor = new ADOPersonAccessor(appConfigConnectionString);
                    break;
                case 3:
                    accessor = new DirectoryPersonAccessor(@"C:\Users\pc-1\Desktop\MyOrm\DataProject\bin\Debug\Data\FolderDBb");
                    break;
                case 4:
                    accessor = new FilePersonAccessor(@"C:\Users\pc-1\Desktop\MyOrm\DataProject\bin\Debug\Data\FilePersonDB.txt");
                    break;
                case 5:
                    accessor = new MemoryPersonAccessor();
                    break;
            }               
            RunPersonCUI(accessor);
        }

        private static void RunPersonCUI(IAccessor<Person> accessor)
        {
            Console.WriteLine(
@"Commands:
p                         - print all
p [id]                    - print one
i [id]                    - insert
i [id] [name] [last name] - insert
d [id]                    - delete");    
         
            Console.WriteLine("Now using: {0} ", accessor.GetType().Name);
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', ',');
                if (command[0] == "p")
                {
                    var s = new SimpleTimer();
                    if (command.Length == 1)
                    {
                        foreach (Person p in accessor.GetAll())
                        {
                            Console.WriteLine(p);
                        }
                    }
                    else if (command.Length == 2)
                    {
                        int id = Int32.Parse(command[1]);
                        Person p = accessor.GetById(id);
                        Console.WriteLine(p.ToString());
                    }
                    s.Dispose();
                }
                else if (command[0] == "d")
                {
                    var s = new SimpleTimer();
                    int id = Int32.Parse(command[1]);
                    accessor.DeleteById(id);
                    s.Dispose();
                }
                else if (command[0] == "i")
                {
                    var s = new SimpleTimer();
                    int id = Int32.Parse(command[1]);
                    Person p = new Person() { ID = id };
                    if (command.Length >= 4)
                    {
                        p.Name = command[2];
                        p.LastName = command[3];
                    }
                    accessor.Insert(p);
                    s.Dispose();
                }
                else if (String.IsNullOrEmpty(command[0]))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }  
        }
    }    
}
