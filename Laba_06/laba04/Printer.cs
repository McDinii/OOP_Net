namespace laba05
{
    public class Printer
    {
        public static void IAmPrinting(ITransport element)
        {
            if (element is TransportVehicle)
            {
                Console.WriteLine($"Type object({element.GetType()}): " + element);
            }
            else
            {
                var temp = element as Transformer;
                if (temp != null)
                    Console.WriteLine($"Type object({temp.GetType()}): " + temp);
            }
        }
    }
}
