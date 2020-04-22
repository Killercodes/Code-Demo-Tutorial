# CRM 4.0: Plug-ins

## Introduction
One method of customizing or extending the functionality of the Microsoft Dynamics CRM 4.0 on-premise product is through the integration of custom business logic (code). It is through this extension capability that you can add new data processing features to the product or alter the way business data is processed by the system. You can also define the specific conditions under which the custom business logic is to execute. Whether you are new to extending Microsoft Dynamics CRM or have been developing 3.0 callouts for some time, this article tells you what you need to know to get started learning about and writing plug-ins.

Plug-ins provide one of the most powerful customization points within Microsoft Dynamics CRM. As users work in the application, their actions cause Microsoft Dynamics CRM to trigger events that developers can use to execute custom business logic through the use of plug-ins. For example, you can register plug-ins to run business logic every time a user creates an account or deletes an activity. You can create plug-ins to run in response to a vast number of events, including plug-ins for custom entities. You can use plug-ins for a variety of features, such as synchronizing data to an external database, tracking changes in an audit log, or simply creating follow-up tasks for a newly created account.

Some of the tasks you can accomplish with plug-ins—such as populating fields with default values or specific field formatting—you can also accomplish with form JavaScript. Plug-ins have the advantage of running on the server, so you are guaranteed that these types of tasks will run even if the entity is created or updated from a bulk import or through the Web service API.

Microsoft Dynamics CRM Online does not support plug-ins. However, you can extend the functionality of the product by using workflows.

## Comparing Plug-ins to Callouts
The programming model for adding business logic extensions to Microsoft Dynamics CRM has changed in the latest Microsoft Dynamics CRM 4.0 SDK release as compared to the 3.0 release. This change was the direct result of customers asking for access to more capabilities and run-time information in plug-in code. In addition, architectural changes and feature additions to Microsoft Dynamics CRM 4.0 necessitated changes to the programming model so that plug-ins could take advantage of the new platform capabilities.

What about your existing callouts? Do you have to throw them away and develop new plug-ins? The good news is that Microsoft Dynamics CRM 4.0 is backwards compatible with the callout programming model. Your existing callouts should continue to work alongside any new plug-ins that you develop as long as you do not use any deprecated features. However, if you want to take advantage of the new Microsoft Dynamics CRM 4.0 capabilities and the rich information that is available at run time, you need to make use of the plug-in programming model.

The following points highlight what has changed when comparing the new plug-in programming model to the previous callout model.

