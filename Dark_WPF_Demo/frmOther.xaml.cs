using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private const int maxRow = 10;
        private const int maxColumn = 10;
        private int _nRow, _nColumn;

        private List<List<Button>> _arrayBtn;
        private int s = 40;

        private int _padding = 5;
        private int _margin = 5;
        #endregion

        public frmOther()
        {
            InitializeComponent();
            btnCreate.Click += new RoutedEventHandler(BtnCreate_Click);
            txtRow.PreviewTextInput += TextBox_PreviewTextInput;
            txtColumn.PreviewTextInput += TextBox_PreviewTextInput;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void Init(List<List<Button>> source)
        {
            int idx = 0;
            int idx2 = 0;
            foreach (List<Button> items in source)
            {
                foreach (Button item in items)
                {
                    item.BorderThickness = new Thickness(2);
                    item.Content = (idx + ", " + idx2).ToString();
                    item.Width = s;
                    item.Height = s;
                    item.Margin = new Thickness(_margin);
                    item.Padding = new Thickness(_padding);
                    idx2 += 1;
                }
                idx += 1;
                idx2 = 0;
            }
        }
  
        private void DefineRowColDefinitions(Grid grid1)
        {
            double size = s + (_margin * 2);
            for (int idx = 0; idx < _arrayBtn.Count; idx++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(size, GridUnitType.Pixel);
                grid1.RowDefinitions.Add(rowDef);
            }
            for (int idx = 0; idx < _arrayBtn[0].Count; idx++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(size, GridUnitType.Pixel);
                grid1.ColumnDefinitions.Add(colDef);
            }
        }

        private void AddToGroupBox()
        {
            Grid grid1 = new Grid();
            DefineRowColDefinitions(grid1);
            
            int idx = 0;
            int idx2 = 0;
            foreach (List<Button> lstBtn in _arrayBtn)
            {
                foreach (Button btn in lstBtn)
                {
                    btn.Click += BtnSub_Click;
                    grid1.Children.Add(btn);

                    Grid.SetRow(btn, idx);
                    Grid.SetColumn(btn, idx2);

                    idx2 += 1;
                }
                idx += 1;
                idx2 = 0;
            }
            gb.Content = grid1;
        }

        private void BtnSub_Click(object sender, RoutedEventArgs e)
        {
            Button item = sender as Button;
            MessageBox.Show("Button Click!");
            item.Background = new SolidColorBrush(Colors.Red);
            item.Click -= BtnSub_Click;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            _nRow = _nColumn = -1;
            if (!IsCheck())
            {
                ClearTextBox();
                return;
            }
            Utilities.Allocate(out _arrayBtn, _nRow, _nColumn);
            Init(_arrayBtn);
            AddToGroupBox();

            DisableTextBox();
            btnCreate.IsEnabled = false;
        }

        public static IEnumerable<T> FindLogicalChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                foreach (object rawChild in LogicalTreeHelper.GetChildren(depObj))
                {
                    if (rawChild is DependencyObject)
                    {
                        DependencyObject child = (DependencyObject)rawChild;
                        if (child is T)
                        {
                            yield return (T)child;
                        }

                        foreach (T childOfChild in FindLogicalChildren<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }

        public bool IsCheck()
        {
            try
            {
                _nRow = Convert.ToInt32(txtRow.Text);
                _nColumn = Convert.ToInt32(txtColumn.Text);
            }
            catch
            {
                MessageBox.Show("Please input number", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                return false;
            }

            if (_nRow <= 0 || _nColumn <= 0)
            {
                MessageBox.Show("Please input number that greater than 0", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
                return false;
            }

            if (_nRow > maxRow || _nColumn > maxColumn)
            {
                MessageBox.Show("Please input number that less than {0}");
                return false;
            }
            return true;
        }

        private void ClearTextBox()
        {
            foreach (TextBox tb in FindLogicalChildren<TextBox>(this))
            {
                tb.Clear();
            }
        }

        private void DisableTextBox()
        {
            foreach (TextBox tb in FindLogicalChildren<TextBox>(this))
            {
                tb.IsEnabled = false;
            }
        }
    }
}
