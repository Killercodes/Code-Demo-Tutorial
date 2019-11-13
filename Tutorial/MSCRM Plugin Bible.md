# MS Dynamics CRM Plug-ins & Workflows

# Plugin Overview
We can use CRM 2011 Plug-ins to perform an action on create, on delete and update events of records. You also use the new transaction feature in Plug-ins to group operations on multiple entities and to roll back these operations as a group on failure.

Plug-ins allows a CRM 2011 developer to execute custom code as part of an event pipeline provided by the CRM Application Framework.  Plug-ins allow you to execute code when records are created, updated, deleted, assigned or have their state changed. 

The new Sandbox feature allows code to be executed in an isolated trusted environment.

Finally, the new tracing capability can be used to provide detailed diagnostic information to developers while building and debugging plug-ins as well as to IT Pros once the plug-ins are in production. You will be using the tracing feature of CRM 2011 to provide detailed information on the execution of the plug-in you will build

Dynamics CRM 2011 uses an event driven pipeline to allow applications to integrate custom code into the processing of normal platform operations.  Plug-ins is the mechanism that allows developers to create custom code that can subscribe to the published events.  For example, a plug-in can subscribe to the operations on entities such as when data is inserted or updated to perform additional custom logic. 

In this exercise you will create a plug-in to execute in this pipeline.
The plug-in will be built using the new isolatable plug-in interface supported by Dynamics CRM 2011. This interface allows plug-ins to be executed in an isolated sandbox so that their potential to adversely impact the stable operation of the CRM server is greatly reduced. You will install your plug-in into the new CRM 2011plug-inSandbox and test the execution of the custom code.

## Definition:
A plug-in is custom business logic (code) that you can integrate with Microsoft Dynamics CRM 2011 and Microsoft Dynamics CRM Online to modify or augment the standard behavior of the platform. Another way to think about plug-ins is that they are handlers for events fired by Microsoft Dynamics CRM. You can subscribe, or register, a plug-in to a known set of events to have your code run when the event occurs.

 ## What’s New
In addition to the plug-in features mentioned in the previous topic, the following capabilities are also supported.

- **Infinite loop detection and prevention**
The Microsoft Dynamics CRM platform has the ability to terminate a plug-in that performs an operation that causes the plug-in to be executed repeatedly, resulting in a significant performance hit on the system.
- **Plug-ins receive expanded run-time information (context)**
Information passed to plug-ins include: custom data, the conditions under which the plug-in was run, information included in the request and response messages that the system is processing, and snapshots of entity attributes before and after the core system operation. Plug-ins can also pass data between themselves.
- **Execution dependency**
Plug-ins can be registered so as to be dependent with other plug-ins. Dependency defines an order to plug-in execution whereby one plug-in must run to completion before another plug-in executes.
- **Database deployment**
Plug-ins can be deployed to the Microsoft Dynamics CRM database in addition to on-disk and GAC deployment. Deploying a plug-in to the database enables automatic distribution of the plug-in to multiple Microsoft Dynamics CRM servers in a data center.
- **Offline execution**
Plug-ins can be deployed to Microsoft Dynamics CRM for Microsoft Office Outlook with Offline Access and execute while Outlook is in offline mode.


# Event Execution Pipeline
The Microsoft Dynamics CRM event processing subsystem executes plug-ins based on a message pipeline execution model. A Web service method call by a plug-in or other application results in a message being created in the Microsoft Dynamics CRM platform. The message contains business entity information and core operation information. The message is passed through the event execution pipeline where it can be read or modified by the platform core operation and any registered plug-ins.
>	The following figure illustrates the overall architecture of the Microsoft Dynamics CRM platform with respect to both synchronous and asynchronous event processing.
 

The event execution pipeline processes events either synchronously or asynchronously. The platform core operation and any plug-ins registered for synchronous execution are executed immediately and in a well-defined order. Plug-ins registered for asynchronous execution are queued with the Asynchronous Service and executed at a later time. Synchronous plug-ins are executed before any workflows execute, assuming both are registered for the same data change event.
The event pipeline is divided into 5 stages, of which only 2 are available to custom developed plug-ins. Multiple plug-ins that are registered in each stage can be further be ordered (ranked) within that stage during plug-in registration using the Event Framework plug-in registration API.


Stage|No|Stage Name|Description
--|--|--|--
Pre Event | 10| PreValidation (BeforeMainOperationOutsideTransaction)|Stage in the pipeline for plug-ins that are to execute before the main system operation. Pre-Event is raised before the platform core operation and before database transactions are started. For more information, see Inclusion in Database Transactions.
Pre-Event|	20|	PreOperation(BeforeMainOperationInsideTransaction)|	For internal use only.
Platform Core Operation|	30|MainOperation	|In-transaction main operation of the system, such as create, update, delete, and so on. No custom plug-ins can be registered in this stage.
Post-Event	|40	|AfterMainOperationInsideTransaction	|For internal use only.
Post-Event|	50|	AfterMainOperationOutsideTransaction	|Stage in the pipeline for plug-ins which are to execute after the main operation. In general plug-ins registered in this stage do not participate in the database transaction. For more information, see Inclusion in Database Transactions.

> **Note:** Validation (privilege checks) of the system user account under which a plug-in executes occurs after the Pre-Event stage. Use caution when registering a pre-event plug-in that modifies data in an external data store because the user has not yet been validated in Microsoft Dynamics CRM when the plug-in code executes.

Whenever application code or a workflow invokes a Microsoft Dynamics CRM Web service method, a state change in the system occurs that raises an event. The information passed as a parameter to the Web service method is internally packaged up into a Request message and processed by the pipeline. The information in the Request message is passed to the first plug-in registered for that event where it can be read or modified before being passed to the next registered plug-in for that event and so on. Plug-ins receive the message information in the form of context that is passed to their Execute method. The message is also passed to the platform core operation.

Plug-ins can be registered to execute before or after the core platform operation. Pre-event registered plug-ins receive the Request message first and can modify the message information before the message is passed to the core operation. After the core platform operation has completed, the message is passed to the registered post-event plug-ins.  This plug-ins have the opportunity to modify the message before the final result, known as the Response, is returned to the application or workflow that invoked the original Web service method call. 

A pre-event registered plug-in that passes a specific exception `(InvalidPluginExecutionException)` back to the platform cancels the core operation, any pre-event or post event registered plug-ins that have not yet executed, and any workflow that is triggered by the same data change event that the plug-in was registered for.

Because a single Microsoft Dynamics CRM server can host more than one organization, the execution pipeline is organization specific. There is a virtual pipeline for every organization that is defined in Microsoft Dynamics CRM. Plug-ins registered with the pipeline can only process business data for a single organization. A plug-in that is designed to work with multiple organizations must be registered with each organization's execution pipeline.
 
# Plug-in Basics
Plug-ins subscribe to a set of events and run when the events occur. These events occur regardless of the method that is used to perform the activity so that they are independent of the user interface. During plug-in registration, the event that the plug-in subscribes to is specified.
Plug-ins have many uses. This includes the following:
- Performing complex platform level data validation
- Performing auto-number generation
- Providing integration with other applications
- Executing complex business logic

Any number of plug-ins can be associated with a given entity and event. When multiple plug-ins are registered for the same event on the same entity, they are called in a sequence based on the order specified on the step registration. This value is specified as the Rank and it is supplied when the plug-in is registered. This allows developer control over the sequence. Plug-ins can be written in any Microsoft .NET 4.0 CLR-compliant language.
Plug-ins not executed by the sandbox or asynchronous service execute under the security context of the Microsoft Dynamics CRM application pool, CrmAppPool, as defined in Internet Information Services. By default, CrmAppPool uses the Network Security account identity. Therefore, it is important to set credentials correctly. Many times, it might be necessary to impersonate the user whose actions caused the plug-in to run.
 

