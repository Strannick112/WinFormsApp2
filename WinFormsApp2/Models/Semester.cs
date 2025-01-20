using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinFormsApp2.Models;

public partial class Semester
{
    public int IdSemester { get; set; }

    public int NumberSemester { get; set; }

    public string Date { get; set; } = null!;

    [Browsable(false)]
    public virtual ICollection<Week> Weeks { get; set; } = new List<Week>();
}
