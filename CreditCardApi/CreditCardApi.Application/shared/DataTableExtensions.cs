using CreditCardApi.Application.Dtos.Transaction;
using System.Data;
using System.Reflection;
using ToDataTable;

namespace CreditCardApi.Application.shared;

public static class DataTableExtensions
{
    public static DataTable ConvertToDataTable<T>(this DataTable dt, T item)
    {
        DataTable dataTable = new DataTable();
        PropertyInfo[] properties = typeof(T).GetProperties();    

        foreach (PropertyInfo property in properties)
        {
            dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
        }

            DataRow row = dataTable.NewRow();
            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(item);
                row[property.Name] = value ?? DBNull.Value;
            }
            dataTable.Rows.Add(row);
        

        return dataTable;
    }
    public static DataTable PrepareDTtoInsertTransaction(this DataTable dataTable, CreateTransactionDto item)
    {
        dataTable.Columns.Add("Id", typeof(Guid));
        dataTable.Columns.Add("CreditCardID", typeof(Guid));
        dataTable.Columns.Add("Concept", typeof(string));
        dataTable.Columns.Add("TransactionType", typeof(int));
        dataTable.Columns.Add("TransactionDate", typeof(DateTime));
        dataTable.Columns.Add("Amount", typeof(double));

        DataRow row = dataTable.NewRow();
        row["Id"] = Guid.NewGuid();
        row[nameof(item.CreditCardID)] = item.CreditCardID;
        row[nameof(item.Concept)] = item.Concept;
        row[nameof(item.TransactionType)] = (int) item.TransactionType;
        row[nameof(item.TransactionDate)] = item.TransactionDate;
        row[nameof(item.Amount)] = item.Amount;
        dataTable.Rows.Add(row);

        return dataTable;
    }
    public static DataTable ConverToDataTable<T>(this DataTable dt, IEnumerable<T> items)
    {
        return items.ToDataTable();
    }
}
