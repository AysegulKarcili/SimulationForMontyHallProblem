using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationForMontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            int simSize = 10000;
            Random random = new Random();
            int conservWinCnt = 0;
            int changedWinCnt = 0;

            for (int i = 0; i < simSize; i++)
            {
                int carInd = random.Next(1, 4);
                System.Threading.Thread.Sleep(1);
                int choice = random.Next(1, 4);
                System.Threading.Thread.Sleep(1);

                int openDoor;
                if (carInd != choice)
                {
                    openDoor = 6 - carInd - choice;
                }
                else
                {
                    int[] pouch = new int[2];
                    pouch[0] = (int)Math.Round((6.0 - carInd) / 2 - 0.75);
                    pouch[1] = (int)Math.Round((6.0 - carInd) / 2 + 0.75);
                    openDoor = pouch[random.Next(0, pouch.Length)];
                }
                
                int conservChoice = choice;
                int changedChoice = 6 - openDoor - choice;

                char conservWin = ' ';
                char changedWin = ' ';
                if (conservChoice == carInd)
                {
                    conservWin = '+';
                    conservWinCnt++;
                }
                else if (changedChoice == carInd)
                {
                    changedWin = '+';
                    changedWinCnt++;
                }

                Console.WriteLine("{0} {1} {2} {3} {4}", carInd, choice, openDoor, conservWin, changedWin);
            }

            Console.WriteLine("conservWinCnt = {0}, changedWinCnt = {1}", conservWinCnt, changedWinCnt);
            Console.WriteLine("P(conserver wins) = {0}", (double)conservWinCnt / (conservWinCnt + changedWinCnt));
            Console.WriteLine("P(changer wins) = {0}", (double)changedWinCnt / (changedWinCnt + conservWinCnt));
            Console.WriteLine("The ratio is {0}", (double)changedWinCnt / conservWinCnt);

            Console.ReadLine();
        }
    }
}
