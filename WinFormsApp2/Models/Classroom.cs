using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class Classroom
{
    public int IdClassroom { get; set; }

    public int NumberClassroom { get; set; }

    public int NumberOfSeats { get; set; }

    public virtual ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();

    public virtual ICollection<TypesClassroom> TypesClassroomsIdTypeClassrooms { get; set; } = new List<TypesClassroom>();
}
