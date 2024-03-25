class AIController : Component
{
    protected ulong processTime;
    protected ulong ElapsedTime;
    public AIController()
    {
        processTime = 500;
        ElapsedTime = 0;
    }

    public override void Update()
    {
        ElapsedTime += Engine.GetInstance().deltaTime;
        if (ElapsedTime < processTime)
        {
            return;
        }

        ElapsedTime = 0;

        Random random = new Random();

        int oldX = transform.x;
        int oldY = transform.y;

        int NextDirection = random.Next(0, 4);

        if (NextDirection == 0)
        {
            transform.Translate(-1, 0);
        }
        if (NextDirection == 1)
        {
            transform.Translate(1, 0);
        }
        if (NextDirection == 2)
        {
            transform.Translate(0, -1);
        }
        if (NextDirection == 3)
        {
            transform.Translate(0, +1);
        }

        transform.x = Math.Clamp(transform.x, 0, 80);
        transform.y = Math.Clamp(transform.y, 0, 80);

        foreach (GameObject findGameObject in Engine.GetInstance().gameObjects)
        {
            if (findGameObject == gameObject)
            {
                continue;   // 자기 자신 제외
            }

            Collider2D? findComponent = findGameObject.GetComponent<Collider2D>();
            if (findComponent != null)
            {
                if (findComponent.Check(gameObject))
                {
                    // 충돌
                    transform.x = oldX;
                    transform.y = oldY;
                    //OnCollide(GameObject other);
                    break;
                }
            }
        }

    }
}

