using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Principal;
using System.Threading;
using System.Security.Permissions;

namespace RbsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoWindowsRbsDemo();
            //DoGenericRbsDemo();
            //DoCustomRbsDemo();
            //DoDeclarativeRbsCheck();
            //DoImperativeRbsCheck();
        }

        static void DoWindowsRbsDemo()
        {
            // Specify that Windows Principal should be used (already used by default)
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            // WindowsIdentity
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            
            // Print the username of the current windows user
            Console.WriteLine(string.Format("(Windows)Identity name: {0}", identity.Name));

            // WindowsPrincipal
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            // Check if the current windows user is a member of the 'Administrators' group.
            Console.WriteLine(string.Format("Is in administrators group: {0}",
                principal.IsInRole(WindowsBuiltInRole.Administrator)));
        }

        static void DoGenericRbsDemo()
        {
            // GenericIdentity
            GenericIdentity identity = new GenericIdentity("User1");
            
            // Print the username of the current user
            Console.WriteLine(string.Format("(Generic)Identity name: {0}", identity.Name));

            // GenericPrincipal
            string[] groups = { "Administrators", "Users" };
            GenericPrincipal principal = new GenericPrincipal(identity, groups);
            
            // Check if the current user is a member of the 'Administrators' group.
            Console.WriteLine(string.Format("Is in administrators group: {0}",
                principal.IsInRole("Administrators")));

            // Store the generic principal on the current thread.
            Thread.CurrentPrincipal = principal;
        }

        static void DoCustomRbsDemo()
        {
            // GenericIdentity
            MyCustumIdentity identity = new MyCustumIdentity(true, "MyAuthenticationType", "User1", "Pontus");

            // Print the username of the current user
            Console.WriteLine(string.Format("(Generic)Identity name: {0}", identity.Name));

            // GenericPrincipal
            string[] groups = { "Administrators", "Users" };
            MyCustomPrincipal principal = new MyCustomPrincipal(identity, groups);

            // Check if the current user is a member of the 'Administrators' group.
            Console.WriteLine(string.Format("Is in administrators group: {0}",
                principal.IsInRole("Administrators")));

            // Store the generic principal on the current thread.
            Thread.CurrentPrincipal = principal;
        }

        // Declarative RBS check
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        [PrincipalPermission(SecurityAction.Demand, Name = "User1")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        static void DoDeclarativeRbsCheck()
        {
            /*
            If reached:
            * The users is authenticated
            * The username is "User1"
            * The user is a member of the "Administrators" role
            */
        }

        static void DoImperativeRbsCheck()
        {
            // Imperative RBS check
            PrincipalPermission permission =
                new PrincipalPermission("User1", @"MyDomain\Administrators", true);

            try
            {
                permission.Demand();

                /*
                If reached:
                * The users is authenticated
                * The username is "User1"
                * The user is a member of the "Administrators" role
                */
            }
            catch
            {
                // If reached - One of the above was NOT true

                throw;
            }
        }
    }

    class MyCustumIdentity : IIdentity
    {
        string authenticationType, name, firstName;
        bool isAuthenticated;

        public MyCustumIdentity()
        {
        }

        public MyCustumIdentity(bool isAuthenticated, string authenticationType, string name, string firstName)
        {
            this.isAuthenticated = isAuthenticated;
            this.authenticationType = authenticationType;
            this.name = name;
            this.firstName = firstName;
        }

        public string AuthenticationType
        {
            get { return authenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
        }

        public string Name
        {
            get { return name; }
        }

        // Custom property (not part of the interface)
        public string FirstName
        {
            get { return firstName; }
        }
    }


    class MyCustomPrincipal : IPrincipal
    {
        IIdentity identity;
        string[] roles;

        public MyCustomPrincipal(IIdentity identity, string[] roles)
        {
            this.identity = identity;
            this.roles = roles;
        }

        public IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string role)
        {
            return roles.Contains(role);
        }
    }


}
