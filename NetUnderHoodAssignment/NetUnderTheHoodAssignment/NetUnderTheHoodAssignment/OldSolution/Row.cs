namespace CsvDataAccess.OldSolution;

public class Row
{
    private Dictionary<string, object> _data;
    private Dictionary<string, int> _intData;
    private Dictionary<string, string> _stringData;
    private Dictionary<string, bool> _boolData;
    private Dictionary<string, decimal> _decimalData;
    private Dictionary<string, MixedType> _mxd;

    public struct MixedType
    {
        public int IntValue { get; set; }
        public string StringValue { get; set; }
        public decimal DecimalValue { get; set; }
        public bool BoolValue { get; set; }

    }

    public Row(Dictionary<string, MixedType> mxd)
    {
        _mxd = mxd;
    }

    public Row(Dictionary<string, int> intData)
    {
        _intData = intData;
    }

    public Row(Dictionary<string, string> stringData)
    {
        _stringData = stringData;
    }


    public Row(Dictionary<string, bool> boolData)
    {
        _boolData = boolData;
    }

    public Row(Dictionary<string, decimal> decimalData)
    {
        _decimalData = decimalData;
    }

    public Row(Dictionary<string, object> data)
    {
        _data = data;
    }

    public object GetAtColumn(string columnName)
    {
        return _data[columnName];
    }
}