## Determining When to Use Plug-ins
Generally, if developing custom code and assemblies, working with plug-ins is more powerful than developing a whole solution in workflow. This is for the following reasons:
- All code is in C# or Visual Basic .NET.
- Plug-ins are not bound by the features and logic patterns that the workflow editor supports.
- It is possible to step through and debug all aspects of the code. It is not possible to step through a process, although you can step through custom workflow activities.

### Ease of development
- Best Choice: Depends whether custom workflow activities are required.
- Processes: For simple operations that are supported by processes and do not have custom  workflow  activities, processes are the easiest.
- Plug-ins: For advanced operations or operations that are not supported by processes, plug-ins could be easier.
### Modifications by non-developers
- Best Choice: Processes
- Processes: Processes have the advantage when the logic is supported by processes natively. Non-developers can use custom workflow activities created by developers to include additional capabilities in the process rules they design.
- Plug-ins: Plug-ins usually require a developer to apply changes. However a plug-in can reference an external file, registry setting or database so that a non-developer can modify the behavior of the plug-in.
### On Demand Application
- Best Choice: Processes
- Processes: Processes can be applied manually from the Microsoft Dynamics CRM 2011 application.
- Plug-ins: Plug-ins do not apply here. web resources and code can be developed if opting not to use workflow. These pages can be integrated in the Microsoft Dynamics CRM 2011 application through custom buttons, menu commands or IFrames.
### Logic Support
- Best Choice: Plug-ins.
- Processes: Limited to what the editor supports unless using a custom workflow activity.
- Plug-ins: This is limited only by the capabilities of the available development resources.
### Immediacy: 
-	The requirement to affect data before committing it to the database so that users have instant feedback.
- Best Choice: Plug-ins or Client-side code
- Processes: Because event-based process activities are asynchronous, users do not see the results of any data changes immediately in the Microsoft Dynamics CRM application.
- Plug-ins: Plug-ins allow for data changes to be made that are visible after the form is reloaded following a Save. Pre-event plug-ins can also cancel any submitted changes.
- Client-Side code: Most responsive. But because it does not occur at the platform layer, scenarios can arise where users with different interfaces get different application behavior.
### Platform Layer Data Validation: 
- The requirement to perform data validation and return errors when requirements are not met.
-  Best Choice: Plug-ins
-  Processes: Not possible: workflow activities run asynchronously after the event occurs. They cannot return errors to the client or cancel the event.
- Plug-ins: In pre-event plug-ins, validation can be performed, the event that fired the plug-in can be canceled and an error can be returned to the client.
 

## Information Available to Plug-ins
After a plug-in is registered for a given entity and event, the system can call a well-defined plug-in method to execute custom logic when the event occurs. As part of the invocation of a plug-in, entity and user context information is passed to the plug-in.

It is also possible in the registration process to define custom configuration information to be passed to a plug-in. Additionally, the state of an entity before and after the platform operation can be passed to a plug-in. This is passed in the `PreEntityImages` and  arrays. The registration process defines which information is available in these arrays.
 
## Plug-ins and the Outlook Client
Plug-ins can be registered to execute in online mode or both Online and Offline. Offline mode is only supported on the Microsoft Dynamics CRM for Outlook® with Offline Access client. Plug-ins can check whether it is executing in offline mode by checking the IsExecutingOffline property of the execution context.

When a plug-in is designed that will be registered for both online and offline execution, consider the possibility that the plug-in could be executed two times. The first time that the plug-in could potentially execute is while Microsoft Dynamics CRM for Outlook with Offline Access is offline. The plug-in is then executed again when the client goes online and synchronization between the client and the Microsoft Dynamics CRM server occurs. Plug-ins can check the IsOfflinePlayback property of the execution context to determine whether the plug-in is being executed because of synchronization between the client and the Microsoft Dynamics CRM server.

When registering a plug-in for offline execution, always register the plug-in for a synchronous mode of execution. Asynchronous execution of offline plug-ins is not supported.
 
System Requirements for Plugin
You must have the following items to complete this lab:
- Microsoft Dynamics CRM 2011
- Microsoft Visual Studio 2010
- Microsoft Dynamics CRM 2011 SDK
- Plugin Registeration Tool

# Write a Plugin
Plug-in Assemblies
The pluginassembly class is used to define an assembly entity in Microsoft Dynamics CRM that contains one or more plug-ins or custom workflow activities. The pluginassembly entity contains information such as a user friendly name, the relevant organization, file name (pathname attribute), version, and other data. The pluginassembly instance is used to set the Pluginassembly property of the RegisterSolutionRequest instance.
- A plug-in can be composed of more than one assembly. Plug-ins can be a collection of files that includes other referenced assemblies and configuration files. Regardless of whether you deploy your plug-in to the database or disk, if your plug-in requires other assemblies to run, you must put copies of these assemblies in the Global Assembly Cache (GAC) on each server where the plug-in is to execute.
- Before you unregister an asynchronous plug-in, stop the asynchronous service. Failure to do this can result in a situation where the plug-in has been queued to execute, but the plug-in assembly is no longer available.
- There can be one or more plug-in types in an assembly. After the plug-in assembly is registered and deployed, plug-ins can perform their intended operation in response to a Microsoft Dynamics CRM run-time event.
- In Microsoft Dynamics CRM, plug-in assemblies must be readable by everyone to work correctly. Therefore, it is a  security best practice to develop plug-in code that does not contain any system logon information, confidential information, or company trade secrets.
- Each plug-in assembly must be signed, either by using the Signing tab of the project's properties sheet in  Microsoft Visual Studio 2010 or the Strong Name tool, before being registered and deployed to Microsoft Dynamics CRM. For more information about the Strong Name tool, run the sn.exe program, without any arguments, from a Visual Studio 2010 Command Prompt window.
- If your assembly contains a plug-in that can execute while the Microsoft Dynamics CRM for Outlook is offline, there is additional security that the Microsoft Dynamics CRM platform imposes on assemblies. 

# Writing a Basic Plug-in:
Plug-ins are custom classes that implement the IPlugin interface. You can write a plug-in in any .NET Framework 4 CLR-compliant language such as Microsoft Visual C# and Microsoft Visual Basic .NET. To be able to compile plug-in code, you must add Microsoft.Xrm.Sdk.dll and Microsoft.Crm.Sdk.Proxy.dll assembly references to your project. These assemblies can be found in the SDK\Bin folder of the SDK download.

## A Sample Plug-in
So you now know about the powerful plug-in capabilities and the extensive data passed to a plug-in at run-time. But what does plug-in code look like? Here is a very basic plug-in that displays "Hello world!" in a dialog to the user.
```csharp
using System;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.SdkTypeProxy;

namespace MyPlugins
{
   public class HelloWorldPlugin: IPlugin
   {
      public void Execute(IServiceProvider serviceProvider)
      {
         // Call the Microsoft Dynamics CRM Web services here or perform
         // some other useful work.
         throw new InvalidPluginExecutionException("Hello world!");
      }
   }
}
```
The real power of plug-ins lies in the extensive context information that is passed to the plug-in, the ability to alter some of that information as it passes through the system, and the ability to call Microsoft Dynamics CRM Web methods. For more information, refer to the SDK documentation.
 A plug-in class that implements the IPlugin interface and the required Execute method.
```cs
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
namespace Microsoft.Crm.Sdk.Samples
{
	public class SamplePlugin: IPlugin
	{
		public void Execute(IServiceProvider serviceProvider)
		{
			// Obtain the execution context from the service provider.
			IPluginExecutionContext context =
			(IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
			
			// Get a reference to the organization service.
			IOrganizationServiceFactory factory =
			(IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
			IOrganizationService service = factory.CreateOrganizationService(context.UserId);
			
			// Get a reference to the tracing service.
			ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
			
			try
			{
				// Plug-in business logic goes below this line.
				// Invoke organization service methods.
			}
			catch (FaultException<OrganizationServiceFault> ex)
			{
				// Handle the exception.
			}
		}
	}
}
```
The IServiceProvider parameter of the Execute method is a container for several service useful objects that can be accessed within a plug-in.The service provider contains instance references to the execution context, IOrganizationServiceFactory, ITracingService, and more. The sample code demonstrates how to obtain references to the execution context, IOrganizationService, and ITracingService from the service provider parameter. For more information about the tracing service, refer to Debug a Plug-In.

