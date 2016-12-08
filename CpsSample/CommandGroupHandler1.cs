using System;
using System.Collections.Immutable;
using System.Windows;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.ProjectSystem;

namespace CpsSample
{
    /// <summary>
    /// Provides implementation for handling commands.
    /// </summary>
    // TODO: If your implementation is async, consider using IAsyncCommandGroupHandler instead of ICommandGroupHandler
    // TODO: Replace the Guid specified in the ExportCommandGroup attribute with the group id of your commands
    [ExportCommandGroup(VSConstants.CMDSETID.StandardCommandSet97_string)]
    [AppliesTo(MyUnconfiguredProject.UniqueCapability)]
    internal class CommandGroupHandler1 : ICommandGroupHandler
    {
        /// <summary>
        /// Check if a specific command is supported and enabled.
        /// </summary>
        /// <param name="nodes">The project nodes being queried.</param>
        /// <param name="commandId">The command ID.</param>
        /// <param name="focused">A value indicating whether <paramref name="nodes"/> or the project have the user focus.
        ///     A value of <c>false</c> indicates this command is being routed through the application in search of command handlers to process a command that the focused UI did not handle.</param>
        /// <param name="commandText">The default caption of the command that is displayed to the user.  <c>null</c> to allow the default caption to be used.</param>
        /// <param name="progressiveStatus">The query result thus far (as default, or as handed off from previous handler).</param>
        /// <returns>A value that describes how this command may be handled.</returns>
        public CommandStatusResult GetCommandStatus(IImmutableSet<IProjectTree> nodes, long commandId, bool focused, string commandText, CommandStatus progressiveStatus)
        {
            CommandStatusResult result = CommandStatusResult.Unhandled;

            // TODO: Handle your commands here
            switch ((VSConstants.VSStd97CmdID)commandId)
            {
                // Enable the View In Browser command. You can invoke it by using right click on the project View -> View In Browser or on any of the project files
                case VSConstants.VSStd97CmdID.PreviewInBrowser:
                    progressiveStatus |= CommandStatus.Enabled | CommandStatus.Supported;
                    result = new CommandStatusResult(true, commandText, progressiveStatus);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Indicates that the user wants to execute a specific command.
        /// </summary>
        /// <param name="nodes">The project nodes to execute on.</param>
        /// <param name="commandId">The command ID.</param>
        /// <param name="focused">A value indicating whether <paramref name="nodes"/> or the project have the user focus.
        ///     A value of <c>false</c> indicates this command is being routed through the application in search of command handlers to process a command that the focused UI did not handle.</param>
        /// <param name="commandExecuteOptions">Values describe how the object should execute the command.</param>
        /// <param name="variantArgIn">Pointer to a VARIANTARG structure containing input arguments. Can be NULL</param>
        /// <param name="variantArgOut">VARIANTARG structure to receive command output. Can be NULL.</param>
        /// <returns>true if the extension has handled execution for this command and should prevent other handlers from processing the command. false otherwise.</returns>
        public bool TryHandleCommand(IImmutableSet<IProjectTree> nodes, long commandId, bool focused, long commandExecuteOptions, IntPtr variantArgIn, IntPtr variantArgOut)
        {
            bool result = false;

            // TODO: Handle your commands here
            switch ((VSConstants.VSStd97CmdID)commandId)
            {
                // Display a message for the View In Browser command. You can invoke it by using right click on the project View -> View In Browser or on any of the project files
                case VSConstants.VSStd97CmdID.PreviewInBrowser:
                    MessageBox.Show("Hello World!");
                    result = true;
                    break;
            }

            return result;
        }
    }
}
