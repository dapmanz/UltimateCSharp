using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;
using static CsvDataAccess.OldSolution.Row;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<Row>();
        // var listMixedTypes = new List<MixedType?>();

        foreach (var row in csvData.Rows)
        {
            // var newRowData = new Dictionary<string, MixedType>();
            var newRowData = new Dictionary<string, Row.MixedType>();

            var intData = new Dictionary<string, int>();
            var decimalData = new Dictionary<string, decimal>();
            var boolData = new Dictionary<string, bool>();
            var stringData = new Dictionary<string, string>();  

            // string valueAsString = default;

            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];
                newRowData[column] = ReturnToTargetType(column, valueAsString).Value;
            }


            //for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            //{
            //    var column = csvData.Columns[columnIndex];
            //    string valueAsString = row[columnIndex];
            //    newRowData[column] = ConvertValueToTargetType(valueAsString);
            //}

            resultRows.Add(new Row(newRowData);  
        }

        return new TableData(csvData.Columns, resultRows);
    }

    private object ConvertValueToTargetType(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        if (value == "TRUE")
        {
            return true;
        }
        if (value == "FALSE")
        {
            return false;
        }
        if (value.Contains(".") && decimal.TryParse(value, out var valueAsDecimal))
        {
            return valueAsDecimal;
        }
        if (int.TryParse(value, out var valueAsInt))
        {
            return valueAsInt;
        }
        return value;
    }

    private Dictionary<string, T> ReturnToTargetType(string column, string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        if (value == "TRUE")
        {
            return new Dictionary<string, bool> { [column] = true };
        }
        if (value == "FALSE")
        {
            return new Dictionary<string, bool> { [column] = false };
        }
        if (value.Contains(".") && decimal.TryParse(value, out var valueAsDecimal))
        {
            return new Dictionary<string, decimal> { [column] = valueAsDecimal };
        }
        if (int.TryParse(value, out var valueAsInt))
        {
            return new Dictionary<string, int> { [column] = valueAsInt };
        }
        return new Dictionary<string, string> { [column] = value };
    }
}
