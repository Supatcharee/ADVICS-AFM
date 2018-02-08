using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubix.Framework
{
    public class ExcelManager : IDisposable
    {
        private dynamic _excel = null;
        private dynamic _workbook = null;
        private dynamic _sheet = null;
        public ExcelManager()
        {
            Type officeType = Type.GetTypeFromProgID("Excel.Application");
            if (officeType == null)
            {
                throw new NotSupportedException("No excel install in the system");
            }
            else
            {
                _excel = Activator.CreateInstance(officeType);
                _excel.DisplayAlerts = false;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_excel != null)
            {
                _excel.Quit();
                _excel = null;
            }
        }

        #endregion

        public void OpenExcel(string filePath)
        {
            _workbook = _excel.Workbooks.Open(filePath);
			_sheet = _workbook.ActiveSheet;
        }

        public string ReadData(int row, int col) 
        {
            return _sheet.Range(_sheet.Cells(row, col), _sheet.Cells(row, col)).Text;
        }

        public object ReadValue(int row, int col) 
        {
            return _sheet.Range(_sheet.Cells(row, col), _sheet.Cells(row, col)).Value;
        }
    }
}
