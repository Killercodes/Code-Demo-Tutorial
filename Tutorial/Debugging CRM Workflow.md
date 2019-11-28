# Debugging custom workflow assemblies


# My cool project and above is the logo of it

Plugin Registration tool can be used to debug not just plugin assemblies, but also custom workflow assemblies. I am not sure how well known this feature is, as I could not find any documentation about this in msdn.

## Prerequisite

Use the correct version of Plugin Registration tool for your organisation. I could not use Plugin Registration tool that came along with CRM SDK 7.1.1, to debug a workflow assembly running in CRM 2015 Update 0.1 (7.0.1). I could however use Plugin Registration tool 8.0.0.7198 to debug workflow assembly running in CRMOnline 2016 (8.0.1.79). So, it seems the major version and minor version have to match to enable workflow assembly debugging.

After installing the profile, select the plugin profile node. You will now see a new button called **Profile Workflow**

<img src="/Images/workflow-profile-button.png" alt="My cool logo"/>


