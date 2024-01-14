using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsNew26._09
{
    public class Pl
    {
        public string Encode(List<int> index, char[,] matrix)
        {
            string newCode = "";
            int a = 0, b = 0;

            for (int i = 0; i <= index.Count - 3; i += 4)    //берем по 4 цифры,  index.Count - 3 - берем 4ю цифру с кона и проверяем последняя ли она
            {
                a = index[i + 3] + 1;
                // Если на одной строке
                if (index[i] == index[i + 2] && a < 5)
                {
                    newCode = newCode + (matrix[index[i], index[i + 1] + 1]);
                    newCode = newCode + (matrix[index[i + 2], a]);
                }
                // Если на одной строке и у края
                if (index[i] == index[i + 2] && a >= 5)
                {
                    a = 0;
                    newCode = newCode + (matrix[index[i], index[i + 1] + 1]);
                    newCode = newCode + (matrix[index[i + 2], a]);
                }
                b = index[i + 2] + 1;
                // Если в одном столбце
                if (index[i + 1] == index[i + 3] && b < 5)
                {
                    newCode = newCode + (matrix[index[i] + 1, index[i + 1]]);
                    newCode = newCode + (matrix[b, index[i + 3]]);
                }
                // Если в одном столбце и у края
                if (index[i + 1] == index[i + 3] && b >= 5)
                {
                    b = 0;
                    newCode = newCode + (matrix[index[i] + 1, index[i + 1]]);
                    newCode = newCode + (matrix[b, index[i + 3]]);
                }
                //
                if (index[i] != index[i + 2] && index[i + 1] != index[i + 3])
                {
                    newCode = newCode + (matrix[index[i + 2], index[i + 1]]);
                    newCode = newCode + (matrix[index[i], index[i + 3]]);
                }

            }
            return newCode;
        }
        public string Decode(List<int> index, char[,] matrix)
        {
            string newCode = "";
            int a = 0, b = 0;

            for (int i = 0; i <= index.Count - 3; i += 4)
            {
                a = index[i + 3] - 1;
                // Если на одной строке
                if (index[i] == index[i + 2] && a >= 0)
                {
                    newCode = newCode + (matrix[index[i], index[i + 1] + 1]);
                    newCode = newCode + (matrix[index[i + 2], a]);
                }
                // Если на одной строке и у края
                if (index[i] == index[i + 2] && a < 0)
                {
                    a = 4;
                    newCode = newCode + (matrix[index[i], index[i + 1] - 1]);
                    newCode = newCode + (matrix[index[i + 2], a]);
                }
                b = index[i + 2] - 1;
                // Если в одном столбце
                if (index[i + 1] == index[i + 3] && b >= 0)
                {
                    newCode = newCode + (matrix[index[i] - 1, index[i + 1]]);
                    newCode = newCode + (matrix[b, index[i + 3]]);
                }
                // Если в одном столбце и у края
                if (index[i + 1] == index[i + 3] && b < 0)
                {
                    b = 4;
                    newCode = newCode + (matrix[index[i] - 1, index[i + 1]]);
                    newCode = newCode + (matrix[b, index[i + 3]]);
                }
                if (index[i] != index[i + 2] && index[i + 1] != index[i + 3])
                {
                    newCode = newCode + (matrix[index[i + 2], index[i + 1]]);
                    newCode = newCode + (matrix[index[i], index[i + 3]]);
                }
            }
            return newCode;
        }

        public string DelDoubleChars(string keyword)
        {
            for (int i = 1; i < keyword.Length; i++)
            {
                if (keyword[i - 1] == keyword[i])
                {
                    keyword = keyword.Remove(i, 1);
                    i--;
                }

            }
            return keyword;
        }
        public string DelKeywordChars(string keyword, string alphabet)
        {
            for (int i = 0; i < keyword.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (keyword[i] == alphabet[j])
                    {
                        alphabet = alphabet.Remove(j, 1);
                        j--; // Уменьшаем j, чтобы корректно проверить следующий символ
                    }
                }
            }
            return alphabet;
        }
        public char[,] GetMatrix(string keyword, string alphabet)
        {
            char[,] matrix = new char[5, 5];
            int k = 0;
            int m = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (k < keyword.Length)
                    {
                        matrix[i, j] = keyword[k];
                    }
                    if (k >= keyword.Length)
                    {
                        matrix[i, j] = alphabet[m];
                        m++;
                    }
                    k++;
                }
            }
            return matrix;
        }
        public string WordN(string code)
        {
            // обработка дублирования в биграмме
            for (int i = 0; i < code.Length - 1; i++)
            {
                if (code[i] == code[i + 1])
                {
                    code = code.Insert(i + 1, "x");
                    i++;
                }
            }
            //добавление символа в неполную биграмму
            if (code.Length % 2 != 0)
            {
                code += 'x';
            }
            return code;
        }
        public List<int> GetIndexList(string code, char[,] matrix)
        {
            List<int> index = new List<int>();
            for (int i = 0; i < code.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k1 = 0; k1 < 5; k1++)
                    {
                        if (code[i] == matrix[j, k1])
                        {
                            index.Add(j);
                            index.Add(k1);
                        }
                    }
                }
            }
            return index;
        }
    }
}
