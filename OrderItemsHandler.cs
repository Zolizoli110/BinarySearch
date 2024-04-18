namespace BinarySearch;

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
}