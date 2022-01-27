using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Password_generation_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Generator gen = null;

        public MainWindow()
        {
            InitializeComponent();

            gen = new Generator();

        }


        private void generButton_Click(object sender, RoutedEventArgs e)
        {
            int size = int.Parse(textBoxNumber.Text);
            string symbols = textBoxLeter.Text;
            bool num = false, sym = false, UpA = false, LowA = false;


            if (size < 4 || size > 8)
            {
                textBoxNumber.ToolTip = "Это поле введено не корректно";
                textBoxNumber.Foreground = Brushes.Red;
            }
            else
            {
                textBoxNumber.ToolTip = "";
                textBoxNumber.Foreground = Brushes.Black;
            }
            if (symbols.Length < 0 || symbols.Length > 50)
            {
                textBoxLeter.ToolTip = "Это поле введено не корректно";
                textBoxLeter.Foreground = Brushes.Red;

            }
            else
            {
                textBoxLeter.ToolTip = "";
                textBoxLeter.Foreground = Brushes.Black;
            }
            if (symbols.Length == 0)
            {
                if (checkBoxNumber.IsChecked == true)
                {
                    num = true;

                }
                if (checkBoxSymbol.IsChecked == true)
                {
                    sym = true;
                }
                if (checkBoxUpperLit.IsChecked == true)
                {
                    UpA = true;
                }
                if (checkBoxLowerLit.IsChecked == true)
                {
                    LowA = true;
                }
                if (num == false && sym == false && UpA == false && LowA == false)
                {
                    MessageBox.Show("Выберите параметр для генерации пароля");
                }
                else
                {
                    Password.Text = gen.PasswordGenerate(size, num, sym, UpA, LowA);
                }

            }
            else
            {
                Password.Text = gen.PasswordGenerate(size, symbols);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|Word Documents|*.doc";
            saveFileDialog.FileName = "MyPassword";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, Password.Text);
            }
        }
    }
}
