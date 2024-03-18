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
        Engine engine = Engine.GetInstance();

        engine.Init();
        engine.LoadScene("level01.map");
        engine.Run();
        engine.Term();
    }
}
