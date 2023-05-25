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
        // B1: Tạo các biến margin, padding, s, nRow, nColumn.
        // B2: Trong sự kiện Button Create.Tạo mảng 2 chiều nút Button và khởi tạo các Properties(Width, Height, Text, Top, Left, Tag) và đăng kí sự kiện Click cho các Button
        // Hủy sự kiện của từng Button(-=).

        #region Fields
        private int _row, _col;
        private Button[][] lstBtn;
        #endregion
        public frmOther()
        {
            InitializeComponent();
            btnCreate.Click += new RoutedEventHandler(BtnCreate_Click);
        }


        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            _row = _col = 1;

            try
            {
                _row = Convert.ToInt32(txtRow.Text);
                _col = Convert.ToInt32(txtColumn.Text);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            foreach (Button[] item in lstBtn)
            {

            }
        }
    }
}
