using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestController;

namespace TestView
{
    public partial class Main : Form
    {
        private StudentsController studentsController;
        public Main()
        {
            InitializeComponent();
            this.studentsController = new StudentsController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SearchStudents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchStudents();
        }

        private void SearchStudents()
        {
            studentsController.getFilteredStudents(this.textBox2.Text.ToLower());
            InvalidateGrid();
        }

        private void InvalidateGrid()
        {
            this.dataGridView1.Rows.Clear();
            string id_card,full_name,school_name,date_of_birth = null;            
            for (int i = 0; i < this.studentsController.studentList.Count; i++)
            {
                id_card = this.studentsController.studentList[i].identity_card.ToString();
                full_name = this.studentsController.studentList[i].full_name;
                school_name = this.studentsController.studentList[i].school_name;
                date_of_birth = this.studentsController.studentList[i].date_of_birth.ToString("yyyy-MM-dd");
                string[] row = new string[] { id_card, full_name, school_name, date_of_birth };
                this.dataGridView1.Rows.Add(row);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SearchStudents();
            }
        }
    }
}
