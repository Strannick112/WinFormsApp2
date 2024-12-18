using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class Group
{
    public int IdGroup { get; set; }

    public string NameOfGroup { get; set; } = null!;

    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
