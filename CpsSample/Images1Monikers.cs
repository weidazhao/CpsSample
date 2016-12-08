using System;
using Microsoft.VisualStudio.Imaging.Interop;

namespace CpsSample
{
    public static class Images1Monikers
    {
        private static readonly Guid ManifestGuid = new Guid("242316b4-d103-4b4f-8cfc-b0d369edf91d");

        private const int ProjectIcon = 0;

        public static ImageMoniker ProjectIconImageMoniker
        {
            get
            {
                return new ImageMoniker { Guid = ManifestGuid, Id = ProjectIcon };
            }
        }
    }
}
