using System;
using Microsoft.Win32;

class MainClass
{
    public static void Main()
    {
      RegistryKey start = Registry.LocalMachine;
      RegistryKey cardServiceName, networkKey;
      string networkcardKey = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkCards";
      string serviceKey = "SYSTEM\\CurrentControlSet\\Services\\";
      string networkcardKeyName, deviceName, deviceServiceName, serviceName;
    
      RegistryKey serviceNames = start.OpenSubKey(networkcardKey);
      if (serviceNames == null)
      {
          Console.WriteLine("Bad registry key");
          return;
      }
    
      string[] networkCards = serviceNames.GetSubKeyNames();
      serviceNames.Close();
    
      foreach(string keyName in networkCards)
      {
          networkcardKeyName = networkcardKey + "\\" + keyName;
          cardServiceName = start.OpenSubKey(networkcardKeyName);
          if (cardServiceName == null)
          {
            Console.WriteLine("Bad registry key: {0}", networkcardKeyName);
            return;
          }
          deviceServiceName = (string)cardServiceName.GetValue("ServiceName");
          deviceName = (string)cardServiceName.GetValue("Description");
          Console.WriteLine("\nNetwork card: {0}", deviceName);
      }
    
      start.Close();
    }
}
