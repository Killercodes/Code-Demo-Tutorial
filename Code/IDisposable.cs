using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDisposableDemo
{
    class TestClass : IDisposable
    {
        bool isDisposed = false;

        // Destructor (will be called by the GC if the calling code forgets to manually call Dispose)
        ~TestClass()
        {
            Dispose(false);
        }

        // Should be called from the calling code as soon as it is done with the instance
        // This is the only member defined in the System.IDisposable interface
        public void Dispose()
        {
            Dispose(true);

            // Inform the GC that it can now ignore the destructor of this instance
            GC.SuppressFinalize(this);
        }

        // Implemented as virtual so that any sub class can modify the implementation
        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed) // Protects the calling code from calling Dispose twice
            {
                if (isDisposing) // The method was not called from the destructor
                {
                    // TODO: clean up managed resources (optional)
                }

                // TODO: Clean up unmanaged resources

                isDisposed = true;

                // Call the base implementatin of the Dispose method (if any)
                //base.Dispose(isDisposing);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Manuall call to Dispose
            TestClass o1 = new TestClass();
            o1.Dispose();

            // Implicit call Dispose (recommended)
            using (TestClass o2 = new TestClass())
            {
                // Todo: Do stuff with the o2 instance
            } // Will call Dispose on the o2 instance

            // Will allow the GC to eventually call the destructor of the o3 instance
            TestClass o3 = new TestClass();
        }
    }
}
