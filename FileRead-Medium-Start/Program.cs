/*
       Purpose:   Demonstrate a simple File Read of a *.csv file   
         Input:   StudentClassData.csv     
        Output:   formated output of the file     
    Written By:   
 Last Modified:   
 
 */

//add the following namespace for reading/writing from/to a file
using System.IO;
namespace FileRead_Medium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declare variables
            const string PathAndFile = @"C:\Users\mkamiss1\Documents\C3\StudentClassData.csv";
            string input,
                studentID,
                lastName,
                firstName,
                grade;
            int mark,
                count = 0;
            double average = 0;

            // 1. Test if file exists
            if (File.Exists(PathAndFile))
            {
                // 2. Setup the StreamReader
                StreamReader reader = null;

                // 3. Use a try-catch-finally to read & display file contents
                try
                {
                    // 4. Display column headers
                    Console.WriteLine($"{"ID",-12}{"Last Name",-20}{"First Name",-20}{"Mark",-3}");

                    // 5. Open the file for reading
                    reader = File.OpenText(PathAndFile);

                    // 6. Use a while loop to loop through the file
                    while ((input = reader.ReadLine()) != null)
                    {
                        // 7. Split the file on the delimeter, i.e., the comma
                        string[] parts = input.Split(',');
                        studentID = parts[0];
                        lastName = parts[1];
                        firstName = parts[2];   
                        mark = int.Parse((parts[3]));
                        // 8. Read and display the data from each line of the file
                        Console.WriteLine($"{studentID,-12}{lastName,-20}{firstName,-20}{mark,3}");

                        //increment count and add to average
                        count++;
                        average += mark;
                    }

                    //display class average to one decimal place
                    average /= count;
                    Console.WriteLine($"The class average is {average:f1}");

                }
                catch (Exception ex)
                {
                    // 9. Display any exceptions
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // 10. Close the StreamReader
                    reader.Close();
                }
                // end of file read and display
            }
            else
            {
                // 11. Information message if the file does not exist\
                Console.WriteLine($"The file, {PathAndFile}, does not exist");
            }

            Console.ReadLine();
        }
    }
}