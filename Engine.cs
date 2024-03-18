using System.Data;
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
        string Dir = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
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
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Wall";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = '*';

                    //Instantiate(new Wall(x, y));    // GameObject newGameObject = Instantiate(new Wall(x, y));
                    //Instantiate(new Floor(x, y));
                    //newGameObject.x = x;
                    //newGameObject.y = y;
                }
                else if (map[y][x] == ' ')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    //SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    //renderer.Shape = ' ';

                    //Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'P')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Player";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = 'P';
                    PlayerController controller = newGameObject.AddComponent<PlayerController>();

                    //Instantiate(new Player(x, y)); 
                    //Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'G')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Goal";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = 'G';

                    //Instantiate(new Goal(x, y));
                    //Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'M')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Monster";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.Shape = 'M';

                    /* GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Monster";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    newGameObject.GetComponent<SpriteRenderer>().Shape = 'M'; */

                    //Instantiate(new Monster(x, y));
                    //Instantiate(new Floor(x, y));
                }
            }
        }

        // Load();
        //gameObjects.Sort();  // Objects sorting // 2024-03-18

/*        int WallCount = 0;
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
*/
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

    public GameObject Instantiate(GameObject newGameObject)
    {
        gameObjects.Add(newGameObject);
        return newGameObject;
    }

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
        /*        // all game object
                for (int i = 0; i < gameObjects.Count; i++)
                {
                    gameObjects[i].Render();
                }
        */
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

}