namespace Lab3;

public class University(Student[] students)
{
    public Student[] Students { get; } = students;

    public void SortStudentsByGroupAscAndNumberDesc()
    {
        Students.Sort(StudentComparerByGroupAscAndNumberDesc);
    }

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