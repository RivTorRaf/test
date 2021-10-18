using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel
{
    public class Student
    {
        public int identity_card;
        public string names;
        public string surnames;
        public string full_name;
        public DateTime date_of_birth;
        public int id_school;
        public string school_name;

        public Student(int identity_card, string names, string surnames, DateTime date_of_birth, int id_school, string school_name)
        {
            this.identity_card = identity_card;
            this.names = names;
            this.surnames = surnames;
            this.date_of_birth = date_of_birth;
            this.id_school = id_school;
            this.full_name = names + " " + surnames;
            this.school_name = school_name;
        }
    }    
}
