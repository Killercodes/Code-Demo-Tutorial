using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using System.IO;
using System.Security;


// ============================================================
// Declarative assembly permissions
// ============================================================

// ==============================
// RequestMinimum
// ==============================
// Tells the runtime NOT TO LOAD this assembly if the assembly IS NOT granted
// the specified permission.
//[assembly: RegistryPermission(SecurityAction.RequestMinimum, Unrestricted = true)]

// ==============================
// RequestOptional
// ==============================
// Tells the runtime REFUSE ALL permissions not EXPLICITLY specified in a
// RequestOptional OR RequestMinimum action.
//[assembly: FileIOPermission(SecurityAction.RequestOptional, Unrestricted = true)]

// ==============================
// RequestRefuse
// ==============================
// Tells the runtime to DENY this assembly the specified permission.
//[assembly: FileIOPermission(SecurityAction.RequestRefuse, Read = @"C:\boot.ini")]

namespace CasDemo
{
    class Program
    {
        public static void Main()
        {
            // ============================================================
            // Validate granted permissions programmatically
            // ============================================================

            //SecurityManagerDemo();
            //DemandExample();
            //LinkDemandExample();
            //AssertExample();
            //DenyExample();
            //PermitOnlyExample();
            //InheritanceDemandExample();
        }

        private static void SecurityManagerDemo()
        {
            if (SecurityManager.IsGranted(new FileIOPermission(
                FileIOPermissionAccess.Read, @"C:\boot.ini")))
            {
                // Has permission
            }
            else
            {
                // Lacks permission
            }
        }

        // ============================================================
        // Declarative (and imperative) method permissions
        // ============================================================

        // ==============================
        // Demand
        // ==============================
        // Will run if ALL CALLERS have the specified permission
        [FileIOPermission(SecurityAction.Demand, Read=@"c:\boot.ini")]
        static void DemandExample()
        {
            // Can also be specified imperatively:
            new FileIOPermission(FileIOPermissionAccess.Read, @"C:\boot.ini").Demand();
        }

        // ==============================
        // LinkDemand
        // ==============================
        // Will run if THE CALLER have the specified permission
        [FileIOPermission(SecurityAction.LinkDemand, Read = @"c:\boot.ini")]
        static void LinkDemandExample()
        {
            // No imperative alternative exists
        }

        // ==============================
        // Assert
        // ==============================
        // Will run EVEN IF any caller would lack the specified permission
        [FileIOPermission(SecurityAction.Assert, Read = @"c:\boot.ini")]
        static void AssertExample()
        {
            // Can also be specified imperatively:
            new FileIOPermission(FileIOPermissionAccess.Read, @"C:\boot.ini").Assert();
        }

        // ==============================
        // Deny
        // ==============================
        // Will deny the method the specified permission
        [FileIOPermission(SecurityAction.Deny, Read = @"c:\boot.ini")]
        static void DenyExample()
        {
            // Can also be specified imperatively:
            new FileIOPermission(FileIOPermissionAccess.Read, @"C:\boot.ini").Deny();
        }

        // ==============================
        // PermitOnly
        // ==============================
        // Will deny the method ALL BUT the specified permissions
        [FileIOPermission(SecurityAction.PermitOnly, Read = @"c:\boot.ini")]
        static void PermitOnlyExample()
        {
            // Can also be specified imperatively:
            new FileIOPermission(FileIOPermissionAccess.Read, @"C:\boot.ini").PermitOnly();
        }

        // ==============================
        // InheritanceDemand
        // ==============================
        // The method will only be able to be overridden if the specified permission is honored by the overriding member
        [FileIOPermission(SecurityAction.InheritanceDemand, Read = @"c:\boot.ini")]
        static void InheritanceDemandExample()
        {
            // No imperative alternative exists
        }
    }
}