- **Registration**
Callouts are registered by editing an XML configuration file that is stored in a specific folder on the Microsoft Dynamics CRM 3.0 server. In essence this is a static registration method. Changes to the configuration file require an IIS reset to apply the changes.
Plug-ins are registered dynamically through a new registration API. No IIS reset is required. Sample tools to register plug-ins, complete with source code, are provided in the SDK.
- **Context**
Callouts received a basic amount of data at run-time about the user who initiated an operation in Microsoft Dynamics CRM and the entity being acted upon.
Plug-ins receive a wealth of information at run-time. For more information, see the following What’s New topic.
- **Supported messages**
Callouts could only be executed in response to a subset of messages that were processed by the Microsoft Dynamics CRM platform. 
Plug-ins can execute in response to most messages being processed by the platform.
- **Mode of execution**
Callouts were executed synchronously as part of the main execution thread of the platform. Callouts that performed a lot of processing could reduce overall system performance.
Plug-ins can execute both synchronously and asynchronously. Asynchronous registered plug-ins are queued to execute at a later time and can incorporate process-intensive operations.

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
      public void Execute(IPluginExecutionContext context)
      {
         // Call the Microsoft Dynamics CRM Web services here or perform
         // some other useful work.
         throw new InvalidPluginExecutionException("Hello world!");
      }
   }
}
```
The real power of plug-ins lies in the extensive context information that is passed to the plug-in, the ability to alter some of that information as it passes through the system, and the ability to call Microsoft Dynamics CRM Web methods. For more information, refer to the SDK documentation.

## Creating the Plug-in Project
Plug-ins are implemented as classes that implement a specific interface and are contained within a signed Microsoft .NET assembly. The assembly needs to target the Microsoft .NET runtime version 2.0, which can be accomplished by creating a class library in Microsoft Visual Studio 2008 targeting the .NET Framework 2.0, 3.0, or 3.5. However, installing Microsoft Dynamics CRM 4.0 only guarantees that Microsoft .NET Framework 3.0 is installed on the server. If you need assemblies included in the Microsoft .NET Framework 3.5, you have to install that version of the framework yourself. Before we can create our first plug-in, we need to create a class library project. Follow these steps to set up your first plug-in project.

Creating the plug-in project in Microsoft Visual Studio 2008

1. Open Microsoft Visual Studio 2008.
2. On the File Menu, select New and then click Project.
3. In the New Project dialog box, select the Other Project Types > Visual Studio Solutions type, and then select the Blank Solution template.
4. Type the name ProgrammingWithDynamicsCrm4 in the Name box. Click OK.
5. On the File Menu, select Add and then click New Project.
6. In the New Project dialog box, select the Visual C# project type targeting the .NET Framework 3.0 and then select the Class Library template.
7. Type the name ProgrammingWithDynamicsCrm4.Plugins in the Name box. Click OK.
8. Delete the default Class.cs file.
9. Right-click the ProgrammingWithDynamicsCrm4.Plugins project in Solution Explorer and then click Add Reference.
10. On the Browse tab, navigate to the CRM SDK’s bin folder and select microsoft.crm.sdk.dll and microsoft.crm.sdktypeproxy.dll. Click OK.
11. Right-click the ProgrammingWithDynamicsCrm4.Plugins project in Solution Explorer and then click Add Reference.
12. On the .NET tab, select System.Web.Services. Click OK.
13. Right-click the ProgrammingWithDynamicsCrm4.Plugins project in Solution Explorer and then click Properties.
14. On the Signing tab, select the Sign The Assembly box and then select <New...> from the list below it.
15. Type the key file name ProgrammingWithDynamicsCrm4.Plugins, and then clear the Protect My Key File With A Password check box. Click OK.
16. Close the project properties window.

# Deploying the Plug-in
After compiling our plug-in registration tool, we are ready to register our first plug-in. During registration you specify which messages for specific entities will cause the plug-in to execute. Depending on the message, you can specify additional filtering or request more information to be provided to your plug-in during execution.

> **Important**
To register a plug-in you must be listed as a Deployment Administrator on the CRM server. To verify that you are a Deployment Administrator, log on to the CRM server and launch the Deployment Manager tool, which is located in the Microsoft Dynamics CRM group on the Start menu. If you are not a Deployment Administrator, the tool will show an error indicating so and then exit. If this is the case, you need to have a Deployment Administrator use this tool and add you to the list of Deployment Administrators.

When you register a plug-in, Microsoft Dynamics CRM offers you multiple registration properties:

- **Mode.** A plug-in can execute either synchronously or asynchronously.
- **Stage.** This option specifies whether the plug-in will respond to pre-events or post-events.
- **Deployment.** A plug-in can execute only on the server, within the Outlook client, or both.
- **Messages.** This option determines which Microsoft Dynamics CRM events should trigger your logic, such as Create, Update, and even Retrieve.
- **Entity.** A plug-in can execute against most of the entities, including custom entities.
- **Rank.** This option is an integer that specifies the order in which all plug-in steps should be executed.
- **Assembly Location.** This option tells Microsoft Dynamics CRM whether the assemblies are stored in the database or on the Web server’s file system.
- **Images.** You can pass attribute values from the record as either pre-images or post-images for certain message types.

You configure these plug-in properties when you register the plug-in with Microsoft Dynamics CRM.

## Mode
Microsoft Dynamics CRM allows you to execute plug-ins synchronously or asynchronously. Asynchronous plug-ins are loaded into the Microsoft CRM Asynchronous Service and executed at some point after the main event processing is complete. Asynchronous plug-ins are ideal for handling situations that are not critical to complete immediately, such as audit logging. Because the plug-in executes asynchronously, it does not negatively affect the response time for an end user who initiates the core operation.

> **Real World** In practice, most plug-ins perform tasks that users expect to see feedback on as soon as they save their changes within the CRM application. Because of this, you will probably find that most plug-ins are registered to execute synchronously. When it is determined that a plug-in can be registered to execute asynchronously, implementing a custom workflow step instead is frequently more beneficial because business users can more easily maintain the work-flow. Scenarios still exist in which an asynchronous plug-in is the right answer, but they are not very common. Microsoft Dynamics CRM does not support pre-event plug-ins configured for asynchronous operation.

# Stage
When you register a plug-in, you can configure the plug-in to run before or after the core operation takes place. A plug-in that executes before the core operation is referred to as a pre-event plug-in, while a plug-in that executes after the core operation is a post-event plug-in. Pre-event plug-ins are useful when you want to validate or alter data prior to submission. With post-event plug-ins, you can execute additional logic or integration after the data has been safely stored in the database.

> **Important** How do you know which stage to register for? If a plug-in needs to interrupt or modify values before they are committed to the database, you should register it as a pre-event plug-in. Otherwise, you end up needing to execute an additional message to apply your change when you could have accomplished this by just modifying the data before the original message’s core operation executed. On the other hand, if your plug-in needs to create a child entity whenever the parent entity type is created, you need to register it to execute during the post-event stage to have access to the newly created parent’s ID.

## Deployment
One of the great new features of Microsoft Dynamics CRM 4.0 is the ability to have your plug-in logic execute offline with the Outlook client, further extending your existing solution. You can choose to have the plug-in execute only against the server, run offline with the Outlook client, or both.

Remember that when a client goes offline and then returns online, any plug-in calls are executed after the data synchronizes with the server. If you choose to have your logic execute both with the server and offline, be prepared for Microsoft Dynamics CRM to execute your plug-in code twice.

> **CAUTION** Microsoft Dynamics CRM does not support an asynchronous implementation of a plug-in with offline deployment. If you want to have your plug-in work offline, you need to register it in synchronous mode.

## Messages
In the documentation, Microsoft Dynamics CRM 4.0 refers to server-based trigger events as messages. The Microsoft Dynamics CRM 4.0 SDK also supports all the events from Microsoft Dynamics CRM 3.0, such as `Create`, `Update`, `Delete`, and `Merge`. In addition, Microsoft Dynamics CRM 4.0 includes some new messages such as `Route`, `Retrieve`, and `RetrieveMultiple`.


## Entities
Most system and all custom entities are available for plug-in execution. Please refer to the “Supported Messages and Entities” section for more information on the supported entities.

## Rank
Rank merely denotes the order in which a plug-in should fire. Rank is simply an integer, and Microsoft Dynamics CRM starts with the plug-in with the lowest rank and then cycles through all available plug-ins. You should definitely consider the order of plug-ins, depending on the logic they perform.

## Assembly Location
You can deploy plug-in assemblies to the database, to a folder on the Microsoft Dynamics CRM server, or to the Global Assembly Cache (GAC) on the server. Typically the database is the best option because you do not need to manually copy the file to the server before registering the plug-in. Unless you have a specific need to do otherwise, we recommend that you leave the default option and deploy your plug-ins to the database.

## Images
Images provide you with the record attribute values. Images exist as pre-values (before the core plat form operation) and post-values. Not all messages allow images.

# Event Execution Pipeline
 Plug-ins run within an execution pipeline specific to the message being executed. Also executing within the pipeline is the core operation, which is implemented by Microsoft Dynamics CRM 4.0. The core operation typically consists of a database operation—either retrieving, updating, inserting, or deleting records.

The Microsoft Dynamics CRM 2011 event processing subsystem executes plug-ins based on a message pipeline execution model. A user action or an SDK method call or other application results in a message being sent to the organization Web service contains business entity and core operation information. The message is passed through the event execution pipeline where it can be read or modified by the platform core operation and any registered plug-ins.

## Parent and Child Pipelines
Some events will in turn cause other events to be executed. When this happens, a secondary pipeline is created for this event and is referred to as a child pipeline. For example, when an Opportunity is converted to an Account, the Create event is executed in a child pipeline. If you want to handle the creation of an account in this scenario, you need to specify Child as the InvocationSource when registering your plug-in step.

Typically, plug-ins only execute outside the main database transaction and cannot cause a rollback to occur. However, when a plug-in is running inside a child pipeline, it is executing inside the parent pipeline’s transaction, and if the plug-in throws an exception, the parent’s transaction will be rolled back.

- **CAUTION** One additional point to be aware of is that when you run a plug-in inside a child pipeline, you cannot use the IPluginExecutionContext interface’s CreateCrmService method. If you do, an exception is thrown. The use of the CreateCrmService method was intentionally disabled in child pipelines because it would be too easy to cause an infinite loop or a database deadlock if it were enabled. If you absolutely need to talk back to the CRM services inside a child pipeline, you can manually create a CrmService, but be sure to use it with caution. Additionally, any calls you make with your own CrmService run within their own thread and are outside transactions in which the plug-in executes. This means that if the transaction is rolled back for any reason, changes made with your instance of CrmService will not be undone.

# IPluginExecutionContext
As stated earlier, every plug-in must implement the IPlugin interface, which includes the Execute method in its definition. The Execute method takes a single argument of type IPluginExecutionContext, which provides the plug-in with the state of the current execution pipeline and a means to communicate with the Microsoft Dynamics CRM Web service API. IPluginExecutionContext has twenty-two properties and two methods, all of which are described in the following list.

- **BusinessUnitId property.** BusinessUnitId is a Guid that represents the business unit that the primary entity belongs to.

- **CallerOrigin property.** CallerOrigin is an instance of one of the following classes:

**ApplicationOrigin, AsyncServiceOrigin, OfflineOrigin, or WebServiceApiOrigin.** You can use this property to determine who initiated the pipeline. The following code determines whether the pipeline was initiated from the CRM Web service.
``` csharp
public bool IsOriginatingFromWebServiceApi(IPluginExecutionContext context)
{
    return context.CallerOrigin is WebServiceApiOrigin;
}
```
**CorrelationId, CorrelationUpdatedTime, and Depth properties.** These three properties are combined to detect infinite loops in plug-ins. If you only use the IPluginExecutionContext interface’s CreateCrmService method to create CrmService instances, you don’t need to worry about these three properties, as they will be set on the returned CrmService for you. However, if you need to create your own instance of a CrmService class, you can use these properties to initialize its CorrelationTokenValue property, which ensures safety from infinite loops. The code shown here demonstrates how to use the correlation properties when creating your own CrmService instances.

``` csharp
public CrmService GetSafeCrmService(IPluginExecutionContext context)
{
    CrmService crmService = new CrmService();
    crmService.CorrelationTokenValue = new CorrelationToken(
        context.CorrelationId,
        context.CorrelationUpdatedTime,
        context.Depth
    );

    // finish initializing crmService here...

    return crmService;
}
```
> One additional use for CorrelationId is as a unique value for logging. In a production environment you will likely have multiple plug-ins executing at the same time, and the unique ID can be useful in determining which plug-in instance is generating the log messages.

- **InitiatingUserId property.** This property is always the Guid of the user that caused the event to execute, regardless of whether the plug-in was registered to impersonate another user. See the UserId property later in this section for more information.

- **InputParameters property.** This property is an instance of Microsoft.Crm.Sdk. PropertyBag. Each value contained in PropertyBag corresponds with a property on the Request that caused this event to execute. For example, CreateRequest has a property named Target, so you would find a value in InputParameters with a key of "Target”.

> When accessing the values in InputParameters, you should use the ParameterNames static class, instead of typing keys, to avoid run-time errors caused by typos.

``` csharp
if (context.InputParameters.Contains(ParameterName.Target))
{
    DynamicEntity target = (DynamicEntity)
        context.InputParameters[ParameterName.Target];
    // ...
}
```
- **InvocationSource property.** The InvocationSource property is an integer value that you can use to determine whether the current plug-in is running in a child pipeline. Table 5-1 lists the valid values as defined by the MessageInvocationSource class.

MessageInvocationSource Values

Field|Value|Description
--|--|--
Child|1|Specifies a child pipeline
Parent|0|Specifies a parent pipeline

- **IsExecutingInOfflineMode property.** You can register plug-ins to run offline with Microsoft CRM for Outlook with Offline Access. If a plug-in is running in such a state, this Boolean property is set to true. See Chapter 10 for more information on offline plug-ins.

- **MesssageName property.** MessageName is a string property that allows the current plug-in to know the name of the message that is being executed (Create, Update, Assign, and so on).

- **Mode property.** Mode is an integer property that you can use to determine whether the plug-in is executing synchronously or asynchronously. The valid values are from the MesssageProcessingMode class, as listed in Table 5-2.

**MessageProcessingMode Values**

Field|Value|Description
--|--|--
Asynchronous|1|Specifies asynchronous processing
Synchronous|0|Specifies synchronous processing

- **OrganizationId and OrganizationName properties.** These properties contain information about the organization that the current entity belongs to and that the current pipeline is executing within.

> **CAUTION** The initial release of Microsoft Dynamics CRM 4.0 had a bug that caused the friendly organization name to be passed into the plug-in execution context instead of the actual name. When you create an organization, these two values are the same by default, but if they are different you can run into issues quickly. The main problem is that when you use the CreateCrmService method, an invalid organization is specified for the ICrmService proxy and any calls you make with it result in an unauthorized exception. At the time this book went to press, Microsoft was aware of the defect and was implementing a fix, but until the fix is released you can just keep the organization name and the friendly name identical.

- **OutputParameters property.** Similar to the InputParameters property, this property is an instance of a PropertyBag. The values in the OutputParameters property correspond with the properties on the Response for the message being executed. For example, a CreateResponse has an Id property, so a post-event plug-in could expect the corresponding value in the OutputParameters property using a key value of “Id”.

> **TIP** Using the static ParameterNames class instead of string keys is encouraged so that you’ll discover errors at compile time instead of at run time.
```
// Getting the entity id in a Post-Event for a Create message
Guid contactId = (Guid)context.OutputParameters[ParameterName.Id];
```
- **ParentContext property.** ParentContext is another instance of IPluginExecutionContext. If the current plug-in is executing in a child pipeline, ParentContext will contain the context of the parent pipeline; otherwise, ParentContext will be null.

- **PreEntityImages and. PostEntityImages properties** PreEntityImages and PostEntityImages are both PropertyBag properties. When registering a plug-in, you can specify for certain messages that you want a snapshot of the entity before or after the core operation has completed. You also specify the alias you would like to give that snapshot. Those snapshots, or images, show up in these two collections with the alias as the key. PreEntityImages contains the images from before the core operation, and PostEntityImages contains the images from after the core operation.

- **PrimaryEntityName property.** PrimaryEntityName is a string property that contains the name of the primary entity for which the pipeline is executing.

- **SecondaryEntityName property.** SecondaryEntityName is a string property that contains the name of the secondary entity for which the pipeline is executing, if one exists. A majority of the messages deal with a single entity, so this property will almost always be set to “none”. However some messages, like SetRelated, refer to two entities. In this case, you can use SecondEntityName to find out the type of the second entity.

- **SharedVariables property.** SharedVariables is a PropertyBag property that is meant to be used by plug-in developers to pass information between plug-ins. Using SharedVariables, a pre-event plug-in can pass along information to a post-event plug-in. Another potential use is to look up data in a parent pipeline step and then later access it in a child pipeline through the child’s ParentContext property’s SharedVariables property.

- **Stage property.** Stage is an integer property that a plug-in can use to determine whether it is running as a pre-event or a post-event plug-in. The valid values are from the MessageProcessingStage class, as listed in Table 5-3.

**MessageProcessingStage Values**

Field|Value|Description
--|--|--
AfterMainOperationOutsideTransaction|50|Specifies to process after the main operation, outside the transaction
BeforeMainOperationOutsideTransaction|10|Specifies to process before the main operation, outside the transaction

> There are, in fact, three other values for Stage, but they are for internal use only by Microsoft Dynamics CRM and you will receive an error if you try to register your plug-in to run in one of these stages. Just in case you run into one of these values while trying to debug an issue, they are BeforeMainOperationInsideTransaction (20), MainOperation (30), and AfterMainOperationInsideTransaction (40).

- **UserId property.** UserId is a Guid property that represents the user that the plug-in is running as for any CrmService calls. This value is typically the user that initiated the event, but if a plug-in is registered to impersonate another user, this value contains the impersonated user’s ID. See the InitiatingUserId property for more information.

- **CreateCrmService method.** This is an overloaded method that you can use to create an instance of an ICrmService interface that has the same methods as the CrmService class, which is explained in detail in Chapter 3. The arguments control impersonation within the plug-in and are explored in more depth in the “Impersonation” section later in this chapter.

- **CreateMetadataService method.** You use the CreateMetadataService method to get an instance of the IMetadataService interface that has the same methods as the MetadataService class, which is explained in detail in Chapter 3. The method accepts a single Boolean named useCurrentUserId and is used for impersonation with in the plug-in. See the next section, “Impersonation,” for more details.

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

      public void Execute(IPluginExecutionContext context)
      {
         // Do something here.
      }
   }
}
```
The first string parameter of the constructor contains public (unsecure) information. The second string parameter contains non-public (secure) information. However, the secure string is not passed to a plug-in that executes while offline.


