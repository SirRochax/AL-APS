using AL_APS.Services;
using System;

namespace AL_APS
{
    class Program
    {
        static void Main(string[] args)
        {
            string palavra;
            int length;


            Console.WriteLine("Insira uma palavra!(6 dígitos)");
            palavra = Console.ReadLine();
            length = palavra.Length;

            var conversor = new ConversorService();
            palavra = palavra.ToUpper();
            var matrix = conversor.ConversorPalavra(palavra);



        }
    }
}
