using System.Collections;

Console.WriteLine();
var linkedList = new CustomLinkedList<string>();

linkedList.AddFirst(new Node<string>("Folasade"));
linkedList.AddFirst(new Node<string>("Demilade"));
linkedList.AddFirst(new Node<string>("Darasimi"));

foreach (var node in linkedList)
{
    Console.WriteLine(node.Value);
}

public class Node<T>
{
    public T Value { get; set; }    
    public Node<T>? Next { get; set; }
    public Node<T>? Prev { get; set; }

    public Node(T value)
    {
        Value = value;
    }
}

public class CustomLinkedList<T> : IEnumerable<Node<T>>
{
    public Node<T>? First { get; set; }
    public int Count { get; set; }

    public IEnumerator<Node<T>> GetEnumerator()
    {
        Node<T> currentNode = First;

        while (currentNode is not null)
        {
            yield return currentNode;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void AddFirst(Node<T> nodeToAdd)
    {
        if (First is null)
        {
            First = nodeToAdd;
        }
        else
        {
            nodeToAdd.Next = First;
            First.Prev = nodeToAdd;

            First = nodeToAdd;
        }

        Count++;
    }

    public Node<T>? Find(T valueToFind)
    {
        var aux = First;

        while (aux is not null)
        {
            if (EqualityComparer<T>.Default.Equals(aux.Value, valueToFind))
            {
                return aux;
            }

            aux = aux.Next;
        }

        return default;
    }

    public void Remove(T valueToRemove)
    { 
        var find = Find(valueToRemove);

        if (find is null)
        {
            return;
        }

        var next = find.Next;
        var prev = find.Prev;

        if (prev is not null)
        {
            prev.Next = next;
        }

        if (next is not null)
        { 
            next.Prev = prev;
        }

        Count--; 
    }
}