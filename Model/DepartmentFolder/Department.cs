
namespace Assignment1.Model.DepartmentFolder
{
    abstract class Department
    {
        private string depname;
        private int id;
        private string ward;
        public Department(int id, string ward, string depname)
        {
            this.depname = depname;
            this.id = id;
            this.ward = ward;
        }

        public string Ward
        {
            get
            {
                return this.ward;
            }
            set
            {
                this.ward = value;
            }
        }
        public string Depname
        {
            get
            {
                return this.depname;
            }
            set
            {
                this.depname = value;
            }

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
    }
}
