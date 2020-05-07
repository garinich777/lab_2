
namespace lab_2.Model
{
    interface ICipherModel
    {
        string Encode(string input_text, string key);
        string Decode(string input_text, string key);
    }
}
