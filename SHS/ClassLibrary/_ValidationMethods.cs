using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public struct _ValidationMethods
    {
        public static bool isValid = true;
        private static List<string> invalidFields = new List<string>();
        private static string invalidFieldsLine;

        public static void ValidateChar(char charValue, string field)
        {
            if (charValue == '\0')
            {
                isValid = false;
                AddToInvalidFields(field);
            }
        }

        public static void ValidateString(string strValue, string field, int maxLength)
        {
            if (!strValue.All(Char.IsLetter) || strValue == String.Empty || strValue == null || strValue.Length > maxLength)
            {
                isValid = false;
                AddToInvalidFields(field);
            }
        }

        public static void ValidateStringWithSpaces(string strValue, string field, int maxLength)
        {
            if (strValue == String.Empty || strValue == null || strValue.Length > maxLength)
            {
                isValid = false;
                AddToInvalidFields(field);
            }
            else
            {
                foreach (char character in strValue)
                {
                    if (character != ' ' && !character.ToString().All(Char.IsLetter))
                    {
                        isValid = false;
                        AddToInvalidFields(field);
                    }
                }
            }
        }

        public static void ValidateInteger(string intValue, string field, int length)
        {
            if (!intValue.All(Char.IsDigit) || intValue.Length > length || intValue == String.Empty || intValue == null)
            {
                isValid = false;
                AddToInvalidFields(field);
            }
        }

        public static void ValidateEmail(string email, string field, int maxLength)
        {
            if (!email.Contains("@") || !email.Contains(".") || email == String.Empty || email == null)
            {
                isValid = false;
                AddToInvalidFields(field);
            }
        }

        public static void ValidateDropDown(string strValue, string field)
        {
            if (strValue == String.Empty || strValue == null)
            {
                isValid = false;
                AddToInvalidFields(field);
            }
        }

        public static void ValidateCode(string strValue, string field, int length)
        {
            if (strValue == String.Empty || strValue == null || strValue.Length != length)
            {
                isValid = false;
                AddToInvalidFields(field);
            }
        }

        public static void Reset()
        {
            isValid = true;
            invalidFields.Clear();
            invalidFieldsLine = "";
        }

        public static void AddToInvalidFields(string field)
        {
            isValid = false;
            invalidFields.Add(field);
        }

        public static void ShowErrorMessage()
        {
            int count = 0;

            invalidFields.Sort();

            foreach (string field in invalidFields)
            {
                if (count == 0)
                {
                    invalidFieldsLine += field;
                    count++;
                }
                else
                {
                    invalidFieldsLine += ", " + field;
                }
            }

            MessageBox.Show("Invalid fields: " + invalidFieldsLine, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
