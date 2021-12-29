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

namespace lopputyo
{
    /// <summary>
    /// Interaction logic for Draw.xaml
    /// </summary>
    public partial class Draw : Window
    {
        public Draw()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (inkCanvas.Strokes.Count > 0)
            {
                inkCanvas.Strokes.RemoveAt(inkCanvas.Strokes.Count - 1);
            }
            Title = inkCanvas.Strokes.Count + " strokes";
        }
    }
}
