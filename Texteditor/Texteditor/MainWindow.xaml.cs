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

namespace Texteditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //bool isLoaded=false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // Создали диалог
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // Установили фильтр по типу файлов.
            if (ofd.ShowDialog()==true) // Если диалог сработал
            {
                string fileName = ofd.FileName; // Получаю из диалога имя файла
                labFile.Content = fileName; // Запомнил в метке статусной строки
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    tbEdit.Text = sr.ReadToEnd();
                }
                //isLoaded = true;
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Создали диалог

            sd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // Установили фильтр по типу файлов.
            if (sd.ShowDialog() == true) // Если диалог сработал
            {
                string fileName = sd.FileName; // Получаю из диалога имя файла

                labFile.Content = fileName; // Запомнил в метке статусной строки

                try // Защищенный сегмент кода
                {
                    using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                    {
                        sw.Write(tbEdit.Text); // Пишу содержимое текстового окна
                    }
                }
                catch
                { // Если все пошло не так - то я ругаюсь
                    MessageBox.Show("Ошибка записи в файл", "Текстовый редактор", MessageBoxButton.OK);
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Создали диалог
            sd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // Установили фильтр по типу файлов.
            sd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (sd.ShowDialog() == true) // Если диалог сработал
            {
                string fileName = sd.FileName; // Получаю из диалога имя файла
                labFile.Content = fileName; // Запомнил в метке статусной строки
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                {
                    sw.Write(tbEdit.Text); // Пишу содержимое текстового окна

                }
            }
            /*if (isLoaded)
            { 
              string fileName = labFile.Content.ToString();
             using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
             {
                sw.Write(tbEdit.Text);
             }
            }else
            {
                MenuItem_Click_2(sender, e);
            }*/

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            if (ftexChange.IsChecked==false) //создать новый файл
            {
                labFile.Content = "N/A";
                tbEdit.Text = "";
            }
            else
            {
                MessageBoxResult m = MessageBox.Show("Файл не сохранен. Сохранить?", "My App", MessageBoxButton.YesNoCancel);
                if (m == MessageBoxResult.Yes)
                {
                    MenuItem_Click_4(sender, e);
                    tbEdit.Text = "";
                    labFile.Content = "N/A";
                }
                else if (m == MessageBoxResult.No)
                {
                    tbEdit.Text = "";
                    labFile.Content = "N/A";
                }

            }
        }

        private void tbEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            ftexChange.IsChecked = true;
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            tbEdit.Copy();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            tbEdit.Paste();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            tbEdit.Cut();
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            Window1 winhelp = new Window1();
            winhelp.ShowDialog(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // Создали диалог
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // Установили фильтр по типу файлов.
            if (ofd.ShowDialog() == true) // Если диалог сработал
            {
                string fileName = ofd.FileName; // Получаю из диалога имя файла

                labFile.Content = fileName; // Запомнил в метке статусной строки

                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    tbEdit.Text = sr.ReadToEnd();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Создали диалог
            sd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // Установили фильтр по типу файлов.
            sd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (sd.ShowDialog() == true) // Если диалог сработал
            {
                string fileName = sd.FileName; // Получаю из диалога имя файла
                labFile.Content = fileName; // Запомнил в метке статусной строки
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                {
                    sw.Write(tbEdit.Text); // Пишу содержимое текстового окна

                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Создали диалог

            sd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // Установили фильтр по типу файлов.
            if (sd.ShowDialog() == true) // Если диалог сработал
            {
                string fileName = sd.FileName; // Получаю из диалога имя файла

                labFile.Content = fileName; // Запомнил в метке статусной строки

                try // Защищенный сегмент кода
                {
                    using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                    {
                        sw.Write(tbEdit.Text); // Пишу содержимое текстового окна
                    }
                }
                catch
                { // Если все пошло не так - то я ругаюсь
                    MessageBox.Show("Ошибка записи в файл", "Текстовый редактор", MessageBoxButton.OK);
                }
            }
        }
    }
}