The execution context contains a wealth of information about the event that caused the plug-in to execute and the data contained in the message that is currently being processed by the pipeline. For more information about the data context, see Understand the Data Context Passed to a Plug-In.

The platform provides the correct Web service URLs and network credentials when you obtain the organization Web service reference from the service provider. Instantiating your own Web service proxy is not supported because it creates deadlock and authentication issues. After you have the organization service reference, you can use it to make method calls to the organization Web service. You can retrieve or change business data in a single Microsoft Dynamics CRM organization by issuing one or more message requests to the Web service. For more information about message requests, see Use Messages (Request and Response Classes) with the Execute Method.

A typical plug-in should access the information in the context, perform the required business operations, and handle exceptions. For more information about handling exceptions in a plug-in, refer to Handle Exceptions in Plug-Ins. A more complete plug-in sample is available in the topic Sample: Basic Plug-In.
The plug-in's Execute method should be written to be stateless because the constructor is not called for every invocation of the plug-in. Also, multiple system threads could execute the plug-in at the same time. All per invocation state information is stored in the context, so you should not use global variables in plug-ins or attempt to store any data in member variables for use during the next plug-in invocation.

## Use Early-Bound Types
To use early-bound Microsoft Dynamics CRM types in your plug-in code simply include the types file, generated using the CrmSvcUtil program, in your Microsoft Visual Studio plug-in project.

Conversion of a late-bound entity to an early-bound entity is handled as follows:
```cs 
Account acct = entity.ToEntity<Account>();
```
In the previous line of code, the acct variable is an early-bound type. All Entity16 values that are assigned to IPluginExecutionContext17 must be late-bound types. If an early-bound type is assigned to the context, a SerializationException18 will occur. For more information, see Understand the Data Context Passed to a Plug-In9. Make sure that you do not mix your types and use an early bound type where a late-bound type is called for as shown in the following code.
```cs
context.InputParameters["Target"] = new Account() { Name = "MyAccount" }; 
// WRONG: Do not do this.
```

In the example above, you do not want to store an early-bound instance in the plug-in context where a late-bound instance should go. This is to avoid requiring the platform to convert between early-bound and late bound types before calling a plug-in and when returning from the plug-in to the platform.

## Logging and Tracing
An alternative method to debug a plug-in is to use tracing. Tracing assists developers in troubleshooting plug-ins by providing run-time plug-in information as an aid in diagnosing the cause of plug-in failure. Tracing is especially useful to debug Microsoft Dynamics CRM Online registered plug-ins as it is the only supported debugging method for that scenario.

The tracing discussed here is different from ASP.NET tracing. Tracing is implemented in the Microsoft Dynamics CRM SDK through the use of the tracing service ITracingService. Developers add Trace statements to their plug-in code, then build and deploy the plug-in. During execution and only when that plug-in passes an exception back to the platform at run-time, tracing information is displayed to the user. For a synchronous registered plug-in, the tracing information is displayed in a dialog of the Microsoft Dynamics CRM Web application. For an asynchronous registered plug-in, the tracing information is shown in the Details area of the System Job form in the Web application. The amount and nature of this information is up to you as a developer to code into your plug-ins.
The main reason for implementing this type of tracing is to support the isolated (sandboxed) plug-in capability in Microsoft Dynamics CRM.

> Sandboxed plug-ins are not able to write information to the system event log or the file system. The tracing service was implemented to provide sandboxed plug-ins with a means to output run-time information when an exception is thrown. In addition, tracing is also supported in plug-ins that are not sandboxed.

An important design feature of tracing is that the tracing information is only made available when an exception is passed from the plug-in back to the platform. When the error dialog is displayed in the Web application, the user must click the Download Log File button to view the log containing exception and trace output. If an exception is not thrown or is caught by the plug-in/custom activity code, any tracing information generated by your custom code is lost.

An alternate approach is to create a custom entity to track any run-time plug-in information that you want to record. When your plug-in executes, have the plug-in store its exception information in a record of your custom entity. In this way, you are logging your run-time plug-in information to the Microsoft Dynamics CRM database. This method works for any plug-in regardless of how it is registered. However, if the plug-in executes within the database transaction and an exception occurs that causes a transaction rollback, any entity data changes by the
plug-in will be undone.
## Access to the Organization Service

To access the Microsoft Dynamics CRM organization service, it is required that plug-in code create an instance of the service through the ServiceProvider.GetService method.
```cs
// Obtain the organization service reference.
IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
```
The platform provides the correct Web service URLs and network credentials for you when you use this method. Instantiating your own Web service proxy is not supported as it will create deadlock and authentication issues.

## Write a Plug-in Constructor

The Microsoft Dynamics CRM platform supports an optional plug-in constructor that accepts either one or two string parameters. If you write a constructor like this, you can pass any strings of information to the plug-in at run time.
The following sample shows the format of the constructor. In this example, the plug-in class is named SamplePlugin.
```cs
public SamplePlugin()
public SamplePlugin(string unsecure)
public SamplePlugin(string unsecure, string secure)
```

The first string parameter of the constructor contains public (unsecure) information. The second string parameter contains non-public (secure)information. In this discussion, secure refers to an encrypted value while unsecure is an unencrypted value. 
# Plug-in Constructor
The Microsoft Dynamics CRM platform has special support for a plug-in constructor that accepts two string parameters. If you write a constructor for your plug-in that accepts two string parameters, you can pass any two strings of information to the plug-in at run time. The following code shows these two parameters.

**Example**
```csharp
using System;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.SdkTypeProxy;

namespace MyPlugins
{
   public class AccountCreateHandler: IPlugin
   {
      public AccountCreateHandler(string unsecure, string secure)
      {
         // Do something with the parameter strings.
      }

      public void Execute(IServiceProvider serviceProvider)
      {
         // Do something here.
      }
   }
}
```
The first string parameter of the constructor contains public (unsecure) information. The second string parameter contains non-public (secure) information. However, the secure string is not passed to a plug-in that executes while offline.

The information that is passed to the plug-in constructor in these two strings is specified when the plug-in is registered with Microsoft Dynamics CRM. When you use the PluginRegistration tool to register a plug-in, you can enter the secure and unsecure information in the Secure Configuration and Unsecure Configuration fields provided in the Register New Step form. The PluginDeveloper tool only supports the unsecure string through its CustomConfiguration attribute of the Step tag in the register.xml input file.
When using Microsoft Dynamics CRM for Microsoft Office Outlook with Offline Access, the secure string is not passed to a plug-in that executes while Microsoft Dynamics CRM for Outlook is offline.

The information that is passed to the plug-in constructor in these strings is specified when the plug-in is registered with Microsoft Dynamics CRM. When using the Plug-in Registration tool to register a plug-in, you can enter secure and unsecure information in the Secure Configuration and Unsecure Configuration fields provided in the Register New Step form. 

When registering a plug-in programmatically using the Microsoft Dynamics CRM SDK, `SdkMessageProcessingStep.Configuration` contains the unsecure value and `SdkMessageProcessingStep.SecureConfigId` refers to a `SdkMessageProcessingStepSecureConfig` record that contains the secure value.

Following are the two key differences found between these two configuration settings.

Unsecure Configuration of Plugin 	|Secure Configuration of Plugin 
--|--
Unsecure configuration information could be read by any user in CRM. Remember its publicinformation (Eg: Parameter strings to be used in plugin could be supplied here)	|TheSecureConfiguration information could beread only by CRM Administrators.(Eg: Restricted data from normal user could be supplied here)
Imagine that you include a plugin, plugin steps and activate them in a solution. Later solution was exported as Managed Solution to another environment. In this scenario, the supplied Unsecure configuration values would be available in the new environment.	|Imagine that you include a plugin, plugin steps and activate them in a solution. Later solution was exported as Managed Solution to another environment. In this scenario, the supplied Secure configuration information would NOTbe available in the new environment. The simple reason behind this is to provide more security to the contents of Secure Configuration.

