using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.Model.DrugFolder
{
    class Drug
    {
        private int id;
        private string name;

        public Drug(int id, string name)
        {
            this.id = id;
            this.name = name;

        }
        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
            }
        }
    }
}
