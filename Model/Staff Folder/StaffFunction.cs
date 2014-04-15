using System;
using System.Collections.Generic;
using System.IO;
using Assignment1.Model.Staff_Folder;
using System.Text.RegularExpressions;
namespace Assignment1.Model
{
    class StaffFunction
    {
        private List<Qualification> quaList;
        private List<Staff> staList;
        private static int staId=0, quaId=0;

        public StaffFunction(List<Staff> staList, List<Qualification> quaList)
        {
            //quaList = new List<Qualification>();
            //staList = new List<Staff>();
            this.quaList = quaList;
            this.staList = staList;

            //readStaffFile();
            //readQualificationFile();
        }

        //private bool readQualificationFile()
        //{
        //    //Qualification File
        //    TextReader tr = new StreamReader(@"C:\Users\Nghia\Documents\Visual Studio 2010\Projects\Week2BTutorial\Assignment1\Model\Staff Folder\Qualification.txt");

        //    string input;
        //    while ((input = tr.ReadLine()) != null)
        //    {
        //        string[] array = input.Split(',');
        //        quaId = int.Parse(array[0].Trim());
                
        //        quaList.Add(new Qualification(quaId, array[1].Trim()));
        //    }
        //    Console.WriteLine("Qualification File Loaded Successfully.");

        //    tr.Close();
        //    quaId++;

        //    return true;
        //}

        //private bool writeQualificationFile()
        //{

        //    //Qualification file
        //    TextWriter tw = new StreamWriter(@"C:\Users\Nghia\Documents\Visual Studio 2010\Projects\Week2BTutorial\Assignment1\Model\Staff Folder\Qualification.txt");

        //    for (int i = 0; i < quaList.Count; i++)
        //    {
        //        tw.WriteLine("{0},{1}", quaList[i].Id, quaList[i].QuaName);
        //    }
        //    Console.WriteLine("Write Qualification File Successfully.");
        //    return true;
        //}

        //private bool readStaffFile()
        //{

        //    //staff File
        //    TextReader tr = new StreamReader(@"C:\Users\Nghia\Documents\Visual Studio 2010\Projects\Week2BTutorial\Assignment1\Model\Staff Folder\Staff.txt");

        //    string input;
        //    while ((input = tr.ReadLine()) != null)
        //    {
        //        string[] array = input.Split(',');
        //        staId = int.Parse(array[0].Trim());

        //        if (array[5].Contains("ass"))
        //        {
        //            staList.Add(new Assistant(staId, array[1], array[2].Trim(), array[3].Trim(), array[4].Trim(), array[5].Trim(), array[6].Trim()));
        //        }
        //        else
        //            if (array[5].Contains("exe"))
        //            {
        //                staList.Add(new Executive(staId, array[1], array[2].Trim(), array[3].Trim(), array[4].Trim(), array[5].Trim(), array[6].Trim()));
        //            }
        //            else
        //                if (array[5].Contains("rec"))
        //                {
        //                    staList.Add(new Reception(staId, array[1], array[2].Trim(), array[3].Trim(), array[4].Trim(), array[5].Trim(), array[6].Trim()));
        //                }
        //                else
        //                    if (array[5].Contains("gua"))
        //                    {
        //                        staList.Add(new Guard(staId, array[1], array[2].Trim(), array[3].Trim(), array[4].Trim(), array[5].Trim(), array[6].Trim()));
        //                    }
        //                    else

        //                        if (array[5].Contains("doc"))
        //                        {
        //                            staList.Add(new Doctor(staId, array[1], array[2].Trim(), array[3].Trim(), array[4].Trim(), array[5].Trim(), array[6].Trim()));
        //                        }
        //                        else
        //                            if (array[5].Contains("nur"))
        //                            {
        //                                staList.Add(new Nurse(staId, array[1], array[2].Trim(), array[3].Trim(), array[4].Trim(), array[5].Trim(), array[6].Trim()));
        //                            }
        //                            else
        //                            {
        //                                return false;
        //                            }

        //    }
        //    Console.WriteLine("Staff File Loaded Successfully.");
        //    staId++;

        //    tr.Close();
        //    return true;
        //}

        //public bool writeStaffFile()
        //{

