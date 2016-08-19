using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace OSProcessTools
{
    /// <summary>
    /// This is an interface for a class to start a command line utility using the shell 
    /// </summary>
    public interface IShellClass
    {
       string StartInShell();
    }
    public class ShellClass : IShellClass
    {
        string WorkingDir { get; set; }
        string Executable { get; set; }
        string Arguments { get; set; }
        string Options { get; set; }
        /// <summary>
        /// Start a command and let windows start a shell automagically accoriding to it's rules
        /// </summary>
        /// <returns>output from command that was run</returns>
        public string StartInShell()
        {
            string retVal = "";
            var proc1 = new ProcessStartInfo();
            string anyCommand;
            proc1.UseShellExecute = true;

            //proc1.WorkingDirectory = @"C:\Windows\System32";
            //proc1.FileName = @"C:\Windows\System32\cmd.exe";
            //proc1.Verb = "runas";
            StringBuilder commandString = new StringBuilder();
            commandString.AppendFormat("{0} {1} {2}", Executable, Arguments, Options);
            proc1.Arguments = commandString.ToString();
            proc1.WindowStyle = ProcessWindowStyle.Normal;
            Process.Start(proc1);
            return retVal;
        }
    }
}
