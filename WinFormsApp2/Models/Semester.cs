using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class Semester
{
    public int IdSemester { get; set; }

    public int NumberSemester { get; set; }

    public string Date { get; set; } = null!;

    public virtual ICollection<Week> Weeks { get; set; } = new List<Week>();
}
