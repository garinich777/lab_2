using System;

namespace lab_2.Model
{
    class VigenereModel : ICipherModel
    {
        string rus_letters = Letters.RussianLetters;
        string eng_letters = Letters.EnglishLetters;
        string letters;

        public string Encode(string text, string Keyword)
        {
            if (Properties.Settings.Default.Language == "rus")
                letters = rus_letters;
            else if (Properties.Settings.Default.Language == "eng")
                letters = eng_letters;

            int LettersLength = letters.Length;
            text = text.ToLower();
            Keyword = Keyword.ToLower();

            string ResultedText = string.Empty;

            int index = 0;
            foreach (char el in text)
            {
                if (!char.IsLetter(el))
                {
                    ResultedText += el;
                    continue;
                }

                int сurrent_сharacter = (Array.IndexOf(letters.ToCharArray(), el) +
                    Array.IndexOf(letters.ToCharArray(), Keyword[index])) % LettersLength;

                ResultedText += letters[сurrent_сharacter];

                if ((index + 1) == Keyword.Length)
                    index = 0;
                else
                    index++;
            }

            return ResultedText;
        }
        public string Decode(string Text, string Keyword)
        {
            if (Properties.Settings.Default.Language == "rus")
                letters = rus_letters;
            else if (Properties.Settings.Default.Language == "eng")
                letters = eng_letters;

            int LettersLength = letters.Length;
            Text = Text.ToLower();
            Keyword = Keyword.ToLower();

            string ResultedText = "";

            int KeywordIndex = 0;

            foreach (char Symbol in Text)
            {
                if (!char.IsLetter(Symbol))
                {
                    ResultedText += Symbol;
                    continue;
                }
                int CurrentCharacter = (Array.IndexOf(letters.ToCharArray(), Symbol) + LettersLength -
                    Array.IndexOf(letters.ToCharArray(), Keyword[KeywordIndex])) % LettersLength;

                ResultedText += letters[CurrentCharacter];

                if ((KeywordIndex + 1) == Keyword.Length)
                    KeywordIndex = 0;
                else
                    KeywordIndex++;
            }

            return ResultedText.ToLower();
        }
    }
}
