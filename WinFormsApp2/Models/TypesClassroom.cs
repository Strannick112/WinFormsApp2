using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WinFormsApp2.Models;

public partial class TypesClassroom
{
    public int IdTypeClassroom { get; set; }

    public string NameOfType { get; set; } = null!;

    [Browsable(false)]
    public virtual ICollection<Classroom> ClassroomsIdClassrooms { get; set; } = new List<Classroom>();
}
