using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace Assignment1.Model
{
    class PatientFunction
    {
        private List<Patient> patList;
        private static int patId=0;
        public PatientFunction(List<Patient> patList)
        {
            this.patList = patList;

            //patList = new List<Patient>();
            //readPatientFile();
        }

        private void printingBreakLine()
        {
            for (int i = 0; i < 78; i++)
            {
                Console.Write("=");
            }
            Console.Write("\n");
        }

        //private bool readPatientFile()
        //{

        //    //Patient File
        //    TextReader tr = new StreamReader(@"C:\Users\Nghia\Documents\Visual Studio 2010\Projects\Week2BTutorial\Assignment1\Model\Patient Folder\Patient.txt");

        //    string input;
        //    while ((input = tr.ReadLine()) != null)
        //    {
        //        string[] array = input.Split(',');
        //        patId = int.Parse(array[0].Trim());
        //        patList.Add(new Patient(patId, array[1], array[2].Trim(), array[3].Trim(), array[4].Trim(), array[5].Trim()));

        //    }
        //    Console.WriteLine("Patient File Loaded Successfully.");
        //    patId++;
        //    //Console.WriteLine("Current patID is {0}\n", patId);
        //    tr.Close();

        //    return true;
        //}

        //public bool writePatientFile()
        //{
            
        //    //Patient File
        //    TextWriter tw = new StreamWriter(@"C:\Users\Nghia\Documents\Visual Studio 2010\Projects\Week2BTutorial\Assignment1\Model\Patient Folder\Patient.txt");
        //    for (int i = 0; i < patList.Count; i++)
        //    {
        //        tw.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", patList[i].Id, patList[i].Name, patList[i].Phone, patList[i].Dob, patList[i].Gender, patList[i].Address);
        //    }
        //    Console.WriteLine("Write Patient File Successfully.\n");
        //    tw.Close();
        //    return true;
        //}

        public bool patientMenu()
        {
            bool con = true;
            patientChoice();
            Console.WriteLine("Please enter your choice: ");
            string input = Console.ReadLine();

            while (con)
            {
                if ("a".Equals(input) || "A".Equals(input))
                {
                    //Add Patient
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Adding Patient Form.");
                    printingBreakLine();
                    addPatient();
                    Console.WriteLine("\n");
                }
                else if ("e".Equals(input) || "E".Equals(input))
                {
                    //Edit Patient
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Editing Patient Form.");
                    printingBreakLine();
                    editPatient();
                    Console.WriteLine("\n");
                }
                else if ("d".Equals(input) || "D".Equals(input))
                {
                    //Delete Patient
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Deleting Patient Form.");
                    printingBreakLine();
                    deletePatient();
                    Console.WriteLine("\n");
                }
                else if ("l".Equals(input) || "L".Equals(input))
                {
                    //Patient List
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Patient's List.");
                    printingBreakLine();
                    patientList();
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
                patientChoice();
                Console.WriteLine("Please enter your choice: ");
                input = Console.ReadLine();
            }
            return con;
        }

        private void patientChoice()
        {
            printingBreakLine();
            Console.WriteLine("\tPATIENT SCREEN");
            Console.WriteLine("\tA - Add Patient.");
            Console.WriteLine("\tE - Edit Patient.");
            Console.WriteLine("\tD - Delete Patient.");
            Console.WriteLine("\tL - Patient List.");
            Console.WriteLine("\tB - Back to Menu Screen.");
            printingBreakLine();
        }

        //Add patient method
        public int addPatient()
        {
            //Patient p;
            string error = "";
            string nameInput, dobInput, genderInput, addressInput;
            string phoneInput;
            int index=0;
            string checkName = "^[a-zA-Z ]*$";
            string checkPhone1 = "^((012[0-9])|(016[2-9])|(09[0-9])|(0188)|(0199))[0-9]{7}$";
            string checkPhone2 = "^08[0-9]{8}$";
            string checkDob = "^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$";
            string checkGender = "^m$|^f$";
            string checkAddress = "[a-zA-Z0-9 ,./]+";
            
            Console.WriteLine("Please enter patient's name:");
            nameInput = Console.ReadLine();
            Console.WriteLine("Please enter patient's phone: ");
            phoneInput = Console.ReadLine();
            Console.WriteLine("Please enter patient's date of birth(dd/mm/yyyy): ");
            dobInput = Console.ReadLine();
            Console.WriteLine("Please enter patient's gender(f/m): ");
            genderInput = Console.ReadLine();
            Console.WriteLine("Please enter patient's address: ");
            addressInput = Console.ReadLine();
            Console.WriteLine("\n");

            if (nameInput.Equals("") || dobInput.Equals("") || genderInput.Equals("") || addressInput.Equals(""))
            {
                Console.WriteLine("All Fields must be filled. Please add again\n");
            }
            else
            {
                if (!Regex.IsMatch(nameInput, checkName))
                {
                    error += "Invalid patient's name. Name cant have special characters.\n";
                }

                if (!Regex.IsMatch(phoneInput, checkPhone1) && !Regex.IsMatch(phoneInput, checkPhone2))
                {
                    error += "Invalid patient's phone. Phone number must be followed by cellphone or telephone format.\n";

                }

                if (!Regex.IsMatch(dobInput, checkDob))
                {
                    error += "Invalid patient's date of birth. DOB must be followed by dd/mm/yyyy format.\n";
                }

                if (!Regex.IsMatch(genderInput, checkGender))
                {
                    error += "Invalid patient's gender. Must be m or f(non-capitalize)\n";
                }

                if (!Regex.IsMatch(addressInput, checkAddress))
                {
                    error += "Invalid patient's address\n";
                }

                if (!error.Equals(""))
                {
                    Console.WriteLine(error);
                }

                else
                {
                    
                    patList.Add(new Patient(patId, nameInput, phoneInput, dobInput, genderInput, addressInput));
                    index = patList.Count - 1;
                    patId++;
                    Console.WriteLine("Add New Patient Successfully.");

                }

            }
            return index;
        }

        //Edit patient method
        private void editPatient()
        {
            int input, index;
            bool checkindex = false;
            string inputId;
            string confirm;

            patientList();
            Console.WriteLine("Please choose the Patient's ID that you want to edit: ");
            inputId = Console.ReadLine();
            while (!int.TryParse(inputId, out  input) || input < 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                inputId = Console.ReadLine();
            }

            input = int.Parse(inputId);

            for (index = 0; index < patList.Count; index++)
            {
                if (input == patList[index].Id)
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
                Console.WriteLine("Cannot find this patient with ID ={0}", input);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(String.Format("|{0,3}|{1,15}|{2,11}|{3,11}|{4,7}|{5,15}", "ID", "Name", "Phone", "DOB", "Gender", "Address"));
                Console.WriteLine();
                Console.WriteLine(String.Format("|{0,3}|{1,15}|{2,11}|{3,11}|{4,7}|{5,15}",
                    patList[index].Id, patList[index].Name, patList[index].Phone, patList[index].Dob, patList[index].Gender, patList[index].Address));
                Console.WriteLine("Do you want to edit this patient with ID ={0}", patList[index].Id);
                Console.WriteLine("Enter your confirm input(y/n):");
                confirm = Console.ReadLine();
                while (!Regex.IsMatch(confirm, "^y$|^n$"))
                {
                    Console.WriteLine("The confirm input must be y/n ");
                    confirm = Console.ReadLine();
                }
                if (confirm.Equals("y"))
                {
                    string error = "";
                    string nameInput, dobInput, genderInput, addressInput;
                    string phoneInput;

                    string checkName = "^[a-zA-Z ]*$";
                    string checkPhone1 = "^((012[0-9])|(016[2-9])|(09[0-9])|(0188)|(0199))[0-9]{7}$";
                    string checkPhone2 = "^08[0-9]{8}$";
                    string checkDob = "^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$";
                    string checkGender = "^m$|^f$";
                    string checkAddress = "[a-zA-Z0-9 ,./]+";
                    Console.WriteLine("Please enter patient's name:");
                    nameInput = Console.ReadLine();
                    Console.WriteLine("Please enter patient's phone: ");
                    phoneInput = Console.ReadLine();
                    Console.WriteLine("Please enter patient's date of birth(dd/mm/yyyy): ");
                    dobInput = Console.ReadLine();
                    Console.WriteLine("Please enter patient's gender(f/m): ");
                    genderInput = Console.ReadLine();
                    Console.WriteLine("Please enter patient's address: ");
                    addressInput = Console.ReadLine();
                    Console.WriteLine("\n");

                    if (nameInput.Equals("") || dobInput.Equals("") || genderInput.Equals("") || addressInput.Equals(""))
                    {
                        Console.WriteLine("All Fields must be filled. Please add again\n");
                    }
                    else
                    {
                        if (!Regex.IsMatch(nameInput, checkName))
                        {
                            error += "Invalid patient's name. Name cant have special characters.\n";
                        }

                        if (!Regex.IsMatch(phoneInput, checkPhone1) && !Regex.IsMatch(phoneInput, checkPhone2))
                        {
                            error += "Invalid patient's phone. Phone number must be followed by cellphone or telephone format.\n";

                        }

                        if (!Regex.IsMatch(dobInput, checkDob))
                        {
                            error += "Invalid patient's date of birth. DOB must be followed by dd/mm/yyyy format.\n";
                        }

                        if (!Regex.IsMatch(genderInput, checkGender))
                        {
                            error += "Invalid patient's gender. Must be m or f(non-capitalize)\n";
                        }

                        if (!Regex.IsMatch(addressInput, checkAddress))
                        {
                            error += "Invalid patient's address\n";
                        }

                        if (!error.Equals(""))
                        {
                            Console.WriteLine(error);
                        }

                        else
                        {
                            patList[index].Name = nameInput;
                            patList[index].Phone = phoneInput;
                            patList[index].Dob = dobInput;
                            patList[index].Gender = genderInput;
                            patList[index].Address = addressInput;
                            Console.WriteLine("Edit Patient Successfully.");
                        }

                    }
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        //Delete patient method
        private void deletePatient()
        {
            int input, index;
            bool checkindex = false;
            string inputId;
            string confirm;

            patientList();
            Console.WriteLine("Please choose the ID that you want to delete: ");
            inputId = Console.ReadLine();
            while (!int.TryParse(inputId, out  input) || input < 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                inputId = Console.ReadLine();
            }

            input = int.Parse(inputId);

            for (index = 0; index < patList.Count; index++)
            {
                if (input == patList[index].Id)
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
                Console.WriteLine("Cannot find this patient with ID ={0}", input);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(String.Format("|{0,3}|{1,20}|{2,11}|{3,11}|{4,7}|{5,15}", "ID", "Name", "Phone", "DOB", "Gender", "Address"));
                Console.WriteLine(String.Format("|{0,3}|{1,20}|{2,11}|{3,11}|{4,7}|{5,15}",
                    patList[index].Id, patList[index].Name, patList[index].Phone, patList[index].Dob, patList[index].Gender, patList[index].Address));
                Console.WriteLine("Do you want to delete this patient with ID ={0}", patList[index].Id);
                Console.WriteLine("Enter your confirm input(y/n): ");
                confirm = Console.ReadLine();
                while (!Regex.IsMatch(confirm, "^y$|^n$"))
                {
                    Console.WriteLine("The confirm input must be y/n ");
                    confirm = Console.ReadLine();
                }
                if (confirm.Equals("y"))
                {
                    Console.Clear();
                    patList.RemoveAt(index);
                    Console.WriteLine("Deleting Successfully");
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        //View patient list method
        public void patientList()
        {
            Console.WriteLine("\n");
            printingBreakLine();
            Console.WriteLine("Total number of patient is {0}", patList.Count);
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("|{0,3}|{1,10}|{2,11}|{3,11}|{4,7}|{5,15}", "ID", "Name", "Phone", "DOB", "Gender", "Address"));
            Console.WriteLine();
            foreach (Patient p in patList)
            {
                Console.WriteLine(String.Format("|{0,3}|{1,10}|{2,11}|{3,11}|{4,7}|{5,15}", p.Id, p.Name.Trim(), p.Phone.Trim(), p.Dob.Trim(), p.Gender, p.Address));
            }
            printingBreakLine();
        }
    }
}
