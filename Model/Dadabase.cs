using System;
using System.Collections.Generic;
using Assignment1.Model.DepartmentFolder;
namespace Assignment1.Model
{
    class Dadabase
    {
        private List<Patient> patList;
        private List<Staff> staList;
        private List<Qualification> quaList;
        private List<Department> depList;
        private List<CheckupFunction> checkList;
        private List<SubclinicalServiceOrderFunction> subList;
        private List<PrescriptionFunction> prepList;
        private PatientFunction pf;
        private StaffFunction sf;
        private DepartmentFunction df;
        private static int checkupId = 0, subId = 0, prepId = 0;
        public Dadabase()
        {
            patList = new List<Patient>();
            staList = new List<Staff>();
            quaList = new List<Qualification>();
            depList = new List<Department>();
            checkList = new List<CheckupFunction>();
            subList = new List<SubclinicalServiceOrderFunction>();
            prepList = new List<PrescriptionFunction>();
            pf = new PatientFunction(patList);
            sf = new StaffFunction(staList, quaList);
            df = new DepartmentFunction(depList);            

        }

        public bool menuScreen()
        {

            bool con = true;
            dataManagementChoice();
            Console.Write("Please enter your choice: ");
            string input = Console.ReadLine();

            while (con)
            {
                if ("p".Equals(input) || "P".Equals(input))
                {
                    //Patient Menu                    
                    Console.Clear();
                    pf.patientMenu();

                }

                else if ("s".Equals(input) || "S".Equals(input))
                {
                    //Staff Menu
                    Console.Clear();
                    sf.staffMenu();

                }
                else if ("b".Equals(input) || "B".Equals(input))
                {
                    //Exit Program
                    Console.Clear();
                    con = false;
                    return con;
                }
                else if ("l".Equals(input) || "L".Equals(input))
                {
                    //Staff Menu
                    Console.Clear();
                    df.departmentMenu();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("INVALID input. Please try again.");
                }

                Console.Write("\n");
                dataManagementChoice();
                Console.WriteLine("Please enter your choice: ");
                input = Console.ReadLine();
            }
            return con;
        }


        private bool checkup()
        {
            bool checkindex = false, checkindex2 = false;

            int patientindex = pf.addPatient();
            string inputId, problemInput, confirmInput, diagnosis;
            int input;
            int doctorIndex, wardIndex;

            sf.staffList();

            Console.WriteLine("Please enter Doctor ID(Number only): ");
            inputId = Console.ReadLine();
            while (!int.TryParse(inputId, out  input) || input < 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                inputId = Console.ReadLine();
            }

            input = int.Parse(inputId);

            for (doctorIndex = 0; doctorIndex < staList.Count; doctorIndex++)
            {
                if (input == staList[doctorIndex].Id)
                {
                    checkindex = true;
                    Console.WriteLine("Doctor name {0}", staList[doctorIndex].Name);
                    break;
                }
                else if (doctorIndex == staList.Count - 1 && input != staList[doctorIndex].Id)
                {
                    Console.WriteLine("Doctor not found");
                    checkindex = false;
                }
            }
            if (checkindex == false)
            {
                return checkindex;
            }

            Console.WriteLine("Please enter Ward ID(Number only): ");
            inputId = Console.ReadLine();
            while (!int.TryParse(inputId, out  input) || input < 0)
            {
                Console.WriteLine("Invalid ID. Please try again.");
                inputId = Console.ReadLine();
            }

            input = int.Parse(inputId);

            for (wardIndex = 0; wardIndex < depList.Count; wardIndex++)
            {
                if (input == depList[wardIndex].Id)
                {
                    checkindex2 = true;
                    Console.WriteLine("Ward name {0}", staList[wardIndex].Name);
                    break;
                }
                else if (wardIndex == depList.Count - 1 && input != depList[wardIndex].Id)
                {
                    Console.WriteLine("Ward not found");
                    checkindex2 = false;
                }
            }
           
            if (checkindex2 == false)
            {
                return checkindex2;
            }
            DateTime d = DateTime.Now;
            string date = d.ToString();
            Console.WriteLine("Enter patient problem:");
            problemInput = Console.ReadLine();
            Console.WriteLine("Enter Doctor diagnosis:");
            diagnosis = Console.ReadLine();
            Console.WriteLine("Finish checkup");
            Console.WriteLine("Do you want further checking to collect detailed problems(y/n): ");
            confirmInput = Console.ReadLine();
            while (!confirmInput.Equals("y") && !confirmInput.Equals("Y") && !confirmInput.Equals("n") && !confirmInput.Equals("N")) {
                Console.WriteLine("Invalid confirm input. Try again. ");
                Console.WriteLine("Do you want further checking to collect detailed problems(y/n): ");
                confirmInput = Console.ReadLine();
            }
            if (confirmInput.Equals("y") || confirmInput.Equals("Y"))
            {
                checkList.Add(new CheckupFunction(checkupId, patList[patientindex].Name,staList[doctorIndex].Name, depList[wardIndex].Depname, date, problemInput, diagnosis));
                checkupId++;
                subclinicalServiceOrder(patientindex, doctorIndex, wardIndex, date, problemInput, diagnosis);
            }
            else {
                prescription(patientindex, doctorIndex, wardIndex, date, problemInput, diagnosis);
            }

            return true;
        }

