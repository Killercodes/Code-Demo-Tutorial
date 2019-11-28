# Debugging Custom Workflow CRM 2015

Plugin Registration tool can be used to debug not just plugin assemblies, but also custom workflow assemblies. I am not sure how well known this feature is, as I could not find any documentation about this in msdn.

## Prerequisite

Use the correct version of Plugin Registration tool for your organisation. I could not use Plugin Registration tool that came along with CRM SDK 7.1.1, to debug a workflow assembly running in CRM 2015 Update 0.1 (7.0.1). I could however use Plugin Registration tool 8.0.0.7198 to debug workflow assembly running in CRMOnline 2016 (8.0.1.79). So, it seems the major version and minor version have to match to enable workflow assembly debugging.

After installing the profile, select the plugin profile node. You will now see a new button called **Profile Workflow**
<img src="/Images/workflow-profile-button.png" alt="workflow-profile-button"/>

Next, choose the CRM workflow which contains the custom workflow assembly. If the workflow has multiple custom workflow assembly steps, you will see each of these in this screen. You can choose the assembly to profile. It is best to choose “Persist to Entity” option, as you won’t see the exception when it is thrown by the workflow.

> Profile Settings
<img src="/Images/profile-settings.png">
 

Once you click OK, a clone of the workflow will be created. It will have “(Profiled)” in the end. Your original workflow will now be in **Draft** state.

> Workflow Cloned
<img src="/Images/workflow-cloned1.png">


Now execute the profiled workflow manually. Confirm that the workflow has finished running.

> Workflow Log
<img src="/Images/workflow-log.png">

Once the workflow has completed running, you can now use the serialised profile to debug the workflow assembly. After you click the “Replay Plugin Execution” button you will see this screen, which will help you to select the correct profile record.

> Debug Profile Selection
<img src="/Images/debug-profile-selection.png">

I ran the workflow manually only once and hence there is only one profile row. If the workflow ran multiple times, you will see multiple rows. After you click select, you’ll then have to choose the correct workflow assembly that matches this profile.

> Start Debug
<img src="/Images/start-debug.png">

Now attach the Visual Studio Debugger to the Plugin Registration Tool. Now is also a good time to put couple of breakpoints in the workflow assembly code in Visual Studio. Once you click “Start Execution”, the control should now be transferred to Visual Studio to facilitate debugging.

> Visual Studio Debug
<img src="/Images/visual-studio-debug.png">

The behaviour is exactly same as plugin debugging. You can step though the code, understand the root cause of any weird behaviour and resolve it. Once you complete the execution, you will see the trace logs in the profiler.

> Debug Result
<img src="/Images/debug-result.png">

One more thing: You can use this exact same process to debug an Action which has a custom assembly. Here is how the profile looks when an action with custom workflow assembly is profiled.

> Debug an action
<img src="/Images/debug-an-action.png">

Things to note:
- When a workflow step is profiled, the workflow assembly containing this activity is cloned and registered as a profiled workflow assembly. It is this assembly that is used in the workflow that has the name ending with “(Profiled)”
- Even though you can see the workflow being profiled, stopping the workflow profile using the Plugin Registration tool seems impossible. You can see what is being profiled.Profiled Workflow

In order to stop profiling, you’ll have to
- Unpublish and delete the workflow/action that ends with “(Profiled)“
- Delete the weirdly named assembly (all guid name) from the “Default Solution“. This will be under the “Plugin Assemblies” nodeCloned Workflow Assembly

