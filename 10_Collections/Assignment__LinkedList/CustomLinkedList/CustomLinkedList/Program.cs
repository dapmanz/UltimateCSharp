using System.Collections;

var customLinkedList = new CustomLinkedList<string>();
customLinkedList.AddToFront("Bose");
customLinkedList.AddToFront("Gbemi");
customLinkedList.AddToFront("Tolu");
customLinkedList.Add("Sola");
customLinkedList.AddToEnd("Segun");

var result = customLinkedList.Remove("Gbemi");

foreach (var item in customLinkedList)
{
    Console.WriteLine(item);
}

Console.WriteLine(customLinkedList.Contains("Segun"));

public record Node<T>
{
    public T Value { get; set; }
    public Node<T>? Previous { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T value)
    {
        if (value == null)
        { 
            throw new ArgumentNullException("value"); 
        }
        Value = value;
    }
}

public class CustomLinkedList<T> : ILinkedList<T>
{
    public Node<T>? First { get; set; }
    public CustomLinkedList()
    {
    }

    public int Count { get; set; }

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        if (item!.GetType()  != typeof(T))
        {
            throw new NotSupportedException();
        }
        AddToEnd(item);
    }

    public void AddToEnd(T item)
    {
        var nodeToAdd = new Node<T>(item);

        // check the linked list is not empty
        if (First is null)
        {
            First = nodeToAdd;
            Count++;
            return;
        }
        else
        {
            // Find last item... then last.Next = item and item.Prev = last
            var aux = First;
            while (aux.Next is not null)
            {
                aux = aux.Next;
            }
            aux.Next = nodeToAdd;
            nodeToAdd.Previous = aux;
            Count++;
            return;
        }
    }

    public void AddToFront(T item)
    {
        if (First is null)
        {
            First = new Node<T>(item);
        }
        else
        {
            Node<T> nodeToAdd = new Node<T>(item);
            nodeToAdd.Next = First;
            First.Previous = nodeToAdd;

            First = nodeToAdd;
        }
        Count++;
    }

    public void Clear()
    {
        if (First is  not null)
        {
            First = null;
            Count = 0;
        }
    }

    public bool Contains(T item)
    {
        var nodeToFind = new Node<T>(item);
        var nodeToCheck = First;
        while (nodeToCheck != null)
        {
            if (nodeToCheck.Value!.Equals(nodeToFind.Value))
            {
                return true;
            }
            nodeToCheck = nodeToCheck.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
        // throw null exceptn if node.value is null
        // throw arg ex if node.value type does not match array type
        // throw arg out of range ex if Count of collection > arrayLength - index 

        // loop through each node.value and copy to the correct index in array
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? currentNode = First;
        while(currentNode is not null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    public bool Remove(T item)
    {
        var nodeToRemove = new Node<T>(item);
        var nodeToCheck = First;
        while (nodeToCheck is not null)
        {
            //if (nodeToCheck.Equals(nodeToRemove))
            if (nodeToCheck.Value!.Equals(nodeToRemove.Value))
            {
                var nextNode = nodeToCheck.Next;
                var previousNode = nodeToCheck.Previous;
                if (previousNode is not null)
                {
                    previousNode.Next = nextNode;
                }
                if (nextNode is not null)
                {
                    nextNode.Previous = previousNode;
                }
                
                Count--;
                return true; 
            }
            else
            {
                nodeToCheck = nodeToCheck.Next;
            }
        }
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}