The information that is passed to the plug-in constructor in these two strings is specified when the plug-in is registered with Microsoft Dynamics CRM. When you use the PluginRegistration tool to register a plug-in, you can enter the secure and unsecure information in the Secure Configuration and Unsecure Configuration fields provided in the Register New Step form. The PluginDeveloper tool only supports the unsecure string through its CustomConfiguration attribute of the Step tag in the register.xml input file.

## Difference between Secure / Unsecure Configuration of Plugin Registration tool

Unsecure Configuration|Secure Configuration of Plugin
--|--
Unsecure configuration information could be read by any user in CRM. Remember its public information (Eg: Parameter strings to be used in plugin could be supplied here)|The Secure Configuration information could be read only by CRM Administrators.(Eg: Restricted data from normal user could be supplied here)
Imagine that you include a plugin, plugin steps and activate them in a solution. Later solution was exported as Managed Solution to another environment. In this scenario, the supplied Unsecure configuration values would be available in the new environment.|Imagine that you include a plugin,plugin steps and activate them in asolution. Later solution was exportedas Managed Solution to anotherenvironment. In this scenario, thesupplied Secure configuration  information would NOTbe available in the new environment. The simple  reason behind this is to provide more security to the contents of Secure Configuration.

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
    public void Execute(IPluginExecutionContext context)
    {
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
    public void Execute(IPluginExecutionContext context)
    {
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

# Online vs. Offline Plug-ins
You can register plug-ins to execute in online mode, offline mode, or both. Your plug-in code can check whether it is executing in offline mode. The following code sample shows you how to determine offline plug-in execution by checking the IPluginExecutionContext.IsExecutingInOfflineMode property value.

**Example**
```csharp
using System;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.SdkTypeProxy;

namespace MyPlugins
{
   public class AccountCreateHandler: IPlugin
   {
      public void Execute(IPluginExecutionContext context)
      {
         // Check Whether the Web service is offline.            
         if (context.IsExecutingInOfflineMode)
         {
            // Do something…
         }
      }
   }
}
```
When you design a plug-in that will be registered for both online and offline execution, you should consider the possibility that the plug-in could be executed two times. The first time that the plug-in could potentially execute is while Microsoft Dynamics CRM for Microsoft Office Outlook is offline. The plug-in is then executed again when Microsoft Dynamics CRM for Outlook goes online and synchronization between Microsoft Dynamics CRM for Outlook and the Microsoft Dynamics CRM server occurs.

You can add code to your plug-in to check if the plug-in is being executed due to a synchronization between Microsoft Dynamics CRM for Outlook and the Microsoft Dynamics CRM server. To add this functionality to your plug-in, add code to inspect the CallerOrigin property of IPluginExecutionContext as shown in the following code sample.

```csharp
using System;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.SdkTypeProxy;

public class OnlinePlugin : IPlugin
{
   public void Execute(IPluginExecutionContext context)
   {
      // Check to see if this is a playback context.
      CallerOrigin callerOrigin = context.CallerOrigin;
      if (callerOrigin is OfflineOrigin)
      {
         // This plug-in was fired from the playback queue after the user
         // selected to go online within Microsoft Dynamics CRM for Outlook.
         return;
      }
      else
      {
         // Do something here.
      }
   }
}
```
When registering a plug-in for offline execution, always register the plug-in for a synchronous mode of execution. Asynchronous execution of offline plug-ins is not supported.

# Impersonation
Impersonation in Microsoft Dynamics CRM occurs when a CrmService or MetadataService call is made on behalf of another user. Plug-ins have two options for impersonation. First, they can be registered to impersonate a specific user by default. Second, they can specify a user ID to impersonate on the fly during execution.

> **Important**
Plug-in impersonation does not work offline. Actions offline are always taken by the logged-on user.

## Impersonation During Registration
When you register a plug-in, you can specify an impersonatinguserid value. In this situation, any calls to the `IPluginExecutionContext` interface’s `CreateCrmService` or `CreateMetadataService` methods with a value of true for the `useCurrentUser` argument result in a service that is impersonating the user specified at registration. Passing `false` for the useCurrentUser argument results in a service that is executing as the **system** user. In addition, the `IPluginExecutionContext` interface’s `UserId` property contains the user ID specified during registration.

## Impersonation During Execution
A plug-in’s second option for impersonation is to specify a user ID when calling the `IPluginExecutionContext` interface’s `CreateCrmService method`. This allows the plug-in to determine on the fly which user to impersonate, possibly pulling a value from a registry setting or configuration file.

> **Best Practices**
You may be wondering which method of impersonation you should use. Unless you know that you need to impersonate another user, you should simply pass in true to the useCurrentUser argument and create service instances that will behave as determined by the plug-in registration. Most often, plug-ins will be registered without an impersonatinguserid specified and you will run as the user that initiated the event. If at a later point it is determined that you need a plug-in to run with impersonation, you can change the plug-in step without needing to recompile the plug-in assembly. Avoid passing in false for useCurrentUser unless you need to because this value means that calls into the CrmService effectively run as an administrator, possibly elevating the privilege of the user who caused the plug-in to execute.

# Exception Handling
We frequently receive questions regarding exceptions when writing plug-ins. How are exceptions handled? Should all inner exceptions be handled by the plug-in? Does Microsoft Dynamics CRM automatically log exceptions? What does an end user see when an exception goes unhandled? Fortunately these questions have fairly straightforward answers, as detailed in the following sections.

## Exceptions and the Event Processing Pipeline
The impact of an unhandled exception within a plug-in on the event processing pipeline is fairly intuitive. If you registered your plug-in as a pre-event plug-in and it throws an exception or lets an exception go unhandled, no further plug-ins will execute and the core operation will not occur. If you registered your plug-in as a post-event and it throws an exception, no further plug-ins will execute, and since the core operation already occurred Microsoft Dynamics CRM will not roll it back. However, if the plug-in is executing in a child pipeline, an unhandled exception results in the parent pipeline’s core operation being rolled back.

## Exception Feedback
Microsoft Dynamics CRM logs all unhandled exceptions in the Event Viewer on the server where they occurred. In addition, if the exception generating event was initiated by the user through the Microsoft Dynamics CRM user interface, the user is presented with an error message. To control the message that the user sees, you should throw an `InvalidPluginExecution`-Exception. In this case, the Message property for the exception is displayed. If you let an exception of another type go unhandled, a generic error message may be used.

# Debugging Plug-ins
The first thing you will probably do after deploying a plug-in is attempt to execute it to see whether it works. If you are greeted with a vague error message, you can check the Event Viewer on the CRM server for more information, but eventually you will find that you need more information, especially for more advanced plug-ins. Remote debugging and logging are two common techniques used to chase down errors in plug-ins.

## Remote Debugging
By far the most powerful option, remote debugging allows you to set breakpoints in your plug-in code and step through the process in Visual Studio. The steps for setting up remote debugging are detailed in Chapter 9 in the companion book to this one: Working With Microsoft Dynamics CRM 4.0 by Mike Snyder and Jim Steger. The CRM SDK also has information to help you set up remote debugging.

The downside to remote debugging is that it blocks other calls to the CRM application while you are stepping through your code. This can be a problem if you have multiple developers working with the same environment at the same time, and it will definitely be a problem if you are trying to debug something in a production environment.

## Logging
The next-best option to discovering errors is to include extensive logging code in your plug-ins. Plug-ins typically execute in a process that is running as the Network Service user andshould have rights to access the file system. You could then write some simple logging logicto output to a text file. Example 5-17 demonstrates some simple logging code.
```csharp
//Simple logging code
private static readonly object _logLock = new Object();
protected static void LogMessage(string message)
{
    try
    {
        if (IsLoggingEnabled)
        {
            lock (_logLock)
            {
                File.AppendAllText(LogFilePath, String.Format("[{0}] {1} {2}",
                    DateTime.Now, message, Environment.NewLine));
            }
        }
    }
    catch
    {
    }
}
```
The `IsLoggingEnabled` and `LogFilePath` properties could be initialized once at startup or be implemented to check the registry at a certain frequency to determine whether logging should occur and where the log file should be created. With this method implemented, you can add logging messages to your plug-ins to help chase down those hard-to-interpret errors:
```csharp
if (IsLoggingEnabled)
{
    StringBuilder message = new StringBuilder();
    message.Append("InputParameters: ");
    foreach (PropertyBagEntry entry in context.InputParameters.Properties)
    {
        message.Append(entry.Name);
        message.Append(" ");
    }

    LogMessage(message.ToString());
}
```
> **WARNING** 
Be sure that you restrict directory access to only those users who need access to the log data, especially if the logs might contain sensitive customer data. Plug-ins execute as the user who the Microsoft Dynamics CRM Web application pool is configured to run as. By default this is the special Network Service user. This user will, of course, need write access to the log folder.

#  InputParameters and OutputParameters

##  InputParameters
The InputParameters property bag contains all the information specified in the Request class whose message caused the plug-in to execute. The keys used to obtain values from the property bag are named according to the name of the Request class instance properties. When the plug-in is executed, the information that is in the Request object is passed to the plug-in in the InputParameters property of IPluginExecutionContext. For this example, the InputParameters property bag contains two key/value pairs. The first key is named "Target" and its associated value is the target of the request, namely the account object. The second key is named "OptionalParameters" and its associated value is the OptionalParameters instance property that is defined in the Request class from which CreateRequest is derived.

InputParameters contains Object types. Therefore, you must cast the property bag values to their appropriate types. The following sample plug-in code shows how to obtain the original account object.

```csharp
DynamicEntity entity = (DynamicEntity)context.InputParameters.Properties[ParameterName.Target]
```
> **Note** The dynamic entity obtained from the InputParameters of the context contains only those attributes that are set to a value or null.

## Output Parameters

For a post-event, the OutputParameters property bag contains the result of the core operation that is returned in the Response message. The key names that are used to access the values in the OutputParameters property bag match the names of the Response class instance properties. A post-event registered plug-in can obtain the GUID from the OutputParameters property bag by using the "id" key name or ParameterName.Id.

```csharp
Guid regardingobjectid = (Guid)context.OutputParameters[ParameterName.Id]
```
If a plug-in is registered for a pre-event, the OutputParameters property bag would not contain a value for the "id" key because the core operation would not yet have occurred. 

# Pre-Image & Post Image
Plugins in Dynamics CRM, allow you to register images against the steps of a plugin assembly. Images are a way to pass the image of the record that is currently being worked upon prior or after the action has been performed. In general it could be said, it is the image of the record as is available in the SQL backend. 

Two types of Images are supported, **Pre-Image** and **Post Image**. 
> In case of **Pre-image**, you get the image of the record as is stored in the SQL database *before the CRM Platform action* has been performed. It is basically used to capture the data when the form loads.

> **Post Image**, returns the image of the record *after the CRM Platform action* has been performed. The Post Image contains the attributes value which are finally changed. We can capture the changed data before the database operation takes place. And can do any kind of validation based on the changed data. Remember it can only be registered  for update message and cannot be registered on create message.

It is there important to understand when the images would be available and what state of the record would be returned in these images. 

Say you were to register a `Pre-Image` for a plugin registered in `Pre-Create` Stage. We just mentioned above, that the image is a copy of the record as is stored in the SQL backend. Since this is the create stage and the record has not even been created as yet, there is no record in the SQL backend that can be returned in the `Pre-Image` and hence any call for the image would fail with the above error message. 

The following table explains the Pre-Image & Post-Image Availability

Image|Stage|Create|Update|Delete
--|--|--|--|--
Pre-Image|PRE|~~No~~|**Yes**|**Yes**
Pre-Image|POST|**Yes**|**Yes**|**Yes**
Post-Image|PRE|~~No~~|~~No~~|~~No~~
Post-Image|POST|**Yes**|**Yes**|~~No~~

To confuse you more
Images are snapshots of the entity’s attributes, before and after the core system operation. Following table shows when in the event pipeline different images are available:

Message|Stage|Pre-Image|Post-Image
--|--|--|--
Create|PRE|No|No
Create|POST|No|Yes
Update|PRE|Yes|No
Update|POST|Yes|Yes
Delete|PRE|Yes|No
Delete|POST|Yes|No

## The benefits of images
One of the best uses for this is in update plug-ins. As mentioned before, update plug-in target entity only contains the updated attributes. However, often the plug-in will require information from other attributes as well. Instead of issuing a retrieve, the best practice is to push the required data in an image instead.

Comparison of data before and after. This allows for various audit-type plugins, that logs what the value was before and after, or calculating the time spent in a stage or status.
These images needs to be casted into an entity, suppose you create a **LeadImage**
```csharp
DynamicEntity preLead = (DynamicEntity)context.PreEntityImages["LeadImage"];
DynamicEntity postLead = (DynamicEntity)context.PostEntityImages["LeadImage"];
```

Suppose you registered the Plugin and added a Image with name `PreImage`

**Entity preMessageImage**
```csharp
if (context.PreEntityImages.Contains("PreImage") && context.PreEntityImages["PreImage"] is Entity)
{
    preMessageImage = (Entity)context.PreEntityImages[“PreImage”];
    accountnumber = (String)preMessageImage.Attributes[“accountnumber”];
}
```

**Entity postMessageImage**
```csharp
if (context.PostEntityImages.Contains("PostImage") && context.PostEntityImages["PostImage"] is Entity)
{
    postMessageImage = (Entity)context.PostEntityImages[“PostImage”];
    accountnumber = (String)postMessageImage.Attributes[“accountnumber”];
}
```
