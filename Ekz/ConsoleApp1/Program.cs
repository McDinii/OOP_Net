class Program
{
    public interface ICleanble
    {
        public void Clean();
    }
    public enum Spec
    {
        poit,isit,mobile
    }
    public class Stud
    {
        public string name;
        public int group;
        public int course;
        public Spec spec;
        public double[] grade;
        public Tuple<double,double,double> Grade()
        {
            double min = grade.Min();
            double max = grade.Max();
            double avg = Math.Round(grade.Average(),1);
           var t = new Tuple<double,double,double> (min,max,avg);
            return t;

        }
        public override string ToString()
        {
            return $"Name:{name}, Group:{group}, Course:{course}, Spec: {spec}, Grade:[{grade[0]},{grade[1]},{grade[2]}]";
        }

    }
    public class Group:ICleanble
    {
        public List<Stud> groupp = new List<Stud>();
        public void Add(Stud st)
        {
            groupp.Add(st);
        }
        public void Print()
        {
            foreach (var g in groupp)
                Console.WriteLine(g);
        }
        public void Clean()
        {
            if (groupp.Count == 0)
            throw new Exception("Уже пуста");
            else groupp.Clear();
        }
    }
    public static void Main()
    {
        var stud1 = new Stud {name="Denis",group=7,course=2,spec= Spec.mobile, grade = new[] {9.0,8.0,5.0 }  };
        var stud2 = new Stud {name="Masha",group=5,course=2,spec= Spec.poit, grade = new[] {5.0,4.0,5.0 }  };
        var stud3 = new Stud {name="Dasha",group=3,course=2,spec= Spec.isit, grade = new[] {9.0,8.0,9.0}  };
        var stud4 = new Stud {name="Petya",group=3,course=2,spec= Spec.isit, grade = new[] {9.0,8.0,9.0}  };
        var stud5 = new Stud {name="Vasya",group=3,course=2,spec= Spec.isit, grade = new[] {9.0,8.0,9.0}  };
       Console.WriteLine(stud1.Grade());
       Console.WriteLine(stud2.Grade());
        var gr = new Group();
        gr.Add(stud1);
        gr.Add(stud2);
        gr.Add(stud3);
        gr.Add(stud4);
        gr.Add(stud5);
        gr.Print();
        
        var sp = new[] {Spec.mobile,Spec.poit,Spec.isit}; 
        foreach (var s in sp) { 
            var av = (from g in gr.groupp
                     where g.spec == s
                     select g.Grade().Item3).Max();
           Console.WriteLine(av);

            }
        gr.Clean();
        //gr.Clean();
    }

}