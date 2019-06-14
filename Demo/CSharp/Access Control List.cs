using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.AccessControl;
using System.Security.Principal;
using System.IO;

namespace AclDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ListAccessRules();
            AddAccessRule();
        }

        static void ListAccessRules()
        {
            // Could also be a RegistrySecurity
            DirectorySecurity ds =
                new DirectorySecurity(@"C:\DemoTemp", AccessControlSections.Access);

            // Get all access rules related to the directory
            AuthorizationRuleCollection rules =
                ds.GetAccessRules(true, true, typeof(NTAccount));

            foreach (FileSystemAccessRule accessRule in rules)
                Console.WriteLine("{0} ({1}) - {2}",
                    accessRule.IdentityReference,
                    accessRule.AccessControlType,
                    accessRule.FileSystemRights);
        }

        static void AddAccessRule()
        {
            // Could also be a RegistrySecurity
            DirectorySecurity ds =
                new DirectorySecurity(@"C:\DemoTemp", AccessControlSections.Access);

            // Add rule to the directory
            ds.AddAccessRule(new FileSystemAccessRule("Guest",
                FileSystemRights.Read, AccessControlType.Allow));

            // Save new rules to the directory
            Directory.SetAccessControl(@"C:\DemoTemp", ds);
        }
    }
}
