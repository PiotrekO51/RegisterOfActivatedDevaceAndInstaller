using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfActivatedDevaceAndInstaller;

public abstract class RegisterBase : IApp
{
    public delegate void GradeAddedDelegdate(object sender, object sender2,EventArgs a);
    public event GradeAddedDelegdate DevAdded;
    public RegisterBase()
    {
       
    }
    public RegisterBase(string name, string number,string date) 
    {
        this.Name = name;
        this.Number = number;   
        this.Date = date;   
    }

    public string Name { get; private set; }
    public string Number { get; private set; }
    public string Date { get; private set; }

    public abstract void AddData(string grade, string grade2, string grade3);

    public abstract void AddPerson(string grade, string grade2, string grade3);

    public abstract void Color(ConsoleColor color);
    

    public  void DeviceAdded()
    {
        if (DevAdded != null)
        {
            DevAdded(this.Name, Number, new EventArgs()) ;
        }
    }
}
