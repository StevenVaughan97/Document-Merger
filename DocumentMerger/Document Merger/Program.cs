using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Document Merger \n");

            var rerun = "yes";
            while (rerun == "yes")
            {
                String file1;
                String file2;
                String name1;
                String name2;
                String mergeFile;

                {

                    Console.WriteLine("Please enter the name for the first text file:");
                    name1 = Console.ReadLine();
                    file1 = name1 + ".txt";

                    while (File.Exists(file1) == false)
                    {
                        Console.WriteLine("File does not exists.");
                        Console.WriteLine("Please enter a different file's name: ");
                        file1 = Console.ReadLine();
                    }

                    Console.WriteLine("\nPlease enter the name for the second text file:");
                    name2 = Console.ReadLine();
                    file2 = name2 + ".txt";

                    while (File.Exists(file2) == false)
                    {
                        Console.WriteLine("File does not exists.");
                        Console.WriteLine("Please enter a different file's name: ");
                        file2 = Console.ReadLine();
                    }

                    mergeFile = name1 + name2 + ".txt";

                    String line = "";
                    String line2 = "";
                    String result = "";
                    int count = 0;
                    StreamReader sr1 = new StreamReader(file1);
                    StreamReader sr2 = new StreamReader(file2);
                    StreamWriter sw = new StreamWriter(mergeFile);


                    try
                    {
                        while ((line = sr1.ReadLine()) != null)
                        {
                            count += line.Length;
                            result += line;
                        }

                        while ((line2 = sr2.ReadLine()) != null)
                        {
                            count += line2.Length;
                            result += line2;
                        }
                        sw.WriteLine(result);

                        Console.WriteLine("\n");
                        Console.WriteLine(mergeFile + " was successfully saved.\n");
                        Console.WriteLine("The document contains " + count + " characters.\n");
                        Console.WriteLine(mergeFile + " and " + count + " are placeholders for the filename of the document and the number of characters it contains.\n");

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        sr1.Close();
                        sr2.Close();
                        sw.Close();
                    }
                }
                Console.WriteLine("Would you like to merge two more files?");
                Console.WriteLine("Enter 'yes' to merge 2 more files or 'no' to exit the program:");
                rerun = Console.ReadLine();
            }
        }
    }
}