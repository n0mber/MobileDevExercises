using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Olympiarenkaat
{
    class myCanvas2 : Canvas
    {
        double x = 50;
        double y = 100;
        
        protected override void OnRender(DrawingContext dc)
        {
            //base.OnRender(dc);

            dc.DrawEllipse(Brushes.Transparent, new Pen(Brushes.Blue, 6), new System.Windows.Point(x, y), 50, 50);

            dc.DrawEllipse(Brushes.Transparent, new Pen(Brushes.Yellow, 6), new System.Windows.Point(x + 40, y + 20), 50, 50);
  
            dc.DrawEllipse(Brushes.Transparent, new Pen(Brushes.Black, 6), new System.Windows.Point(x + 80, y), 50, 50);
    
            dc.DrawEllipse(Brushes.Transparent, new Pen(Brushes.Green, 6), new System.Windows.Point(x + 120, y + 20), 50, 50);
     
            dc.DrawEllipse(Brushes.Transparent, new Pen(Brushes.Red, 6), new System.Windows.Point(x + 160, y), 50, 50);
  
            
        }

        //public void SetX(double x1)
        //{
        //    this.x = x1;
        //    InvalidateVisual();

        //}

        public void SetY(double y1)
        {
            this.y = y1;
            InvalidateVisual();

        }
    }
}
