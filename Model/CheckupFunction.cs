using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.Model
{
    class CheckupFunction
    {
        
        private int id;
        private string date, problemInput, diagnosis, patientindex, doctorIndex, wardIndex;
        public CheckupFunction(int id,string patientindex, string doctorIndex, string wardIndex, string date, string problemInput, string diagnosis)
        {
            this.id = id;
            this.patientindex = patientindex;
            this.doctorIndex = doctorIndex;
            this.wardIndex = wardIndex;
            this.date = date;
            this.problemInput = problemInput;
            this.diagnosis = diagnosis;

        }
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Patientindex { get { return this.patientindex; } set { this.patientindex = value; } }
        public string DoctortIndex { get { return this.doctorIndex; } set { this.doctorIndex = value; } }
        public string WardIndex { get { return this.wardIndex; } set { this.wardIndex = value; } }
        public string Date { get { return this.date; } set { this.date = value; } }
        public string ProblemInput { get { return this.problemInput; } set { this.problemInput = value; } }
        public string Diagnosis { get { return this.diagnosis; } set { this.diagnosis = value; } }
    }
}
