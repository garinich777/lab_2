using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Model
{
    class VigenereModel : ICipherModel
    {
        char[] RussianLetters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                             'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                             'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                             'Э', 'Ю', 'Я' };
        char[] EnglishLetters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                             'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                                             'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        char[] Letters;

        public string Encode(string Text, string Keyword)
        {
            if (Properties.Settings.Default.Language == "Russian")
                Letters = RussianLetters;
            else
                Letters = EnglishLetters;
            int LettersLength = Letters.Length;
            Text = Text.ToUpper();
            Keyword = Keyword.ToUpper();

            string ResultedText = "";

            int KeywordIndex = 0;


            foreach (char Symbol in Text)
            {

                if (!char.IsLetter(Symbol))
                {
                    ResultedText += Symbol;
                    continue;
                }

                int CurrentCharacter = (Array.IndexOf(Letters, Symbol) +
                    Array.IndexOf(Letters, Keyword[KeywordIndex])) % LettersLength;

                ResultedText += Letters[CurrentCharacter];

                if ((KeywordIndex + 1) == Keyword.Length)
                    KeywordIndex = 0;
                else
                    KeywordIndex++;
            }

            return ResultedText;
        }
        public string Decode(string Text, string Keyword)
        {
            if (Properties.Settings.Default.Language == "Russian")
                Letters = RussianLetters;
            else
                Letters = EnglishLetters;
            int LettersLength = Letters.Length;
            Text = Text.ToUpper();
            Keyword = Keyword.ToUpper();

            string ResultedText = "";

            int KeywordIndex = 0;

            foreach (char Symbol in Text)
            {
                if (!char.IsLetter(Symbol))
                {
                    ResultedText += Symbol;
                    continue;
                }
                int CurrentCharacter = (Array.IndexOf(Letters, Symbol) + LettersLength -
                    Array.IndexOf(Letters, Keyword[KeywordIndex])) % LettersLength;

                ResultedText += Letters[CurrentCharacter];

                if ((KeywordIndex + 1) == Keyword.Length)
                    KeywordIndex = 0;
                else
                    KeywordIndex++;
            }

            return ResultedText.ToLower();
        }
    }
}
