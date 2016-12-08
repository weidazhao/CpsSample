using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Build.Framework.XamlTypes;
using Microsoft.VisualStudio.ProjectSystem.Properties;

namespace CpsSample
{
    /// <summary>
    /// Generates dynamic enum values.
    /// </summary>
	public class DynamicEnumValues1Generator : IDynamicEnumValuesGenerator
    {
        /// <summary>
        /// Gets whether the dropdown property UI should allow users to type in custom strings
        /// which will be validated by <see cref="TryCreateEnumValueAsync"/>.
        /// </summary>
        public bool AllowCustomValues
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// The list of values for this property that should be displayed to the user as common options.
        /// It may not be a comprehensive list of all admissible values however.
        /// </summary>
        /// <seealso cref="AllowCustomValues"/>
        /// <seealso cref="TryCreateEnumValueAsync"/>
        public async Task<ICollection<IEnumValue>> GetListedValuesAsync()
        {
            await Task.Yield();

            List<IEnumValue> values = new List<IEnumValue>();
            values.Add(new PageEnumValue(new EnumValue() { Name = "abc", DisplayName = "abc", IsDefault = true }));
            values.Add(new PageEnumValue(new EnumValue() { Name = "def", DisplayName = "def" }));
            values.Add(new PageEnumValue(new EnumValue() { Name = "ghi", DisplayName = "ghi" }));

            return values;
        }

        /// <summary>
        /// Tries to find or create an <see cref="IEnumValue"/> based on some user supplied string.
        /// </summary>
        /// <param name="userSuppliedValue">The string entered by the user in the property page UI.</param>
        /// <returns>
        /// An instance of <see cref="IEnumValue"/> if the <paramref name="userSuppliedValue"/> was successfully used
        /// to generate or retrieve an appropriate matching <see cref="IEnumValue"/>.
        /// A task whose result is <c>null</c> otherwise.
        /// </returns>
        /// <remarks>
        /// If <see cref="AllowCustomValues"/> is false, this method is expected to return a task with a <c>null</c> result
        /// unless the <paramref name="userSuppliedValue"/> matches a value in <see cref="GetListedValuesAsync"/>.
        /// A new instance of an <see cref="IEnumValue"/> for a value
        /// that was previously included in <see cref="GetListedValuesAsync"/> may be returned.
        /// </remarks>
        public async Task<IEnumValue> TryCreateEnumValueAsync(string userSuppliedValue)
        {
            await Task.Yield();

            return new PageEnumValue(new EnumValue() { Name = userSuppliedValue, DisplayName = userSuppliedValue });
        }
    }
}
