/*using System.Data;
class Engine
{
    protected Engine()  // 2024-03-18 Update Singleton
    {
        gameObjects = new List<GameObject>();
        isRunning = true;
    }

    ~Engine()
    {

    }

    public static Engine? instance;

    public static Engine GetInstance()
    {
        if( instance == null)
        {
            instance = new Engine();
        }
        return instance;
        // return instance ?? (instance = new Engine());
        // instance == null ? (instance = new Engine()) : instance;
    }


    public List<GameObject> gameObjects;
    public bool isRunning;

    public void Init()  // file load
    {
        Input.Init();
    }

    public void Stop()
    {
        isRunning = false;
    }


    public void LoadScene(string SceneName)
    {
        // data file 이 bin\Debug\net8.0에 있으면 이렇게 써도 됨 그러나 git으로 관리 못함
        // string[] map = File.ReadAllLines("./data/level01.map"); 
#if DEBUG
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string Dir = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        string[] map = File.ReadAllLines(Dir + "/data/" + SceneName);    // string을 배열로 불러옴
#else
        string Dir = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
        string[] map = File.ReadAllLines(Dir + "/data/" + SceneName);    // string을 배열로 불러옴
#endif

        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == '*')
                {
                    //GameObject newGameObject = Instantiate(new GameObject());
                    GameObject newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Wall";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = '*';
                    renderer.renderOrder = RenderOrder.Wall;

                    //Instantiate(new Wall(x, y));    // GameObject newGameObject = Instantiate(new Wall(x, y));
                    //Instantiate(new Floor(x, y));
                    //newGameObject.x = x;
                    //newGameObject.y = y;

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.renderOrder = RenderOrder.Floor;

                }
                else if (map[y][x] == ' ')
                {
                    GameObject newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.renderOrder = RenderOrder.Floor;

                    //Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'P')
                {
                    GameObject newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Player";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = 'P';
                    renderer.renderOrder = RenderOrder.Player;
                    newGameObject.AddComponent<PlayerController>();

                    //Instantiate(new Player(x, y)); 
                    //Instantiate(new Floor(x, y));

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.renderOrder = RenderOrder.Floor;
                }
                else if (map[y][x] == 'G')
                {
                    GameObject newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Goal";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Goal;
                    renderer.Shape = 'G';

                    //Instantiate(new Goal(x, y));
                    //Instantiate(new Floor(x, y));

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.renderOrder = RenderOrder.Floor;
                }
                else if (map[y][x] == 'M')
                {
                    GameObject newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Monster";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Monster;
                    renderer.Shape = 'M';

                    *//* GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Monster";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    newGameObject.GetComponent<SpriteRenderer>().Shape = 'M'; *//*

                    //Instantiate(new Monster(x, y));
                    //Instantiate(new Floor(x, y));

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.renderOrder = RenderOrder.Floor;
                }
            }
        }

        // Load();
        //gameObjects.Sort();  // Objects sorting // 2024-03-18

        *//*        int WallCount = 0;
                foreach(GameObject go in gameObjects)
                {
                    // reflection
                    if(go.GetType() == typeof(Wall))    // 벽 갯수 카운팅할 수 있는 코드
                    {
                        Console.WriteLine("Wall");
                        WallCount++;
                    }
                    Console.WriteLine(WallCount);
                }

                // FindGameObject<Player> 로 만들 수 있다.
        *//*

        RenderSort();
    }

    public void RenderSort()
    {
        // gameObjects

        for(int i = 0; i < gameObjects.Count; i++)
        {
            for(int j = i + 1; j < gameObjects.Count; j++)
            {
                SpriteRenderer? prevRender = gameObjects[i].GetComponent<SpriteRenderer>();
                SpriteRenderer? nextRender = gameObjects[j].GetComponent<SpriteRenderer>();

                if(prevRender != null && nextRender != null)
                {
                    if((int)prevRender.renderOrder > (int)nextRender.renderOrder)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;
                    }
                }

            }
        }
    }



    public void Run()
    {
        while (isRunning)
        {
            ProcessInput();
            Update();
            Render();
        }   // frame
    }

    public void Term()
    {
        gameObjects.Clear();
    }

   // 2024-03-20 아래를 제네릭 문법으로 변경
    public T Instantiate<T>() where T : GameObject, new()
    {
        T newObject = new T();
        gameObjects.Add( newObject );

        return new T();
    }

*//*    public GameObject Instantiate(GameObject newGameObject)
    {
        gameObjects.Add(newGameObject);
        return newGameObject;
    }*//*

    protected void ProcessInput()
    {
        Input.keyInfo = Console.ReadKey();
    }

    protected void Update() // All of GameObject Update
    {
        foreach (GameObject gameObject in gameObjects)
        {
            foreach(Component component in gameObject.components)
            {
                component.Update();
            }
        }
    }

    protected void Render()
    {
        *//*        // all game object
                for (int i = 0; i < gameObjects.Count; i++)
                {
                    gameObjects[i].Render();
                }
        *//*
        Console.Clear();
        foreach (GameObject gameObject in gameObjects)   // Generic Collections
        {
            Renderer? renderer = gameObject.GetComponent<Renderer>();
            if(renderer != null)
            {
                renderer.Render();  // SpriteRenderer.cs
            }
        }
    }

}*/

using SDL2;
using System.Data;

class Engine
{
    protected Engine()
    {
        gameObjects = new List<GameObject>();
        isRunning = true;
    }

    ~Engine()
    {

    }

    public static Engine? instance;

    public static Engine GetInstance()
    {
        if (instance == null)
        {
            instance = new Engine();
        }

        return instance;
        //return instance ?? (instance = new Engine());
    }

