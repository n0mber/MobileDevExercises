using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace lopputyo
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
            OpenLastSession("MyData.json");
        }

        //Page content
        public void OpenLastSession(string filename)
        {
            if (File.Exists(filename))
            {
                charactersMain = JsonSerializer.Deserialize<List<Character>>(File.ReadAllText(filename));
                File.WriteAllText("MyData.json", JsonSerializer.Serialize(charactersMain));
                int lastCharacter = charactersMain.Count-1;
                if (lastCharacter < 0)
                    TextInfoMain.Text = "Open character file or create new one at Edit - Character Info";
                else { 
                    TextInfoMain.Text = "Name: " + charactersMain[lastCharacter].Name +"\n Age:" + charactersMain[lastCharacter].Age +
                "\n Profession:" + charactersMain[lastCharacter].Profession + "\n Interests:";
                    interestListMain.Clear();
                    foreach (var item in charactersMain[lastCharacter].Interests)
                    {
                        interestListMain.Add(item.ToString());
                    }

                    MainInterestList.ItemsSource = interestListMain;
                }
            }

            //Ei toimi, mutta tarkoitus oli, että Add image lisää kuvan, jonka on tehtyä Draw character dialogissa
            if (File.Exists("/bin/debug/net5.0-windows/character.png"))
            {
                Uri resourceUri = new Uri("/bin/debug/net5.0-windows/character.png", UriKind.Relative);
                CharacterImage.Source = new BitmapImage(resourceUri);
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
            dialog.DefaultExt = ".json"; // default file extention
            dialog.Filter = "Json documents (.json) |*.json|All Files(*.*)|*.*"; //filter files by extention

            //Show open file dialog box
            bool? result = dialog.ShowDialog();

            string filename = "";
            //Process open file dialog box results
            if (result == true)
            {
                //Open document
                filename = dialog.FileName;

            }
            
            OpenLastSession(filename);
           
        }

        //save
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Character"; // Default file name
            dialog.DefaultExt = ".json"; // Default file extension
            dialog.Filter = "Json document (.json)|*.json"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            string filename = "";
            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dialog.FileName;
            }

            charactersMain = JsonSerializer.Deserialize<List<Character>>(File.ReadAllText("MyData.json"));
            File.WriteAllText(filename, JsonSerializer.Serialize(charactersMain));
            
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

        //show character info dialog
        private void InfoMenu_Click(object sender, RoutedEventArgs e)
        {
            BasicInfo mybasicinfo = new BasicInfo();
            mybasicinfo.ShowDialog();

        }

        //Refresh page
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenLastSession("MyData.json");

        }

        //Add image
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                CharacterImage.Source = new BitmapImage(fileUri);
            }
            
        }

    }
    
}
