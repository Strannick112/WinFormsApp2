using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class LectureNumber
{
    public int IdLectureNumber { get; set; }

    public int NumberOfLecture { get; set; }

    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
