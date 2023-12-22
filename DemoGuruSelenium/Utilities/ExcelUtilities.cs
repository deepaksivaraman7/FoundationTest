using DemoGuruSelenium.Helpers;
using ExcelDataReader;
using System.Data;
using System.Text;

namespace DemoGuruSelenium.Utilities
{
    internal class ExcelUtilities
    {
        public static List<UserDetails> ReadExcelData(string excelFilePath, string sheetName)
        {
            List<UserDetails> excelDataList = new();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables[sheetName];
                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            UserDetails userData = new()
                            {
                                FirstName = GetValueOrDefault(row, "firstname"),
                                LastName = GetValueOrDefault(row, "lastname"),
                                Phone = GetValueOrDefault(row, "phone"),
                                Email = GetValueOrDefault(row, "email"),
                                Address = GetValueOrDefault(row, "address"),
                                City = GetValueOrDefault(row, "city"),
                                State = GetValueOrDefault(row, "state"),
                                PostalCode = GetValueOrDefault(row, "postalcode"),
                                Country = GetValueOrDefault(row, "country"),
                                UserName = GetValueOrDefault(row, "username"),
                                Password = GetValueOrDefault(row, "password"),
                            };
                            excelDataList.Add(userData);
                        }
                    }
                    else
                    {
                        Console.WriteLine(sheetName + " not found in the excel file.");
                    }
                }
            }
            return excelDataList;
        }
        static string GetValueOrDefault(DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
