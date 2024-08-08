using Microsoft.Win32;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace RegisterOfActivatedDevaceAndInstaller;
internal class Register
{ 
    private static void Main()
    {
        DeviceRegister name = new DeviceRegister();
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ Witam w programie Rejestracji Urządzeń i Instalatorów  ║");
        Console.WriteLine("║  Program służy do kontroli zajerestrownych urządzeń    ║");
        Console.WriteLine("║           oraz przeszkolonych  instalatorów            ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        int counter1= 0;
        int p = 0;
            int p2 = 0;
        bool ExitMenu = true;
        while (ExitMenu)
        {
            counter1++;
            //MENU GŁÓWNE
            if (counter1 == 1) 
            {
                p = 6;
                p2 = 8;
            }
            else { p = 2; p2 = 4; }
            WriteLineColor(ConsoleColor.Blue);
            Console.SetCursorPosition(1,p); ;
            Console.WriteLine("MENU WYBORU ");
            Console.ResetColor();
            WriteLineColor(ConsoleColor.Red);
            Console.SetCursorPosition(0, p2);
            Console.WriteLine(" 1 - Rejestr urządzeń i uruchomień:\n" +
                                " 2 - Rejestr Instalatorów;\n" +
                                 " X lub x koniec programu ");
            Console.ResetColor();

            var userInput1 = Console.ReadLine();

            switch (userInput1)
            {
                case "1":
                    
                    RegisterDevice();
                    
                    break;
                case "2":
                    AddingInstaller();
                    break;

                case "x":
                case "X":
                    ExitMenu = false;
                    break;
                default:
                    Console.WriteLine("Nie poprawny wybór");
                    break;
            }
        }
        Console.WriteLine("\n\n Diękujemy za skorzystanie z programu");
        Thread.Sleep(3000);
        Console.Clear();
    }

    private static void Installer()
    {
        Console.WriteLine("TU NA RAZIE JEST PUSTO wciśnij dowolny klawisz");
        Console.ReadKey();
        return;
    }

    private static void RegisterDevice()
    {
        DeviceRegister master = new DeviceRegister();
        //Console.WriteLine("Podaj nazwę katalogu");
        //string fileName = Console.ReadLine();
        //master.Name21(fileName);
        Console.Clear();
        bool ExitMenu2 = true;
        while (ExitMenu2)
        {
            // REJESTR MONTARZU I URUCHOMIENIA URZĄDZEŃ
            
            Console.Clear();
            WriteLineColor(ConsoleColor.Green);
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("MENU WYBORU URZĄDZEŃ ");
            Console.ResetColor();
            WriteLineColor(ConsoleColor.Red);
            Console.SetCursorPosition(0, 3);
            Console.WriteLine(" 1 - Rejestr Montażu i uruchomienia\n" +
                                " 2 - Rejestr przeglądu\n" +
                                " 3 - Lista zarejestrowanych urządzeń\n"+
                                " 4 - Poprawianie listy urządzeń\n" +
                                " X lub x Powrót do MENU głównego ");
            Console.ResetColor();

            var userInput2 = Console.ReadLine();
            switch (userInput2)
            {
                case "1":
                    
                    AddingDevice();
                    break;
                case "2":
                    DateOfRegister();
                    break;
                case "3":
                    OdczytDanych();
                    break;
                case "4":
                    master.poprawaListy();
                    //PoprawatDanych();
                    break;

                case "x":
                case "X":
                    ExitMenu2 = false;
                    break;
                default:
                    Console.WriteLine("Nie poprawny wybór");
                    break;
            }
        }
        Console.Clear();
    }
    private static void DeviceList()
    {
        Console.Clear();
        Console.WriteLine("TU NA RAZIE JEST PUSTO wciśnij dowolny klawisz");
        Console.ReadKey();
        Console.Clear();
        return;
    }

    private static void DeviceAdded(object sender, object sender2, EventArgs a)
    {
        Console.WriteLine($"Dodano {sender} NS: {sender2}");
        Thread.Sleep(2000);
    }

    private static void AddingDevice()
    {
        DeviceRegister name1 = new DeviceRegister();
        //Console.WriteLine("Podaj nazwę pliku");
        //string data = Console.ReadLine();
        //name1.Name21(data);
        //Console.Clear();

        string name = GetDataFromUser("Podaj nazwę urządzenia");
        string number = GetDataFromUser("Podaj numer seryjny urządzenia");
        string date = GetDateFromUser("Podaj datę rejestracji urządzenia YYYY-MMM-DD");
        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(number) && !string.IsNullOrEmpty(date))
        {
            IApp register = new DeviceRegister(name, number, date);
         
            register.DevAdded += DeviceAdded;
            register.AddData(name, number, date);
           
        }
        else { Pusto(number); }

    }
    //private static void PoprawatDanych()
    //{
    //    DeviceRegister register = new DeviceRegister();

    //    register.poprawaListy();

    //    Console.ReadLine();
    //}

    private static void OdczytDanych()
    {
        DeviceRegister register = new DeviceRegister();

        register.GetList();
        Console.WriteLine();
        Console.WriteLine("Wciśnij dowolny klawisz w celu powrotu do Menu");
        Console.ReadKey();
    }

    private static void AddingInstaller()
    {
        Console.Clear();
        Console.WriteLine("TU NA RAZIE JEST PUSTO wciśnij dowolny klawisz");
        Console.ReadKey();
        Console.Clear();
        return;
    }

    private static string GetDataFromUser(string text)
    {
        Console.Clear();
        Console.WriteLine($" {text}");
        string nameInput = Console.ReadLine();
        string nameInputTooAray = nameInput.ToUpper();
        return nameInputTooAray;
    }
    private static string GetDateFromUser(string text)
    {
        Console.Clear();
        Console.WriteLine($" {text}");
        Console.WriteLine("Podaj rok ");
        string year = Console.ReadLine();
        Console.WriteLine("Podaj miesiąc  od 01 do 12 ");
        string month = Console.ReadLine();
        Console.WriteLine("Podaj dzień w zależności od miesiąca ");
        string day = Console.ReadLine();
        string pole = $"{year}-{month}-{day}";
        string nameInput = pole;
        return nameInput;
    }
    public static void Pusto(string text)
    {
        Console.WriteLine($"Nie wypełniono pola {text} ");
        Console.ReadKey();
    }

    private static void DateOfRegister()
    {
        Console.Clear();
        Console.WriteLine("TU NA RAZIE JEST PUSTO wciśnij dowolny klawisz");
        Console.ReadKey();
        Console.Clear();
        return;
    }
    private static void WriteLineColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;

    }
}

