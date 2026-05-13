using JetBrains.Annotations;
using Lab3;
using Xunit;

namespace Lab3.Tests;

[TestSubject(typeof(University))]
public class UniversityTest
{
    [Fact]
    public void Constructor_ShouldSetStudents()
    {
        // Arrange
        Student[] students =
        [
            new() { Name = "A", Surname = "B", NumberInGroup = 3, Group = "G1" },
            new() { Name = "L", Surname = "Sir", NumberInGroup = 1, Group = "g-02" },
        ];

        // Act
        var university = new University(students);

        // Assert
        Assert.Equal(students, university.Students);
    }
    
    [Fact]
    public void FindEqualStudent_WhenStudentExists_ShouldReturnFoundStudent()
    {
        // Arrange
        var studentToFind = new Student() { Name = "A", Surname = "B", NumberInGroup = 1, Group = "G1" };
        Student[] students =
        [
            new() { Name = "Alex", Surname = "Bridnia", NumberInGroup = 1, Group = "G1" },
            new() { Name = "A", Surname = "B", NumberInGroup = 1, Group = "G1" },
            new() { Name = "L", Surname = "Sir", NumberInGroup = 1, Group = "g-02" }
        ];
        var university = new University(students);

        // Act
        var result = university.FindEqualStudent(studentToFind);

        // Assert
        Assert.Equal(studentToFind, result);
        Assert.NotSame(studentToFind, result);
    }

    [Fact]
    public void FindEqualStudent_WhenStudentDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        var studentToFind = new Student() { Name = "NewName", Surname = "NewS", NumberInGroup = 1, Group = "G1" };
        Student[] students =
        [
            new() { Name = "A", Surname = "B", NumberInGroup = 1, Group = "G1" },
            new() { Name = "V", Surname = "White", NumberInGroup = 3, Group = "G1" }
        ];
        var university = new University(students);

        // Act
        var result = university.FindEqualStudent(studentToFind);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SortStudentsByGroupAscAndNumberDesc_ShouldSortInnerStudents()
    {
        // Arrange
        Student[] students =
        [
            new() { Name = "A", Surname = "1", NumberInGroup = 5, Group = "g-2" },
            new() { Name = "B", Surname = "2", NumberInGroup = 1, Group = "g-1" },
            new() { Name = "C", Surname = "3", NumberInGroup = 3, Group = "g-3" },
            new() { Name = "D", Surname = "1", NumberInGroup = 2, Group = "g-1" },
            new() { Name = "E", Surname = "2", NumberInGroup = 8, Group = "g-3" },
            new() { Name = "F", Surname = "3", NumberInGroup = 2, Group = "g-3" },
        ];
        var university = new University(students);

        // Act
        university.SortStudentsByGroupAscAndNumberDesc();

        // Assert
        var sortedStudents = university.Students;
        Assert.Equal(students.Length, sortedStudents.Length);
        Assert.Equal(students[3], sortedStudents[0]);
        Assert.Equal(students[1], sortedStudents[1]);
        Assert.Equal(students[0], sortedStudents[2]);
        Assert.Equal(students[4], sortedStudents[3]);
        Assert.Equal(students[2], sortedStudents[4]);
        Assert.Equal(students[5], sortedStudents[5]);
    }
}