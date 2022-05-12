using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Korobki_project.Excel
{
	class ExcelTools : IDisposable
	{
		private Application _excel;
		private Workbook _workbook;
		private string _filePath;

		public ExcelTools()
		{
			_excel = new Microsoft.Office.Interop.Excel.Application();
		}

		internal void Clear()
		{
			_excel.Workbooks.Close();
			_excel.Quit();
			GC.Collect();
		}

		internal bool Open(string filePath)
		{
			try
			{
				if (File.Exists(filePath))
				{
					_workbook = _excel.Workbooks.Open(filePath);
				}
				else
				{
					_workbook = _excel.Workbooks.Add();
					_filePath = filePath;
				}
				return true;
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); }
			return false;
		}

		internal bool Set(string column, int row, object data)
		{
			try
			{
				Worksheet _worksheet = (Microsoft.Office.Interop.Excel.Worksheet)_excel.ActiveSheet;

				if (row == 1)
				{
					_worksheet.Cells[row, column].Font.Bold = true;
					_worksheet.Cells[row, column].Font.Size = 14;
					_worksheet.Cells[row, column].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
					_worksheet.Cells[row, column].EntireColumn.AutoFit();
					_worksheet.Cells[row, column].EntireRow.AutoFit();
				}
				else
				{
					if (data is string)
					{
						_worksheet.Cells[row, column].Font.Italic = true;
						_worksheet.Cells[row, column].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
					}
					else
					{
						_worksheet.Cells[row, column].Font.Italic = false;
						_worksheet.Cells[row, column].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
					}
					_worksheet.Cells[row, column].EntireColumn.AutoFit();
					_worksheet.Cells[row, column].EntireRow.AutoFit();
				}

				_worksheet.Cells[row, column] = data;

				return true;
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); }
			return false;
		}

		internal void Save()
		{
			if (!string.IsNullOrEmpty(_filePath))
			{
				_workbook.SaveAs(_filePath);
				_filePath = null;
			}
			else
			{
				_workbook.Save();
			}
		}
		public void Dispose()
		{
			try
			{
				_workbook.Close();
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); }
		}
	}
}