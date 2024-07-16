var ints = new int[] { 1, 2, 3 };
var strings = new string[] {"a", "b", "c", "d"};
var pairOfArrays = new PairOfArrays<int, string>(ints, strings);

(int, string) result = pairOfArrays[2, 1];
pairOfArrays[2, 1] = (100, "XXX");

(int, string) resultAfterSet = pairOfArrays[2, 1];

Console.WriteLine(result);
Console.WriteLine(resultAfterSet);

public class PairOfArrays<TLeft, TRight>
{
    private readonly TLeft[] _left;
    private readonly TRight[] _right;

    public PairOfArrays(
        TLeft[] left, TRight[] right)
    {
        _left = left;
        _right = right;
    }

    //your code goes here

    public ValueTuple<TLeft, TRight> this[int lIndex, int rIndex]
    {
        get
        {
            if (lIndex > _left.Length || rIndex > _right.Length)
            { 
                throw new IndexOutOfRangeException();
            }

            return (_left[lIndex], _right[rIndex]);
        }

        set
        {
            if (lIndex > _left.Length || rIndex > _right.Length)
            {
                throw new IndexOutOfRangeException();
            }
  
            (_left[lIndex], _right[rIndex]) = value;
        }
    }
}
