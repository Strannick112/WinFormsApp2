using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class Week
{
    public int IdWeek { get; set; }

    public int NumberWeek { get; set; }

    public int IdSemester { get; set; }

    public virtual ICollection<Day> Days { get; set; } = new List<Day>();

    public virtual Semester IdSemesterNavigation { get; set; } = null!;
}
