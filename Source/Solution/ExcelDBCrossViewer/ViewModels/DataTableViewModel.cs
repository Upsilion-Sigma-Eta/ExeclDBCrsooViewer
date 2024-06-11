using ExcelDBCrossViewer.InternalLogic;
using ExcelDBCrossViewer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExcelDBCrossViewer.ViewModels
{
    public class DataTableViewModel : BaseViewModel
    {
        public DataTableModel DataTableModel { get; set; }
        public DataView DataView => DataTableModel.DataTable.DefaultView;

        public ICommand PasteCommand { get; set; }

        public DataTableViewModel()
        {
            DataTableModel = new DataTableModel();
            PasteCommand = new RelayCommand(ExecutePasteCommand);
        }

        private void ExecutePasteCommand(object parameter)
        {
            string clipboardData = Clipboard.GetText();

            if (string.IsNullOrEmpty(clipboardData))
            {
                return;
            }

            string[] rows = clipboardData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var data = rows.Select(rows => rows.Split('\t'));

            DataTableModel.DataTable.Clear();
            DataTableModel.DataTable.Columns.Clear();

            int columnCount = data.First().Length;

            for (int i = 0; i < columnCount; i++)
            {
                DataTableModel.DataTable.Columns.Add($"Column{i + 1}");
            }

            foreach (var row in data)
            {
                DataTableModel.DataTable.Rows.Add(row);
            }

            OnPropertyChanged(nameof(DataView));
        }
    }
}
