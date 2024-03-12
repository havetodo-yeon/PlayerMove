namespace L20240305_PlayerMove
{
    internal class PlayerMove
    {
        static Player player;

        static ConsoleKeyInfo keyInfo;
        static int[,] map =
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            };

        static void Input()
        {
            keyInfo = Console.ReadKey(); // 키 입력 받기
        }

        static void Update()
        {
            player.Move(keyInfo, map);
        }

        static void Render()
        {
            Console.Clear();    // 콘솔 화면 지우기

            // Render Map
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.SetCursorPosition(x, y);    // 
                    if (map[y, x] == 1)
                    {
                        Console.Write('*');
                    }
                    else if (map[y, x] == 0)
                    {
                        Console.Write(' ');
                    }
                }
            }

            // Render Player
            Console.SetCursorPosition(player.PlayerX, player.PlayerY);    // 커서 위치
            Console.WriteLine('P');
        }

        static void Main(string[] args)
        {
            player = new Player();
            player.PlayerX = 1;
            player.PlayerY = 1;

            // file 입출력
            while (true)
            {
                Input();
                Update();
                Render();
            }
        }
    }
}
