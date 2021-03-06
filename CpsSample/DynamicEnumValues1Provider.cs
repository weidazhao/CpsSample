﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Build.Framework.XamlTypes;
using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.Properties;

namespace CpsSample
{
    /// <summary>
    /// Custom property page dynamic enum value provider
    /// </summary>
    /*
    TODO: Please refer to the online documentation for current limitations and issues related to IDynamicEnumValuesProvider at https://github.com/Microsoft/VSProjectSystem/blob/master/doc/extensibility/IDynamicEnumValuesProvider.md
    TODO: Follow these additional steps to see the editor in action

    Step1: Insert the following snippet before the closing tag in this file:
    * BuildSystem\Rules\csharp.browseobject.xaml

    <DynamicEnumProperty Name="MyProperty" DisplayName="My Property" Visible="True" Description="Sample property" EnumProvider="DynamicEnumValues1Provider" />

    This will expose a new property "My Property" in the "Properties" pane that uses the editor.

    Step 2: Select a .cs file from a project of your project type (e.g. Program.cs)

    Step 3: In the "Properties" pane, you should see a new property "My Property". Expanding the drop down will show the values generated by the DynamicEnumValues1Generator class.
    */
    [ExportDynamicEnumValuesProvider("DynamicEnumValues1Provider")]
    [AppliesTo(MyUnconfiguredProject.UniqueCapability)]
    public class DynamicEnumValues1Provider : IDynamicEnumValuesProvider
    {
        /// <summary>
        /// Returns an <see cref="IDynamicEnumValuesGenerator"/> instance prepared to generate dynamic enum values
        /// given an (optional) set of options.
        /// </summary>
        /// <param name="options">
        /// A set of options set in XAML that helps to customize the behavior of the
        /// <see cref="IDynamicEnumValuesGenerator "/> instance in some way.
        /// </param>
        /// <returns>
        /// Either a new <see cref="IDynamicEnumValuesGenerator"/> instance
        /// or an existing one, if the existing one can serve responses based on the given <paramref name="options"/>.
        /// </returns>
        public async Task<IDynamicEnumValuesGenerator> GetProviderAsync(IList<NameValuePair> options)
        {
            // TODO: Provide your own implementation
            await Task.Yield();

            return new DynamicEnumValues1Generator();
        }
    }
}
