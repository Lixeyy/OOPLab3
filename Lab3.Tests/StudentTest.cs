using System;
using JetBrains.Annotations;
using Lab3;
using Xunit;

namespace Lab3.Tests;

[TestSubject(typeof(Student))]
public class StudentTest
{
    [Fact]
    public void Constructor_WhenDataIsCorrect_ShouldCreateStudent()
    {
        // Arrange
        var numInGroup = 2;
        var name = "Олег";
        var surname = "Коршун";
        var group = "01";
        var dateOfBirth = new DateTime(1032828);
        
        // Act
        var student = new Student() { Name = name, Surname = surname, NumberInGroup = numInGroup, Group = group, DateOfBirth = dateOfBirth };
        
        // Assert
        Assert.Equal(numInGroup, student.NumberInGroup);
        Assert.Equal(name, student.Name);
        Assert.Equal(surname, student.Surname);
        Assert.Equal(group, student.Group);
        Assert.Equal(dateOfBirth, student.DateOfBirth);
    }

    [Fact]
    public void Constructor_WhenNameIsEmpty_ShouldThrowError()
    {
        // Arrange
        const string name = " ";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => 
            new Student() { Name = name, Surname = "Twix", NumberInGroup = 2, Group = "G1" });

        // Assert
        Assert.Contains("Name", exception.ParamName);
    }

    [Fact]
    public void Constructor_WhenSurnameIsEmpty_ShouldThrowError()
    {
        // Arrange
        const string surname = "";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => 
            new Student() { Name = "Fin", Surname = surname, NumberInGroup = 2, Group = "G1" });

        // Assert
        Assert.Contains("Surname", exception.ParamName);
    }

    [Fact]
    public void Constructor_WhenNumberInGroupIsNegative_ShouldThrowError()
    {
        // Arrange
        const int numInGroup = -100;

        // Act
        var exception = Assert.Throws<ArgumentException>(() => 
            new Student() { Name = "Fin", Surname = "Twix", NumberInGroup = numInGroup, Group = "G1" });

        // Assert
        Assert.Contains("NumberInGroup", exception.ParamName);
    }

    [Fact]
    public void Constructor_WhenGroupNameIsEmpty_ShouldThrowError()
    {
        // Arrange
        const string groupName = "   ";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => 
            new Student() { Name = "Fin", Surname = "Twix", NumberInGroup = 2, Group = groupName });

        // Assert
        Assert.Contains("Group", exception.ParamName);
    }

    [Fact]
    public void Constructor_WhenDateOfBirthIsInFuture_ShouldThrowError()
    {
        // Arrange
        var tomorrow = DateTime.Now.AddDays(1);

        // Act
        var exception = Assert.Throws<ArgumentException>(() => 
            new Student() { Name = "Fin", Surname = "Twix", NumberInGroup = 2, Group = "G1", DateOfBirth = tomorrow });

        // Assert
        Assert.Contains("DateOfBirth", exception.ParamName);
    }

    [Fact]
    public void ToString_WhenDataIsNotNull_ShouldReturnCorrectString()
    {
        // Arrange
        var student = new Student()
        {
            Name = "Олексій",
            Surname = "Брідня",
            NumberInGroup = 1,
            Group = "ІО-51",
            DateOfBirth = new DateTime(2008, 8, 1)
        };
        var expectedResult = "Name: Олексій Брідня; Group: ІО-51; Number: 1; Birthday: 01.08.2008";

        // Act
        var result = student.ToString();

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ToString_WhenDataIsNull_ShouldReturnCorrectStringWithNA()
    {
        // Arrange
        var student = new Student()
        {
            Name = "Олексій",
            Surname = "Брідня",
            NumberInGroup = 1,
            Group = "ІО-51"
        };
        var expectedResult = "Name: Олексій Брідня; Group: ІО-51; Number: 1; Birthday: N/A";

        // Act
        var result = student.ToString();

        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void Equals_WhenAllFieldsAreIdentical_ShouldReturnTrue()
    {
        // Arrange
        var student1 = new Student()
        {
            Name = "Cat",
            Surname = "Dog",
            NumberInGroup = 100,
            Group = "G2",
            DateOfBirth = new DateTime(1000)
        };
        var student2 = new Student()
        {
            Name = student1.Name,
            Surname = student1.Surname,
            NumberInGroup = student1.NumberInGroup,
            Group = student1.Group,
            DateOfBirth = student1.DateOfBirth
        };

        // Act
        var result = student1.Equals(student2);

        // Assert
        Assert.True(result);
    }
        
    [Fact]
    public void Equals_WhenDateIsDifferent_ShouldReturnFalse()
    {
        // Arrange
        var student1 = new Student()
        {
            Name = "Jemma Maria",
            Surname = "Renoir",
            NumberInGroup = 25,
            Group = "KL",
            DateOfBirth = new DateTime(1999,10,5)
        };
        var student2 = new Student()
        {
            Name = student1.Name,
            Surname = student1.Surname,
            NumberInGroup = student1.NumberInGroup,
            Group = student1.Group,
            DateOfBirth = new DateTime(1999,5,10)
        };

        // Act
        var result = student1.Equals(student2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_WhenNameIsDifferent_ShouldReturnFalse()
    {
        // Arrange
        var student1 = new Student()
        {
            Name = "Jemma Maria",
            Surname = "Renoir",
            NumberInGroup = 25,
            Group = "KL",
            DateOfBirth = new DateTime(1999,10,5)
        };
        var student2 = new Student()
        {
            Name = "Horton",
            Surname = student1.Surname,
            NumberInGroup = student1.NumberInGroup,
            Group = student1.Group,
            DateOfBirth = student1.DateOfBirth
        };

        // Act
        var result = student1.Equals(student2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_WhenSurnameIsDifferent_ShouldReturnFalse()
    {
        // Arrange
        var student1 = new Student()
        {
            Name = "Jemma Maria",
            Surname = "Renoir",
            NumberInGroup = 25,
            Group = "KL",
            DateOfBirth = new DateTime(1999,10,5)
        };
        var student2 = new Student()
        {
            Name = student1.Name,
            Surname = "Bridnia",
            NumberInGroup = student1.NumberInGroup,
            Group = student1.Group,
            DateOfBirth = student1.DateOfBirth
        };

        // Act
        var result = student1.Equals(student2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_WhenGroupIsDifferent_ShouldReturnFalse()
    {
        // Arrange
        var student1 = new Student()
        {
            Name = "A",
            Surname = "B",
            NumberInGroup = 1000,
            Group = "KL",
            DateOfBirth = new DateTime(2025,10,5)
        };
        var student2 = new Student()
        {
            Name = student1.Name,
            Surname = student1.Surname,
            NumberInGroup = student1.NumberInGroup,
            Group = "G-3",
            DateOfBirth = student1.DateOfBirth
        };

        // Act
        var result = student1.Equals(student2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_WhenNumberInGroupIsDifferent_ShouldReturnFalse()
    {
        // Arrange
        var student1 = new Student()
        {
            Name = "Jemma Maria",
            Surname = "Renoir",
            NumberInGroup = 300,
            Group = "KL",
            DateOfBirth = new DateTime(1980,1,1)
        };
        var student2 = new Student()
        {
            Name = student1.Name,
            Surname = student1.Surname,
            NumberInGroup = 500,
            Group = student1.Group,
            DateOfBirth = student1.DateOfBirth
        };

        // Act
        var result = student1.Equals(student2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetHashCode_WhenAllFieldsAreIdentical_ShouldReturnSameResult()
    {
        // Arrange
        var student1 = new Student()
        {
            Name = "Kate",
            Surname = "Mer",
            NumberInGroup = 6,
            Group = "G4",
            DateOfBirth = new DateTime(2020,3,31)
        };
        var student2 = new Student()
        {
            Name = student1.Name,
            Surname = student1.Surname,
            NumberInGroup = student1.NumberInGroup,
            Group = student1.Group,
            DateOfBirth = student1.DateOfBirth
        };

        // Act
        var student1HashCode = student1.GetHashCode();
        var student2HashCode = student2.GetHashCode();

        // Assert
        Assert.True(student1HashCode > 0);
        Assert.True(student2HashCode > 0);
        Assert.Equal(student1HashCode, student2HashCode);
    }
}