        //    //Staff File
        //    TextWriter tw = new StreamWriter(@"C:\Users\Nghia\Documents\Visual Studio 2010\Projects\Week2BTutorial\Assignment1\Model\Staff Folder\Staff.txt");
        //    for (int i = 0; i < staList.Count; i++)
        //    {

        //    }
        //    Console.WriteLine("Staff File Wrote Successfully.\n");
        //    tw.Close();
        //    return true;
        //}

        private void printingBreakLine()
        {
            for (int i = 0; i < 78; i++)
            {
                Console.Write("=");
            }
            Console.Write("\n");
        }

        private void staffChoice()
        {
            printingBreakLine();
            Console.WriteLine("\tSTAFF SCREEN");
            Console.WriteLine("\tA - Add Staff.");
            Console.WriteLine("\tE - Edit Staff.");
            Console.WriteLine("\tD - Delete Staff.");
            Console.WriteLine("\tL - Staff's List.");
            Console.WriteLine("\tQ - Qualification");
            Console.WriteLine("\tB - Back to Menu Screen.");
            printingBreakLine();
        }

        public void staffMenu()
        {
            bool con = true;
            staffChoice();
            Console.WriteLine("Please enter your choice: ");
            string input = Console.ReadLine();

            while (con)
            {
                if ("a".Equals(input) || "A".Equals(input))
                {
                    //Add staff
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Adding Staff Form.");
                    printingBreakLine();
                    addStaff();
                    Console.WriteLine("\n");
                }
                else if ("e".Equals(input) || "E".Equals(input))
                {
                    //Edit staff
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Editing Staff Form.");
                    printingBreakLine();
                    editStaff();
                    Console.WriteLine("\n");
                }
                else if ("d".Equals(input) || "D".Equals(input))
                {
                    //Delete staff
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Deleting Staff Form.");
                    printingBreakLine();
                    deleteStaff();
                    Console.WriteLine("\n");
                }
                else if ("l".Equals(input) || "L".Equals(input))
                {
                    //staff List
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Staff's List.");
                    printingBreakLine();
                    staffList();
                    Console.WriteLine("\n");
                }
                else if ("q".Equals(input) || "Q".Equals(input))
                {
                    //Qualification 
                    Console.Clear();
                    qualificationMenu();
                }
                else if ("b".Equals(input) || "B".Equals(input))
                {
                    //Back to Main Menu
                    Console.Clear();
                    con = false;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("INVALID input. Please try again.");
                }

                Console.Write("\n");
                staffChoice();
                Console.WriteLine("Please enter your choice: ");
                input = Console.ReadLine();
            }
        }

