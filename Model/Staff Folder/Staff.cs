
namespace Assignment1
{
    abstract class Staff
    {
        private int id;
        private string name;
        private string dob;
        private string gender;
        private string stafftype;
        private string qualification;
        private string job;

        public Staff(int id, string name, string dob, string gender, string stafftype, string job, string qualification) {
            this.id = id;
            this.name = name;
            this.dob = dob;
            this.gender = gender;            
            this.stafftype = stafftype;
            this.job = job;
            this.qualification = qualification;

        }

         public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id =value;
            }
        }

         public string Stafftype
        {
            get
            {
                return this.stafftype;
            }
            set
            {
                this.stafftype = value;
            }
        }

         public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

         public string Dob
        {
            get
            {
                return this.dob;
            }
            set
            {
                this.dob = value;
            }
        }

         public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

         public string Qualification
        {
            get
            {
                return this.qualification;
            }
            set
            {
                this.qualification = value;
            }
        }

         public string Job { 
             get
            {
                return this.job;
            }
            set
            {
                this.job = value;
            }
         }
    }
}
