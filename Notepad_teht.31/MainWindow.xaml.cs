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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Threading;
using System.Globalization;

namespace Notepad_teht._31
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sv-SE");
            //CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("sv-SE");

            InitializeComponent();

            Title = Properties.Resource1.Title;
            FileMenu.Header = Properties.Resource1.File;
            OpenMenu.Header = Properties.Resource1.FileOpen;
            SaveMenu.Header = Properties.Resource1.FileSaveAs;
            PrintMenu.Header = Properties.Resource1.FilePrint;
            ExitMenu.Header = Properties.Resource1.FileExit;
            EditMenu.Header = Properties.Resource1.FileEdit;
            CopyMenu.Header = Properties.Resource1.EditCopy;
            PasteMenu.Header = Properties.Resource1.EditPaste;
            FontMenu.Header = Properties.Resource1.EditFont;
            
        }



        /// <summary>
        /// File/Open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; //default file name
            dialog.DefaultExt = ".txt"; // default file extention
            dialog.Filter = "Text documents (.text) |*.txt|All Files(*.*)|*.*"; //filter files by extention

            //Show open file dialog box
            bool? result = dialog.ShowDialog();

            string filename = "";
            //Process open file dialog box results
            if (result == true)
            {
                //Open document
                filename = dialog.FileName;
                
            }
            
            //avaa annettu tiedosto ja kopioi sen sisältö TextBoxiin

            StreamReader reader = File.OpenText(filename);
            string line = reader.ReadLine();
            string textBoxText = "";
            while (line != null)
            {
                textBoxText += line + "\n";
                line = reader.ReadLine();
            }
            textBox1.Text = textBoxText;
            reader.Close();

            
        }

        //Print
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            if(printDialog.ShowDialog() == true)
            {
                
                printDialog.PrintVisual(textBox1, "FilePrint");
            }
        }

        //Font
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            WindowFont mywindow = new WindowFont();
            mywindow.listFonts.SelectedItem = textBox1.FontFamily;
            mywindow.TextBoxSize.Text = textBox1.FontSize.ToString();
            if (mywindow.ShowDialog() == true)
            {
                textBox1.FontFamily = (FontFamily)mywindow.listFonts.SelectedItem;
                textBox1.FontSize = int.Parse(mywindow.TextBoxSize.Text);
            }
        }

        //Save
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            string filename = "";
            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dialog.FileName;
            }

            StreamWriter writer = File.CreateText(filename);
            writer.WriteLine(textBox1.Text);
            writer.Close();

        }

        //Kun ikkuna suljetaan
        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings1.Default.Teksti = textBox1.Text;
            Properties.Settings1.Default.Save();
        }

        //Kun ikkuna avataan
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox1.Text = Properties.Settings1.Default.Teksti;
        }
    }
}
