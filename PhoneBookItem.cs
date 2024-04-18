namespace BinarySearch;

public class PhoneBookItem : IComparable
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    
    public int CompareTo(object? obj)
    {
        if (obj is null) throw new ArgumentNullException(nameof(obj));
        var item = obj as PhoneBookItem;
        if (item == null) throw new ArgumentException(nameof(obj));

        return String.Compare(Name, item.Name, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj)
    {
        var item = obj as PhoneBookItem;
        if (item == null) throw new ArgumentException(nameof(obj));

        return Name == item.Name && PhoneNumber == item.PhoneNumber;
    }
}