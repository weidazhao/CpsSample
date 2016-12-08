using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.ProjectSystem;

namespace CpsSample
{
    /// <summary>
    /// Provides handling for an example special file.
    /// </summary>
    [ExportSpecialFileProvider(SpecialFiles.AssemblyInfo)]
    [AppliesTo(MyUnconfiguredProject.UniqueCapability)]
    public class SpecialFileProvider1 : ISpecialFileProvider
    {
        [ImportingConstructor]
        public SpecialFileProvider1(ConfiguredProject configuredProject)
        {
            this.SourceItemsServices = new OrderPrecedenceImportCollection<IProjectItemProvider>(projectCapabilityCheckProvider: configuredProject);
        }

        /// <summary>
        /// Gets or sets the accessor to project items.
        /// </summary>
        [ImportMany(ExportContractNames.ProjectItemProviders.SourceFiles)]
        private OrderPrecedenceImportCollection<IProjectItemProvider> SourceItemsServices { get; set; }

        private IProjectItemProvider SourceItems
        {
            get { return this.SourceItemsServices.Single().Value; }
        }

        public async Task<string> GetFileAsync(SpecialFiles fileId, SpecialFileFlags flags, CancellationToken cancellationToken = default(CancellationToken))
        {
            switch (fileId)
            {
                case SpecialFiles.AssemblyInfo:
                    IEnumerable<IProjectItem> compileItems = await this.SourceItems.GetItemsAsync("Compile");
                    foreach (IProjectItem item in compileItems)
                    {
                        if (String.Equals(Path.GetFileName(item.EvaluatedIncludeAsFullPath), "AssemblyInfo.cs", StringComparison.OrdinalIgnoreCase))
                        {
                            return item.EvaluatedIncludeAsFullPath;
                        }
                    }

                    break;
                default:
                    break;
            }

            return string.Empty;
        }
    }
}
