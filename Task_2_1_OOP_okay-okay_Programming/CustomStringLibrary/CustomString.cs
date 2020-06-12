using System;

namespace CustomStringLibrary
{
    public class CustomString
    {
        #region Field
        char[] literals = null; // массив хранения символов
        #endregion

        #region PROPs
        public char[] CustomValue // свойство установки и получения массива символов
        {
            get
            {
                return literals;
            }
            set
            {
                for (int i = 0; i < literals.Length; i++)
                {
                    CustomValue[i] = literals[i];
                }
            }
        }
        public int Length // свойство установки и получения длины
        {
            get
            {
                return literals.Length;
            }
            set
            {
                char[] temp = new char[value];
                if (value > literals.Length)
                    value = literals.Length;
                for (int i = 0; i < value; i++)
                {
                    temp[i] = literals[i];
                    literals = temp;
                }
            }
        }
        #endregion

        #region Indexer
        // *"Подумайте над использованием в своем классе функционала индексатора(indexer). Реализуйте его для своей строки."
        // Индексатор для возможности индексирования через [] к выражению типа CustomString
        // В данном классе обеспечивает возможность сравнения и присвоения элементов практически во всех методах
        public char this[int index]
        {
            get
            {
                return literals[index];
            }
            set
            {
                literals[index] = value;
            }
        }
        #endregion

        #region CTORs
        public CustomString()
        {
            literals = new char[128];
        }
        public CustomString(int size)
        {
            literals = new char[size];
        }
        // конструктор, позволяющий описать строку как массив символов
        public CustomString(char[] array)
        {
            literals = new char[array.Length];
            CustomValue = new char[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                literals[i] = array[i];
            }
        }
        #endregion

        #region Methods
        // Реализация метода сравнения значений строк,
        // проверка на равенство ссылок может быть проведена с помощью оператора ==
        public static bool CustomCompare(CustomString str1, CustomString str2)
        {
            if (str1.Length != str2.Length)
                return false;
            for (int i = 0; i < str1.Length; i++)
                if (str1[i] != str2[i])
                    return false;
            return true;
        }
        // Реализация метода конкатенации - оператор + перегружен
        public static CustomString CustomConcat(CustomString str1, CustomString str2)
        {
            int summOfLenght = str1.Length + str2.Length;
            CustomString result = new CustomString(summOfLenght);
            for (int i = 0; i < str1.Length; i++)
            {
                result[i] = str1[i];
            }
            for (int i = 0; i < str2.Length; i++)
            {
                result[str1.Length + i] = str2[i];
            }
            return result;
        }
        // Реализация метода конвертации из массива символов
        public static CustomString ToCustomString(char[] array)
        {
            CustomString result = new CustomString(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
            }
            return result;
        }
        public static CustomString ToCustomString(CustomString str)
        {
            CustomString result = new CustomString(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                result[i] = str[i];
            }
            return result;
        }
        // Реализация метода конвертации в массив символов
        public static char[] ToArray(CustomString str)
        {
            char[] result = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                result[i] = str[i];
            }
            return result;
        }
        // Реализация метода поиска символа
        public int FindLiteral(char literal)
        {
            for (int i = 0; i < this.Length; i++)
                if (literals[i] == literal)
                    return i + 1;
            return -1;
        }
        // *"Подумайте, какие функции вы бы добавили к имеющемуся в .NET функционалу строк (достаточно 1-2 функций)"
        // Реализация метода реверсирования строки
        public static CustomString CustomReverse(CustomString str)
        {
            char[] strToArray = ToArray(str);
            Array.Reverse(strToArray);
            return ToCustomString(strToArray);
        }
        #endregion

        #region Reload operator
        // перегрузка оператора +
        public static CustomString operator +(CustomString str1, CustomString str2)
        {
            int summOfLenght = str1.Length + str2.Length;

            CustomString result = new CustomString(summOfLenght);

            for (int i = 0; i < str1.Length; i++)
            {
                result[i] = str1[i];
            }
            for (int i = 0; i < str2.Length; i++)
            {
                result[str1.Length + i] = str2[i];
            }
            return result;
        }
        #endregion
    }
}