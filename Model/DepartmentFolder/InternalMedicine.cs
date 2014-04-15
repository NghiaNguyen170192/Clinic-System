using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.Model.DepartmentFolder
{
    class InternalMedicine : Department
    {

        public InternalMedicine(int id, string ward,string name)
            : base(id, ward, name)
        {

        }
    }
}
