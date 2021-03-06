﻿using lab_2.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using Path = System.IO.Path;
using System;

namespace lab_2
{
    public partial class MainWindow : Window
    {
        CryptVM VM = new CryptVM();

        enum WriteSettings { SourceAndCipher, Source, Cipher }

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
                    file_name = Path.GetFileName(file_path);
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
                    MessageBox.Show($"Файл \"{file_name}\" не содержит исходный текст");
            }
        }

        private void WriteText(WriteSettings write_settings)
        {
            string file_path = string.Empty;
            string file_name = string.Empty;
            if (tb_plain_text.Text == string.Empty)
            {
                MessageBox.Show("Записать пустоту? Я не умею");
                return;
            }
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(file_path = saveFileDialog1.FileName))
                    {
                        file_name = Path.GetFileName(file_path);
                        if(write_settings == WriteSettings.SourceAndCipher)
                            VM.WriteFile(file_path, tb_cipher_text.Text, tb_plain_text.Text);
                        else if (write_settings == WriteSettings.Cipher)
                            VM.WriteFile(file_path, tb_cipher_text.Text);
                        else
                            VM.WriteFile(file_path, string.Empty, tb_plain_text.Text);
                        MessageBox.Show($"Файл \"{file_name}\" успешно записан", file_name);
                    }
                }
            }
        }

        private void WriteSourceAndCipherTextClick(object sender, RoutedEventArgs e)
        {
            WriteText(WriteSettings.SourceAndCipher);
        }

        private void WriteSourceTextClick(object sender, RoutedEventArgs e)
        {
            WriteText(WriteSettings.Source);
        }

        private void WriteCipherTextClick(object sender, RoutedEventArgs e)
        {
            WriteText(WriteSettings.Cipher);
        }

        private void HelloMessageShow(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.HelloShow)
            {
                var result = MessageBox.Show(VM.HelloMessage() + Environment.NewLine + "Показывать это окно в дальнейшем?", "О программе", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                Properties.Settings.Default.HelloShow = result == System.Windows.Forms.DialogResult.Yes;
                Properties.Settings.Default.Save();
            }
        }

        private void HelloWindow(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(VM.HelloMessage() + Environment.NewLine + "Показывать это окно в дальнейшем?", "О программе", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            Properties.Settings.Default.HelloShow = result == System.Windows.Forms.DialogResult.Yes;
            Properties.Settings.Default.Save();
        }

        private void ApplySettings()
        {
            if (rb_atbash == null || rb_encode == null || tb_cipher_text == null || tb_key == null)
                return;

            if (rb_eng.IsChecked.Value)
                Properties.Settings.Default.Language = "eng";
            else if (rb_rus.IsChecked.Value)
                Properties.Settings.Default.Language = "rus";

            if (rb_atbash.IsChecked.Value)
                Properties.Settings.Default.Сipher = "atbash";
            else if (rb_vigenere.IsChecked.Value)
                Properties.Settings.Default.Сipher = "vigenere";

            Properties.Settings.Default.Save();

            DoCoding();
        }


        private void tb_key_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplySettings();
        }

        private void rb_rus_Checked(object sender, RoutedEventArgs e)
        {
            ApplySettings();
        }

        private void rb_eng_Checked(object sender, RoutedEventArgs e)
        {
            ApplySettings();
        }

        private void rb_vigenere_Checked(object sender, RoutedEventArgs e)
        {
            ApplySettings();
        }

        private void rb_atbash_Checked(object sender, RoutedEventArgs e)
        {
            ApplySettings();
        }

        private void rb_encode_Checked(object sender, RoutedEventArgs e)
        {
            ApplySettings();
        }

        private void rb_decode_Checked(object sender, RoutedEventArgs e)
        {
            ApplySettings();
        }
    }
}
