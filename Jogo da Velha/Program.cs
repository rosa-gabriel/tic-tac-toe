using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar == true)
            {
                Console.Clear();
                char[] dots = new char[9];
                char[] jogador = new char[] { 'O', 'X' };
                int nowjog = 0;
                int res = 0;
                int temp = 0;
                bool erro = false;
                for (int i = 0; i < 9; i++)
                {
                    dots[i] = ' ';
                }
                Show();
                while (res == 0)
                {
                    do
                    {
                        erro = false;
                        Console.WriteLine("Digite a casa que deseja marcar jogador " + jogador[nowjog] + ": ");
                        temp = Convert.ToInt32(Console.ReadLine());
                        if (canRead()) dots[temp - 1] = jogador[nowjog];
                        else
                        {
                            Console.WriteLine("Fora dos valores disponiveis");
                            Show();
                            erro = true;
                        }
                    }
                    while (erro);
                    Show();
                    if (rescheck())
                    {
                        Console.WriteLine("\n Jogador " + jogador[nowjog] + " Ganhou");
                        res = 1;
                        continuar = replay();
                    }
                    else if (Velha())
                    {
                        Console.WriteLine("Velha");
                        res = 1;
                        continuar = replay();
                    }
                    if (nowjog == 0) nowjog = 1;
                    else nowjog = 0;

                }



                bool rescheck()
                {
                    int horiz = 0;
                    for (int i = 0; i < dots.Length; i += 3)
                    {
                        if (dots[i] == jogador[nowjog] && dots[i + 1] == jogador[nowjog] && dots[i + 2] == jogador[nowjog]) return true;
                        if (dots[horiz] == jogador[nowjog] && dots[horiz + 3] == jogador[nowjog] && dots[horiz + 6] == jogador[nowjog]) return true;
                        horiz++;
                    }
                    if (dots[0] == jogador[nowjog] && dots[4] == jogador[nowjog] && dots[8] == jogador[nowjog]) return true;
                    if (dots[2] == jogador[nowjog] && dots[4] == jogador[nowjog] && dots[6] == jogador[nowjog]) return true;
                    return false;

                }
                void Show()
                {
                    Console.WriteLine(" " + dots[0] + " | " + dots[1] + " | " + dots[2]);
                    Console.WriteLine("-----------");
                    Console.WriteLine(" " + dots[3] + " | " + dots[4] + " | " + dots[5]);
                    Console.WriteLine("-----------");
                    Console.WriteLine(" " + dots[6] + " | " + dots[7] + " | " + dots[8]);
                }
                bool canRead()
                {
                    if (temp <= dots.Length)
                    {
                        if (dots[temp - 1] == ' ') return true;
                    }
                    return false;
                }
                bool replay()
                {
                    Console.WriteLine("\n Deseja jogar Novamente? 1- Sim 2- Nao");
                    if (Convert.ToInt32(Console.ReadLine()) == 2) return false;
                    return true;
                }
                bool Velha()
                {
                    bool exists = Array.Exists(dots, element => element == ' ');
                    if (!exists) return true;
                    return false;
                }
            }
        }

    }
}
