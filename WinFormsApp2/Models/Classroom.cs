using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinFormsApp2.Models;

public partial class Classroom
{
    public int IdClassroom { get; set; }

    public int NumberClassroom { get; set; }

    public int NumberOfSeats { get; set; }

    [Browsable(false)]
    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

    [Browsable(false)]
    public virtual ICollection<TypesClassroom> TypesClassroomsIdTypeClassrooms { get; set; } = new List<TypesClassroom>();
}