> Pitfall:  Consider a scenario that you have developed a plugin and certain parameter strings are designed tosupply to the plugin in such a way that it is required to run the plugin smoothly.If you supply these parameter strings under secure configuration then the plugin will work fine only for the CRM Administrators. The simple reason is secure configuration can only be read by a CRM Administrator. So if the user is not a CRM administrator then the plugin would try to readbut it would fail just because its under the secure configuration.All public information should be supplied via Unsecure configuration section. So please remember these tips when you supply the secure and unsecure configuration via Plugin Registration tool.

 
# Passing Data Between Plug-ins
The message pipeline model provides for a PropertyBag of custom data values in the execution context that is passed through the pipeline and shared among registered plug-ins. This collection of data can be used by different plug-ins to communicate information between plug-ins and enable chain processing where data processed by one plug-in can be processed by the next plug-in in the sequence and so on. This feature is especially useful in pricing engine scenarios where multiple pricing plug-ins pass data between one another to calculate the total price for a sales order or invoice. Another potential use for this feature is to communicate information between a plug-in registered for a pre-event and a plug-in registered for a post-event.

The name of the parameter that is used for passing information between plug-ins is SharedVariables. This is a collection of System.Object. A common type of object that is used to fill the collection is DynamicEntity. At run time, plug-ins can add, read, or modify properties in the SharedVariables property bag. This provides a method of information communication among plug-ins.

> Note Only types that are XML serializable should be placed in SharedVariables. All types derived from BusinessEntity are XML serializable.

The following code example shows how to use SharedVariables to pass data from a pre-event registered plug-in to a post-event registered plug-in.

**Example**
``` csharp
using System;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.SdkTypeProxy;

public class AccountSetStatePreHandler : IPlugin
{
    public void Execute(IServiceProvider serviceProvider)
    {
        // Obtain the execution context from the service provider.
	    IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
        // Create or retrieve some data that will be needed by the post event
        // handler. You could run a query, create an entity, or perform a calculation.
        //In this sample, the data to be passed to the post plug-in is
        // represented by a GUID.
        Guid contact = new Guid("{74882D5C-381A-4863-A5B9-B8604615C2D0}");

        // Pass the data to the post event handler in an execution context shared
        // variable named PrimaryContact.
        context.SharedVariables.Properties.Add(
            new PropertyBagEntry("PrimaryContact", (Object)contact.ToString()));
        // Alternate code: context.SharedVariables["PrimaryContact"] = contact.ToString();
    }
}

public class AccountSetStatePostHandler : IPlugin
{
    public void Execute(IServiceProvider serviceProvider)
    {
        // Obtain the execution context from the service provider.
    IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
        // Obtain the contact from the execution context shared variables.
        if (context.SharedVariables.Contains("PrimaryContact"))
        {
            Guid contact = 
                new Guid((string)context.SharedVariables["PrimaryContact"]);
            // Do something with the contact.
        }
    }
}
```



This sample shows how to use SharedVariables to pass data from a pre-event registered plug-in to a post-event registered plug-in.
```cs 
using System;
// Microsoft Dynamics CRM namespace(s)
using Microsoft.Xrm.Sdk;
namespace Microsoft.Crm.Sdk.Samples
{
    /// <summary>
    /// A plug-in that sends data to another plug-in through the SharedVariables
    /// property of IPluginExecutionContext.
    /// </summary>
    /// <remarks>Register the PreEventPlugin for a pre-event and the
    /// PostEventPlugin plug-in on a post-event.
    /// </remarks>
    public class PreEventPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context from the service provider.
            Microsoft.Xrm.Sdk.IPluginExecutionContext context = (IPluginExecutionContext)
            serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Create or retrieve some data that will be needed by the post event
            // plug-in. You could run a query, create an entity, or perform a calculation.
            //In this sample, the data to be passed to the post plug-in is
            // represented by a GUID.
            Guid contact = new Guid("{74882D5C-381A-4863-A5B9-B8604615C2D0}");

            // Pass the data to the post event plug-in in an execution context shared
            // variable named PrimaryContact.
            context.SharedVariables.Add("PrimaryContact", (Object)contact.ToString());
        }
    }
    public class PostEventPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context from the service provider.
            Microsoft.Xrm.Sdk.IPluginExecutionContext context = (Microsoft.Xrm.Sdk.IPluginExecutionContext)
            serviceProvider.GetService(typeof(Microsoft.Xrm.Sdk.IPluginExecutionContext));
            // Obtain the contact from the execution context shared variables.
            if (context.SharedVariables.Contains("PrimaryContact"))
            {
                Guid contact = new Guid((string)context.SharedVariables["PrimaryContact"]);
                // Do something with the contact.
            }
        }
    }
}
```
It is important that any type of data added to the shared variables collection be serializable otherwise the server will not know how to serialize the data and plug-in execution will fail.

For a plug-in registered in stage 20 or 40, to access the shared variables from a stage 10 registered plug-in that executes on create, update, delete, or by a RetrieveExchangeRateRequest2, you must access the ParentContext3.SharedVariables collection. For all other cases, IPluginExecutionContext4.SharedVariables contains the collection.
 

## Walkthrough

## Imports
The CRM plugin needs to access Organization Service (Organization.svc) to perform CRUD operation inside Dynamics CRM 2011, to call & access Organization service CRM SDK provides two interfaces IOrganizationService & IOrganizationServiceProxy. These two interfaces are provided within a set of DLL file present in SDK\Bin folder.

The following reference in needed to write a plug-in:
```cs
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.ServiceModel;
using Microsoft.crm.sdk.proxy;
using System.Runtime.Serialization;
```

### `using Microsoft.Xrm.Sdk;`
A reference of this dll file is needed because it contains IPlugin interface which must be implemented by the plugin class and call the Execute function. It also contains Entity class which is used to late bound your code against CRM server.

### `using Microsoft.Xrm.Query;`
To Retrive a single or a set of record we need to call the service.Retrive/service.RetriveMultiple method. The Microsoft.Xrm.Query contains a set of classes to query and filter the set of record.

### `using System.ServiceModel;`
Provides classes related to the service model.

### Obtain the organization service reference.
```cs
IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
 ```

### Obtian the target entity
```cs
// Obtain the target entity from the input parmameters.
Entity entity = (Entity)context.InputParameters["Target"];
```
### Check Account
```cs
//check if the account number exist
if (entity.Attributes.Contains("accountnumber") != false)
    var accNum = entity["accountnumber"];
```
### Create a new Entity
```cs
//create a task
Entity task = new Entity("task");

//adding attribute using the add function
task.Attributes.Add("description", "Account number is missng for the following account. Please enter the account number");
service.Create(task);

```



# Plug-in Isolation, Trusts, and Statistics
Microsoft Dynamics CRM 2011 supports the execution of plug-ins in an isolated environment. In this isolated environment, also known as a sandbox, a plug-in can make use of the full power of the Microsoft Dynamics CRM SDK to access the organization web service. Access to the file system, system event log, certain network protocols, registry, and more is prevented in the sandbox. However, sandbox plug-ins do have access to external endpoints like the Windows Azure cloud.

Microsoft Dynamics CRM collects run-time statistics and monitors plug-ins that execute in the sandbox. If the sandbox worker process that hosts this custom code exceeds threshold CPU, memory, or handle limits or is otherwise unresponsive, that process will be killed by the platform. At that point any currently executing plug-in in that worker process will fail with exceptions. However, the next time that the plug-in is executed it will run normally. There is one worker process per organization so failures in one organization will not affect another organization.

