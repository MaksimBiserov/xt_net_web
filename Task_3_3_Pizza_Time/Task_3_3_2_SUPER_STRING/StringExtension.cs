using System.Linq;
using System.Text;

namespace Task_3_3_2_SUPER_STRING
{
    public static class StringExtension
    {
        public static Languages CheckLanguage(this string phrase)
        {
            phrase = phrase.ToLower();
            byte[] symbol = Encoding.Default.GetBytes(phrase);

            if (symbol.All(letter => letter >= 48 && letter <= 57))
            {
                return Languages.Number;
            }
            else if (symbol.All(letter => letter >= 97 && letter <= 122))
            {
                return Languages.English;
            }
            else if (symbol.All(letter => (letter >= 192 && letter <= 255) || letter == 184))
            {
                return Languages.Russian;
            }
            else
            {
                return Languages.Mixed;
            }
        }
    }

    public enum Languages
    {
        English,
        Russian,
        Number,
        Mixed
    }
}