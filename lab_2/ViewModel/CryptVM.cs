using lab_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.ViewModel
{
    class CryptVM
    {
        ICipherModel coder = new AtbashModel();

        private string TrueLettersOnle(string text)
        {
            string language = string.Empty;
            string new_text = string.Empty;
            if (Properties.Settings.Default.Language == "rus")
                language = Letters.EnglishLetters;

            else if (Properties.Settings.Default.Language == "eng")           
                language = Letters.RussianLetters;

            foreach (var symbol in text)
                if (!language.Contains(symbol.ToString().ToLower()))
                    new_text += symbol;

            return new_text;            
        }

        public string EncryptText(out string new_text, out string new_key, string text, string key)
        {
            new_text = TrueLettersOnle(text);
            new_key = TrueLettersOnle(key);

            if (Properties.Settings.Default.Сipher == "atbash")
                coder = new AtbashModel();
            else if (Properties.Settings.Default.Сipher == "vigenere")
                coder = new VigenereModel();
            return coder.Encode(new_text, new_key);
        }

        public string DecryptText(out string new_text, out string new_key, string text, string key)
        {
            new_text = TrueLettersOnle(text);
            new_key = TrueLettersOnle(key);

            if (Properties.Settings.Default.Сipher == "atbash")
                coder = new AtbashModel();
            else if (Properties.Settings.Default.Сipher == "vigenere")
                coder = new VigenereModel();
            return coder.Decode(new_text, new_key);
        }
    }
}
