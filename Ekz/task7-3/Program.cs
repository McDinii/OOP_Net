class Program
{
    public class Point
    {
        public int x;
        public int y;
        public double w;
        public double h;
        public override string ToString()
        {
            return $"x:{x}, y:{y},\n w:{w}, h:{h}";
        }
    }
    public class Button
    {
        public string caption;
        public Point startPoint;
        public override bool Equals(object? obj)
        {
            Button but2 = obj as Button;
            if (caption == but2.caption && startPoint.w == but2.startPoint.w && startPoint.h == but2.startPoint.h)
                return true;
            else return false;
        }
        public override string ToString()
        {
            return $"Button:{caption}\n Coordinate: {startPoint} \n\n";
        }
    }
    public enum state
    {
        uncheckedd,
        checkedd
        
    }
    public class CheckButton:Button
    {
        public state st = state.uncheckedd;
        public void Check()
        {
            
            Console.WriteLine($"Before check: state:{st}");

            if (st == state.uncheckedd)
            {
                st = state.checkedd;
            }
            else st = state.uncheckedd;
            Console.WriteLine($"After check: state:{st}\n");
        }
        public void Zoom(double per)
        {
            Console.WriteLine($"Before: w:{startPoint.w}, h:{startPoint.h}");
            startPoint.h = (double)startPoint.h*per;
            startPoint.w = (double)startPoint.w*per;
            Console.WriteLine($"After: w:{startPoint.w}, h:{startPoint.h}\n");

        }
        public override string ToString()
        {
            return $"Button:{caption}\n Coordinate: {startPoint} \n State: {st}\n\n";
        }
        
    } 

    public class User:CheckButton
    {
         public delegate void Click();
        public  event Click Clicker;
        public  delegate void Zoom(double per);
        public event Zoom Zoomer;
        
        public void Zoomu(double value)
        {
            if(Zoomer != null)
            {
                Zoomer.Invoke(value);
            }
        }
        public void Resize()
        {
            if(Clicker != null)
            {
                Clicker.Invoke();
            }
        }

    }
    public static void Main()
    {
        // Task 1
        var pointRed = new Point{x=0,y=0,w=10,h=10 };
        var pointGreen = new Point{x=0,y=0,w=15,h=10 };
        var butRed = new CheckButton{caption="Red",startPoint= pointRed };
        var butGreen = new CheckButton{caption="Green",startPoint= pointGreen };
        var butNotCh = new Button{caption="Blue",startPoint= pointGreen };

        Console.WriteLine(butRed);
        Console.WriteLine(butGreen);
        Console.WriteLine(butGreen.Equals(butRed));
        Console.WriteLine(butGreen.Equals(butGreen));
        // Task 2
        butGreen.Check();
        butRed.Check();
        butRed.Zoom(0.5);
        butGreen.Zoom(0.05);
        
        // Task 3
        Console.WriteLine("Task3 \n");
        var user = new User();
        user.Zoomer += butRed.Zoom;
        user.Zoomer += butGreen.Zoom;
        user.Clicker += butGreen.Check;
        user.Zoomu(0.5);
        user.Resize();

        // Task 4
        Console.WriteLine("Task4 \n");
        LinkedList<Button> buts = new LinkedList<Button>();
        buts.AddFirst(butRed);
        buts.AddLast(butGreen);
        buts.AddLast(butNotCh);
        var butss = from b in buts
                    where (b.startPoint.w*b.startPoint.h == 25)
                    select b;
        foreach(var b in butss)
            Console.WriteLine($"\nTask 4:\n{b}");

        // Task 5
        Console.WriteLine("\nTask5:");
        var che = new CheckButton();
        var butsss = from b in buts
                    where(b.GetType().Name == "CheckButton")
                     select b;
        foreach (var b in butsss)
            Console.WriteLine($"\n{b}");

    }
} 