In summary, the sandbox is the recommended execution environment for plug-ins as it is more secure, supports run-time monitoring and statistics reporting, and is supported on all Microsoft Dynamics CRM deployments.

## Trusts

Developers have the option of registering their plug-ins in the sandbox, known as partial trust, or outside the sandbox, known as full trust. Full trust is supported for on-premises and Internet-facing Microsoft Dynamics CRM deployments. 
For a Microsoft Dynamics CRM Online deployment, plug-ins must be registered in the sandbox (partial trust) where they are isolated as previously described.

## Run-time Statistics

The Microsoft Dynamics CRM platform collects run-time information about plug-ins that execute in the sandbox. This information is stored in the database using PluginTypeStatistic entity records. These records are populated within 30 minutes to one hour after the sandboxed custom code executes. 
See the PluginTypeStatistic attributes to find out what information is collected. You can retrieve this information by using the retrieve message or method.

## Web Access

Sandboxed plug-ins can access the network through the HTTP and HTTPS protocols. This capability provides support for accessing popular web resources like social sites, news feeds, web services, and more. The following web access restrictions apply to this sandbox capability.
- Only the HTTP and HTTPS protocols are allowed.
- Access to localhost (loopback) is not permitted.
- IP addresses cannot be used. You must use a named web address that requires DNS name resolution.
- Anonymous authentication is supported and recommended. There is no provision for prompting the logged on user for credentials or saving those credentials.

These default web access restrictions are defined in a registry key on the server that is running the Microsoft.Crm.Sandbox.HostService.exe process. The value of the registry key can be changed by the System Administrator according to business and security needs. The registry key path on the server is:
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSCRM\SandboxWorkerOutboundUriPattern

The key value is a regular expression string that defines the web access restrictions. The default key value is:
```regx
"^http[s]?://(?!((localhost[:/])|(\[.*\])|([0-9]+[:/])|(0x[0-9a-f]+[:/])|(((([0-9]+)|(0x[0-9A-F]+))\.){3}(([0-9]+)|(0x[0-9A-F]+))[:/]))).+";
```
By changing this registry key value, you can change the web access for sandboxed plug-ins.
 

# Understand the Data Context Passed to a Plug-In

`IPluginExecutionContext` contains information that describes the run-time environment that the plug-in is executing in, information related to the execution pipeline, and entity business information. The context is contained in the System.IServiceProvider parameter that is passed at run-time to a plug-in through its Execute method.
```cs
// Obtain the execution context from the service provider.
IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
```

When a system event is fired for which a plug-in is registered, the system creates and populates the context and passes it to a plug-in through the above mentioned classes and methods. The execution context is passed to each registered plug-in in the pipeline when they are executed.

Each plug-in in the execution pipeline is able to modify writable properties in the context. For example, given a plug-in registered for a preevent and another plug-in registered for a post-event, the post-event plug-in can receive a context that has been modified by the pre-event plug-in. The same situation applies to plug-ins that are registered within the same stage.

All the properties in IPluginExecutionContext are read-only. However, your plug-in can modify the contents of those properties that are collections. For information on infinite loop prevention, refer to Depth.

## Input and Output Parameters

The InputParameters property contains the data that is in the request message currently being processed by the event execution pipeline. Plug-in code can access this data. The property is of type ParameterCollection where the keys to access the request data are the names of the actual public properties in the request.

Your plug-in code can access this data. The property is of type ParameterCollection where the keys to access the request data are the names of the actual public properties in the request. As an example, take a look at CreateRequest. 
One property of CreateRequest is named Target which is of type Entity. This is the entity currently being operated upon by the platform. To access the data of the entity you would use the name “Target” as the key in the input parameter collection. You also need to cast the returned instance.

```cs
// The InputParameters collection contains all the data passed in the message request.
if (context.InputParameters.Contains("Target") &&
context.InputParameters["Target"] is Entity)
{
   // Obtain the target entity from the input parmameters.
   Entity entity = (Entity)context.InputParameters["Target"];
```

Similarly, the OutputParameters property contains the data that is in the response message, for example CreateResponse, currently being passed through the event execution pipeline. 

However, only synchronous post-event and asynchronous registered plug-ins have OutputParameters populated as the response is the result of the core platform operation. The property is of type ParameterCollection where the keys to access the response data are the names of the actual public properties in the response.

NOTE: If a plug-in is registered for a pre-event, the OutputParameters property  bag does not contain a value for the "id" key because the core operation did not occur.

 

# Pre and Post Entity Images

Plugins in Dynamics CRM, allow you to register images against the steps of a plugin assembly. Images are a way to pass the image of the record that is currently being worked upon prior or after the action has been performed. In general it could be said, it is the image of the record as is available in the SQL backend.

Two types of Images are supported, Pre-Image and Post Image. 

- **Pre-image:** In case of Pre-image, you get the image of the record as is stored in the SQL database before the CRM Platform action has been performed.

- **Post Image:** returns the image of the record after the CRM Platform action has been performed. As developers, you may have at times, received the following error when trying to implement a plugin.

In general `PreEntityImages` and `PostEntityImages` contain snapshots of the primary entity's attributes before (pre) and after (post) the core platform operation. Microsoft Dynamics CRM populates the pre-entity and post-entity images based on the security privileges of the impersonated system user. 
Only entity attributes that are set to a value or null are available in the pre or post entity images. You can specify to have the platform populate these `PreEntityImages` and `PostEntityImages` properties when you register your plug-in. The entity alias value you specify during plug-in registration is used as the key into the image collection in your plug-in code.

PreEntityImages is basically used to capture the data when the form loads. That is the data which is present by default when the form loads. 

Suppose you registered the Plugin and added a Image with name _PreImage_
```cs
Entity preMessageImage;

if (context.PreEntityImages.Contains("PreImage") && context.PreEntityImages["PreImage"] is Entity)
{
	preMessageImage = (Entity)context.PreEntityImages["PreImage"];
```

whereas the Post Image contains the attributes value which are finally changed. We can capture the changed data before the database operation takes place. And can do any kind of validation based on the changed data. Remember it can only be registered  for update message and cannot be registered on create message.

```cs
Entity postMessageImage;

if (context.PostEntityImages.Contains("PostImage") && context.PostEntityImages["PostImage"] is Entity)
{
	postMessageImage = (Entity)context.PostEntityImages["PostImage"];
```


Registering for pre or post images to access entity attribute values results in improved plug-in performance as compared to obtaining entity attributes in plug-in code through RetrieveRequest or RetrieveMultipleRequest requests.The PreEntityImages and PostEntityImages are Very useful in Scenarios where we want to compare the data that is changed by the user. Based on the changes the custom operation can be performed.

TO sum up here are the different ways to capture the Images form the Context when the "PreImage" & "PostImage" is defined
```cs
Entity entity = (Entity)context.InputParameters["Target"];
Entity preentity = (Entity)context.PreEntityImages["PreImage"];
Entity postentity = (Entity)context.PostEntityImages["PostImage"];
```

It is there important to understand when the images would be available and what state of the record would be returned in these images.

There are some events where images are not available. For example, only synchronous post-event and  asynchronous registered plug-ins have populated. In addition, the create operation does not support a pre-image and a delete operation does not support a post-image.


Say you were to register a "Pre-Image" for a plugin registered in Pre-Create Stage. We just mentioned above, that the image is a copy of the record as is stored in the SQL backend. Since this is the create stage and the record has not even been created as yet, there is no record in the SQL backend that can be returned in the Pre-Image and hence any call for the image would fail with the above error message.

The following table explains the Pre-Image & Post-Image Availability

Image|Stage|Create|Update|Delete
--|--|--|--|--
**Pre-Image**|PRE|~~No~~|**Yes**|**Yes**
**Pre-Image**|POST|**Yes**|**Yes**|**Yes**
**Post-Image**|PRE|~~No~~|~~No~~|~~No~~
**Post-Image**|POST|**Yes**|**Yes**|~~No~~

