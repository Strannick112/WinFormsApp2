using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinFormsApp2.Models;

public partial class Subject
{
    public int IdSubject { get; set; }

    public string NameSubject { get; set; } = null!;

    public int HoursLecture { get; set; }

    public int HoursLaboratory { get; set; }

    public int HoursPractices { get; set; }

    public int HoursConsultation { get; set; }

    public int HoursExam { get; set; }

    [Browsable(false)]
    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
