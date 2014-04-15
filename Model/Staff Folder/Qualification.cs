
namespace Assignment1.Model
{
    class Qualification
    {
        private int id;
        private string quaname;
        public Qualification(int id, string quaname)
        {
            this.quaname = quaname;
            this.id = id;
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

        public string QuaName
        {
            get
            {
                return this.quaname;
            }
            set
            {
                this.quaname = value;
            }
        }
    }
}