To confuse you more
Images are snapshots of the entity’s attributes, before and after the core system operation. Following table shows when in the event pipeline different images are available:

Message|Stage|Pre-Image|Post-Image
--|--|--|--
**Create**|PRE|No|No
**Create**|POST|No|Yes
**Update**|PRE|Yes|No
**Update**|POST|Yes|Yes
**Delete**|PRE|Yes|No
**Delete**|POST|Yes|No

The following table explains the Pre-Image Availability

Stage	|Create	|Update	|Delete
--|--|--|--
**PRE**|	No|	Yes|	Yes
**POST**|	Yes|	Yes|	Yes


The following table explains the Post-Image Availability

Stage|Create|Update|Delete
--|--|--|--
**PRE**	|No	|No	|No
**POST**|	Yes	|Yes|	No

 

## Support Offline Execution

You can register plug-ins to execute in online mode, offline mode, or both. Offline mode is only supported on Microsoft Dynamics CRM for Microsoft Office Outlook with Offline Access. Your plug-in code can check whether it is executing in offline mode by checking the IsExecutingOffline13 property.

When you design a plug-in that will be registered for both online and offline execution, remember that the plug-in can execute twice. The first time is while Microsoft Dynamics CRM for Microsoft Office Outlook with Offline Access is offline. The plug-in executes again when Microsoft Dynamics CRM for Outlook goes online and synchronization between Microsoft Dynamics CRM for Outlook and the Microsoft Dynamics CRM server occurs. You can check the IsOfflinePlayback14 property to determine if the plug-in is executing because of this synchronization.
 

## Web Access for Isolated (sandboxed) Plug-ins

If you plan on registering your plug-in in the sandbox, you can still access Web addresses from your plug-in code. You can use any .NET Framework class in your plug-in code that provides Web access within the Web access restrictions outlined Plug-in Isolation, Trusts, and Statistics.
For example, the following plug-in code downloads a Web page.
```cs
// Download the target URI using a Web client. Any .NET class that uses the
// HTTP or HTTPS protocols and a DNS lookup should work.
using (WebClient client = new WebClient())
{
byte[] responseBytes = client.DownloadData(webAddress);
string response = Encoding.UTF8.GetString(responseBytes);
```
For sandboxed plug-ins to be able to access external Web services, the server where the Sandbox Processing Service role is installed must be exposed to the Internet, and the account that the sandbox service runs under must have Internet access. Only outbound connections on ports 80 and 443 are required. Inbound connection access is not required. 
Use the Windows Firewall control panel to enable outbound connections for the Microsoft.Crm.Sandbox.WorkerProcess application located on the server in the `%PROGRAMFILES%\Microsoft Dynamics CRM\Server\bin folder.`
 

# Impersonation in Plug-Ins

Impersonation is used to execute business logic (custom code) on behalf of a Microsoft Dynamics CRM system user to provide a desired feature or service for that user. Any business logic executed within a plug-in, including Web service method calls and data access, is governed by the security privileges of the impersonated user.

Plug-ins not executed by either the sandbox or asynchronous service execute under the security account that is  specified on the Identity tab of the CRMAppPool Properties dialog box. The dialog box can be accessed by right-clicking the CRMAppPool application pool in Internet Information Services (IIS) Manager and then clicking Properties in the shortcut menu. By default, CRMAppPool uses the Network Service account identity but this can be changed by a system administrator during installation. If the CRMAppPool identity is changed to a system account other than Network Service, the new identity account must be added to the PrivUserGroup group in Active Directory. Refer to the “Change a Microsoft Dynamics CRM service account” topic in the Microsoft Dynamics CRM 2011 Implementation Guidefor complete and detailed
instructions.

The two methods that can be employed to impersonate a user are discussed below.

## Impersonation during plug-in registration

One method to impersonate a system user within a plug-in is by specifying the impersonated user during plug-in registration. When registering a plug-in programmatically, if the  `
SdkMessageProcessingStep.ImpersonatingUserId` attribute is set to a specific Microsoft Dynamics CRM system user, Web service calls made by the plug-in execute on behalf of the impersonated user. If ImpersonatingUserId is set to a value of null or Guid.Empty during plug-in registration, the calling/logged on user or the standard "system" user is the impersonated user.

Whether the calling/logged on user or "system" user is used for impersonation is dependent on the request being processed by the pipeline and is beyond the scope of the SDK documentation. For more information about the "system" user, refer to the next topic.

When you register a plug-in using the sample plug-in registration tool that is provided in the SDK download, service methods invoked by the plug-in execute under the account of the calling or logged on user by default unless you select a different user in the Run in User’s Context dropdown menu.

> For more information about the tool sample code, refer to the tool code under the SDK\Tools\PluginRegistration folder of the SDK download.

## Impersonation during plug-in execution

Impersonation that was defined during plug-in registration can be altered in a plug-in at run time. Even if impersonation was not defined at plug-in registration, plug-in code can still use impersonation. The following discussion identifies the key properties and methods that play a role in impersonation when making Web service method calls in a plug-in.

The platform passes the impersonated user ID to a plug-in at run time through the UserId1 property. This property can have one of three different values as shown in the table below.

UserId Value|Condition
--|--
Initiating user or **"system"** user	|The `SdkMessageProcessingStep.ImpersonatingUserId` attribute is set to null or Guid.Empty at plug-in registration.
Impersonated user	|The Impersonating UserId property is set to a valid system user ID at plug-in registration.
**"system"** user 	|The current pipeline was executed by the platform, not in direct response to a service method call.

The `InitiatingUserId` property of the execution context contains the ID of the system user that called the service method that ultimately caused the plug-in to execute. 
For plug-ins executing offline, any entities created by the plug-in are owned by the logged on user. Impersonation in plug-ins is not supported while in offline mode.
 

## Register the Plug-in in the CRM 2011:

Plug-in registration should be done after the assembly has been copied to the **Server\bin\assembly** folder on the server to prevent the situation where a system user causes an event in Microsoft Dynamics CRM to be raised but the registered plug-in assembly does not yet exist on the server. For server database deployment, the plug-in assembly is automatically copied during plug-in registration so that the earlier situation is not an issue.

Before you unregister an asynchronous plug-in, stop the asynchronous service. Failure to do this can result in a situation where the plug-in has been queued to execute, but the plug-in assembly is no longer available.
Security Restrictions

There is a security restriction that enables only privileged users to register plug-ins. The system user account under which the plug-in is being registered must exist in the Deployment Administratorsgroup of Deployment Manager. Only the System Administrator user account or any user account included in the Deployment Administratorsgroup can run Deployment Manager.

NoteFailure to include the registering user account in the Deployment Administratorsgroup results in an exception being thrown during plug-in registration. The exception description states "Not have enough privilege to complete Create operation for an Sdk entity." 

The system user account under which the plug-in is being registered must have the following organization wide security privileges:
- `prvCreatePluginAssembly`
- `prvCreatePluginType`
- `prvCreateSdkMessageProcessingStep`
- `prvCreateSdkMessageProcessingStepImage`
- `prvCreateSdkMessageProcessingStepSecureConfig`

The System Administrator and System Customizer roles have these privileges.
CRM 2011 provides a service API for registering plug-ins in the pipeline. The CRM SDK also includes a simple client application that provides a graphical interface to this API.  We will use this application to register our plug-in into the pipeline.

## Restriction
The following restrictions apply when registering a plug-in assembly:
- You can register only one version of a plug-in assembly in the Microsoft Dynamics CRM database.
- To update the plug-in assembly to a new version, the old version must first be unregistered. It is recommended that you use UnRegisterSolutionRequestto unregister the assembly and all related plug-ins. Use RegisterSolutionRequestto register the new version of the plug-in assembly and any plug-ins within that assembly.

## Step Registration
Step registration informs the Microsoft Dynamics CRM system about the conditions under which a plug-in is to be executed. It also defines what information is to be passed to the plug-in in the IPluginExecutionContextparameter of the IPlugin.Executemethod. 

