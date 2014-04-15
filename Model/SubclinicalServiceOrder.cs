using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.Model
{
    class SubclinicalServiceOrderFunction
    {
        private int id;
        private string patient;
        private string wardName;
        private string date;
        public SubclinicalServiceOrderFunction(int id,string patient, string wardName, string date)
        {
            this.id = id;
            this.wardName = wardName;
            this.date = date;
            this.patient = patient;
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
        public string WardName { get { return this.wardName; } set { this.wardName = value; } }
        public string Patient { get { return this.patient; } set { this.patient = value; } }
        public string Date { get { return this.date; } set { this.date = value; } }
    }
}
