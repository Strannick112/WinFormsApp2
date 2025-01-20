using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
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

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            comboBox1.Items.Clear();
            var properties = mysqlContext.GetType().GetProperties();
            foreach (var prop in properties)
                if (prop.PropertyType.ToString().StartsWith("Microsoft.EntityFrameworkCore.DbSet"))
                {
                    comboBox1.Items.Add(prop.Name.ToString());
                }

            dataGridView1.MinimumSize = new Size(480, 240);
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
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
                    dayRefresh();
                    break;

                case "Groups":
                    mysqlContext.Groups.Load();
                    dataGridView1.DataSource = mysqlContext.Groups.Local.ToBindingList();
                    break;

                case "Lectures":
                    mysqlContext.Lectures.Load();
                    var bindingLectureList = mysqlContext.Lectures.Local.ToBindingList();
                    dataGridView1.DataSource = bindingLectureList;
                    //if (bindingList.Count == 0)
                    //{
                    //    dataGridView1.Rows.Add(
                    //        new Lecture {
                    //            IdLectures = 1, 
                    //            IdTeacher = 1,
                    //            IdGroup = 1,
                    //            IdSubject = 1,
                    //            IdClassrooms = 1,
                    //            IdTypeLecture = 1,
                    //            IdDay = 1,
                    //            IdLectureNumber = 1
                    //        }
                    //    );
                    //}
                    //mysqlContext.Teachers.Load();
                    var myTeacherCombobox = new DataGridViewComboBoxColumn
                    {
                        HeaderText = "Teacher",
                        DataPropertyName = "IdTeacher",
                        //DataSource = mysqlContext.Teachers.Local.ToList(),
                        DataSource = mysqlContext.Teachers.Select(row => new
                        {
                            IdTeacher = row.IdTeacher,
                            FullName = row.FullName
                        }).ToList(),
                        DisplayMember = "FullName",
                        //DisplayMember = "Name", // Поле для отображения
                        ValueMember = "IdTeacher" // Поле для значения

                    };
                    
                    //my_custom_combobox.DataPropertyName = "IdTeacher";

                    // Удаляем старый столбец CategoryId, если он есть
                    if (dataGridView1.Columns["IdTeacher"] != null)
                    {
                        dataGridView1.Columns.Remove("IdTeacher");
                    }

                    dataGridView1.Columns.Insert(1, myTeacherCombobox);

                    //my_custom_combobox = new DataGridViewComboBoxColumn();
                    //my_custom_combobox.Name = "Groups";
                    //my_custom_combobox.DataSource = mysqlContext.Groups.Select(row => new {
                    //    id = row.IdGroup,
                    //    value = row.NameOfGroup
                    //}).ToList();
                    //my_custom_combobox.DisplayMember = "value";
                    //my_custom_combobox.ValueMember = "id";
                    //dataGridView1.Columns.Insert(2, my_custom_combobox);

                    //my_custom_combobox = new DataGridViewComboBoxColumn();
                    //my_custom_combobox.Name = "Subjects";
                    //my_custom_combobox.DataSource = mysqlContext.Subjects.Select(row => new {
                    //    id = row.IdSubject,
                    //    value = row.NameSubject
                    //}).ToList();
                    //my_custom_combobox.DisplayMember = "value";
                    //my_custom_combobox.ValueMember = "id";
                    //dataGridView1.Columns.Insert(3, my_custom_combobox);

                    //my_custom_combobox = new DataGridViewComboBoxColumn();
                    //my_custom_combobox.Name = "Classrooms";
                    //my_custom_combobox.DataSource = mysqlContext.Classrooms.Select(row => new {
                    //    id = row.IdClassroom,
                    //    value = row.NumberClassroom
                    //}).ToList();
                    //my_custom_combobox.DisplayMember = "value";
                    //my_custom_combobox.ValueMember = "id";
                    //dataGridView1.Columns.Insert(4, my_custom_combobox);
                    break;

                case "LectureNumbers":
                    mysqlContext.LectureNumbers.Load();
                    dataGridView1.DataSource = mysqlContext.LectureNumbers.Local.ToBindingList();
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
                default: return; break;
            }
            if(dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns.Insert(0, new DataGridViewColumn(new DataGridViewButtonCell()));
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.EndEdit();
            dataGridView1.ClearSelection();
            
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Teachers":

                    Teacher teacher;
                    int intValue;
                    string cellValue;
                    DataGridViewRow row;

                    row = dataGridView1.Rows[e.RowIndex];
                    cellValue = row.Cells[1].EditedFormattedValue.ToString();
                    
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                    {
                        teacher = mysqlContext.Teachers.Find(intValue);
                        if (teacher != null)
                        {
                            teacher.FullName = row.Cells[2].EditedFormattedValue.ToString();
                            teacher.Status = row.Cells[3].EditedFormattedValue.ToString();
                            mysqlContext.Teachers.Update(teacher);
                            mysqlContext.SaveChanges();
                            dataGridView1.Refresh();
                        }
                        else
                        {   
                            teacher = new Teacher();
                            teacher.FullName = row.Cells[2].EditedFormattedValue.ToString();
                            teacher.Status = row.Cells[3].EditedFormattedValue.ToString();
                            mysqlContext.Teachers.Add(teacher);
                            mysqlContext.SaveChanges();
                            dataGridView1.Refresh();
                        }
                    }

                    mysqlContext.Teachers.Load();
                    dataGridView1.DataSource = mysqlContext.Teachers.Local.ToBindingList();
                    break;

                case "Subjects":
                    Subject subject;

                    row = dataGridView1.Rows[e.RowIndex];
                    cellValue = row.Cells[1].EditedFormattedValue.ToString();
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out  intValue))
                    {
                        subject = mysqlContext.Subjects.Find(intValue);
                        
                        if (subject != null)
                        {
                            subject.NameSubject = row.Cells[2].EditedFormattedValue.ToString();
                            cellValue = row.Cells[3].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                subject.HoursLecture = intValue;
                            cellValue = row.Cells[4].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                subject.HoursLaboratory = intValue;
                            cellValue = row.Cells[5].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                subject.HoursPractices = intValue;
                            cellValue = row.Cells[6].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                subject.HoursConsultation = intValue;
                            cellValue = row.Cells[7].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                subject.HoursExam = intValue;

                            mysqlContext.Subjects.Update(subject);
                            mysqlContext.SaveChanges();
                            dataGridView1.Refresh();
                        }
                        else
                        {
                            subject = new Subject();
                            subject.NameSubject = row.Cells[2].EditedFormattedValue.ToString();
                            cellValue = row.Cells[3].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                subject.HoursLecture = intValue;
                            cellValue = row.Cells[4].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                subject.HoursLaboratory = intValue;
                            cellValue = row.Cells[5].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                subject.HoursPractices = intValue;
                            cellValue = row.Cells[6].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                subject.HoursConsultation = intValue;
                            cellValue = row.Cells[7].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                subject.HoursExam = intValue;
                            mysqlContext.Subjects.Add(subject);
                            mysqlContext.SaveChanges();
                            dataGridView1.Refresh();
                        }
                    }

                    mysqlContext.Subjects.Load();
                    dataGridView1.DataSource = mysqlContext.Subjects.Local.ToBindingList();
                    break;

                case "Classrooms":
                    Classroom classroom;

                    row = dataGridView1.Rows[e.RowIndex];
                    cellValue = row.Cells[1].EditedFormattedValue.ToString();
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                    {
                        classroom = mysqlContext.Classrooms.Find(intValue);

                        if (classroom != null)
                        {
                            cellValue = row.Cells[2].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                classroom.NumberClassroom = intValue;
                            cellValue = row.Cells[3].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                classroom.NumberOfSeats = intValue;

                            mysqlContext.Classrooms.Update(classroom);
                            mysqlContext.SaveChanges();
                        }
                        else
                        {
                            classroom = new Classroom();
                            cellValue = row.Cells[2].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                classroom.NumberClassroom = intValue;
                            cellValue = row.Cells[3].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                classroom.NumberOfSeats = intValue;
                            mysqlContext.Classrooms.Add(classroom);
                            mysqlContext.SaveChanges();
                        }
                    }

                    break;

                case "Days":
                    Models.Day day;

                    row = dataGridView1.Rows[e.RowIndex];
                    cellValue = row.Cells[1].EditedFormattedValue.ToString();
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                    {
                        day = mysqlContext.Days.Find(intValue);
                        if (day != null)
                        {
                            day.DayOfWeek = row.Cells[2].EditedFormattedValue.ToString();
                            cellValue = row.Cells[3].EditedFormattedValue.ToString();
                            if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                day.IdWeek = intValue;

                            mysqlContext.Days.Update(day);
                            mysqlContext.SaveChanges();
                        }
                    }
                    else
                    {
                        if(row.Cells[1].EditedFormattedValue.ToString() != null)
                        {
                            day = new Models.Day();
                            day.DayOfWeek = row.Cells[2].EditedFormattedValue.ToString();
                            if (row.Cells[3].Value.ToString() != null)
                            {
                                cellValue = row.Cells[3].Value.ToString();
                                if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                                    day.IdWeek = intValue;
                                mysqlContext.Days.Add(day);
                                mysqlContext.SaveChanges();
                            }
                            
                        }
                    }
                    //dayRefresh();

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
                    Semester semester = (Semester)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                    if (semester != null)
                    {
                        if (mysqlContext.Entry(semester).State == EntityState.Detached)
                            mysqlContext.Semesters.Add(semester);
                        else
                            mysqlContext.Entry(semester).State = EntityState.Modified;
                        mysqlContext.SaveChanges();
                        dataGridView1.Refresh();
                    }
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
                    Week week = (Week)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                    if(week != null)
                    {
                        if (mysqlContext.Entry(week).State == EntityState.Detached)
                            mysqlContext.Weeks.Add(week);
                        else
                            mysqlContext.Entry(week).State = EntityState.Modified;
                        mysqlContext.SaveChanges();
                        dataGridView1.Refresh();
                    }
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
                        int intValue;
                        string cellValue;
                        cellValue = dataGridView1.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
                        if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                        {
                            teacher = mysqlContext.Teachers.Find(intValue);
                            if (teacher != null)
                            {
                                mysqlContext.Teachers.Remove(teacher);
                                mysqlContext.SaveChanges();
                                dataGridView1.Refresh();
                            }
                        }
                        mysqlContext.Teachers.Load();
                        dataGridView1.DataSource = mysqlContext.Teachers.Local.ToBindingList();
                        break;

                    case "Subjects":
                        Subject subject;

                        cellValue = dataGridView1.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
                        if (cellValue != null && int.TryParse(cellValue.ToString(), out intValue))
                        {
                            subject = mysqlContext.Subjects.Find(intValue);
                            if (subject != null)
                            {
                                mysqlContext.Subjects.Remove(subject);
                                mysqlContext.SaveChanges();
                                dataGridView1.Refresh();
                            }
                        }
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

        private void dayRefresh()
        {
            mysqlContext.Days.Load();
            mysqlContext.Weeks.Load();
            var dayRows = mysqlContext.Days.Local.ToList();
            var weekRows = mysqlContext.Weeks.Local.ToList();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "IdDay"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "DayOfWeek"
            });

            var my_custom_combobox = new DataGridViewComboBoxColumn
            {
                HeaderText = "Week",
                DataSource = weekRows,
                DisplayMember = "NumberWeek",
                ValueMember = "IdWeek"             };
            dataGridView1.Columns.Add(my_custom_combobox);

            foreach (var row in dayRows)
            {
                dataGridView1.Rows.Add(row.IdDay, row.DayOfWeek, my_custom_combobox.Items[row.IdWeek]);
            }

            // Затычка


        }
    }
}
