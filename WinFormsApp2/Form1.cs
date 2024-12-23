using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
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

            comboBox1.Items.Clear();
            var properties = mysqlContext.GetType().GetProperties();
            foreach (var prop in properties)
                if (prop.PropertyType.ToString().StartsWith("Microsoft.EntityFrameworkCore.DbSet"))
                {
                    comboBox1.Items.Add(prop.Name.ToString());
                }

            dataGridView1.MinimumSize = new Size(480, 240);
            dataGridView1.AutoSize = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Teachers":
                    mysqlContext.Teachers.Load();
                    dataGridView1.DataSource = mysqlContext.Teachers.Local.ToBindingList();
                    break;


                case "Subjects":
                    mysqlContext.Subjects.Load();
                    dataGridView1.DataSource = mysqlContext.Subjects.Local.ToBindingList();
                    break;

                case "Classrooms":
                    mysqlContext.Classrooms.Load();
                    dataGridView1.DataSource = mysqlContext.Classrooms.Local.ToBindingList();
                    break;

                case "Days":
                    mysqlContext.Days.Load();
                    dataGridView1.DataSource = mysqlContext.Days.Local.ToBindingList();
                    break;

                case "Groups":
                    mysqlContext.Groups.Load();
                    dataGridView1.DataSource = mysqlContext.Groups.Local.ToBindingList();
                    break;

                case "Lectures":
                    mysqlContext.Lectures.Load();
                    dataGridView1.DataSource = mysqlContext.Lectures.Local.ToBindingList();
                    break;

                case "Semesters":
                    mysqlContext.Semesters.Load();
                    dataGridView1.DataSource = mysqlContext.Semesters.Local.ToBindingList();
                    break;

                case "TypesClassrooms":
                    mysqlContext.TypesClassrooms.Load();
                    dataGridView1.DataSource = mysqlContext.TypesClassrooms.Local.ToBindingList();
                    break;

                case "TypesLectures":
                    mysqlContext.TypesLectures.Load();
                    dataGridView1.DataSource = mysqlContext.TypesLectures.Local.ToBindingList();
                    break;

                case "Weeks":
                    mysqlContext.Weeks.Load();
                    dataGridView1.DataSource = mysqlContext.Weeks.Local.ToBindingList();
                    break;
                default: break;
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns.Insert(0, new DataGridViewColumn(new DataGridViewButtonCell()));
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Teachers":

                    Teacher teacher;

                    var cellValue = dataGridView1.Rows[e.RowIndex].Cells[1].EditedFormattedValue;
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int intValue))
                    {
                        teacher = mysqlContext.Teachers.Find(intValue);
                        if (teacher != null)
                        {
                            teacher.FullName = dataGridView1.Rows[e.RowIndex].Cells[2].EditedFormattedValue.ToString();
                            teacher.Status = dataGridView1.Rows[e.RowIndex].Cells[3].EditedFormattedValue.ToString();
                            mysqlContext.Teachers.Update(teacher);
                            mysqlContext.SaveChanges();
                        }
                        else
                        {
                            teacher = new Teacher();
                            teacher.FullName = dataGridView1.Rows[e.RowIndex].Cells[2].EditedFormattedValue.ToString();
                            teacher.Status = dataGridView1.Rows[e.RowIndex].Cells[3].EditedFormattedValue.ToString();
                            mysqlContext.Teachers.Add(teacher);
                            mysqlContext.SaveChanges();
                        }
                    }

                    mysqlContext.Teachers.Load();
                    dataGridView1.DataSource = mysqlContext.Teachers.Local.ToBindingList();
                    break;

                case "Subjects":
                    mysqlContext.Subjects.Load();
                    dataGridView1.DataSource = mysqlContext.Subjects.Local.ToBindingList();
                    break;

                case "Classrooms":
                    mysqlContext.Classrooms.Load();
                    dataGridView1.DataSource = mysqlContext.Classrooms.Local.ToBindingList();
                    break;

                case "Days":
                    mysqlContext.Days.Load();
                    dataGridView1.DataSource = mysqlContext.Days.Local.ToBindingList();
                    break;

                case "Groups":
                    mysqlContext.Groups.Load();
                    dataGridView1.DataSource = mysqlContext.Groups.Local.ToBindingList();
                    break;

                case "Lectures":
                    mysqlContext.Lectures.Load();
                    dataGridView1.DataSource = mysqlContext.Lectures.Local.ToBindingList();
                    break;

                case "Semesters":
                    mysqlContext.Semesters.Load();
                    dataGridView1.DataSource = mysqlContext.Semesters.Local.ToBindingList();
                    break;

                case "TypesClassrooms":
                    mysqlContext.TypesClassrooms.Load();
                    dataGridView1.DataSource = mysqlContext.TypesClassrooms.Local.ToBindingList();
                    break;

                case "TypesLectures":
                    mysqlContext.TypesLectures.Load();
                    dataGridView1.DataSource = mysqlContext.TypesLectures.Local.ToBindingList();
                    break;

                case "Weeks":
                    mysqlContext.Weeks.Load();
                    dataGridView1.DataSource = mysqlContext.Weeks.Local.ToBindingList();
                    break;
                default: break;
            }

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
            if (e.ColumnIndex == 0 && e.RowIndex > 0)
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Teachers":

                        Teacher teacher;

                        var cellValue = dataGridView1.Rows[e.RowIndex].Cells[1].EditedFormattedValue;
                        if (cellValue != null && int.TryParse(cellValue.ToString(), out int intValue))
                        {
                            teacher = mysqlContext.Teachers.Find(intValue);
                            if (teacher != null)
                            {
                                mysqlContext.Teachers.Remove(teacher);
                                mysqlContext.SaveChanges();
                            }
                            
                        }

                        mysqlContext.Teachers.Load();
                        dataGridView1.DataSource = mysqlContext.Teachers.Local.ToBindingList();
                        break;

                    case "Subjects":
                        mysqlContext.Subjects.Load();
                        dataGridView1.DataSource = mysqlContext.Subjects.Local.ToBindingList();
                        break;

                    case "Classrooms":
                        mysqlContext.Classrooms.Load();
                        dataGridView1.DataSource = mysqlContext.Classrooms.Local.ToBindingList();
                        break;

                    case "Days":
                        mysqlContext.Days.Load();
                        dataGridView1.DataSource = mysqlContext.Days.Local.ToBindingList();
                        break;

                    case "Groups":
                        mysqlContext.Groups.Load();
                        dataGridView1.DataSource = mysqlContext.Groups.Local.ToBindingList();
                        break;

                    case "Lectures":
                        mysqlContext.Lectures.Load();
                        dataGridView1.DataSource = mysqlContext.Lectures.Local.ToBindingList();
                        break;

                    case "Semesters":
                        mysqlContext.Semesters.Load();
                        dataGridView1.DataSource = mysqlContext.Semesters.Local.ToBindingList();
                        break;

                    case "TypesClassrooms":
                        mysqlContext.TypesClassrooms.Load();
                        dataGridView1.DataSource = mysqlContext.TypesClassrooms.Local.ToBindingList();
                        break;

                    case "TypesLectures":
                        mysqlContext.TypesLectures.Load();
                        dataGridView1.DataSource = mysqlContext.TypesLectures.Local.ToBindingList();
                        break;

                    case "Weeks":
                        mysqlContext.Weeks.Load();
                        dataGridView1.DataSource = mysqlContext.Weeks.Local.ToBindingList();
                        break;
                    default: break;
                }
            }
            
        }

    }
}