        public void addStaff()
        {
            string error = "";
            string nameInput, dobInput, genderInput, staffTypeInput, jobInput, quaInput;
            bool checkIndex = false;

            string checkName = "^[a-zA-Z ]*$";
            string checkDob = "^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$";
            string checkGender = "^m$|^f$";
            string checkStaffType = "^m$|^non$";
            string checkJob = "^doctor$|^nurse$|^executive$|^assistant$|^reception$|^guard$";


            int index, input;

            Console.WriteLine("Please enter staff's name:");
            nameInput = Console.ReadLine();
            Console.WriteLine("Please enter staff's date of birth(dd/mm/yyyy): ");
            dobInput = Console.ReadLine();
            Console.WriteLine("Please enter staff's gender(f/m)");
            genderInput = Console.ReadLine();
            Console.WriteLine("Please enter staff's type(m/non): ");
            staffTypeInput = Console.ReadLine();
            Console.WriteLine("Please enter staff's job(doctor/nurse/executive/assistant/reception/guard): ");
            jobInput = Console.ReadLine();
            qualificationList();
            Console.WriteLine("Please enter qualification id: ");
            quaInput = Console.ReadLine();

            if (nameInput.Equals("") || dobInput.Equals("") || genderInput.Equals("") || staffTypeInput.Equals("")
                || jobInput.Equals("") || quaInput.Equals(""))
            {
                Console.WriteLine("All Fields must be filled. Please add again\n");
            }
            else
            {
                if (!Regex.IsMatch(nameInput, checkName))
                {
                    error += "Invalid staff's name. Name cant have special characters.\n";
                }

                if (!Regex.IsMatch(dobInput, checkDob))
                {
                    error += "Invalid staff's date of birth. DOB must be followed by dd/mm/yyyy format.\n";
                }

                if (!Regex.IsMatch(genderInput, checkGender))
                {
                    error += "Invalid staff's gender. Must be m or f(non-capitalize)\n";
                }

                if (!Regex.IsMatch(staffTypeInput, checkStaffType))
                {
                    error += "Invalid staff's type\n";
                }

                if (!Regex.IsMatch(jobInput, checkJob))
                {
                    error += "Invalid staff's job\n";
                }

                while (!int.TryParse(quaInput, out  input))
                {
                    Console.WriteLine("Invalid ID. Please try again.");
                    quaInput = Console.ReadLine();
                }

                input = int.Parse(quaInput);

                for (index = 0; index < quaList.Count; index++)
                {
                    if (input == quaList[index].Id)
                    {
                        checkIndex = true;
                        break;
                    }
                    else
                    {
                        checkIndex = false;
                    }
                }


                if (!error.Equals("") || checkIndex != true)
                {
                    Console.WriteLine(error);
                    Console.WriteLine("Invalid Qualification ID");
                }

                else
                {
                    if (jobInput.Contains("ass"))
                    {
                        staList.Add(new Assistant(staId, nameInput, dobInput, genderInput, staffTypeInput, jobInput, quaList[index].QuaName));
                    }
                    if (jobInput.Contains("exe"))
                    {
                        staList.Add(new Executive(staId, nameInput, dobInput, genderInput, staffTypeInput, jobInput, quaList[index].QuaName));
                    }
                    if (jobInput.Contains("rec"))
                    {
                        staList.Add(new Reception(staId, nameInput, dobInput, genderInput, staffTypeInput, jobInput, quaList[index].QuaName));
                    }
                    if (jobInput.Contains("gua"))
                    {
                        staList.Add(new Guard(staId, nameInput, dobInput, genderInput, staffTypeInput, jobInput, quaList[index].QuaName));
                    }

                    if (jobInput.Contains("doc"))
                    {
                        staList.Add(new Doctor(staId, nameInput, dobInput, genderInput, staffTypeInput, jobInput, quaList[index].QuaName));
                    }
                    if (jobInput.Contains("nur"))
                    {
                        staList.Add(new Nurse(staId, nameInput, dobInput, genderInput, staffTypeInput, jobInput, quaList[index].QuaName));
                    }

                    staId++;

                    Console.WriteLine("Add New Staff Successfully.");
                }

            }
        }

