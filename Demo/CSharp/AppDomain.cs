using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Policy;
using System.Security;

namespace AppDomainsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateAndUnload();
            //CreateAndUnloadWithEvidence();
            //CreateAndUnloadWithPrivileges();
            //LoadAssemblies();
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
    }
}