An array of SdkMessageProcessingStepRegistrationinstances is used to set the Stepsproperty of RegisterSolutionRequest. Note that for custom workflow activities, no steps need to be defined.
Pre and Post Event Images

Images are snapshots of an entity's attributes at a given moment in time. The  SdkMessageProcessingStepImageRegistrationclass identifies a named list of entity attributes whose values are to be made available at run time to the registered plug-in. A plug-in can access these images through the `PreEntityImages` and `PostEntityImages` properties of IPluginExecutionContext. Whether the image is obtained during the pre-event or post-event of the event execution pipeline depends on which stagethe associated SdkMessageProcessingStepRegistrationinstance is being registered for. 
An array of SdkMessageProcessingStepImageRegistrationinstances is used to set the Imagesproperty of SdkMessageProcessingStepRegistration.

>**Tip:** Registering for pre or post images to access entity attribute values results in improved plug-in performance as compared to obtaining entity attributes in plug-in code through Retrieve or RetrieveMultiple requests.

>**Note:** Only entity attributes that are set to a value or null are available in the pre or post entity images.

 
First, we will register our assembly to be stored in the Database on the CRM server.  We can then register the plug-in from that assembly to be executed based on events raised in the pipeline.
-	Open thePlug-in registration tool solution located at **%CRMSDK%\tools\pluginregistration\pluginregistrationtool.sln** in Visual Studio 2010.  This tool is provided as source code and must be built prior to use. After the solution is opened, click ctrl-F5 to launch the tool.
-	Click the Create New Connection button in the toolbar and Set the following valuesand click Connect.

Field|	Value
--|--
Discovery URL	|**http://<`servername`>** if on-premise __https://<`orgname`>.crm.dynamics.com__ for North American CRM Online organizations
User Name|	administrator if on-premise or your Live ID if using CRM Online
Connect
3.	Click Yes to the prompt asking to save changes
4.	You will now be asked to provide the password for the user.  Enter pass@word1or whatever the password is for the Live ID you are using.
5.	After a short period, all available organizations will be displayed. Highlight Contoso8 or the name of the Test Organization you are using for the labs, and click Connect.
 
Figure 2
Connect to the Test Organization
6.	Click Register | Register New Assembly
 
Figure 3
Register New Assembly
7.	Browse by clicking the “…” button, locate, and select the FitnessCenterPlugins_Exercise1.dll assembly in the projects debug folder.
8.	Select Sandbox as the Isolation Mode
9.	Select Database as the location
10.	Click Register Selected Plugins
 
Figure 4
Register Selected Plugins
11.	Click OK on the resulting dialog, noting 1 assembly registered and 1 plug-in registered.
 
Figure 5
Assembly Registered
12.	Now we will register our plug-in to be executed at a step in the pipeline.  
13.	Expand the FitnessCenterPlugins_Exercise1 assembly, and right click on the BMIMeasurement.CalculateMeasurementPlug-inand select Register New Step  
 
Figure 6
Register New Step
14.	Enter the following settings:
Field	Value
Message	Create
Primary Entity	contoso_bmimeasurement
Eventing Pipeline Stage of Execution	Pre-operation (CRM 2011 Only)

Note:  We set it to Pre-operation, as we want the save to fail if an error occurs.  If the Plug-In fired at Post-operation, the data would be saved first then our Plug-In would fire, potentially leaving us with erroneous data being saved. 
13.	Leave the other settings as default and click Register New Step
 
Figure 7
Register New Step
14.	Close the Plug-in Registration Tool
 

## Plug-in Storage
Plug-ins can be deployed to the Microsoft Dynamics CRM server's database or the file system that is known as "on-disk". We strongly recommend that you deploy your plug-ins in the Microsoft Dynamics CRM database, instead of on-disk, as the primary way to deploy plug-ins for Microsoft Dynamics CRM. 

> Plug-ins stored in the database are automatically distributed across multiple Microsoft Dynamics CRM servers in a datacenter cluster. On-disk deployment of plug-ins is supported for backward compatibility with Microsoft Dynamics CRM 3.0 callouts and also to support debugging of plug-ins by using Visual Studio 2005.

Plug-ins not registered in the sandbox can be stored in the Microsoft Dynamics CRM server's database or the on-disk file system. It is strongly recommended to store production-ready plug-ins in the Microsoft Dynamics CRM database, instead of on-disk. Plug-ins stored in the database are automatically distributed across multiple Microsoft Dynamics CRM servers in a data center cluster and are included in database backups and redeployments. On-disk storage of plug-ins is useful for debugging plug-ins using Microsoft Visual Studio.

Plug-ins registered in the sandbox must be stored in the database.

## Sandbox Deployment
When deploying a plug-in to the sandbox execution environment on Microsoft Dynamics CRM Online or On-premise, the plug-in can only be registered and deployed to the database. On-disk plug-in deployment is not supported with Microsoft Dynamics CRM Online.

For on-premise or Internet-Facing Microsoft Dynamics CRM installations, when deploying plug-ins from another computer to the Microsoft Dynamics CRM server disk (on-disk deployment), the plug-in assembly must be manually copied to the server before registration. The assembly must be deployed to the following folder:
__<`installdir`>\Program Files\Microsoft CRM\server\bin\assembly__

Plug-in registration should be done after the assembly has been copied to the ...\bin\assembly folder on the server to prevent the situation where a system user causes an event in Microsoft Dynamics CRM to be raised but the registered plugin assembly does not yet exist on the server. For server database deployment, the plug-in assembly is automatically copied during plug-in registration so that the earlier situation is not an issue.

Depending on the plug-in's design, the plug-ins can require other referenced assemblies to run. Regardless of whether the plug-in is deployed to the database or disk, if the plug-in requires other assemblies to run, copies of those assemblies must be placed in the Global Assembly Cache (GAC) on each server where the  plug-in is to execute. This does not apply to a Microsoft Dynamics CRM Online server because users do not have access to the GAC on that server. In that case, the plug-in must not require other assemblies.

>__HINT:__ Before unregistering an asynchronous plug-in, stop the asynchronous service. Failure to do this can result in a situation where the plug-in has been queued to execute. But the plug-in assembly is no longer available.
 

# Debug a Plug-in

## Register and deploy the plug-in assembly.</li>
If there is another copy of the assembly at the same location and you cannot overwrite that copy because it is locked by Microsoft Dynamics CRM, you must restart the service process that was executing the plug-in. Refer to the table below for the correct service process. For more information, see Register and Deploy Plug-Ins1.
## Configure the debugger.
Attach the debugger to the process on the Microsoft Dynamics CRM server that will run your plug-in. Refer to the following table to identify the process. 
Plug-in Registration Configuration |	Service Process
--|--
online| 	`w3wp.exe`
offline| 	`Microsoft.Crm.Application.Hoster.exe`
asynchronous registered plug-ins (or custom workflow assemblies)|	`CrmAsyncService.exe`
sandbox (isolation mode)|	`Microsoft.Crm.Sandbox.WorkerProcess.exe`

If there are multiple processes running the same executable, for example multiple w3wp.exe processes, attach the debugger to all instances of the running executable process. Next, set one or more breakpoints in your plug-in code.


## Test the plug-in.
Run the Microsoft Dynamics CRM application, or other custom application that uses the SDK, and perform whatever action is required to cause the plug-in to execute. For example, if a plug-in is registered for an account creation event, create a new account.

## Debug your plug-in code.
Make any needed changes to your code so that it performs as you want. If the code is changed, compile the code into an assembly and repeat steps 1 through 4 in this procedure as necessary. However, if you change the plug-in assembly’s major or minor version numbers, you must unregister the earlier version of the assembly and register the new version. For more information, see Register and Deploy Plug-Ins.

### Register the plug-in in the database.
After the edit/compile/deploy/test/debug cycle for your plug-in has been completed, unregister the (on-disk) plug-in assembly and then reregister the plug-in in the Microsoft Dynamics CRM database. For more information, see Register and Deploy Plug-Ins.

