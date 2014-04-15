
namespace Assignment1
{
    class Patient
    {
        private int id;
        private string phone;
        private string name;
        private string dob;
        private string gender;
        private string address;

        public Patient(int id, string name, string phone, string dob, string gender, string address)
        {
            this.id = id;
            this.phone = phone;
            this.name = name;
            this.dob = dob;
            this.gender = gender;
            this.address = address;
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
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
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
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }
    }
}
