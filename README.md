# PowerShell xunit demo

Simple example project showing how to use xunit with PowerShell projects that target `netstandard`.

## Things to note

- To pull in `Microsoft.PowerShell.SDK` you need the `nuget.config` file.
- The SDK is required when running tests because `xunit` tries to use the reference library. All of
  the methods/properties in the reference library are empty and return null
- A new configuration was added for `Test` that must be specified when running `xunit` tests
- Customizations in the `sln` file prevent the tests from being built in any configuration other than `Test`.
  See "Solution File Changes" for more info

## Solution File Changes

1. The configuration `Test` was added for all projects
1. The `.Build.0` option was removed for all configurations other than `Test` in the xunit project.

You can make these changes with the configuration manager in Visual Studio, or you can do the following
manually.

1. Under the following text
    ```none
        Release|Any CPU = Release|Any CPU
        Release|x64 = Release|x64
        Release|x86 = Release|x86
    ```

    Add this

    ```none
        Test|Any CPU = Test|Any CPU
        Test|x64 = Test|x64
        Test|x86 = Test|x86
    ```

1. Find the text that looks like this, except where `{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}` is the
    Guid of your test project.

    ```none
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Debug|x64.ActiveCfg = Debug|x64
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Debug|x64.Build.0 = Debug|x64
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Debug|x86.ActiveCfg = Debug|x86
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Debug|x86.Build.0 = Debug|x86
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Release|Any CPU.Build.0 = Release|Any CPU
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Release|x64.ActiveCfg = Release|x64
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Release|x64.Build.0 = Release|x64
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Release|x86.ActiveCfg = Release|x86
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Release|x86.Build.0 = Release|x86
    ```

    And modify it to look like this

    ```none
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Debug|x64.ActiveCfg = Debug|x64
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Debug|x86.ActiveCfg = Debug|x86
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Release|x64.ActiveCfg = Release|x64
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Release|x86.ActiveCfg = Release|x86
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Test|Any CPU.ActiveCfg = Test|Any CPU
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Test|Any CPU.Build.0 = Test|Any CPU
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Test|x64.ActiveCfg = Test|x64
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Test|x64.Build.0 = Test|x64
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Test|x86.ActiveCfg = Test|x86
        {XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}.Test|x86.Build.0 = Test|x86
    ```

    *Note*: Make sure to remove the lines with `.Build.0` for configurations other than test.

## Running xunit

1. `cd .\test\DemoAssembly.Tests`
1. `dotnet xunit -fxversion 2.0.5 --configuration Test`

<sub>**Note**: "fxversion" will vary depending on what runtimes are installed.</sub>