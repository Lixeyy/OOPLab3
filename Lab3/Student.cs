namespace Lab3;

/// <summary>Представляє студента.</summary>
public class Student
{
    /// <summary>Ім'я студента.</summary>
    public required string Name
    {
        get;
        init => field = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Name cannot be empty", nameof(Name))
            : value.Trim();
    }

    /// <summary>Прізвище студента.</summary>
    public required string Surname
    {
        get;
        init => field = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Surname cannot be empty", nameof(Surname))
            : value.Trim();
    }

    /// <summary>Назва групи.</summary>
    public required string Group
    {
        get;
        init => field = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Group cannot be empty", nameof(Group))
            : value.Trim();
    }

    /// <summary>Номер студента у списку групи.</summary>
    public required int NumberInGroup
    {
        get;
        init => field = value < 0
            ? throw new ArgumentException("Id cannot be negative", nameof(NumberInGroup))
            : value;
    }

    /// <summary>Дата народження студента (необов'язково).</summary>
    public DateTime? DateOfBirth
    {
        get;
        init => field = value != null && DateTime.Now < value  
            ? throw new ArgumentException("DateOfBirth cannot be in future", nameof(DateOfBirth))
            : value;
    } = null;

    /// <summary>Повертає рядкове представлення даних студента.</summary>
    public override string ToString()
    {
        var birthdayStr = DateOfBirth == null ? "N/A" : DateOfBirth?.ToString("dd.MM.yyyy");
        return $"Name: {Name} {Surname}; Group: {Group}; Number: {NumberInGroup}; Birthday: {birthdayStr}";
    }

    /// <summary>Перевіряє рівність поточного студента з іншим об'єктом.</summary>
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

    /// <summary>Повертає хеш-код студента.</summary>
    public override int GetHashCode()
    {
        return NumberInGroup.GetHashCode()
               + Group.GetHashCode()
               + Name.GetHashCode()
               + Surname.GetHashCode() 
               + DateOfBirth.GetHashCode();
    }
}