        private void editStaff()
        {
            int input, index;
            bool checkindex = false;
            string inputId;
            string confirm;

            staffList();
            Console.WriteLine("Please choose the ID that you want to edit: ");
            inputId = Console.ReadLine();
            while (!int.TryParse(inputId, out  input) || input < 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                inputId = Console.ReadLine();
            }

            input = int.Parse(inputId);

            for (index = 0; index < staList.Count; index++)
            {
                if (input == staList[index].Id)
                {
                    checkindex = true;
                    break;
                }
                else
                {
                    checkindex = false;
                }
            }

            if (!checkindex)
            {
                Console.WriteLine("Cannot find this staff with ID ={0}", input);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(String.Format("|{0,3}|{1,10}|{2,11}|{3,7}|{4,7}|{5,11}|{6,20}", "ID", "Name", "DOB", "Gender", "S.Type", "Job", "Qualification"));
                Console.WriteLine();
                Console.WriteLine(String.Format("|{0,3}|{1,10}|{2,11}|{3,7}|{4,7}|{5,11}|{6,20}",
                    staList[index].Id, staList[index].Name, staList[index].Dob, staList[index].Gender, staList[index].Stafftype, staList[index].Job, staList[index].Qualification));
                Console.WriteLine("Do you want to edit this patient with ID ={0}", staList[index].Id);
                Console.WriteLine("Enter your confirm input(y/n): ");
                confirm = Console.ReadLine();
                while (!Regex.IsMatch(confirm, "^y$|^n$"))
                {
                    Console.WriteLine("The confirm input must be y/n ");
                    confirm = Console.ReadLine();
                }
                if (confirm.Equals("y"))
                {
                    string error = "";
                    string nameInput, dobInput, genderInput, staffTypeInput, jobInput, quaInput;
                    bool checkIndex = false;

                    string checkName = "^[a-zA-Z ]*$";
                    string checkDob = "^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$";
                    string checkGender = "^m$|^f$";
                    string checkStaffType = "^m$|^non$";
                    string checkJob = "^doctor$|^nurse$|^executive$|^assistant$|^reception$|^guard$";

                    Console.WriteLine("Please enter staff's name:");
                    nameInput = Console.ReadLine();
                    Console.WriteLine("Please enter staff's date of birth(dd/mm/yyyy): ");
                    dobInput = Console.ReadLine();
                    Console.WriteLine("Please enter staff's gender(f/m)");
                    genderInput = Console.ReadLine();
                    Console.WriteLine("Please enter staff's type(m/non): ");
                    staffTypeInput = Console.ReadLine();
                    Console.WriteLine("Please enter staff's job(doctor/nurse/executive/assistant/reception/guard): ");
                    jobInput = Console.ReadLine();
                    qualificationList();
                    Console.WriteLine("Please enter qualification id: ");
                    quaInput = Console.ReadLine();

                    if (nameInput.Equals("") || dobInput.Equals("") || genderInput.Equals("") || staffTypeInput.Equals("")
                        || jobInput.Equals("") || quaInput.Equals(""))
                    {
                        Console.WriteLine("All Fields must be filled. Please add again\n");
                    }
                    else
                    {
                        if (!Regex.IsMatch(nameInput, checkName))
                        {
                            error += "Invalid staff's name. Name cant have special characters.\n";
                        }

                        if (!Regex.IsMatch(dobInput, checkDob))
                        {
                            error += "Invalid staff's date of birth. DOB must be followed by dd/mm/yyyy format.\n";
                        }

                        if (!Regex.IsMatch(genderInput, checkGender))
                        {
                            error += "Invalid staff's gender. Must be m or f(non-capitalize)\n";
                        }

                        if (!Regex.IsMatch(staffTypeInput, checkStaffType))
                        {
                            error += "Invalid staff's type\n";
                        }

                        if (!Regex.IsMatch(jobInput, checkJob))
                        {
                            error += "Invalid staff's job\n";
                        }

                        while (!int.TryParse(quaInput, out  input))
                        {
                            Console.WriteLine("Invalid ID. Please try again.");
                            quaInput = Console.ReadLine();
                        }

                        input = int.Parse(quaInput);

                        for (index = 0; index < quaList.Count; index++)
                        {
                            if (input == quaList[index].Id)
                            {
                                checkIndex = true;
                                break;
                            }
                            else
                            {
                                checkIndex = false;
                            }
                        }


                        if (!error.Equals("") || checkIndex != true)
                        {
                            Console.WriteLine(error);
                            Console.WriteLine("Invalid Qualification ID");
                        }

                        else
                        {
                            staList[index].Name = nameInput;
                            staList[index].Dob = dobInput;
                            staList[index].Gender = genderInput;
                            staList[index].Stafftype = staffTypeInput;
                            staList[index].Job = jobInput;
                            staList[index].Qualification = quaList[index].QuaName;
                            Console.WriteLine("Edit Staff Successfully.");

                        }

                    }

                }
                else
                {
                    Console.Clear();
                }
            }
        }

