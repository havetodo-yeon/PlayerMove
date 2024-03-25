
class GameManager : Component
{
    public bool isGameOver;
    public bool isNextStage;

    protected Timer gameOverTimer;
    protected Timer CompleteTimer;

    public int Gold;

    public GameManager()
    {
        isGameOver = false;
        isNextStage = false;

        // 로딩 다 되면 뭐 해줘
        gameOverTimer = new Timer(3000, () =>
        {
            ProcessGameOver();    // 람다식 활용하면 함수를 생성하지 않아도 이름 없이 직접 이 위치에 함수 내용을 쓸 수 있음 
        });
        //gameOverTimer.callback += ProcessComplete;

        CompleteTimer = new Timer(2000, ProcessComplete);
    }

    private void ProcessGameOver()
    {
        Engine.GetInstance().Stop();
        Console.Clear();
        Console.WriteLine("GameOver");
    }

    private void ProcessComplete()
    {
        Console.Clear();
        Console.WriteLine("Congraturation.");
        Console.ReadKey();
        Engine.GetInstance().NextLoadScene("level02.map");
    }

    public override void Update()
    {
        if(isGameOver)
        {
            gameOverTimer.Update();
        }

        if (isNextStage)
        {
            CompleteTimer.Update();
            //Engine.GetInstance().Term();
            //Engine.GetInstance().LoadScene("Level02.map");
        }

    }

}