using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class TypesLecture
{
    public int IdTypeLecture { get; set; }

    public string TitleLecturec { get; set; } = null!;

    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
