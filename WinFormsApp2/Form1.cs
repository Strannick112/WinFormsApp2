using Microsoft.EntityFrameworkCore;
using WinFormsApp2.Models;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {

        Sql8751847Context mysqlContext;
        public Form1()
        {
            InitializeComponent();
            mysqlContext = new Sql8751847Context();
            mysqlContext.Teachers.Load();
            dataGridView1.DataSource = mysqlContext.Teachers.Local.ToBindingList();
            dataGridView1.AutoSize = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
