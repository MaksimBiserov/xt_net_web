using System;

namespace CustomStringLibrary
{
    public class CustomString
    {
        const int defaultLength = 128;
        char[] literals = null; // array for storing characters

        #region CTORs
        public CustomString()
        {
            literals = new char[defaultLength];
        }
        public CustomString(int size)
        {
            literals = new char[size];
        }
        // constructor for describing a string as an array of characters
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

        #region PROPs
        public char[] CustomValue // property for setting and getting an array of characters
        {
            get
            {
                return literals;
            }
            set
            {
                for (int i = 0; i < literals.Length; i++)
                {
                    if(literals.Length <= defaultLength)
                    {
                        CustomValue[i] = literals[i];
                        CustomValue[i] = value[i];
                    }
                    else
                    {
                        Array.Resize(ref literals, literals.Length);
                        CustomValue[i] = literals[i];
                        CustomValue[i] = value[i];
                    }
                }
            }
        }
        public int Length // property for setting and getting length
        {
            get
            {
                return literals.Length;
            }
            set
            {
                char[] temp = new char[value];
                if (value > literals.Length)
                {
                    value = literals.Length;
                }

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
        // Indexer for indexing via [] to an expression of the CustomString type
        // In this class, it provides the ability to compare and assign elements in almost all methods
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

        #region Methods
        // Implementing a method for comparing string values,
        // checking for equality of links can be performed using the == operator
        public static bool Compare(CustomString str1, CustomString str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }
            return true;
        }
        // Implementation of the concatenation method - the + operator is overloaded
        public static CustomString Concat(CustomString str1, CustomString str2)
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
        // Implementing a conversion method from an array of characters
        public static CustomString ToString(char[] array)
        {
            CustomString result = new CustomString(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
            }
            return result;
        }
        public static CustomString ToString(CustomString str)
        {
            CustomString result = new CustomString(str.Length);

            for (int i = 0; i < str.Length; i++)
            {
                result[i] = str[i];
            }
            return result;
        }
        // Implementation of the conversion method to an array of characters
        public static char[] ToArray(CustomString str)
        {
            char[] result = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                result[i] = str[i];
            }
            return result;
        }
        // Implementation of the symbol search method
        public int FindLiteral(char literal)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (literals[i] == literal)
                {
                    return i + 1;
                }
            }
            return -1;
        }
        // *"Подумайте, какие функции вы бы добавили к имеющемуся в .NET функционалу строк (достаточно 1-2 функций)"
        // Implementation of the string reversal method
        public static CustomString Reverse(CustomString str)
        {
            char[] strToArray = ToArray(str);
            Array.Reverse(strToArray);
            return ToString(strToArray);
        }
        #endregion

        #region Reload operator
        // overloading the + operator
        public static CustomString operator + (CustomString str1, CustomString str2)
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

        // overloading the == operator
        public static bool operator == (CustomString str1, CustomString str2)
        {
            int count = 0;
            char[] ch1 = ToArray(str1);
            char[] ch2 = ToArray(str2);
            if(ch1.Length == ch2.Length)
            {
                for (int i = 0; i < ch1.Length; i++)
                {
                    if (ch1[i] == ch2[i])
                    {
                        count++;
                    }
                }
            }
            if(count == ch1.Length)
            {
                return true;
            }
            return false;
        }

        // overloading the != operator
        public static bool operator !=(CustomString str1, CustomString str2)
        {
            return !(str1 == str2);
        }

        // overloading the methods Equals() and GetHashCode(), so that there are no warnings
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}