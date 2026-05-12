namespace Lab3;

public class Student
{
    public required int NumberInGroup
    {
        get;
        init => field = value < 0
            ? throw new ArgumentException("Id cannot be negative", nameof(NumberInGroup))
            : value;
    }

    public required string Name
    {
        get;
        init => field = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Name cannot be empty", nameof(Name))
            : value.Trim();
    }

    public required string Surname
    {
        get;
        init => field = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Surname cannot be empty", nameof(Surname))
            : value.Trim();
    }

    public required string Group
    {
        get;
        init => field = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Group cannot be empty", nameof(Group))
            : value.Trim();
    }

    public DateTime? DateOfBirth
    {
        get;
        init => field = value != null && DateTime.Now < value  
            ? throw new ArgumentException("DateOfBirth cannot be in future", nameof(DateOfBirth))
            : value;
    } = null;

    public override bool Equals(object? obj)
    {
        var otherStudent = obj as Student;
        if (otherStudent is null)
        {
            return false;
        }

        return Group == otherStudent.Group
            && NumberInGroup == otherStudent.NumberInGroup
            && Name == otherStudent.Name
            && Surname == otherStudent.Surname
            && DateOfBirth?.ToShortDateString() == otherStudent.DateOfBirth?.ToShortDateString();
    }

    public override int GetHashCode()
    {
        return NumberInGroup.GetHashCode()
               + Group.GetHashCode()
               + Name.GetHashCode()
               + Surname.GetHashCode() 
               + DateOfBirth.GetHashCode();
    }

    public override string ToString()
    {
        var birthdayStr = DateOfBirth == null ? "N/A" : DateOfBirth?.ToShortDateString();
        return $"Name: {Name} {Surname}; Group: {Group}; Number: {NumberInGroup}; Birthday: {birthdayStr}";
    }
}