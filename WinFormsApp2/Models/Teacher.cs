using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp2.Models;

public partial class Teacher
{
    [Key]
    public int IdTeacher { get; set; }

    public string FullName { get; set; } = null!;

    public string Status { get; set; } = null!;

    [Browsable(false)]
    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

}
