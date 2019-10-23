using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AL_APS.Services
{
    class DecryptionService
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

        public int[,] DecryptionMatrix(int[,] mc)
        {
            int[,] decryptedArray = new int[3, 2];
            int[,] decryption = new int[,]
            { { 3,-2, 1 },
              {-1, 1, 0 },
              {-2, 2,-1 }};

            for (int i = 0; i < 2; i++)
                for (int l = 0; l < 3; l++)
                    for (int c = 0; c < 3; c++)
                        decryptedArray[l, i] += decryption[l, c] * mc[c, i];

            return decryptedArray;
        }

        public string ConverterMatrixToWord(int[,] matrix)
        {
            string word = null;
            int i = 0;
            for (int c = 0; c < 2; c++)
                for (int l = 0; l < 3; l++)
                {
                    var letter = Convert.ToString(Enum.GetName(typeof(Tabel), matrix[l, c]));
                    if (letter != null)
                    {
                        word += letter;
                    }
                    else
                        return null;
                }
            return word;
        }
    }
}
