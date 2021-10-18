using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel
{
    public class School
    {
        public int id;
        public string name;
        public int id_country;

        public School(int id, string name, int id_country)
        {
            this.id = id;
            this.name = name;
            this.id_country = id_country;
        }
    }
}
