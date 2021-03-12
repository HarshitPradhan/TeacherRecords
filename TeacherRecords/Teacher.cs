using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TeacherRecords
{
    class Teacher
    {
        public static void Do()
        {
            string dir = Directory.GetCurrentDirectory();
            string filename = dir + "\\TeacherData.txt";
            if (File.Exists(filename))
            {
                Console.WriteLine("File exists");
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }

            string[] createText = { "101 Harshit Haridwar 9690241945", "102 Suraj Rishikesh 8920157596", "103 Sachin Pithorgarh 8896184536" };

            File.WriteAllLines(filename,
                               createText,
                               Encoding.UTF8);

            Console.WriteLine("Enter the ID of the teacher for which the data needs to be updated");
            string id_teacher = Console.ReadLine();

            Console.WriteLine("Enter 1 to update name, 2 for city, 3 for mobile number");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new/updated value");
            string newvalue = Console.ReadLine();

            string[] contents = File.ReadAllLines(filename);
            string[] newlines = new string[5];
            int i = 0;
            string updatedline="";
            foreach(var content in contents)
            {
                if (content.Contains(id_teacher) == true)
                {
                    string curr = "";
                    if (n == 1)
                        curr = content.Split(" ")[1];
                    if (n == 2)
                        curr = content.Split(" ")[2];
                    if (n == 3)
                        curr = content.Split(" ")[3];

                    updatedline = content.Replace(curr, newvalue);

                  //  Console.WriteLine(updatedline);
                    continue;

                }
                newlines[i] = content;
                i++;
               // Console.WriteLine(newlines[i-1]);
            }
            newlines[i] = updatedline;
            File.WriteAllLines("TeacherData.txt", newlines);
            Console.WriteLine("Data Updated successfuly! Your updated data is:-");
            Console.WriteLine(updatedline);

        }
    }
}