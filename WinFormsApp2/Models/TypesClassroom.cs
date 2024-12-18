using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class TypesClassroom
{
    public int IdTypeClassroom { get; set; }

    public string NameOfType { get; set; } = null!;

    public virtual ICollection<Classroom> ClassroomsIdClassrooms { get; set; } = new List<Classroom>();
}
