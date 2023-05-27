using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dark_WPF_Demo
{
    /// <summary>
    /// Interaction logic for frmOther.xaml
    /// </summary>
    public partial class frmOther : Window
    {
        // B2: Trong sự kiện Button Create. Tạo mảng 2 chiều nút Button và
        // khởi tạo các Properties(Top, Left, Tag)

        #region Fields
        private int _nRow, _nColumn;
        private List<List<Button>> _arrayBtn;
        private int s;
        private int gridW;
        private int gridH;
        private double cell, cell1, cell2;
        #endregion

        public frmOther()
        {
            InitializeComponent();
            btnCreate.Click += new RoutedEventHandler(BtnCreate_Click);
        }

        public static void Init(List<List<Button>> source)
        {
            int idx = 0;
            int idx2 = 0;
            foreach (List<Button> items in source)
            {
                foreach (Button item in items)
                {
                    item.Content = (idx + ", " + idx2).ToString();
                    item.Name = "btnSub";

                    item.Width = s;
                    item.Height = s;

                    // Update more here ..
                    idx2 += 1;
                }
                idx += 1;
                idx2 = 0;
            }
        }
  
        private void DefineRowColDefinitions(Grid grid1)
        {
            for (int idx = 0; idx < _arrayBtn.Count; idx++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(cell, GridUnitType.Pixel);
                grid1.RowDefinitions.Add(rowDef);
            }
            for (int idx = 0; idx < _arrayBtn[0].Count; idx++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(cell, GridUnitType.Pixel);
                grid1.ColumnDefinitions.Add(colDef);
            }
        }

        private void AddToGroupBox()
        {
            Grid grid1 = new Grid();
            DefineRowColDefinitions(grid1);
            
            int idx = 0;
            foreach (List<Button> lstBtn in _arrayBtn)
            {
                int idx2 = 0;
                foreach (Button btn in lstBtn)
                {
                    btn.Click += BtnSub_Click;
                    grid1.Children.Add(btn);

                    Grid.SetRow(btn, idx);
                    Grid.SetColumn(btn, idx2);

                    idx2 += 1;
                }
                idx += 1;
            }
            gb.Content = grid1;
        }

        private void BtnSub_Click(object sender, RoutedEventArgs e)
        {
            Button item = sender as Button;

            item.Background = new SolidColorBrush(Colors.Red);

            item.Click -= BtnSub_Click;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            gridW = gridH = -1;
            _nRow = _nColumn = -1;
            try
            {
                _nRow = Convert.ToInt32(txtRow.Text);
                _nColumn = Convert.ToInt32(txtColumn.Text);
            }
            catch
            {
                MessageBox.Show("Please input number", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                ClearTextBox();
                return;
            }
            if (_nRow <= 0 || _nColumn <= 0)
            {
                MessageBox.Show("Please input number that greater than 0", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
                ClearTextBox();
                return;
            }
            gridW = _nColumn;
            gridH = _nRow;

            double totalSize2 = (gb.Height <= gb.Width) ? gb.Height : gb.Width;
            cell1 = totalSize2 / _nRow;
            cell2 = totalSize2 / _nColumn;
            cell = (cell1 <= cell2) ? cell1 : cell2;

            s = Convert.ToInt32(cell - 20);
            if (s <= 0)
            {
                MessageBox.Show($"Too large number (s = {s})");
                ClearTextBox();
                return;
            }
            Utilities.Allocate(out _arrayBtn, _nRow, _nColumn);
            Init(_arrayBtn);
            AddToGroupBox();
        }

        private void ClearTextBox()
        {
            txtRow.Text = string.Empty;
            txtColumn.Text = string.Empty;
        }
    }
}
