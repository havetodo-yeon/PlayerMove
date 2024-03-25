/*class Input
{
    public Input()
    {

    }

    ~Input() 
    {
        
    }

    public struct KeyList
    {
        public KeyList(ConsoleKey newButton, ConsoleKey newAltButton)
        {
            button = newButton;
            altButton = newAltButton;
        }

        public ConsoleKey button;
        public ConsoleKey altButton;
    }


    public static void Init()
    {
        //editor 설정
        InputMapping["Up"] = ConsoleKey.W;
        InputMapping["Down"] = ConsoleKey.S;
        InputMapping["Left"] = ConsoleKey.A;
        InputMapping["Right"] = ConsoleKey.D;
        InputMapping["Quit"] = ConsoleKey.Escape;
    }

    public static Dictionary<string, ConsoleKey> InputMapping = new Dictionary<string, ConsoleKey>();

    public static ConsoleKeyInfo keyInfo;  // key input

    public static bool GetKey(ConsoleKey CheckKeyCode)
    {
        return (keyInfo.Key == CheckKeyCode);
    }
    public static bool GetButton(string buttonName)
    {
        return (InputMapping[buttonName] == keyInfo.Key
            || InputMapping[buttonName].altButton == keyInfo.Key);
    }
}
*/

using SDL2;

class Input
{
    public Input()
    {

    }

    ~Input()
    {

    }

    public struct KeyList
    {
        public KeyList(ConsoleKey newButton, ConsoleKey newAltButton)
        {
            button = newButton;
            altButton = newAltButton;
        }

        public ConsoleKey button;
        public ConsoleKey altButton;
    }

    public static void Init()
    {
        //editor 설정
        InputMapping["Up"] = new KeyList(ConsoleKey.W, ConsoleKey.UpArrow);
        InputMapping["Down"] = new KeyList(ConsoleKey.S, ConsoleKey.DownArrow);
        InputMapping["Left"] = new KeyList(ConsoleKey.A, ConsoleKey.LeftArrow);
        InputMapping["Right"] = new KeyList(ConsoleKey.D, ConsoleKey.RightArrow);
        InputMapping["Quit"] = new KeyList(ConsoleKey.Escape, ConsoleKey.None);
    }

    public static Dictionary<string, KeyList> InputMapping = new Dictionary<string, KeyList>();

    public static ConsoleKeyInfo keyInfo;

    public static bool GetKey(ConsoleKey checkKeycode)
    {
        return (keyInfo.Key == checkKeycode);
    }

    public static bool GetKey(SDL.SDL_Keycode checkKeycode)
    {
        return (Engine.GetInstance().myEvent.key.keysym.sym == checkKeycode);
    }

    public static bool GetButton(string buttonName)
    {
        return (InputMapping[buttonName].button == keyInfo.Key
            || InputMapping[buttonName].altButton == keyInfo.Key);
    }
}