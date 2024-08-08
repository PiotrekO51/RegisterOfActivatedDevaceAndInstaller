using static RegisterOfActivatedDevaceAndInstaller.RegisterBase;

namespace RegisterOfActivatedDevaceAndInstaller;

internal interface IApp
{
    string Name { get; }
    public string Number { get;  }
    public string Date { get;  }

    event GradeAddedDelegdate DevAdded;
    void AddData(string grade, string grade2, string grade3);
    void AddPerson(string grade, string grade2, string grade3);
    void DeviceAdded();
    void Color(ConsoleColor color);
   

    
}
