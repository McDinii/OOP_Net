using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Laba_11
{
    public static class Reflector
    {
        const string nameSpace = "Laba_11.";
        public const string pathW = "D:\\ВУЗ\\2nd-year\\OOP_Net\\Laba_11\\fileW.txt";
        public const string pathR = "D:\\ВУЗ\\2nd-year\\OOP_Net\\Laba_11\\fileR.txt";
        public static StreamWriter file = new(pathW, false);
        public static StreamReader fileR = new(pathR);
       

        public static void GetAssembly(string classname)
        {
            var TypeAssembly = nameSpace + classname;
            var mitype = Type.GetType(TypeAssembly, false, true);
            file.WriteLine($"{TypeAssembly}.Assembly: {mitype.Assembly}");
            Console.WriteLine("Write assembly to file");
        }
        public static void GetConstructor(string classname)
        {
            classname = nameSpace + classname;
            Type classType = Type.GetType(classname,false,true);
            file.WriteLine($"\nPublic Constructors of {classname}:");
         
           
            if (classType.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length == 0)
            {
                file.WriteLine("\tNo public constructors");
            }
            else
            {
                file.WriteLine($"\nPuclic Constructors count {classType.GetConstructors(BindingFlags.Public).Length}:");
                foreach (var constructor in classType.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
                {
                    file.WriteLine($"\t {constructor}");
                }
            }
            
            Console.WriteLine("Write constuctors to file");
        }

        public static void GetMethods(string classname)
        {
            
                var typeName = nameSpace + classname;
                Type classType = Type.GetType(typeName, false, true);
                file.WriteLine($"\nPublic Methods of {classname}:");

            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            if (methods.Length == 0)
            {
                file.WriteLine("\tNo public methods");
            }
            else
            {
                file.WriteLine($"\nPublic Methods count {methods.Length}:");
                foreach (var method in methods)
                {
                    file.WriteLine($"\t {method}");
                }
            }
            Console.WriteLine("Write methods to file");
            file.WriteLine("\n");

        }
        public static void GetFields(string classname)
        {
            var typeName = nameSpace + classname;
            Type classType = Type.GetType(typeName, false, true);
           

            file.WriteLine("Fields:");
            foreach (var field in classType.GetFields())
            {
                file.WriteLine(field);
            }
            Console.WriteLine("Write fields to file");
            file.WriteLine("\n");
        }

        public static void GetProperties(string classname)
        {
            var typeName = nameSpace + classname;
            Type classType = Type.GetType(typeName, false, true);
            file.WriteLine("Properties:");
            foreach (var property in classType.GetProperties())
            {
                file.WriteLine(property);
            }
            Console.WriteLine("Write properties to file");
            file.WriteLine("\n");
        }

        public static void GetInterfaces(string classname)
        {
            
                var typeName = nameSpace + classname;
                Type classType = Type.GetType(typeName, false, true);
                file.WriteLine("Interfaces:");
                foreach (var inter in classType.GetInterfaces())
                {
                    file.WriteLine(inter);
                }
                Console.WriteLine("Write interfaces to file");
                file.WriteLine("\n");
            
        }

        public static void GetMethodsByParam(string classname,string param)
        {
            var typeName = nameSpace + classname;
            Type classType = Type.GetType(typeName, false, true);
            file.WriteLine("Param Methods:");
      
            foreach (var method in classType.GetMethods())
            {
                
                foreach (var parametr in method.GetParameters())
                {
                    if (parametr.ParameterType.Name == param)
                    {
                        file.WriteLine(method);
                    }
                }
            }
            Console.WriteLine("Write Param Methods to file");
            file.WriteLine("\n");
        }

        public static void CallMethod(Type type, string methodName, object[] parameters)
        {
            var method = type.GetMethod(methodName);
            method.Invoke(null, parameters);
        }
        public static void Invoke(string name, string method)
        {

            var param = new List<string>
            {
                fileR.ReadLine(),
                fileR.ReadLine(),
                fileR.ReadLine()
            };
            var parms = new object[] { param };
            var type = Type.GetType(name);
            var obj = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(method);
            var result = methodInfo.Invoke(obj, parms);
            Console.WriteLine(result);
            Console.WriteLine("\n");
        }
        public static object Create(string name, object[] parm)
        {
            
            var TypeName = nameSpace + name;
            var miType = Type.GetType(TypeName, false, true);
            var obj = Activator.CreateInstance(miType, parm);
            Console.WriteLine(obj.ToString());
     
            return obj;
        }

    }
}
