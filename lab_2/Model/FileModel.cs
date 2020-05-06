using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab_2.Model
{
    public static class FileModel
    {
        public static void WriteFile(string path, string ciphertext, string sourcetext)
        {
            string content = "<ciphertext>" + ciphertext + "</ciphertext>" + Environment.NewLine + "<sourcetext>" + sourcetext + "</sourcetext>";

            using (StreamWriter writer = new StreamWriter(path))
                writer.Write(content);
        }

        public static void WriteFile(string path, string ciphertext)
        {
            string content = "<ciphertext>" + ciphertext + "</ciphertext>";

            using (StreamWriter writer = new StreamWriter(path))
                writer.Write(content);
        }

        public static bool TryReadArray(string path, out string ciphertext, out string sourcetext)
        {
            string file_content;
            using (StreamReader reader = new StreamReader(path))
                file_content = reader.ReadToEnd();

            Match match = Regex.Match(file_content, "<ciphertext>(.*?)</ciphertext>(.*?)<sourcetext>(.*?)</sourcetext>");

            ciphertext = match.Groups[1].Value;
            sourcetext = match.Groups[3].Value;
            return true;
        }
    }
}
