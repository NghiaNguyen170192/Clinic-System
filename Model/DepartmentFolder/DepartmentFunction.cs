using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace Assignment1.Model.DepartmentFolder
{
    class DepartmentFunction
    {
        private List<Department> depList;
        private static int depId=0;
        public DepartmentFunction(List<Department> depList)
        {
            this.depList = depList;
            //readDepartmentFile();
        }

        //private bool readDepartmentFile() {
        //    TextReader tr = new StreamReader(@"C:\Users\Nghia\Documents\Visual Studio 2010\Projects\Week2BTutorial\Assignment1\Model\DepartmentFolder\Department.txt");

        //    string input;
        //    while ((input = tr.ReadLine()) != null)
        //    {
        //        string[] array = input.Split(',');
        //        depId = int.Parse(array[0].Trim());

        //        if (array[2].Contains("emer"))
        //        {
        //            depList.Add(new Emergency(depId, array[1].Trim(), array[2].Trim()));
        //        }
        //        if (array[2].Contains("internal"))
        //        {
        //            depList.Add(new InternalMedicine(depId, array[1].Trim(), array[2].Trim()));
        //        }
                
        //        if (array[2].Contains("lab"))
        //        {
        //            depList.Add(new Lab(depId, array[1].Trim(), array[2].Trim()));
        //        }
                
        //        if (array[2].Contains("mat"))
        //        {
        //            depList.Add(new Maternity(depId, array[1].Trim(), array[2].Trim()));
        //        }
                
        //        if (array[2].Contains("pae"))
        //        {
        //            depList.Add(new Paediatrics(depId, array[1].Trim(), array[2].Trim()));
        //        }
                
        //        if (array[2].Contains("rad"))
        //        {
        //            depList.Add(new Radiology(depId, array[1].Trim(), array[2].Trim()));
        //        }
                
        //        if (array[2].Contains("sur"))
        //        {
        //            depList.Add(new Surgery(depId, array[1].Trim(), array[2].Trim()));
        //        }
                
        //        if (array[2].Contains("ult"))
        //        {
        //            depList.Add(new Ultrasound(depId, array[1].Trim(), array[2].Trim()));
        //        }
                
        //    }
        //    Console.WriteLine("Department File Loaded Successfully.");

        //    tr.Close();
        //    depId++;         

        //    return true;
        //}

        //private bool writeDepartmentFile() {

        //    return true;
        //}

        private void departmentChoice()
        {
            printingBreakLine();
            Console.WriteLine("\tDEPARTMENT SCREEN");
            Console.WriteLine("\tA - Add Department.");
            Console.WriteLine("\tE - Edit Department.");
            Console.WriteLine("\tD - Delete Department.");
            Console.WriteLine("\tL - Department's List.");
            Console.WriteLine("\tB - Back to Staff Menu.");
            printingBreakLine();

        }

        public bool departmentMenu()
        {
            bool con = true;
            departmentChoice();
            Console.WriteLine("Please enter your choice: ");
            string input = Console.ReadLine();

            while (con)
            {
                if ("a".Equals(input) || "A".Equals(input))
                {
                    //Add staff
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Adding Department Form.");
                    printingBreakLine();
                    addDepartment();
                    Console.WriteLine("\n");
                }
                else if ("e".Equals(input) || "E".Equals(input))
                {
                    //Edit staff
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Editing Department Form.");
                    printingBreakLine();
                    editDepartment();
                    Console.WriteLine("\n");
                }
                else if ("d".Equals(input) || "D".Equals(input))
                {
                    //Delete staff
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Deleting Department Form.");
                    printingBreakLine();
                    deleteDepartment();
                    Console.WriteLine("\n");
                }
                else if ("l".Equals(input) || "L".Equals(input))
                {
                    //staff List
                    Console.Clear();
                    printingBreakLine();
                    Console.WriteLine("Department's List.");
                    printingBreakLine();
                    departmentList();
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
                departmentChoice();
                Console.WriteLine("Please enter your choice: ");
                input = Console.ReadLine();
            }
            return con;
        }

        public void departmentList()
        {
            Console.WriteLine("\n");
            printingBreakLine();
            
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("|{0,3}|{1,5}|{2,30}|", "ID", "Ward", "DepartMent Name"));
            Console.WriteLine();
            foreach (Department d in depList)
            {
                Console.WriteLine(String.Format("|{0,3}|{1,5}|{2, 30}|", d.Id, d.Ward, d.Depname));
            }
            printingBreakLine();
        }

        private void addDepartment()
        {
            string error = "";
            string depInput, wardInput;
            bool checkIndex = false;
            string checkWard = "^main$|^sub$";

            int index;

            Console.WriteLine("Please enter ward(main/sub): ");
            wardInput = Console.ReadLine();
            Console.WriteLine("Please enter Department Name: ");
            depInput = Console.ReadLine();

            if (depInput.Equals("") || wardInput.Equals(""))
            {
                Console.WriteLine("All Fields must be filled. Please add again\n");
            }
            else
            {

                if(!Regex.IsMatch(wardInput, checkWard)){
                    error += "Invalid ward input. Must be main or sub.";
                }
                for (index = 0; index < depList.Count; index++)
                {
                    if (depInput != depList[index].Depname)
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
                    Console.WriteLine("The Department Name is duplicated");
                }

                else
                {

                    if (depInput.Contains("emer"))
                    {
                        depList.Add(new Emergency(depId,wardInput, depInput));
                    }
                    if (depInput.Contains("internal"))
                    {
                        depList.Add(new InternalMedicine(depId, wardInput, depInput));
                    }

                    if (depInput.Contains("lab"))
                    {
                        depList.Add(new Lab(depId, wardInput, depInput));
                    }

                    if (depInput.Contains("mat"))
                    {
                        depList.Add(new Maternity(depId, wardInput, depInput));
                    }

                    if (depInput.Contains("pae"))
                    {
                        depList.Add(new Paediatrics(depId, wardInput, depInput));
                    }

                    if (depInput.Contains("rad"))
                    {
                        depList.Add(new Radiology(depId, wardInput, depInput));
                    }

                    if (depInput.Contains("sur"))
                    {
                        depList.Add(new Surgery(depId, wardInput, depInput));
                    }

                    if (depInput.Contains("ult"))
                    {
                        depList.Add(new Ultrasound(depId, wardInput, depInput));
                    }                    


                    depId++;
                    //Console.WriteLine("Current patId is {0}", patId);
                    Console.WriteLine("Add Department Successfully.");
                }

            }
        }

        private void editDepartment()
        {
            int input, index;
            bool checkindex = false;
            string inputId;
            string confirm;

            string error = "";
            string depInput,wardInput;            
            string checkWard = "^main$|^sub$";                    

            departmentList();
            Console.WriteLine("Please choose the ID Department that you want to delete: ");
            inputId = Console.ReadLine();
            while (!int.TryParse(inputId, out  input) || input < 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                inputId = Console.ReadLine();
            }

            input = int.Parse(inputId);

            for (index = 0; index < depList.Count; index++)
            {
                if (input == depList[index].Id)
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
                Console.WriteLine("Cannot find this Department with ID ={0}", input);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(String.Format("|{0,3}|{1,5}|{2,30}|", "ID", "Ward", "Department Name"));
                Console.WriteLine();
                Console.WriteLine(String.Format("|{0,3}|{1,5}|{2,30}|", depList[index].Id, depList[index].Ward, depList[index].Depname));

                Console.WriteLine("Do you want to edit this Department with ID ={0}", depList[index].Id);
                Console.WriteLine("Enter your confirm input(y/n):");
                confirm = Console.ReadLine();
                while (!Regex.IsMatch(confirm, "^y$|^n$"))
                {
                    Console.WriteLine("The confirm input must be y/n ");
                    confirm = Console.ReadLine();
                }
                if (confirm.Equals("y"))
                {                    

                    Console.WriteLine("Please enter ward(main/sub): ");
                    wardInput = Console.ReadLine();
                    Console.WriteLine("Please enter Department Name: ");
                    depInput = Console.ReadLine();

                    if (depInput.Equals("") || wardInput.Equals(""))
                    {
                        Console.WriteLine("All Fields must be filled. Please add again\n");
                    }
                    else
                    {

                        if(!Regex.IsMatch(wardInput, checkWard)){
                            error += "Invalid ward input. Must be main or sub.";
                        }
                        for (index = 0; index < depList.Count; index++)
                        {
                            if (depInput != depList[index].Depname)
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
                            Console.WriteLine("The Department name is duplicated");
                        }

                        else
                        {
                            depList[index].Ward = wardInput;
                            depList[index].Depname = depInput;
                            depId++;
                            //Console.WriteLine("Current patId is {0}", patId);
                            Console.WriteLine("Edit Department Successfully");
                        }

                    }

                }
                else
                {
                    Console.Clear();
                }
            }
        }

        private void deleteDepartment()
        {
            int input, index;
            bool checkindex = false;
            string inputId;
            string confirm;

            departmentList();
            Console.WriteLine("Please choose the ID Department that you want to delete: ");
            inputId = Console.ReadLine();
            while (!int.TryParse(inputId, out  input) || input < 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                inputId = Console.ReadLine();
            }

            input = int.Parse(inputId);

            for (index = 0; index < depList.Count; index++)
            {
                if (input == depList[index].Id)
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
                Console.WriteLine("Cannot find this Department with ID ={0}", input);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(String.Format("|{0,3}|{1,5}|{2,30}|", "ID", "Ward", "Department Name"));
                Console.WriteLine();
                Console.WriteLine(String.Format("|{0,3}|{1,5}|{2,30}|", depList[index].Id, depList[index].Ward, depList[index].Depname));

                Console.WriteLine("Do you want to delete this Department with ID ={0}", depList[index].Id);
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
                    depList.RemoveAt(index);
                    Console.WriteLine("Delete Department Successfully");
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        private void printingBreakLine()
        {
            for (int i = 0; i < 78; i++)
            {
                Console.Write("=");
            }
            Console.Write("\n");
        }
    }
}