        private void subclinicalServiceOrder(int patientindex, int doctorIndex, int wardIndex,string  date, string problemInput,string  diagnosis) {
            int wardNum;
            string wardName=""; 
            string input ;
            Console.WriteLine("How many departments involved.");
            input = Console.ReadLine();
            while(!int.TryParse(input, out wardNum)){
                Console.WriteLine("Error. How many departments involved.");
                input = Console.ReadLine();
            }
            wardNum = int.Parse(input);
            int [] wardId = new int [wardNum];
                           
            df.departmentList();
            
            for (int i = 0; i < wardId.Length; i++)
			{
			       Console.WriteLine("Enter ward ID: ");
                   wardId[i] = int.Parse(Console.ReadLine());
                   wardName += depList[wardId[i]].Depname;
                   Console.WriteLine("Enter detailed problem: ");
                   problemInput += Console.ReadLine();
                   Console.WriteLine("Enter detailed diagnosis: ");
                   diagnosis += Console.ReadLine();
			}
            subList.Add(new SubclinicalServiceOrderFunction(subId,patList[patientindex].Name,wardName, date));
            subId++;
            prescription(patientindex, doctorIndex, wardIndex, date, problemInput, diagnosis);

        }

        private void prescription(int patientindex, int doctorIndex, int wardIndex, string date, string problemInput, string diagnosis) {
            int drug;
            //string wardName = "";
            string input;
            string drugname="";
            int quantity=0;
            string instruction = "";
            Console.WriteLine("How many drug that patient needs to take.");
            input = Console.ReadLine();
            while (!int.TryParse(input, out drug))
            {
                Console.WriteLine("Error. How many drug that patient needs to take.");
                input = Console.ReadLine();
            }
            drug = int.Parse(input);
            List<Drugs> drugList = new List<Drugs>();
            
            for (int i = 0; i < drug; i++)
            {
                Console.WriteLine("{0}\tDrug name: ", i);
                drugname = Console.ReadLine();
                Console.WriteLine("{0}\tDrug Quantity: ", i);
                quantity = int.Parse(Console.ReadLine());
                drugList.Add(new Drugs(drugname, quantity));

            }

            Console.WriteLine("Special Instruction: ");
            instruction = Console.ReadLine();
            prepList.Add(new PrescriptionFunction(prepId ,patList[patientindex].Name, staList[doctorIndex].Name, date, drugList, instruction));
            prepId++;
        }

        public bool mainScreen()
        {

            bool con = true;
            mainScreenChoice();
            Console.Write("Please enter your choice: ");
            string input = Console.ReadLine();

            while (con)
            {
                if ("c".Equals(input) || "C".Equals(input))
                {
                    //Patient Menu                    
                    Console.Clear();
                    checkup();

                }

                else if ("d".Equals(input) || "D".Equals(input))
                {
                    //Staff Menu
                    Console.Clear();
                    menuScreen();

                }
                else if ("x".Equals(input) || "X".Equals(input))
                {
                    //Staff Menu
                    Console.Clear();
                    con = false;

                    Console.WriteLine("Exit, bye bye");
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("INVALID input. Please try again.");
                }

                Console.Write("\n");
                mainScreenChoice();
                Console.WriteLine("Please enter your choice: ");
                input = Console.ReadLine();
            }
            return con;
        }
        private void printingBreakLine()
        {
            for (int i = 0; i < 78; i++)
            {
                Console.Write("=");
            }
            Console.Write("\n");
        }
        private void mainScreenChoice()
        {
            printingBreakLine();
            Console.WriteLine("\tMAIN SCREEN");
            Console.WriteLine("\tD -Database Management .");
            Console.WriteLine("\tC - Client Service.");
            Console.WriteLine("\tX - Exit Program.");
            printingBreakLine();
        }

        private void dataManagementChoice()
        {
            printingBreakLine();
            Console.WriteLine("\tMENU SCREEN");
            Console.WriteLine("\tP - Patient.");
            Console.WriteLine("\tS - Staff.");
            Console.WriteLine("\tL - Lab.");
            Console.WriteLine("\tD - Drugs.");
            Console.WriteLine("\tB - Back to Main Screen.");
            printingBreakLine();
        }
    }
}