It is possible to debug a database deployed plug-in. The compiled plug-in assembly's symbol file (.pdb) must be copied to the server's <crm-root>\Server\bin\assembly folder and Internet Information Services (IIS) must then be restarted. After debugging has been completed, you must remove the symbol file and reset IIS to prevent the process that was executing the plug-in from consuming additional memory.
 

## Debug a Sandboxed Plug-in

It is important to perform these steps before the first execution of a sandboxed plug-in. If the plug-in has already been executed, either change the code of the assembly, causing the hash of the assembly to change on the server, or restart the Microsoft Dynamics CRM Sandbox Processing Service on the sandbox server.

### Configure the Server
The sandbox host process monitors the sandbox worker process which is executing the plug-in. The host process checks if the plug-in stops responding, if it is exceeding memory thresholds, and more. If the worker process doesn't respond for than 30 seconds, it will be shutdown. In
order to debug a sandbox plug-in, you must disable this shutdown feature. To disable the shutdown feature, set the following registry key to 1
```
(DWORD): HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSCRM\SandboxDebugPlugins
```

### Follow these steps to debug a sandboxed plug-in.

- Register the plug-in in the sandbox (isolation mode) and deploy it to the Microsoft Dynamics CRM server database.
- Copy the symbol file (.pdb) of the compiled plug-in assembly to the server\bin\assembly folder on the server running the sandbox worker
process named Microsoft.Crm.Sandbox.WorkerProcess.exe. This is the server hosting the Sandbox Processing Service role.
- Follow the instructions in steps 2 through 4 presented at the beginning of this topic.
For information on debugging a plug-in using the Plug-in Profiler tool.
 

## Sample: Web Access from a Sandboxed Plug-In

> Demonstrates how to code a plug-in that has Web (network) access and be registered in the sandbox.
```cs
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Net;
// Microsoft Dynamics CRM namespace(s)
using Microsoft.Xrm.Sdk;
namespace Microsoft.Crm.Sdk.Samples
{
    /// <summary>
    /// A sandboxed plugin that can access network (Web) resources.
    /// </summary>
    /// <remarks>Register this plug-in in the sandbox. You can provide an unsecure string
    /// during registration that specifies the Web address (URI) to access from the plug-in.
    /// </remarks>
    public sealed class WebClientPlugin : IPlugin
    {
        private string webAddress;
        /// <summary>
        /// The plug-in constructor.
        /// </summary>
        /// <param name="config">The Web address to access. An empty or null string
        /// defaults to accessing www.bing.com. The Web address can use the HTTP or
        /// HTTPS protocol.</param>
        public WebClientPlugin(string config)
        {
            if (String.IsNullOrEmpty(config))
            {
                webAddress = "http://www.bing.com";
            }
            else
            {
                webAddress = config;
            }
        }
        /// <summary>
        /// Main execute method that is required by the IPlugin interface. Uses the WebClient
        /// .NET class to access the target Web address.
        /// </summary>
        /// <param name="serviceProvider">The service provider from which you can obtain the
        /// tracing service, plug-in execution context, organization service, and more.</param>
        public void Execute(IServiceProvider serviceProvider)
        {
            //Extract the tracing service for use in plug-in debugging.
            ITracingService tracingService =
            (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            try
            {
                tracingService.Trace("Downloading the target URI: " + webAddress);
                try
                {
                    // Download the target URI using a Web client. Any .NET class that uses the
                    // HTTP or HTTPS protocols and a DNS lookup should work.
                    using (WebClient client = new WebClient())
                    {
                        byte[] responseBytes = client.DownloadData(webAddress);
                        string response = Encoding.UTF8.GetString(responseBytes);
                        tracingService.Trace(response);
                        // For demonstration purposes, throw an exception so that the response
                        // is shown in the trace dialog of the Microsoft Dynamics CRM user interface.
                        throw new InvalidPluginExecutionException("WebClientPlugin completed successfully.");
                    }
                }
                catch (WebException exception)
                {
                    string str = string.Empty;
                    if (exception.Response != null)
                    {
                        using (StreamReader reader = new StreamReader(exception.Response.GetResponseStream()))
                        {
                            str = reader.ReadToEnd();
                        }
                        exception.Response.Close();
                    }
                    if (exception.Status == WebExceptionStatus.Timeout)
                    {
                        throw new InvalidPluginExecutionException("The timeout elapsed while attempting to issue the request.", exception);
                    }
                    throw new InvalidPluginExecutionException(String.Format(CultureInfo.InvariantCulture,
                    "A Web exception ocurred while attempting to issue the request. {0}: {1}",
                    exception.Message, str), exception);
                }
            }
            catch (Exception e)
            {
                tracingService.Trace("Exception: {0}", e.ToString());
                throw;
            }
        }
    }
}
```


# Workflow Extension

A great example of when to use a workflow extension is when a business process requires the ability to query for an entity’s child records.  With a workflow extension, you can program the retrieval of a parent’s related children records to either ensure that all records get an updated value, aggregate totals, or applying validation rules.

Another reason to use a workflow extension is maintenance.  If a business process is identified as having complex steps or multiple varying conditions, it will be easier to implement this business logic in code.  If there are changes in how this business process occurs, changes to code will be easier to apply than changes to a workflow using the Workflow Designer.

Another advantage of using a workflow extension is that, like workflows, they allow the ability to be restarted if an error occurs during execution.  Every time a workflow extension executes, CRM creates an entry that allows you to inspect its execution result.  You have the ability to restart the workflow without affecting the user or having the user update any information to a particular record that the workflow extension ran against.

## Create a Workflow Extension
The easiest way to create a workflow extension is to use Visual Studio.  The requirements for creating a workflow extension are as follows:

- Create a Class Library Project.
- Extend your class from CodeActivity located in the `System.Activites` namespace.
- Include a reference to `Microsoft.Xrm.Workflow` and `Microsoft.Xrm.Sdk` assemblies located in the CRM SDK.
- Sign the assembly by creating a SNK file.

The following code block is a basic shell that can be used to quickly create a workflow extension.  The entry point that CRM will utilize is the override void Execute method.  When a workflow is executed in CRM and the workflow extension is subsequently executed, CRM will pass in the information into the Execute method which allows for the TracingService, WorkflowContext, and OrganizationService to be utilized.

```csharp
using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace CustomWF
{
	public class TestWorkflow : CodeActivity
	{
		protected override void Execute(CodeActivityContext ActivityContext)
		{
			//Tracing service
			ITracingService tracing = context.GetExtension<ITracingService>();
			
			//Get the context
			IWorkflowContext WorkflowContext = ActivityContext.GetExtension<IWorkflowContext>();
			IOrganizationServiceFactory serviceFactory = ActivityContext.GetExtension<IOrganizationServiceFactory>();
			IOrganizationService service = serviceFactory.CreateOrganizationService(WorkflowContext.UserId);
		}
		
		[Input("Test")]
		public InArgument<string> Test { get;set; }
	}	
}

```

> The **TracingService** provides a way to log steps as the workflow extension is being executed.  This helps in identifying potential issues as code is being executed.  If an exception occurs, the information logged using the TracingService will be written to the entry that CRM creates when a workflow executes.  You can open this record and inspect the exception information and determine where to correct logic or an error in the code.

> The **WorkflowContext** provides information passed in by CRM about the entity record being executed and data such as the OrganizationId, BusinessId and UserId.  You can utilize this information and save time by not having to retrieve it from CRM.

> The **OrganizationService** is what is used to communicate with CRM to perform CRUD and CRM business processes.

> Input and output parameters are optional, but they provide a great way to save additional time in retrieve information.  This also allows for information to be passed as the workflow is being executed to other steps.  To retrieve a value from an input parameter, use the `GetValue()` method, and to set a value to an output parameter, use the `SetValue()` method.

