namespace PipeToNotepad
{
    using System;
    using System.Diagnostics;
    using System.IO;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string filePath = String.Format("{0}.txt", Path.GetTempFileName());
            using (var writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                string line;
                while ((line = Console.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }
            }

            string app = args.Length > 0 ? args[0] : String.Empty;
            string processName = null;
            switch (app)
            {
                case "np":
                    processName = "notepad++.exe";
                    break;
            }

            if (processName != null)
            {
                Process.Start(processName, filePath);
            }
            else
            {
                Process.Start(filePath);
            }
        }
    }
}
