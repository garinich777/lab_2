using System.Linq;

namespace lab_2.Model
{
    public class Atbash : ICipherModel
    {
        string rus_letters = Letters.RussianLetters;
        string eng_letters = Letters.EnglishLetters;
        string rev_rus_letters = string.Empty;
        string rev_eng_letters = string.Empty;

        Atbash()
        {
            string rev_rus_letters = new string(rus_letters.Reverse().ToArray());
            string rev_eng_letters = new string(eng_letters.Reverse().ToArray());
        }

        private string EncodeOrDecode(string text, string letters, string сipher)
        {
            text = text.ToLower();

            string result_text = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                int index = letters.IndexOf(text[i]);

                if (!char.IsLetter(text[i]))
                    result_text += text[i];

                else if (index >= 0)
                    result_text += сipher[index].ToString();
            }

            return result_text;
        }

        public string Encode(string text, string keyword = "")
        {
            if (Properties.Settings.Default.Language == "rus")
                return EncodeOrDecode(text, rus_letters, rev_rus_letters);
            else if (Properties.Settings.Default.Language == "eng")
                return EncodeOrDecode(text, eng_letters, rev_eng_letters);
            return string.Empty;
        }

        public string Decode(string text, string keyword = "")
        {
            if (Properties.Settings.Default.Language == "rus")
                return EncodeOrDecode(text, rev_rus_letters, rus_letters);
            else if (Properties.Settings.Default.Language == "eng")
                return EncodeOrDecode(text, rev_eng_letters, eng_letters);
            return string.Empty;
        }
    }
}
