using lab_2.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab_2_Test
{
    [TestClass]
    public class lab_2_test
    {
        [TestMethod]
        public void VigenereTestEngEncode()
        {
            lab_2.Properties.Settings.Default.Language = "eng";

            string TestedText = "My heart and actions are utterly unclouded. They are all those of 'Justice'. You're experienced it, didnt you?";
            string TestedKeyword = "Key";
            string ExpectedText = "wc foepd eln eadmmxw ybi sdxcbpw eravssnib. dlci epo ejv xfywc yj 'hewrsgc'. iss'bi chtcbmcxgcn mr, nmbxx wyy?";

            VigenereModel VG = new VigenereModel();
            Assert.AreEqual(ExpectedText.ToLower(), VG.Encode(TestedText, TestedKeyword));
        }

        [TestMethod]
        public void VigenereTestRusEncode()
        {
            lab_2.Properties.Settings.Default.Language = "rus";

            string TestedText = "«Знаешь что, Карло? Последние десять лет я только убивал и всё. Я убивал за свою страну. Убивал за свою семью. Убивал каждого, кто переходил мне дорогу. Но это… Это для меня»";
            string TestedKeyword = "ключ";
            string ExpectedText = "«тщюэгё фйщ, цюзць? мёэчвъшфв ъпюъйе чвй и ялгецл клфычц ф ыир. й ршунюг тл ощщи ойълкк. ямёщкч еч энлф эрйсз. ыяамли вктбёнь, зйщ ъвзпблъуч йеп плзщор. ещ зпё… жял ъцй йэшй»";

            VigenereModel VG = new VigenereModel();
            Assert.AreEqual(ExpectedText.ToLower(), VG.Encode(TestedText, TestedKeyword));
        }
        public void VigenereTestEngDecode()
        {
            lab_2.Properties.Settings.Default.Language = "eng";

            string TestedText = "wc foepd eln eadmmxw ybi sdxcbpw eravssnib. dlci epo ejv xfywc yj 'hewrsgc'. iss'bi chtcbmcxgcn mr, nmbxx wyy?";
            string TestedKeyword = "Key";
            string ExpectedText = "my heart and actions are utterly unclouded. they are all those of 'justice'. you're experienced it, didnt you?";

            VigenereModel VG = new VigenereModel();
            Assert.AreEqual(ExpectedText.ToLower(), VG.Decode(TestedText, TestedKeyword));
        }

        [TestMethod]
        public void VigenereTestRusDecode()
        {
            lab_2.Properties.Settings.Default.Language = "rus";

            string TestedText = "«тщюэгё фйщ, цюзць? мёэчвъшфв ъпюъйе чвй и ялгецл клфычц ф ыир. й ршунюг тл ощщи ойълкк. ямёщкч еч энлф эрйсз. ыяамли вктбёнь, зйщ ъвзпблъуч йеп плзщор. ещ зпё… жял ъцй йэшй»";
            string TestedKeyword = "ключ";
            string ExpectedText = "«знаешь что, карло? последние десять лет я только убивал и всё. я убивал за свою страну. убивал за свою семью. убивал каждого, кто переходил мне дорогу. но это… это для меня»";

            VigenereModel VG = new VigenereModel();
            Assert.AreEqual(ExpectedText.ToLower(), VG.Decode(TestedText, TestedKeyword));
        }


        [TestMethod]
        public void AtbashTestEngEncode()
        {
            lab_2.Properties.Settings.Default.Language = "eng";

            string TestedText = "What's the matter...? Are you simply going to watch? Are you forsaking him to save yourself?";
            string ExpectedText = "dszg'h gsv nzggvi...? ziv blf hrnkob tlrmt gl dzgxs? ziv blf ulihzprmt srn gl hzev blfihvou?";

            AtbashModel AB = new AtbashModel();
            Assert.AreEqual(ExpectedText.ToLower(), AB.Encode(TestedText, null));
        }

        [TestMethod]
        public void AtbashTestRusEncod()
        {
            lab_2.Properties.Settings.Default.Language = "rus";

            string ExpectedText = "Сойдись со мной в поединке! - Сначала со своими сапогами сойдись... Недомерок...";
            string TestedText = "нрхъцне нр тсрх ю прьъцсфь! - нсызыуы нр нюрцтц ныпрэытц нрхъцне... сьъртьорф...";


            AtbashModel AB = new AtbashModel();
            Assert.AreEqual(ExpectedText.ToLower(), AB.Encode(TestedText, null));
        }

        [TestMethod]
        public void AtbashTestEngDecod()
        {
            lab_2.Properties.Settings.Default.Language = "eng";

            string TestedText = "dszg'h gsv nzggvi...? ziv blf hrnkob tlrmt gl dzgxs? ziv blf ulihzprmt srn gl hzev blfihvou?";
            string ExpectedText = "what's the matter...? are you simply going to watch? are you forsaking him to save yourself?";

            AtbashModel AB = new AtbashModel();
            Assert.AreEqual(ExpectedText.ToLower(), AB.Decode(TestedText, null));
        }

        [TestMethod]
        public void AtbashTestRusDecod()
        {
            lab_2.Properties.Settings.Default.Language = "rus";

            string ExpectedText = "нрхъцне нр тсрх ю прьъцсфь! - нсызыуы нр нюрцтц ныпрэытц нрхъцне... сьъртьорф...";
            string TestedText = "сойдись со мной в поединке! - сначала со своими сапогами сойдись... недомерок...";

            AtbashModel AB = new AtbashModel();
            Assert.AreEqual(ExpectedText.ToLower(), AB.Decode(TestedText, null));
        }
    }
}