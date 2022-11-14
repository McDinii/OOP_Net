using System.Collections;

namespace laba06
{
    internal class Logger
    {
        public static void Log(ArgumentException exc, bool fileLogger, bool consoleLogger)
        {
            if (fileLogger) FileLogger(exc);
            if (consoleLogger)
            {
                switch (exc)
                {
                    case InvalidNameException nameException:
                        ConsoleLogger(nameException);
                        break;
                    case InvalidTypeException exception:
                        ConsoleLogger(exception);
                        break;
                    default:
                        Console.WriteLine(exc.Message);
                        break;
                }
            }
        }

        private static void FileLogger(Exception exc)
        {
            var error = $"{DateTime.Now}, Information: {exc.Message}";
            using (var file = new StreamWriter(@"..\..\..\log.txt", true))
            {
                file.WriteLine(error);
                file.Close();
            }
        }

        private static void ConsoleLogger(InvalidNameException exc)
        {
            Console.WriteLine($"\n\tError");
            Console.WriteLine($"Massage: {exc.Message}");
            Console.WriteLine($"Uncorrected name: {exc.Value}");
            Console.WriteLine("-> Locate Exception: {0}", exc.TargetSite);
            foreach (DictionaryEntry d in exc.Data)
                Console.WriteLine("-> {0} {1}", d.Key, d.Value);
        }

        private static void ConsoleLogger(InvalidTypeException exc)
        {
            Console.WriteLine($"\n\tError");
            Console.WriteLine($"Massage: {exc.Message}");
            Console.WriteLine($"Lifetime of the object: {exc.Value}");
            Console.WriteLine("-> Locate Exception: {0}", exc.TargetSite);
            foreach (DictionaryEntry d in exc.Data)
                Console.WriteLine("-> {0} {1}", d.Key, d.Value);
        }
    }
}
