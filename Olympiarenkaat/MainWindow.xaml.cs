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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olympiarenkaat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double x;
        private double y = 100;
        int z = 0;
        Ellipse ellipse = new Ellipse();
        //onnistuisiko käsittely ellipse arrayn avulla
        Ellipse[] ellipseArray = new Ellipse[5];


        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            //myCanvas (TAPA1)
            /*Canvas.SetLeft(ellipse1, x);
            if (x < myCanvas.ActualWidth - ellipse1.Width)
            {
                x += 50;
            }*/

            /*DoubleAnimation a = new DoubleAnimation();
            a.From = 50;
            a.To = 100;
            a.Duration = new Duration(TimeSpan.Parse("0:0:5"));
            ellipse1.BeginAnimation(Canvas.LeftProperty, a);*/

            if (z < 5)
            {
                drawEllipse(z);
                
                z++;

                if (z == 5)
                {
                    z = 0;
                }

            }

            // myCanvas2 (TAPA 2)
           // myCanvas2.SetX(x);

        }

        public void drawEllipse(int i)
        {
            Ellipse ellipse2 = new Ellipse();
            ellipse2.Width = ellipse2.Height = 100;
            ellipse2.StrokeThickness = 6;
            if (i == 0)
            {
                ellipse2.Stroke = Brushes.Blue;
            }

            if (i == 1)
            {
                ellipse2.Stroke = Brushes.Yellow;
                y = 120;

            }

            if (i == 2)
            {
                ellipse2.Stroke = Brushes.Black;
                y = 100;
            }

            if (i == 3)
            {
                ellipse2.Stroke = Brushes.Green;
                y = 120;
            }

            if (i == 4)
            {
                ellipse2.Stroke = Brushes.Red;
                y = 100;
            }

            myCanvas.Children.Add(ellipse2);
            Canvas.SetLeft(ellipse2, x);
            Canvas.SetTop(ellipse2, y);

            if (x < myCanvas.ActualWidth - ellipse2.Width)
            {
                x += 40;
            }

        }

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Canvas.SetLeft(ellipse1, e.GetPosition(myCanvas).X - ellipse1.Width/2);
            //Canvas.SetTop(ellipse1, e.GetPosition(myCanvas).Y - ellipse1.Height / 2);
            if (x < myCanvas.ActualWidth - 50)
            {
                //myCanvas2.SetX(e.GetPosition(myCanvas).X - 50);
                myCanvas2.SetY(e.GetPosition(myCanvas).Y - 50);
            }
            
           


        }

        public void myCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
                      
            
            ellipse.Width = ellipse.Height = 100;
            ellipse.StrokeThickness = 6;
            if (e.ClickCount == 1)
            {
                ellipse.Stroke = Brushes.Blue;
                
            }

            if (e.ClickCount == 2)
            {
                ellipse.Stroke = Brushes.Yellow;
                
            }

            if (e.ClickCount == 3)
            {
                ellipse.Stroke = Brushes.Black;
            }

            if (e.ClickCount == 4)
            {
                ellipse.Stroke = Brushes.Green;
            }

            if (e.ClickCount == 5)
            {
                ellipse.Stroke = Brushes.Red;
            }

            myCanvas.Children.Add(ellipse);
            
            Canvas.SetLeft(ellipse, e.GetPosition(myCanvas).X - ellipse.Width / 2);
            Canvas.SetTop(ellipse, e.GetPosition(myCanvas).Y - ellipse.Height / 2);

           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //onnistuisiko käsittely ellipse arrayn avulla
            myCanvas.Children.Remove(ellipseArray[0]);

        }
    }
}
