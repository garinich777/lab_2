using lab_2.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;


namespace lab_2
{
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

        private void ReadFileClick(object sender, RoutedEventArgs e)
        {
            string file_path = string.Empty;
            string file_name = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    file_path = openFileDialog.FileName;
                    file_name = System.IO.Path.GetFileName(file_path);
                }
            }

            string ciphertext = string.Empty;
            string sourcetext = string.Empty;

            if (file_path != string.Empty)
            {
                if (VM.ReadFile(file_path, out ciphertext, out sourcetext))
                {                    
                    tb_plain_text.Text = sourcetext;
                    tb_cipher_text.Text = ciphertext;
                }
                   
                else
                    System.Windows.Forms.MessageBox.Show($"Файл \"{file_name}\" не содержит исходный текст");
            }
            


           
            
        }
    }
}
