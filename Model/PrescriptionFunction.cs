using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.Model
{
    class PrescriptionFunction
    {
        private List<Drugs> drugList;
        private string date, doctor, patient, instruction;
        private int id;
        public PrescriptionFunction(int id, string patient, string doctor, string date, List<Drugs> drugList, string instruction)
        {
            this.Id = id;
            this.patient = patient;
            this.doctor = doctor;
            this.date = date;
            this.drugList = drugList;
            this.instruction = instruction;
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
        public string Patient { get { return this.patient; } set { this.patient = value; } }
        public string Doctor { get { return this.doctor; } set { this.doctor = value; } }
        public string Date { get { return this.date; } set { this.date = value; } }
        public string Instruction { get { return this.instruction; } set { this.instruction = value; } }
        public List<Drugs> DrugList { get { return this.drugList; } set { this.drugList = value; } }

    }
}
