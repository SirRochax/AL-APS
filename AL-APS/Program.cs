using AL_APS.Services;
using System;

namespace AL_APS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira uma palavra!(6 dígitos)");
            string word = Console.ReadLine();
            int length = word.Length;

            var converter = new CryptographyService();
            word = word.ToUpper();
            var matrix = converter.ConverterWordToMatrix(word);

            var mc = converter.CryptographyMatrix(matrix);

            //Feito o conversor e criptografia da matrix, falta descriptografar, converter para palavra e finalizar as validações

        }
    }
}
