using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AL_APS.Services
{
    class CryptographyService
    {
        enum Tabel
        {
            [Display(Name = " ")]
            SPACE,
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z
        };

        public int[,] ConverterWordToMatrix(string word)
        {
            int[,] converted = new int[3, 2];
            int i = 0;
            for (int c = 0; c < 2; c++)
                for (int l = 0; l < 3; l++)
                {
                    var p = word.Substring(i, 1);
                    foreach (string s in Enum.GetNames(typeof(Tabel))) { 
                        if (p.Equals(s))
                        {
                            var num = (int)Enum.Parse(typeof(Tabel), p);
                            converted[l, c] = num;
                            break;
                        }
                        
                    }
                    i++;
                }
            return converted;
        }

        public int[,] CryptographyMatrix(int[,] matrix)
        {
            int[,] encriptedArray = new int[3, 2];
            int[,] criptography = new int[,]
            { { 1, 0, 1 },
              { 1, 1, 1 },
              { 0, 2,-1 }};
            for (int i = 0; i < 2; i++)
                for (int l = 0; l < 3; l++)
                    for (int c = 0; c < 3; c++)
                        encriptedArray[l, i] += criptography[l, c] * matrix[c, i];

            return encriptedArray;
        }
    }
}
