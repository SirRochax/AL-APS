using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AL_APS.Services
{
    class ConversorService
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
        
        public string[,] ConversorPalavra(string palavra)
        {
            string[,] convertido = new string[3, 2];
            int i = 0;
            for (int l = 0; l <3; l++)
                for(int c=0; c < 2; c++)
                {
                    var p = palavra.Substring(i, 1);
                    foreach (string s in Enum.GetNames(typeof(Tabel)))
                        if (p.Equals(s)) {
                            var x = (int)Enum.Parse(typeof(Tabel), p);
                            convertido[l, c] = Convert.ToString(x);
                        }
                    i++;
                }
            return convertido;
        }

        public string[,] CryptographyMatrix(string matrix)
        {
            string[,] convertido = new string[3, 2];

            return convertido;
        }
    }
}
