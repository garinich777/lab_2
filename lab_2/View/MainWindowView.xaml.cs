using lab_2.ViewModel;
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

namespace lab_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CryptVM VM = new CryptVM();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DoCoding()
        {
            string text = string.Empty;
            string key = string.Empty;
            

            if (rb_encode.IsChecked.Value)
                tb_cipher_text.Text = VM.EncryptText(out text, out key, tb_plain_text.Text, tb_key.Text);
            else
                tb_cipher_text.Text = VM.DecryptText(out text, out key, tb_plain_text.Text, tb_key.Text);

            tb_plain_text.Text = text;
            tb_key.Text = key;
            tb_key.CaretIndex = tb_key.Text.Length;
            tb_plain_text.CaretIndex = tb_plain_text.Text.Length;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoCoding();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (rb_eng.IsChecked.Value)
                Properties.Settings.Default.Language = "eng";
            else if(rb_rus.IsChecked.Value)
                Properties.Settings.Default.Language = "rus";

            if (rb_atbash.IsChecked.Value)
                Properties.Settings.Default.Сipher = "atbash";
            else if(rb_vigenere.IsChecked.Value)
                Properties.Settings.Default.Сipher = "vigenere";

            Properties.Settings.Default.Save();

            DoCoding();
        }
    }
}