        private void deleteStaff()
        {
            int input, index;
            bool checkindex = false;
            string inputId;
            string confirm;

            staffList();
            Console.WriteLine("Please choose the ID that you want to delete: ");
            inputId = Console.ReadLine();
            while (!int.TryParse(inputId, out  input) || input < 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                inputId = Console.ReadLine();
            }

            input = int.Parse(inputId);

            for (index = 0; index < staList.Count; index++)
            {
                if (input == staList[index].Id)
                {
                    checkindex = true;
                    break;
                }
                else
                {
                    checkindex = false;
                }
            }

            if (!checkindex)
            {
                Console.WriteLine("Cannot find this staff with ID ={0}", input);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(String.Format("|{0,3}|{1,10}|{2,11}|{3,7}|{4,7}|{5,11}|{6,20}", "ID", "Name", "DOB", "Gender", "S.Type", "Job", "Qualification"));
                Console.WriteLine();
                Console.WriteLine(String.Format("|{0,3}|{1,10}|{2,11}|{3,7}|{4,7}|{5,11}|{6,20}",
                    staList[index].Id, staList[index].Name, staList[index].Dob, staList[index].Gender, staList[index].Stafftype, staList[index].Job, staList[index].Qualification));
                Console.WriteLine("Do you want to edit this patient with ID ={0}", staList[index].Id);
                Console.WriteLine("Enter your confirm input(y/n):");
                confirm = Console.ReadLine();
                while (!Regex.IsMatch(confirm, "^y$|^n$"))
                {
                    Console.WriteLine("The confirm input must be y/n ");
                    confirm = Console.ReadLine();
                }
                if (confirm.Equals("y"))
                {
                    Console.Clear();
                    staList.RemoveAt(index);
                    Console.WriteLine("Delete Staff Successfully");
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        public void staffList()
        {
            Console.WriteLine("\n");
            printingBreakLine();
            Console.WriteLine("Total number of staff is {0}", staList.Count);
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("|{0,3}|{1,10}|{2,11}|{3,7}|{4,7}|{5,11}|{6,20}", "ID", "Name", "DOB", "Gender", "S.Type", "Job", "Qualification"));
            Console.WriteLine();
            foreach (Staff s in staList)
            {
                Console.WriteLine(String.Format("|{0,3}|{1,10}|{2,11}|{3,7}|{4,7}|{5,11}|{6,20}", s.Id, s.Name, s.Dob, s.Gender, s.Stafftype, s.Job, s.Qualification));
            }

            printingBreakLine();
        }

        private void qualificationChoice()
        {
            printingBreakLine();
            Console.WriteLine("\tQUALIFICATION SCREEN");
            Console.WriteLine("\tA - Add Qualification.");
            Console.WriteLine("\tE - Edit Qualification.");
            Console.WriteLine("\tD - Delete Qualification.");
            Console.WriteLine("\tL - Qualification's List.");
            Console.WriteLine("\tB - Back to Staff Menu.");
            printingBreakLine();

        }

        private bool qualificationMenu()
        {
            bool con = true;
            qualificationChoice();
            Console.WriteLine("Please enter your choice: ");
            string input = Console.ReadLine();

            while (con)
            {
                if ("a".Equals(input) || "A".Equals(input))
                {
                    //Add staff
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Adding Qualification Form.");
                    printingBreakLine();
                    addQualification();
                    Console.WriteLine("\n");
                }
                else if ("e".Equals(input) || "E".Equals(input))
                {
                    //Edit staff
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Editing Qualification Form.");
                    printingBreakLine();
                    editQualification();
                    Console.WriteLine("\n");
                }
                else if ("d".Equals(input) || "D".Equals(input))
                {
                    //Delete staff
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Deleting Qualificaiton Form.");
                    printingBreakLine();
                    deleteQualification();
                    Console.WriteLine("\n");
                }
                else if ("l".Equals(input) || "L".Equals(input))
                {
                    //staff List
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Qualification's List.");
                    printingBreakLine();
                    qualificationList();
                    Console.WriteLine("\n");
                }

                else if ("b".Equals(input) || "B".Equals(input))
                {
                    //Back to Main Menu
                    Console.Clear();
                    con = false;

                    return con;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("INVALID input. Please try again.");
                }

                Console.Write("\n");
                qualificationChoice();
                Console.WriteLine("Please enter your choice: ");
                input = Console.ReadLine();
            }
            return con;
        }

        public void qualificationList()
        {
            Console.WriteLine("\n");
            printingBreakLine();
            //Console.WriteLine("Total number of qualification is {0}", quaList.Count);
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("|{0,3}|{1,25}|", "ID", "Qualification"));
            Console.WriteLine();
            foreach (Qualification q in quaList)
            {
                Console.WriteLine(String.Format("|{0,3}|{1,25}|", q.Id, q.QuaName));
            }
            printingBreakLine();
        }

        private void addQualification()
        {
            string error = "";
            string quaInput;
            bool checkIndex = false;

            int index;

            Console.WriteLine("Please enter qualification name: ");
            quaInput = Console.ReadLine();

            if (quaInput.Equals(""))
            {
                Console.WriteLine("All Fields must be filled. Please add again\n");
            }
            else
            {

                for (index = 0; index < quaList.Count; index++)
                {
                    if (quaInput != quaList[index].QuaName)
                    {
                        checkIndex = true;
                        break;
                    }
                    else
                    {
                        checkIndex = false;
                    }
                }


                if (!error.Equals("") || checkIndex != true)
                {
                    Console.WriteLine(error);
                    Console.WriteLine("The Qualification is duplicated");
                }

                else
                {
                    quaList.Add(new Qualification(quaId, quaInput));
                    quaId++;
                    //Console.WriteLine("Current patId is {0}", patId);
                    Console.WriteLine("Add Qualification Successfully.");
                }

            }
        }

        private void editQualification() {
            int input, index;
            bool checkindex = false;
            string inputId;
            string confirm;

            string error = "";
            string quaInput;

            qualificationList();
            Console.WriteLine("Please choose the ID Qualification that you want to delete: ");
            inputId = Console.ReadLine();
            while (!int.TryParse(inputId, out  input) || input < 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                inputId = Console.ReadLine();
            }

            input = int.Parse(inputId);

            for (index = 0; index < quaList.Count; index++)
            {
                if (input == quaList[index].Id)
                {
                    checkindex = true;
                    break;
                }
                else
                {
                    checkindex = false;
                }
            }

            if (!checkindex)
            {
                Console.WriteLine("Cannot find this Qualification with ID ={0}", input);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(String.Format("|{0,3}|{1,25}|", "ID", "Qualification"));
                Console.WriteLine();
                Console.WriteLine(String.Format("|{0,3}|{1,25}|", quaList[index].Id, quaList[index].QuaName));

                Console.WriteLine("Do you want to edit this Qualification with ID ={0}", quaList[index].Id);
                Console.WriteLine("Enter your confirm input(y/n):");
                confirm = Console.ReadLine();
                while (!Regex.IsMatch(confirm, "^y$|^n$"))
                {
                    Console.WriteLine("The confirm input must be y/n ");
                    confirm = Console.ReadLine();
                }
                if (confirm.Equals("y"))
                {
                    Console.Clear();
                    
                    Console.WriteLine("Please enter qualification name: ");
                    quaInput = Console.ReadLine();

                    if (quaInput.Equals(""))
                    {
                        Console.WriteLine("All Fields must be filled. Please add again\n");
                    }
                    else
                    {

                        for (index = 0; index < quaList.Count; index++)
                        {
                            if (quaInput != quaList[index].QuaName)
                            {
                                checkindex = true;
                                break;
                            }
                            else
                            {
                                checkindex = false;
                            }
                        }


                        if (!error.Equals("") || checkindex != true)
                        {
                            Console.WriteLine(error);
                            Console.WriteLine("The Qualification is duplicated");
                        }

                        else
                        {
                            quaList[index].QuaName = quaInput; 
                            quaId++;
                            //Console.WriteLine("Current patId is {0}", patId);
                            Console.WriteLine("Edit Qualification Successfully");
                        }

                    }       
                    
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        private void deleteQualification()
        {
            int input, index;
            bool checkindex = false;
            string inputId;
            string confirm;

            qualificationList();
            Console.WriteLine("Please choose the ID Qualification that you want to delete: ");
            inputId = Console.ReadLine();
            while (!int.TryParse(inputId, out  input) || input < 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                inputId = Console.ReadLine();
            }

            input = int.Parse(inputId);

            for (index = 0; index < quaList.Count; index++)
            {
                if (input == quaList[index].Id)
                {
                    checkindex = true;
                    break;
                }
                else
                {
                    checkindex = false;
                }
            }

            if (!checkindex)
            {
                Console.WriteLine("Cannot find this Qualification with ID ={0}", input);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(String.Format("|{0,3}|{1,25}|", "ID", "Qualification"));
                Console.WriteLine();
                Console.WriteLine(String.Format("|{0,3}|{1,25}|", quaList[index].Id, quaList[index].QuaName));

                Console.WriteLine("Do you want to delete this Qualification with ID ={0}", quaList[index].Id);
                Console.WriteLine("Enter your confirm input(y/n):");
                confirm = Console.ReadLine();
                while (!Regex.IsMatch(confirm, "^y$|^n$"))
                {
                    Console.WriteLine("The confirm input must be y/n ");
                    confirm = Console.ReadLine();
                }
                if (confirm.Equals("y"))
                {
                    Console.Clear();
                    quaList.RemoveAt(index);
                    Console.WriteLine("Delete Qualification Successfully");
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
}
