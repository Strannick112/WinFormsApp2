using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinFormsApp2.Models;

public partial class Week
{
    public int IdWeek { get; set; }

    public int NumberWeek { get; set; }

    public int IdSemester { get; set; }

    [Browsable(false)]
    public virtual ICollection<Day> Days { get; set; } = new List<Day>();

    [Browsable(false)]
    public virtual Semester IdSemesterNavigation { get; set; } = null!;
}
