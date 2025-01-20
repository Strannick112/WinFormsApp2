using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinFormsApp2.Models;

public partial class Day
{
    public int IdDay { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public int IdWeek { get; set; }


    [Browsable(false)]
    public virtual Week IdWeekNavigation { get; set; } = null!;

    [Browsable(false)]
    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
