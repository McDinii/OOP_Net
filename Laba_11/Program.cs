using System.Reflection;
namespace Laba_11;
  public class Program
{
    public static void Main()
    {
        var s = new MiSet("MiSet");
        // task 1.a
        Reflector.GetAssembly("Program");
        Reflector.GetAssembly("MiSet");
        // task 1.b
        Reflector.GetConstructor("MiSet");
        // task 1.c
        Reflector.GetMethods("MiSet");
        // task 1.d
        Reflector.GetFields("MiSet");
        Reflector.GetProperties("MiSet");
        // task 1.e
        Reflector.GetInterfaces("MiSet");
        // task 1.f
        Reflector.GetMethodsByParam("MiSet", "String");
        
        Reflector.Invoke("Laba_11.Test","ToConsole");
        object[] param = { "MiSet" };
        var miSet = Reflector.Create("Test", param);
        Reflector.file.Close();
    }
}                