using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDBCrossViewer.Models
{
    public class DataTableModel
    {
        public DataTable DataTable { get; set; }

        public DataTableModel()
        {
            DataTable = new DataTable();
        }

        public DataTableModel(DataTable dataTable)
        {
            DataTable = dataTable;
        }

    }
}
