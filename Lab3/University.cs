namespace Lab3;

/// <summary>Представляє університет зі студентами.</summary>
public class University(Student[] students)
{
    /// <summary>Масив усіх студентів університету.</summary>
    public Student[] Students { get; } = [..students];

    /// <summary>Сортує студентів за групою (зростання) та номером (спадання).</summary>
    public void SortStudentsByGroupAscAndNumberDesc()
    {
        Students.Sort(StudentComparerByGroupAscAndNumberDesc);
    }

    /// <summary>Шукає студента з ідентичними даними.</summary>
    public Student? FindEqualStudent(Student student)
    {
        return Students.FirstOrDefault(s => s.Equals(student));
    }

    private static int StudentComparerByGroupAscAndNumberDesc(Student student1, Student student2)
    {
        var groupCompareToAsc = string.Compare(student1.Group, student2.Group, StringComparison.Ordinal);
        var idCompareToDesc = student2.NumberInGroup.CompareTo(student1.NumberInGroup);
        return groupCompareToAsc == 0 ? idCompareToDesc : groupCompareToAsc;
    }
}