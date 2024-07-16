using System;

namespace Coding.Exercise
{
    public class SortedList<T> where T : IComparable<T> //your code goes here
    {
        public IEnumerable<T> Items { get; }

        public SortedList(IEnumerable<T> items)
        {
            var asList = items.ToList();
            asList.Sort();
            Items = asList;
        }


    }

    public class FullName : IComparable <FullName> // your code goes here
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public override string ToString() => $"{FirstName} {LastName}";

        //your code hoes here
        public int CompareTo(FullName? other)
        {
            if (String.Compare(LastName, other.LastName) == 0)
                return (String.Compare(FirstName, other.FirstName));

            return String.Compare(LastName, other.LastName);
        }
    }
}