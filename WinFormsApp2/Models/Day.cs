using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class Day
{
    public int IdDay { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public int IdWeek { get; set; }

    public virtual Week IdWeekNavigation { get; set; } = null!;

    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
