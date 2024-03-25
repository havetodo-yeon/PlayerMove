using SDL2;
using System.Reflection;

class Program
{
    /*    // 객체 한 개 존재
        class Singleton
        {
            // private으로 만들어 아무도 접근하지 못하게 + 실행하자마자 자동으로 실행되게
            private Singleton()
            {
            }

            public static Singleton GetInstance()
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }

            private static Singleton? instance;

            public void Draw()
            {

            }

        }*/

    static void Main(string[] args)
    {


        //Singleton.GetInstance().Draw();

        // Engine engine = new Engine();    // 2024-03-18 Update Singleton

        string dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        Engine engine = Engine.GetInstance();

        engine.Init();
        SDL_mixer.Mix_OpenAudio(44100, SDL_mixer.MIX_DEFAULT_FORMAT, 2, 4096);
        IntPtr bgm = SDL_mixer.Mix_LoadMUS(dir + "/data/bgm.mp3");
        //SDL_mixer.Mix_PlayMusic(bgm, 1);
        SDL_mixer.Mix_Volume(-1, 10);

        engine.LoadScene("level01.map");
        engine.Run();
        engine.Term();

        SDL_mixer.Mix_FreeMusic(bgm);
        SDL_mixer.Mix_CloseAudio();
    }
}
