using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.ProjectSystem;

namespace CpsSample
{
    [Export(typeof(IVetoProjectLoad))]
    [AppliesTo(MyUnconfiguredProject.UniqueCapability)]
    internal class VetoProjectLoad1 : IVetoProjectLoad
    {
        /// <summary>
        /// Gets or sets the unconfigured project.
        /// </summary>
        /// <remarks>
        /// This import is important because it forces the MEF part into the unconfigured project
        /// level composition, so that the project capability constraints can apply.
        /// </remarks>
        [Import]
        private UnconfiguredProject UnconfiguredProject { get; set; }

        public async Task<bool> AllowProjectLoadAsync(bool isNewProject, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.Yield();
            return true;
        }
    }
}
