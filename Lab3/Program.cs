namespace Lab3;

internal class Program
{
    private static void Main(string[] args)
    {
        var initStudents = CreateStudents();
        var university = new University(initStudents);

        university.SortStudentsByGroupAscAndNumberDesc();

        var result = string.Join(Environment.NewLine, university.Students);
        Console.WriteLine("\nSorted students:\n" + result);

        var studentToSearch = new Student() { Name = "Alex", Surname = "Bridnia", Group = "IO-51",
            NumberInGroup = 1, DateOfBirth = new DateTime(2008, 8, 1)};
        var studentFound = university.FindEqualStudent(studentToSearch);

        Console.WriteLine($"\nEquality:\n[{studentFound}] equal [{studentToSearch}]");
        Console.WriteLine($"Are they same: {studentFound == studentToSearch}");
    }

    private static Student[] CreateStudents()
    {
        return
        [
            new Student()
            {
                NumberInGroup = 10,
                Name = "Jeremy",
                Surname = "White",
                DateOfBirth = new DateTime(2008, 3, 9),
                Group = "IO-51"
            },
            new Student()
            {
                NumberInGroup = 1,
                Name = "Sam",
                Surname = "Len",
                DateOfBirth = new DateTime(2010, 5, 12),
                Group = "IO-52"
            },
            new Student()
            {
                NumberInGroup = 1,
                Name = "Alex",
                Surname = "Bridnia",
                DateOfBirth = new DateTime(2008, 8, 1),
                Group = "IO-51"
            },
            new Student()
            {
                NumberInGroup = 8,
                Name = "Sveta",
                Surname = "Hopko",
                Group = "IO-52"
            },
            new Student()
            {
                NumberInGroup = 2,
                Name = "Emma",
                Surname = "Stone",
                DateOfBirth = new DateTime(2011, 12, 19),
                Group = "IO-53"
            },
            new Student()
            {
                NumberInGroup = 13,
                Name = "Alex",
                Surname = "West",
                DateOfBirth = new DateTime(2008, 1, 21),
                Group = "IO-51"
            }
        ];
    }
}
