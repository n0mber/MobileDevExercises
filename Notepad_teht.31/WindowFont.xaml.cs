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

namespace Notepad_teht._31
{
    /// <summary>
    /// Interaction logic for WindowFont.xaml
    /// </summary>
    public partial class WindowFont : Window
    {
        public WindowFont()
        {
            InitializeComponent();
        }

        //OK
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
