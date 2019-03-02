using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static void Main(string[] args)

        {

            Console.WriteLine("Document Merger -");

            Console.Write("Enter the name of the first text file: ");
            string firstDocument = Console.ReadLine();

            while (firstDocument == null || firstDocument == "")
            {
                Console.WriteLine("File Name can not be blank. Please check your spelling and try again");
                Console.Write("Enter the name of the first text file: ");
                firstDocument = Console.ReadLine();
            }

            Console.Write("Enter the name of the second text file: ");
            string secondDocument = Console.ReadLine();

            while (secondDocument == null || secondDocument == "")
            {
                Console.WriteLine("File Name can not be blank. Please check your spelling and try again");
                Console.Write("Enter the name of the second text file: ");
                secondDocument = Console.ReadLine();
            }

            try
            {
                string finalString = "--First Document--" + Environment.NewLine;

                StreamReader text = new StreamReader(firstDocument);
                string line;

                while ((line = text.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    finalString += line + Environment.NewLine;
                }

                text.Close();
                
                finalString += "--Second Document--" + Environment.NewLine;
                StreamReader text2 = new StreamReader(secondDocument);
                string line2;

                while ((line2 = text2.ReadLine()) != null)
                {
                    Console.WriteLine(line2);
                    finalString += line2 + Environment.NewLine;
                }

                finalString += Environment.NewLine;
                text2.Close();

                string finalPathName = @"C:\Users\Moballin\Desktop\" + Path.GetFileNameWithoutExtension(firstDocument) + Path.GetFileNameWithoutExtension(secondDocument) + ".txt";

                File.Create(finalPathName);
                Console.WriteLine(finalString);

                TextWriter finalWriter = new StreamWriter(finalPathName);
                finalWriter.Close();

                Console.WriteLine(finalWriter + " was successfully saved. The document contains" + finalPathName.Length + " characters.");

                File.WriteAllText(finalPathName, finalString);
               
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("You've reached the finally block");
                Console.ReadLine();
            }

        }
    }
}