using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20240305_PlayerMove
{
    internal class Player
    {
        private int playerX = 1;
        private int playerY = 1;
        private int newPlayerX = 0;
        private int newPlayerY = 0;

        public int PlayerX
        {
            get
            {
                return playerX;
            }
            set
            {
                if(value < 0)
                {
                    playerX = value;    // 예외 작업하기에 용이함.
                }
            }
        }

        public int PlayerY
        {
/*            get;    // 이렇게 생략 가능.. 기본값 취급 하는 거임
            set;    // 보통 set은 예외 작업이 있기 때문에 이렇게 하지는 않음
*/       
            get
            {
                return playerY;
            }
            set
            {
                playerY = value;
            }
        }

        public void Move(ConsoleKeyInfo keyInfo, int[,] map)
        {
            newPlayerX = playerX;
            newPlayerY = playerY;

            if (keyInfo.Key == ConsoleKey.W ||
    keyInfo.Key == ConsoleKey.UpArrow)
            {
                newPlayerY--;

            }

            else if (keyInfo.Key == ConsoleKey.S ||
                    keyInfo.Key == ConsoleKey.DownArrow)
            {
                newPlayerY++;
            }

            else if (keyInfo.Key == ConsoleKey.A ||
                    keyInfo.Key == ConsoleKey.LeftArrow)
            {
                newPlayerX--;
            }

            else if (keyInfo.Key == ConsoleKey.D ||
                    keyInfo.Key == ConsoleKey.UpArrow)
            {
                newPlayerX++;
            }

            // predict
            if (map[newPlayerY, newPlayerX] == 1)
            {
                newPlayerX = playerX;
                newPlayerY = playerY;
            }

            playerX = Math.Clamp(newPlayerX, 0, 80);
            playerY = Math.Clamp(newPlayerY, 0, 20);

        }
    }
}
