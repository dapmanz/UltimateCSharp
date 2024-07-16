using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;
using CsvDataAccess.OldSolution;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<FastRow>();

        foreach (var row in csvData.Rows)
        {
            var newRow = new FastRow();

            for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
            {
                var column = csvData.Columns[columnIndex];
                string valueAsString = row[columnIndex];

                if (string.IsNullOrEmpty(valueAsString))
                {
                    continue;
                }
                else if (valueAsString == "TRUE")
                {
                    newRow.AssignCell(column, true);
                }
                if (valueAsString == "FALSE")
                {
                    newRow.AssignCell(column, false);
                }
                if (valueAsString.Contains(".") && decimal.TryParse(valueAsString, out var valueAsDecimal))
                {
                    newRow.AssignCell(column, valueAsDecimal);
                }
                if (int.TryParse(valueAsString, out var valueAsInt))
                {
                    newRow.AssignCell(column, valueAsInt);
                }
                newRow.AssignCell(column, valueAsString);
            }

            resultRows.Add(newRow);
        }

        return new FastTableData(csvData.Columns, resultRows);
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
}
