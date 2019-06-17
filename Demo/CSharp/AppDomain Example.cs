?? AppDomain By example

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Policy;
using System.Security;

namespace AppDomainsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateAndUnload();
            //CreateAndUnloadWithEvidence();
            //CreateAndUnloadWithPrivileges();
            //LoadAssemblies();
			//CreateDoaminExample();
			
        }

        static void CreateAndUnload()
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);

            AppDomain d = AppDomain.CreateDomain("NewDomain");
            Console.WriteLine(d.FriendlyName);

            // Free up all resources allocated by the new app domain
            AppDomain.Unload(d);
        }

        static void CreateAndUnloadWithEvidence()
        {
            object[] hostEvidence = { new Zone(SecurityZone.Internet) };
            Evidence evidence = new Evidence(hostEvidence, null);

            // Will run under internet permissions
            AppDomain d = AppDomain.CreateDomain("NewDomain", evidence);

            // Free up all resources allocated by the new app domain
            AppDomain.Unload(d);
        }

        static void CreateAndUnloadWithPrivileges()
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.DisallowCodeDownload = true;

            // Will not allow HTTP downloads
            AppDomain d = AppDomain.CreateDomain("NewDomain", null, setup);

            // Free up all resources allocated by the new app domain
            AppDomain.Unload(d);
        }

        static void LoadAssemblies()
        {
            AppDomain d = AppDomain.CreateDomain("NewDomain");

            // Load the external assembly into a new app domain
            d.ExecuteAssembly("MyAssembly.exe");
            d.ExecuteAssemblyByName("MyAssembly");

            // Free up all resources allocated by the new app domain
            AppDomain.Unload(d);
        }
        
        static void CreateDoaminExample()
        {
            AppDomain domain = AppDomain.CreateDomain("Test");

            ArrayList list = new ArrayList();
            list.Add("d");
            list.Add("c");
            list.Add("f");

            domain.SetData("Pets", list);

            foreach (string s in (ArrayList)domain.GetData("Pets"))
            {
                Console.WriteLine("  - " + s);
            }
        }
        
        static void CreateInstanceExample()
        {
            AppDomain d = AppDomain.CreateDomain("NewDomain");
    
            ObjectHandle hobj = d.CreateInstance("AnotherDomain", "SimpleObject");
            SimpleObject so = (SimpleObject) hobj.Unwrap();
            Console.WriteLine(so.Display("make this uppercase"));
        }
        
        static void CreateInstanceAndUnwrapExample()
        {
             AppDomain Domain2 = AppDomain.CreateDomain("AppDomainB");
            MainClass MyMyClass = (MainClass)Domain2.CreateInstanceAndUnwrap("YourNameSpace", "YourClassName");
        }
        
        static void CreateInstanceFromAndUnwrapExample()
        {
            AppDomain newDomain = AppDomain.CreateDomain("My New AppDomain");

            MyClass mbvObject = (MyClass)newDomain.CreateInstanceFromAndUnwrap(
                    "MainClass.exe", 
                    "MyClass");

            Console.WriteLine("AppDomain of MBV object = {0}", mbvObject.HomeAppDomain);
        }
        
        
		static void CurrentDomainFriendlyNameExample()
		{
			AppDomain d = AppDomain.CreateDomain("NewDomain");
			Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
			Console.WriteLine(d.FriendlyName);
		}

		static void CurrentDomainExample()
		{
			if (AppDomain.CurrentDomain.FriendlyName != "NewAppDomain")
			{
				AppDomain domain = AppDomain.CreateDomain("NewAppDomain");

				domain.ExecuteAssembly("MainClass.exe", null, args);
			}

			foreach (string s in args)
			{
				Console.WriteLine(AppDomain.CurrentDomain.FriendlyName + " : " + s);
			}
		}

		static void DefineDynamicAssemblyExample()
		{
			 AppDomain ad = AppDomain.CurrentDomain;

			AssemblyName an = new AssemblyName();
			an.Name = "DynamicRandomAssembly";
			AssemblyBuilder ab = ad.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);

			ModuleBuilder mb = ab.DefineDynamicModule("RandomModule");

			TypeBuilder tb = mb.DefineType("DynamicRandomClass",TypeAttributes.Public);

			Type returntype = typeof(int);
			Type[] paramstype = new Type[0];
			MethodBuilder methb=tb.DefineMethod("DynamicRandomMethod", MethodAttributes.Public, returntype, paramstype);

			ILGenerator gen = methb.GetILGenerator();
			gen.Emit(OpCodes.Ldc_I4, 1);
			gen.Emit(OpCodes.Ret);

			Type t = tb.CreateType();

			Object o = Activator.CreateInstance(t);
			Object[] aa = new Object[0];
			MethodInfo m = t.GetMethod("DynamicRandomMethod");
			int i = (int) m.Invoke(o, aa);
			Console.WriteLine("Method {0} in Class {1} returned {2}",m, t, i);
		}

		static void DoCallBackExample()
		{
			 List<AppDomain> ads = new List<AppDomain>();
				for (int i = 0; i < 10; i++)
				{
					AppDomain ad = AppDomain.CreateDomain(i.ToString());
					ad.DoCallBack(delegate { Type t = typeof(Uri); });
					ads.Add(ad);
				}
				Console.WriteLine("After loading System.dll into 10 AppDomains: {0}", Environment.WorkingSet);
		}

		static void DomainUnloadExample()
		{
			AppDomain defaultAD = AppDomain.CreateDomain("SecondAppDomain");

			defaultAD.DomainUnload += (s,e) => { Console.WriteLine("DomainUnload !"); };
			defaultAD.ProcessExit += (s,e) => { Console.WriteLine("ProcessExit !"); };

			// Now unload anotherAD.
			AppDomain.Unload(defaultAD);

			return 0;
		}

    }
}
