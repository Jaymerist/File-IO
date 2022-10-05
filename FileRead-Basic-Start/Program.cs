/*
       Purpose:   Demonstrate a simple File Read    
         Input:   Students.txt      
        Output:   formated output of the file     
    Written By:   Mihiri Kamiss
 Last Modified:   October 5, 2022
 */

//add the following namespace for reading/writing from/to a file
using System.IO;

namespace FileRead_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declare variables
            const string PathAndFile = @"C:\Users\mkamiss1\Documents\C3\Students.txt";
            string input;

            // 1. Test if the file exists
            if (File.Exists(PathAndFile))
            {
                // 2. Setup the StreamReader
                StreamReader reader = null;
                
                // 3. Use a try-catch-finally to read & display file contents
                try
                {
                    // 4. Open the file for reading
                    reader = File.OpenText(PathAndFile);

                    // 5. Use a while loop to loop through the file

                    while ((input = reader.ReadLine()) != null)
                    {
                        // 6. Read and display the data from a line of the file
                        Console.WriteLine(input);
                    }
                }
                catch (Exception ex)
                {
                    // 7. Display any exceptions
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // 8. Close the StreamReader
                    reader.Close();
                }
                // end of file read and display
            }
            else
            {
                // 9. Information message if the file does not exist
                Console.WriteLine($"The file, {PathAndFile}, does not exist");
            }

            Console.ReadLine();
        }
    }
}