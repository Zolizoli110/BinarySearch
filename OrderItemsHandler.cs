namespace BinarySearch;

public enum SortingMethod
{
    Insertion,
    Bubble,
    Selection
}
public class OrderItemsHandler
{
    private IComparable[] _items;
    private Func<IComparable, IComparable, bool> CMP;

    public OrderItemsHandler(IComparable[] items)
    {
        _items = items;
    }

    public void DefineCmp(bool ascending)
    {
        CMP = (a, b) => ascending ? a.CompareTo(b) < 0 : b.CompareTo(a) < 0;
    }
    
    public bool IsOrdered(bool ascending = true)
    {
        DefineCmp(ascending);
        for (int i = 0; i < _items.Length - 1; i++)
        {
            if (!CMP(_items[i], _items[i + 1]))
            {
                return false;
            }
        }

        return true;
    }

    public void Sort(SortingMethod sortingMethod, bool ascending = true)
    {
        DefineCmp(ascending);
        switch (sortingMethod)
        {
            case SortingMethod.Selection: 
                Selection();
                break;
            case SortingMethod.Bubble:
                throw new NotImplementedException();
                break;
            case SortingMethod.Insertion:
                throw new NotImplementedException();
                break;
        }
    }

    public void Selection()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            int min = i;
            for (int j = min + 1; j < _items.Length; j++)
            {
                if (CMP(_items[j], _items[i]))
                {
                    min = j;
                }
            }
            Swap(i, min);
        }
    }

    private void Swap(int i, int j)
    {
        IComparable tmp = _items[i];
        _items[i] = _items[j];
        _items[j] = tmp;
    }

    public int BinarySearchIterated(PhoneBookItem value, bool ascending = true)
    {
        DefineCmp(ascending);
        int left = 0;
        int right = _items.Length - 1;
        int center = (left + right) / 2;

        while (left <= right && !_items[center].Equals(value))
        {
            if (CMP(value, _items[center]))
                right = center - 1;
            else
                left = center + 1;
            center = (left + right) / 2;
        }

        return left <= right ? center : -1;
    }

    public int BinarySearchRecursion(PhoneBookItem value, bool ascending = true)
    {
        DefineCmp(ascending);
        return Recursion(value, 0, _items.Length - 1);
    }

    private int Recursion(PhoneBookItem value, int left, int right)
    {
        if (left > right) return -1;

        int center = (left + right) / 2;
        if (_items[center].Equals(value)) return center;

        if (CMP(value, _items[center]))
            return Recursion(value, left, center - 1);
        return Recursion(value, center + 1, right);
    }
}