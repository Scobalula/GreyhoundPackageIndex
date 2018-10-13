using System;
using System.IO;
using PhilLibX;
using PhilLibX.Cryptography.Hash;
using System.Globalization;

namespace PackageIndexTool
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Title
            Console.Title = "PackageIndexTool";

            // Set Color
            Printer.SetPrefixBackgroundColor(ConsoleColor.DarkBlue);

            // Initial Print
            Printer.WriteLine("INIT", "------------------------------------------------");
            Printer.WriteLine("INIT", "Package Index Tool - A tool for working with WNI Index Files");
            Printer.WriteLine("INIT", "Developed by Scobalula");
            Printer.WriteLine("INIT", "");
            Printer.WriteLine("INIT", "    Drag and drop:");
            Printer.WriteLine("INIT", "    - WNI File/s to decompile it to a CSV");
            Printer.WriteLine("INIT", "    - CSV File/s with Hash and Name to compile to WNI");
            Printer.WriteLine("INIT", "    - TXT File/s with Name's Line by Line to FNV1a Hash and compile to WNI");
            Printer.WriteLine("INIT", "------------------------------------------------");

            // Try process the files
            try
            {
                // Loop files
                for (int i = 0; i < args.Length; i++)
                {
                    // Initialize Index Object
                    PackageIndex index = new PackageIndex();

                    // Switch method by extension
                    switch (Path.GetExtension(args[i]).ToLower())
                    {
                        // Decompile it
                        case ".wni":
                            Decompile(index, args[0]);
                            break;
                        // Compile it
                        case ".csv":
                            CompileFromCSV(index, args[0]);
                            break;
                        // Compile it and generate hashes
                        case ".txt":
                            CompileFromTXT(index, args[0]);
                            break;
                        /// Invalid
                        default:
                            Printer.WriteLine("ERROR", "Invalid file: {0}" + args[i]);
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                // Error
                Printer.WriteLine("ERROR", "An unhandled exception has occured:\n\n" + e.ToString());
            }

            // No files
            if(args.Length == 0)
                Printer.WriteLine("ERROR", "No files given.");

            // Done
            Printer.WriteLine("DONE", "Execution complete, press Enter to exit.");

            Console.ReadKey();
        }

        static void Decompile(PackageIndex index, string fileName)
        {
            // Info
            Printer.WriteLine("INFO", String.Format("Decompiling {0}", Path.GetFileName(fileName)));

            // Load it
            if(!index.Load(fileName))
            {
                Printer.WriteLine("ERROR", "Invalid Package Index File");
                return;
            }

            // Create output file
            using (StreamWriter writer = new StreamWriter(Path.GetFileNameWithoutExtension(fileName) + ".csv"))
                // Loop through entries
                foreach (var entry in index.Entries)
                    // Compile
                    writer.WriteLine("{0:x},{1}", entry.Key, entry.Value);

            // Info
            Printer.WriteLine("INFO", String.Format("Decompiled successfully", fileName));
        }

        static void CompileFromCSV(PackageIndex index, string fileName)
        {
            // Info
            Printer.WriteLine("INFO", String.Format("Compiling {0}", Path.GetFileName(fileName)));

            // Read Lines
            string[] lines = File.ReadAllLines(fileName);

            // Loop Lines
            foreach(string line in lines)
            {
                // Trim Line
                string lineTrim = line.Trim();

                // Check for comments
                if(!lineTrim.StartsWith("#"))
                {
                    // Split line
                    string[] lineSplit = lineTrim.Split(',');

                    // Check for results
                    if(lineSplit.Length > 1)
                    {
                        // Try parse the value
                        if(ulong.TryParse(lineSplit[0], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out ulong id))
                        {
                            // Mask it
                            id &= 0xFFFFFFFFFFFFFFF;

                            // Check for collision
                            if (index.Entries.ContainsKey(id))
                            {
                                // Collision Hit
                                Printer.WriteLine("WARNING", String.Format("Collision Detected: {0:x} - {1}", id, lineSplit[1]));
                                // Skip
                                continue;
                            }

                            // Add to table
                            index.Entries[id] = lineSplit[1];
                        }
                    }
                }
            }

            // Save
            index.Save(Path.GetFileNameWithoutExtension(fileName) + ".wni");

            // Info
            Printer.WriteLine("INFO", String.Format("Compiled successfully", fileName));
        }

        static void CompileFromTXT(PackageIndex index, string fileName)
        {
            // Info
            Printer.WriteLine("INFO", String.Format("Compiling {0}", Path.GetFileName(fileName)));

            // Read Lines
            string[] lines = File.ReadAllLines(fileName);

            // Loop Lines
            foreach (string line in lines)
            {
                // Trim Line
                string lineTrim = line.Trim();

                // Check for comments
                if (!lineTrim.StartsWith("#") && !String.IsNullOrWhiteSpace(lineTrim))
                {
                    // Hash the string and mask it
                    ulong id = FNV1a.Calculate64(lineTrim) & 0xFFFFFFFFFFFFFFF;

                    // Check for collision
                    if (index.Entries.ContainsKey(id))
                    {
                        // Collision Hit
                        Printer.WriteLine("WARNING", String.Format("Collision Detected: {0:x} - {1}", id, lineTrim));
                        // Skip
                        continue;
                    }

                    // Add to table
                    index.Entries[id] = lineTrim;
                }
            }

            // Save
            index.Save(Path.GetFileNameWithoutExtension(fileName) + ".wni");

            // Info
            Printer.WriteLine("INFO", String.Format("Compiled successfully", fileName));
        }

    }
}