    public List<GameObject> gameObjects;
    public bool isRunning;

    public bool isNextLoading = false;
    public string nextSceneName = string.Empty;

    public IntPtr myWindow; // 2024-03-25 ADD SDL
    public IntPtr myRenderer;
    public SDL.SDL_Event myEvent;
    ulong lastTime;

    public ulong deltaTime;

    public void NextLoadScene(string _nextSceneName)
    {
        isNextLoading = true;
        nextSceneName = _nextSceneName;
    }


    public void Init()
    {
        if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
        {
            Console.WriteLine("Init Fail");
            return;
        }

        myWindow = SDL.SDL_CreateWindow("2D Engine", 100, 100, 640, 480, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
        myRenderer = SDL.SDL_CreateRenderer(myWindow, -1,
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
            SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
            SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);

        Input.Init();

        lastTime = SDL.SDL_GetTicks64();
    }

    public void Stop()
    {
        isRunning = false;
    }

    public void LoadScene(string sceneName)
    {
#if DEBUG
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string Dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        string[] map = File.ReadAllLines(Dir + "/data/" + sceneName);
#else
        string Dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        string[] map = File.ReadAllLines(Dir + "/data/" + sceneName);
#endif

        //string[] map = File.ReadAllLines("./data/"+sceneName);

        GameObject newGameObject;
        for (int y = 0; y < map.Length; ++y)
        {
            for (int x = 0; x < map[y].Length; ++x)
            {
                if (map[y][x] == '*')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Wall";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = '*';
                    renderer.Load("wall.bmp");
                    renderer.renderOrder = RenderOrder.Wall;
                    newGameObject.AddComponent<Collider2D>();

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.Load("floor.bmp");
                    renderer.renderOrder = RenderOrder.Floor;

                }
                else if (map[y][x] == ' ')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.Load("floor.bmp");
                    renderer.renderOrder = RenderOrder.Floor;

                }
                else if (map[y][x] == 'P')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Player";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = 'P';
                    renderer.Load("player.bmp");
                    renderer.renderOrder = RenderOrder.Player;
                    newGameObject.AddComponent<PlayerController>();
                    Collider2D collider2D = newGameObject.AddComponent<Collider2D>();
                    collider2D.isTrigger = true;

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.Load("floor.bmp");
                    renderer.renderOrder = RenderOrder.Floor;
                }
                else if (map[y][x] == 'G')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Goal";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Goal;
                    renderer.Shape = 'G';
                    renderer.Load("goal.bmp");
                    Collider2D collider2D = newGameObject.AddComponent<Collider2D>();
                    collider2D.isTrigger = true;

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.Load("floor.bmp");
                    renderer.renderOrder = RenderOrder.Floor;

                }
                else if (map[y][x] == 'M')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Monster";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Monster;
                    renderer.Shape = 'M';
                    renderer.Load("monster.bmp");
                    Collider2D collider2D = newGameObject.AddComponent<Collider2D>();
                    collider2D.isTrigger = true;
                    newGameObject.AddComponent<AIController>();

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = ' ';
                    renderer.Load("floor.bmp");
                    renderer.renderOrder = RenderOrder.Floor;
                }
            }
        }

        newGameObject = Instantiate<GameObject>();
        newGameObject.name = "GameManager";
        newGameObject.AddComponent<GameManager>();


        RenderSort();
    }

    public void RenderSort()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            for (int j = i + 1; j < gameObjects.Count; j++)
            {
                SpriteRenderer? prevRender = gameObjects[i].GetComponent<SpriteRenderer>();
                SpriteRenderer? nextRender = gameObjects[j].GetComponent<SpriteRenderer>();
                if (prevRender != null && nextRender != null)
                {
                    if ((int)prevRender.renderOrder > (int)nextRender.renderOrder)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;
                    }
                }
            }
        }
    }

    public void Run()
    {
        while (isRunning)
        {
            ProcessInput();
            Update();
            Render();
            if (isNextLoading)
            {
                gameObjects.Clear();
                LoadScene(nextSceneName);
                isNextLoading = false;
                nextSceneName = string.Empty;
            }
        } //frame
    }

    public void Term()
    {
        gameObjects.Clear();

        SDL.SDL_DestroyRenderer(myRenderer);
        SDL.SDL_DestroyWindow(myWindow);
        SDL.SDL_Quit();
    }

    public T Instantiate<T>() where T : GameObject, new()
    {
        T newObject = new T();
        gameObjects.Add(newObject);

        return newObject;
    }

    //public GameObject Instantiate(GameObject newGameObject)
    //{
    //    gameObjects.Add(newGameObject);

    //    return newGameObject;
    //}

    protected void ProcessInput()
    {
        SDL.SDL_PollEvent(out myEvent); // 화면 안멈추게 큐에서 꺼내오는 거

        // Input.keyInfo = Console.ReadKey();
    }

    protected void Update()
    {
        deltaTime = SDL.SDL_GetTicks64() - lastTime;
        //Console.WriteLine(deltaTime);
        foreach (GameObject gameObject in gameObjects)
        {
            foreach (Component component in gameObject.components)
            {
                component.Update();
            }
        }
        lastTime = SDL.SDL_GetTicks64();
    }

    protected void Render()
    {
        //for(int i = 0; i < gameObjects.Count; i++)
        //{
        //    gameObjects[i].Render();
        //}
        //Console.Clear();
        foreach (GameObject gameObject in gameObjects)
        {
            Renderer? renderer = gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.Render();
            }
        }
        SDL.SDL_RenderPresent(Engine.GetInstance().myRenderer);
    }

    public GameObject? Find(string name)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name == name)
            {
                return gameObject;
            }
        }

        return null;
    }

}

