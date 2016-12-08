using System.Collections.Immutable;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.ProjectSystem;

namespace CpsSample
{
    /// <summary>
    /// Adds project capabilities when the project file extension matches <see cref="MyUnconfiguredProject.ProjectExtension" />."
    /// </summary>
    [Export(ExportContractNames.Scopes.UnconfiguredProject, typeof(IProjectCapabilitiesProvider))]
    [AppliesTo(ProjectCapabilities.AlwaysApplicable)]
    [SupportsFileExtension("." + MyUnconfiguredProject.ProjectExtension)]
    internal class ProjectCapabilitiesProvider1 : UnconfiguredProjectCapabilitiesProviderBase
    {
        /// <summary>
        /// The set of capabilities to add.
        /// <remarks>Use <see cref="Empty.CapabilitiesSet"/> when constructing to ensure it uses a string comparer consistent with the overall system.</remarks>
        /// </summary>
        private readonly ImmutableHashSet<string> capabilities = Empty.CapabilitiesSet.Add(MyUnconfiguredProject.UniqueCapability);

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectCapabilitiesProvider1"/> class.
        /// <param name="unconfiguredProject">The uncofigured project scope of the current project.</param>
        /// </summary>
        [ImportingConstructor]
        public ProjectCapabilitiesProvider1(UnconfiguredProject unconfiguredProject) : base(nameof(ProjectCapabilitiesProvider1), unconfiguredProject)
        {
        }

        /// <summary>
        /// Gets the capabilities that fit the project in context that this provider contributes.
        /// </summary>
        /// <value>A sequence, possibly empty but never null.</value>
        protected override Task<ImmutableHashSet<string>> GetCapabilitiesAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult<ImmutableHashSet<string>>(this.capabilities);
        }
    }
}
