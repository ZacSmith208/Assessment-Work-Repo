using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Git_Diff_Assessment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // in the main part of the program all of the methods and functions are called

            string fileOneName, fileTwoName, fileOne, fileTwo;
            bool fileComparisonAns = false;
            bool endProgram = false;
            string userinput;
            while (endProgram == false)
            {
                Console.WriteLine("Enter the first file you want to compare:");
                fileOneName = checkIfTextFileExists();
                Console.WriteLine("Enter the second you file you want to compare: ");
                fileTwoName = checkIfTextFileExists();
                fileOne = System.IO.File.ReadAllText(Path.GetFullPath(fileOneName));
                fileTwo = System.IO.File.ReadAllText(Path.GetFullPath(fileTwoName));
                fileComparisonAns = doComparison(fileOne, fileTwo);
                printResult(fileComparisonAns, fileOneName, fileTwoName);
                Console.WriteLine("Do you want to end program?Y/N");
                userinput = Console.ReadLine();
                if (userinput == "y" || userinput == "Y")
                {
                    endProgram = true;
                }
                else
                {
                    break;
                }
            }


        }

        //in this function, the user inputs a file, and the program checks that it exists
        public static string checkIfTextFileExists()
        {
            bool doesFileExist = false;
            string file = "";
            Console.WriteLine("In form of <textfile.txt>");
            file = Console.ReadLine();
            while (doesFileExist == false)
            {
                if (File.Exists(file))
                {
                    doesFileExist = true;
                }
                else
                {
                    Console.WriteLine("File does not exist, please enter a real file: ");
                    Console.WriteLine("In form of <textfile.txt>");
                    file = Console.ReadLine();
                }
            }
            Console.WriteLine("File Exists");
            return file;
        }

        //here is where the files contents are compared, and a boolean value is returned declaring whether the files are the same or not
        public static bool doComparison(string firstFile, string secondFile)
        {
            bool areFilesSame = true;
            char[] arrayFileOne = firstFile.ToCharArray();
            char[] arrayFileTwo = secondFile.ToCharArray();
            char fileOneCharacter, fileTwoCharacter;


            if (arrayFileOne.Length != arrayFileTwo.Length)
            {
                areFilesSame = false;
            }
            else
            {
                
                
                foreach (int n in arrayFileOne)
                {
                    fileOneCharacter = arrayFileOne[n];
                    fileTwoCharacter = arrayFileTwo[n];
                    if(fileOneCharacter != fileTwoCharacter)
                    {
                         areFilesSame = false;
                    }
                    else
                    {
                        break; 
                    }
                }
                
            }
            return areFilesSame;
        }

        //this simply outputs to the user what the values reveal
        public static void printResult(bool result, string nameFileOne, string nameFiletwo)
        {
            if (result == true)
            {
                Console.WriteLine(nameFileOne + " and " + nameFiletwo + " are not different");
            }
            else
            {
                Console.WriteLine(nameFileOne + " and " + nameFiletwo + " are different");
            }
        }
    }
}
