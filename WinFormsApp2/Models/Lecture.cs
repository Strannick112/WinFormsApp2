using System;
using System.Collections.Generic;

namespace WinFormsApp2.Models;

public partial class Lecture
{
    public int IdLectures { get; set; }

    public int IdTypeLecture { get; set; }

    public int IdClassrooms { get; set; }

    public int IdTeacher { get; set; }

    public int IdSubject { get; set; }

    public int IdDay { get; set; }

    public int IdGroup { get; set; }

    public int IdLectureNumber { get; set; }

    public virtual Classroom IdClassroomsNavigation { get; set; } = null!;

    public virtual Day IdDayNavigation { get; set; } = null!;

    public virtual Group IdGroupNavigation { get; set; } = null!;

    public virtual LectureNumber IdLectureNumberNavigation { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;

    public virtual TypesLecture IdTypeLectureNavigation { get; set; } = null!;
}
