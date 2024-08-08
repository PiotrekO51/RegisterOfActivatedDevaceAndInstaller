using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace RegisterOfActivatedDevaceAndInstaller;

public class DeviceRegister : RegisterBase
{
    public delegate void GradeAddedDelegdate(object sender, object sender2, EventArgs a);
    public event GradeAddedDelegdate DevAdded;

    public List<string> grades = new List<string>();
    public List<string> grades1 = new List<string>();

    private const string fileName = "_Device.txt";
    //private string ffileName;
   


    public string Name { get; private set; }
    public string Number { get; private set; }
    public string Date { get; private set; }
    public string FileName { get; private set; }    
    


    public DeviceRegister()
    {
        this.FileName = null;
       
    }
    public DeviceRegister(string name, string number, string date)
        : base(name, number, date)
    {
       
    }
    public void Name21(string grade)
    {
        this.FileName = grade;
        
    }
    public override void AddData(string Name, string Number, string Date)
    {
        
        using (var writer = File.AppendText(fileName))
        {
            if (Name != null)
            {
                writer.WriteLine($"{Name},{Number},{Date}");

                DeviceAdded();
            }
        }
    }
    

    public List<string> GetDataList()
    {
        grades = new List<string>();
        var gradeToList = this.ReadDataToList();
        foreach (var grade in gradeToList)
        {
            grades.Add(grade);
        }
        return grades;
    }

    public void GetList()
    {

        int counter = 0;
        Console.Clear();
        var grades = this.GetDataList();//ReadDataToList();
        foreach (var gra in grades)
        {
            counter++;
            string[] pole = gra.Split(',');
            Console.SetCursorPosition(0, counter);
            Console.WriteLine($"Nr {counter}:");
            Console.SetCursorPosition(7, counter);
            Console.WriteLine($" {pole[0]}");
            Console.SetCursorPosition(23, counter);
            Console.WriteLine($"SN: {pole[1]}");
            Console.SetCursorPosition(40, counter);
            Console.WriteLine($"data: {pole[2]}");
        }
    }

    public void poprawaListy()
    {
        do
        {
            int count = 0;
            var grades = this.ReadDataToList();
            GetList();
            foreach (var grade in grades)
            { count++; }
            Console.SetCursorPosition(0, count +3);
            Console.WriteLine("Podaj numer lini do poprawy lub x by powrócić do Menu");

            string numbLine = Console.ReadLine();
            if (numbLine == "x")
            { break; }

            int numLineint = int.Parse(numbLine);
            string getLine = grades[numLineint - 1];
            string[] pole = getLine.Split(',');
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($" {pole[0]}");
            Console.SetCursorPosition(10, 0);
            Console.WriteLine($" {pole[1]}");
            Console.SetCursorPosition(20, 0);
            Console.WriteLine($" {pole[2]}");
            Console.WriteLine();
            Console.WriteLine("Podaj nową nazwę");
            string pole0 = Console.ReadLine();
            pole[0] = pole0.ToUpper();
            Console.WriteLine("Podaj nowy numer");
            pole[1] = Console.ReadLine();
            Console.WriteLine("Podaj nową datę ");
            Console.WriteLine("Podaj rok ");
            string year = Console.ReadLine();
            Console.WriteLine("Podaj miesiąc  od 01 do 12 ");
            string month = Console.ReadLine();
            Console.WriteLine("Podaj dzień w zależności od miesiąca ");
            string day = Console.ReadLine();
            pole[2] = $"{year}-{month}-{day}";
            Console.WriteLine($"{pole[0]} {pole[1]} {pole[2]}");
            grades[numLineint - 1] = $"{pole[0]},{pole[1]},{pole[2]}";
            File.Delete(fileName);
            using (var writer = File.AppendText(fileName))
            {
                if (grades != null)
                {
                    foreach (var grade in grades)
                    {
                        writer.WriteLine($"{grade}");
                    }
                }
            }
        }
        while (true);
    }


    public List<string> ReadDataToList()
    {
        var grades = new List<string>();
        if (File.Exists(fileName))
            using (var reader = File.OpenText(fileName))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    grades.Add(line);
                    line = reader.ReadLine();
                }
            }
        else
        {
            Color(ConsoleColor.Red);
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("Katalog nie istnieje");
        }

        return grades;
    }

    public override void AddPerson(string grade, string grade2, string grade3)
    {
        throw new NotImplementedException();
    }
    public override void Color(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
}
