// Activator.CreateInstance
using System;
using System.Reflection;
using System.IO;

public class MainClass
{
  public static int Main(string[] args)
  {
    Assembly a = null;
    try
    {
      a = Assembly.Load("YourLibraryName");
    }
    catch(FileNotFoundException e)
    {Console.WriteLine(e.Message);}
  
    Type classType = a.GetType("YourLibraryName.ClassName");

    object obj = Activator.CreateInstance(classType);
  
    MethodInfo mi = classType.GetMethod("MethodName");

    mi.Invoke(obj, null);

    object[] paramArray = new object[2];    
    paramArray[0] = "Fred";
    paramArray[1] = 4;
    mi = classType.GetMethod("MethodName2");
    mi.Invoke(obj, paramArray);

    return 0;
  }
}
