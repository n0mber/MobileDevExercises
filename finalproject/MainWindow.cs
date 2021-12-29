using lopputyo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace finalproject
{
    record Character(string Name, string Age, string Profession, List<string> Interests);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Character> charactersMain = new List<Character>();
        ObservableCollection<string> interestListMain = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenLastSession();
        }


        public void OpenLastSession()
        {


            if (File.Exists("MyData.json"))
            {
                charactersMain = JsonSerializer.Deserialize<List<Character>>(File.ReadAllText("MyData.json"));

                int lastCharacter = charactersMain.Count - 1;
                if (lastCharacter < 0)
                    TextInfoMain.Text = "Open character file or create new one at Edit - Character Info";
                else
                {
                    TextInfoMain.Text = "Name: " + charactersMain[lastCharacter].Name + "\n Age:" + charactersMain[lastCharacter].Age +
                "\n Profession:" + charactersMain[lastCharacter].Profession + "\n Interests:";
                    interestListMain.Clear();
                    foreach (var item in charactersMain[lastCharacter].Interests)
                    {
                        interestListMain.Add(item.ToString());
                    }

                    MainInterestList.ItemsSource = interestListMain;
                }

            }

        }

        //open drawer

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Draw mydrawing = new Draw();
            mydrawing.ShowDialog();
        }

        //open/load file

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
            reader.Close();
        }

        //save

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

        //print
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {

                printDialog.PrintVisual(textBox1, "FilePrint");
            }
        }

        private void InfoMenu_Click(object sender, RoutedEventArgs e)
        {
            BasicInfo mybasicinfo = new BasicInfo();
            mybasicinfo.ShowDialog();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenLastSession();


        }


        //Kun ikkuna suljetaan
        /*private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings1.Default.Teksti = textBox1.Text;
            Properties.Settings1.Default.Save();
        }

        //Kun ikkuna avataan
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox1.Text = Properties.Settings1.Default.Teksti;
        }*/
        
}
}
