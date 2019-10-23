using AL_APS.Services;
using System;

namespace AL_APS
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 99999;

            do
            {
                try
                {

                    //Iniciando a aplicacao
                    Console.WriteLine("Insira a opção desejada:");
                    Console.WriteLine("1 - CRIPTOGRAFIA");
                    Console.WriteLine("2 - DESCRIPTOGRAFIA");
                    Console.WriteLine("0 - SAIR");
                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:

                            bool repeat = false;

                            do
                            {
                                Console.WriteLine("Insira uma palavra!(6 dígitos)");
                                string word = Console.ReadLine();
                                int length = word.Length;

                                //Verificando se a palavra possui 6 digitos
                                if (length == 6)
                                {
                                    var cryptographer = new CryptographyService();

                                    word = word.ToUpper();
                                    Console.WriteLine("Palavra inserida: " + word + "\n");

                                    //Convertendo e exibindo a matriz numerica da palavra
                                    var matrix = cryptographer.ConverterWordToMatrix(word);
                                    Console.WriteLine("Matriz convertida:\n");
                                    for (int l = 0; l < 3; l++)
                                        for (int c = 0; c < 2; c++)
                                        {
                                            if (c != 1)
                                                Console.Write(matrix[l, c] + " - ");
                                            else
                                                Console.Write(matrix[l, c] + "\n");
                                        }

                                    //Convertendo e exibindo a matriz criptografada
                                    var mc = cryptographer.CryptographyMatrix(matrix);
                                    Console.WriteLine("\nMatriz criptografada:\n");
                                    for (int l = 0; l < 3; l++)
                                        for (int c = 0; c < 2; c++)
                                        {
                                            if (c != 1)
                                                Console.Write(mc[l, c] + " - ");
                                            else
                                                Console.Write(mc[l, c] + "\n");
                                        }

                                    break;

                                }
                                else
                                {

                                    Console.WriteLine("****** INSIRA UMA PALAVRA DE 6 DÍGITOS ******\n");
                                    repeat = true;
                                }

                            } while (repeat);

                            break;

                        case 2:

                            int[,] mcForDecryptography = new int[3, 2];
                            int i = 1;

                            //Indicando modo de insercao da matrix
                            Console.WriteLine("\nInsira a MC na ordem a seguir:");
                            Console.WriteLine("1 - 6");
                            Console.WriteLine("2 - 5");
                            Console.WriteLine("3 - 4\n");

                            for (int c = 0; c < 2; c++)
                                for (int l = 0; l < 3; l++)
                                {
                                    Console.Write("Insira o " + i + "º número:");
                                    mcForDecryptography[l, c] = Convert.ToInt32(Console.ReadLine());
                                    i++;
                                }

                            var decrypter = new DecryptionService();

                            //Descriptografando a matriz inserida
                            var matrixDecrypted = decrypter.DecryptionMatrix(mcForDecryptography);

                            //Convertendo a matriz em numero
                            var wordDecrypted = decrypter.ConverterMatrixToWord(matrixDecrypted);

                            //Aqui verifica se a matriz inserida é valida, vaso nao seja válida, retornará null do metodo ConverterMatrixToWord e entrará no if
                            if (wordDecrypted == null)
                            {
                                Console.WriteLine("\n****** A MATRIZ INSERIDA NÃO É VÁLIDA ******\n");
                                Console.ReadLine();
                                break;
                            }


                            //Exibindo matriz inserida
                            Console.WriteLine("\nMatriz inserida:\n");
                            for (int l = 0; l < 3; l++)
                                for (int c = 0; c < 2; c++)
                                {
                                    if (c != 1)
                                        Console.Write(mcForDecryptography[l, c] + " - ");
                                    else
                                        Console.Write(mcForDecryptography[l, c] + "\n");
                                }

                            //Exibindo a matriz sem criptografia
                            Console.WriteLine("Matriz sem criptografia:\n");
                            for (int l = 0; l < 3; l++)
                                for (int c = 0; c < 2; c++)
                                {
                                    if (c != 1)
                                        Console.Write(matrixDecrypted[l, c] + " - ");
                                    else
                                        Console.Write(matrixDecrypted[l, c] + "\n");
                                }

                            //Exibindo a palavra resultado
                            Console.WriteLine("A matriz inserida representa a palavra: " + wordDecrypted);
                            Console.ReadLine();

                            break;

                        case 0:
                            break;

                        default:
                            Console.WriteLine("****** INSIRA UMA OPÇÃO VÁLIDA ******\n");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("****** INSIRA UM NÚMERO ******\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (option != 0);

        }
    }

}
