using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
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
using System.Windows.Shapes;

namespace lopputyo
{
    
    /// <summary>
    /// Interaction logic for BasicInfo.xaml
    /// </summary>
    public partial class BasicInfo : Window
    {
        ObservableCollection<string> interestList = new ObservableCollection<string>();
        

        List<string> profList = new List<string>();
        public BasicInfo()
        {
            InitializeComponent();
            profList.Add("Smith");
            profList.Add("Warrior");
            profList.Add("Mage");
            profList.Add("Ranger");
            profList.Add("Ruler");

            ProfComboBox.ItemsSource = profList;
            InterestListBox.ItemsSource = interestList;
        }



        //show new profession in pop up

        private void ProfComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(ProfComboBox.SelectedItem.ToString());
        }

        //add new interest
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string newItem = TextInterest.Text;
            interestList.Add(newItem);
            TextInterest.Text = string.Empty;
        }


        private void TextInterest_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TextInterest.Text = string.Empty;
        }

        //Delete item from list
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var title = InterestListBox.SelectedItem;
            int index = interestList.IndexOf(title.ToString());
            interestList.RemoveAt(index);
        }

        private void InterestListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //empty name text field when clicked
        private void TextName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextName_GotFocus;
        }

        //empty age text field when clicked
        private void TextAge_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextAge_GotFocus;
        }

        //empty interest text field when clicked
        private void TextInterest_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextInterest_GotFocus;

        }

        //Save and close window
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Character> characters = new List<Character>();
            List<string> interest = new List<string>();

            if (Properties.Settings1.Default.Interests != null)
            {
                foreach (var item in Properties.Settings1.Default.Interests)
                {
                    interest.Add(item.ToString());
                }

            }

            else
                interest.Add("No interests");

            string name = TextName.Text != null ? TextName.Text : "";
            string age = TextAge.Text != null ? TextAge.Text : "";
            string profession = ProfComboBox.SelectedItem != null ? ProfComboBox.SelectedItem.ToString() : "";

            characters.Add(new Character(name, age, profession, interest));
            File.WriteAllText("MyData.json", JsonSerializer.Serialize(characters));
            
            DialogResult = true;

            Close();
        }

 

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextName.Text = Properties.Settings1.Default.Name != null ? Properties.Settings1.Default.Name : "";
            TextAge.Text = Properties.Settings1.Default.Age != null ? Properties.Settings1.Default.Age.ToString() : "";


            if (Properties.Settings1.Default.Profession != null)
            {
                ProfComboBox.SelectedItem = Properties.Settings1.Default.Profession;
            }

            if (Properties.Settings1.Default.Interests != null)
            {
                foreach (var item in Properties.Settings1.Default.Interests)
                {
                    interestList.Add(item.ToString());
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            StringCollection saveInterest = new StringCollection();

            Properties.Settings1.Default.Name = TextName.Text;
            Properties.Settings1.Default.Age = TextAge.Text;
            Properties.Settings1.Default.Profession = ProfComboBox.SelectedItem == null ? "none" : ProfComboBox.SelectedItem.ToString();

            foreach (var item in interestList)
            {
                saveInterest.Add(item.ToString());
            }

            Properties.Settings1.Default.Interests = saveInterest;

        }


        //Menu items
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow myMainWindow = new MainWindow();
            myMainWindow.ShowDialog();
        }


        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Draw mydrawing = new Draw();
            mydrawing.ShowDialog();
        }

        //open/load file

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            /*var dialog = new Microsoft.Win32.OpenFileDialog();
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
            reader.Close();*/
        }

        //save

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
           /* var dialog = new Microsoft.Win32.SaveFileDialog();
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
            writer.Close();*/
        }

        //print
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {

                printDialog.PrintVisual(this, "FilePrint");
            }
        }

        private void InfoMenu_Click(object sender, RoutedEventArgs e)
        {
            BasicInfo mybasicinfo = new BasicInfo();
            mybasicinfo.ShowDialog();

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

    //record Interest(string InterestName);
}
