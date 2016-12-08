using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.Properties;

namespace CpsSample
{
    /// <summary>
    /// Custom property page value editor
    /// </summary>
    /*
    TODO: Follow these additional steps to see the editor in action

    Step1: Insert the following snippet before the closing tag in this file:
    * BuildSystem\Rules\csharp.browseobject.xaml

    <StringProperty Name="MyProperty" DisplayName="My Property" Visible="True" Description="Sample property">
        <StringProperty.ValueEditors>
            <ValueEditor EditorType="ValueEditor1" DisplayName="&lt;ValueEditor1...&gt;" />
        </StringProperty.ValueEditors>
    </StringProperty>

    This will expose a new property "My Property" in the "Properties" pane that uses the editor.

    Step 2: Select a .cs file from a project of your project type (e.g. Program.cs)

    Step 3: In the "Properties" pane, type some string as the value (e.g. "abc")

    Step 4: Expand the dropdown, and click on "<ValueEditor1...>". This will revert the string so it will become "cba"
    */
    [Export(typeof(IPropertyPageUIValueEditor))]
    [ExportMetadata("Name", "ValueEditor1")]
    [AppliesTo(MyUnconfiguredProject.UniqueCapability)]
    internal class ValueEditor1 : IPropertyPageUIValueEditor
    {
        /// <summary>
        /// Invokes the editor.
        /// </summary>
        /// <param name="serviceProvider">The set of potential services the component can query for, mainly for access back to the host itself.</param>
        /// <param name="ruleProperty">the property being edited</param>
        /// <param name="currentValue">the current value of the property (may be different than property.Value - for example if host UI caches the new values until Apply button)</param>
        /// <returns>The new value.  May be <paramref name="currentValue"/> if no change is intended.</returns>
        public async Task<object> EditValueAsync(IServiceProvider serviceProvider, IProperty ruleProperty, object currentValue)
        {
            // TODO: Provide your own editor implementation
            await Task.Yield();
            string currentString = currentValue as string;

            // As sample, we provide a simple editor that reverts the original string
            char[] characters = currentString.ToCharArray();
            Array.Reverse(characters);
            string newString = new string(characters);

            return newString;
        }

    }
}
