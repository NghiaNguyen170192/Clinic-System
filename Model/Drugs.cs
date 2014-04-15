
namespace Assignment1.Model
{
    class Drugs
    {
        private string drugname;
        private int quantity;
        public Drugs(string drugname, int quantity)
        {
            this.drugname = drugname;
            this.quantity = quantity;
        }

        public string Drugname
        {
            get
            {
                return this.drugname;
            }
            set
            {
                this.drugname = value;
            }
        }
    }
}
