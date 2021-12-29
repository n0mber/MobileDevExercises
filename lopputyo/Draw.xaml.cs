using System;
using System.Collections.Generic;
using System.IO;
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
            if (inkCanvasArea.Strokes.Count > 0)
            {
                inkCanvasArea.Strokes.RemoveAt(inkCanvasArea.Strokes.Count - 1);
            }
            Title = inkCanvasArea.Strokes.Count + " strokes";
        }

        //Menu items
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow myMainWindow = new MainWindow();
            myMainWindow.ShowDialog();
        }


        //Save image to bin/Debug/net5.0-windows file and close the window
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)inkCanvasArea.ActualWidth,
            (int)inkCanvasArea.ActualHeight, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(inkCanvasArea);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            using (var fs = System.IO.File.OpenWrite("character.png"))
            {
                pngEncoder.Save(fs);
            }

            DialogResult = true;

            Close();
        }
    }

}
