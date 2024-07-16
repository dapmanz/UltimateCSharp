namespace CsvDataAccess.NewSolution;

public class FastRow
{
    private Dictionary<string, int> _intsData = new();
    private Dictionary<string, decimal> _decimalsData = new();
    private Dictionary<string, bool> _boolsData = new();
    private Dictionary<string, string> _stringsData = new();

    public void AssignCell(string column, string value)
    {
        _stringsData[column] = value;
    }

    public void AssignCell(string column, decimal value)
    {
        _decimalsData[column] = value;
    }

    public void AssignCell(string column, bool value)
    {
        _boolsData[column] = value;
    }

    public void AssignCell(string column, int value)
    {
        _intsData[column] = value;
    }

    public object GetAtColumn(string columnName)
    {
        if (_intsData.ContainsKey(columnName))
        {
            return _intsData[columnName];
        }
        if (_decimalsData.ContainsKey(columnName))
        {
            return _decimalsData[columnName];
        }
        if (_boolsData.ContainsKey(columnName))
        {
            return _boolsData[columnName];
        }
        if (_stringsData.ContainsKey(columnName))
        {
            return _stringsData[columnName];
        }
        return null;
        
    }
}
