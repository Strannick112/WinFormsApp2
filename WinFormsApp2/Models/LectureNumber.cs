using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinFormsApp2.Models;

public partial class LectureNumber
{
    public int IdLectureNumber { get; set; }

    public int NumberOfLecture { get; set; }

    [Browsable(false)]
    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
