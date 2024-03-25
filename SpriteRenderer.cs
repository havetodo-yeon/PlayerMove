using SDL2;

public enum RenderOrder
{
    None = 0,
    Floor = 100,
    Wall = 200,
    Goal = 300,
    Player = 400,
    Monster = 500,
}

class SpriteRenderer : Renderer
{
    public string textureName;

    public SDL.SDL_Color colorKey;

    // 캐릭터 움직이는 모션으로 만들기 위함
    public bool isMultiple = false;

    public int spriteCount = 0;

    protected int currentIndex = 0;

    public ulong currentTime = 0;

    public ulong executeTime = 250;

    public int currentIndexY = 0;

    //


    public SpriteRenderer()
    {
        renderOrder = RenderOrder.None;
        textureName = "";
        colorKey = new SDL.SDL_Color();
        colorKey.r = 255;
        colorKey.g = 255;
        colorKey.b = 255;
        colorKey.a = 255;
    }

    public void Load(string _textureName)
    {
        textureName = _textureName;

        ResourceManager.Load(textureName, colorKey);

    }


    public char Shape;
    public RenderOrder renderOrder;

    public override void Update()
    {
        if(isMultiple)
        {
            currentTime += Engine.GetInstance().deltaTime;
            if (currentTime >= executeTime)
            {
                currentIndex++;
                currentIndex = currentIndex % spriteCount;
                currentTime = 0;
            }
        }
    }

    public override void Render()
    {
        // SDL.SDL_GetTicks64(); // GetTicks로 하면 자료형 크기 한계가 있음
        if (transform != null)
        {
            //Console.SetCursorPosition(transform.x, transform.y);
            //Console.Write(Shape);
        }

            Engine myEngine = Engine.GetInstance();

            SDL.SDL_Rect destRect = new SDL.SDL_Rect();
            destRect.x = transform.x * 30;
            destRect.y = transform.y * 30;
            destRect.w = 30;
            destRect.h = 30;

        /*        if(renderOrder == RenderOrder.Floor)
                {
                    SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 0, 255, 0, 0);
                }
                else if(renderOrder == RenderOrder.Wall)
                {
                    SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 255, 255, 0, 0);
                }
                else if(renderOrder == RenderOrder.Player)
                {
                    SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 0, 0, 255, 0);
                }
                else if(renderOrder == RenderOrder.Monster)
                {
                    SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 255, 0, 255, 0);
                }
                else if(renderOrder == RenderOrder.Goal)
                {
                    SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 255, 255, 255, 0);
                }
        */
        // SDL.SDL_RenderFillRect(myEngine.myRenderer, ref myRect);

        //unsafe        // C, C++
        //{
        SDL.SDL_Rect rect = new SDL.SDL_Rect();
            rect.x = 0;
            rect.y = 0;
            uint format = 0;
            int access = 0;

        #region 움직이는 모션 활용 안할 때
        /*
            SDL.SDL_QueryTexture(ResourceManager.Find(textureName),
                out format, out access, out rect.w, out rect.h);  // 그래픽 카드에서 정보 가져옴

            SDL.SDL_RenderCopy(myEngine.myRenderer, ResourceManager.Find(textureName),
                ref rect, ref destRect);*/
        #endregion

        #region 움직이는 모션 활용

        SDL.SDL_QueryTexture(ResourceManager.Find(textureName),
                        out format, out access, out rect.w, out rect.h);

        if (isMultiple)
        {
            //animation
            int spriteWidth = rect.w / spriteCount;
            int spriteHeight = rect.h / spriteCount;

            rect.x = spriteWidth * currentIndex;
            rect.y = spriteWidth * currentIndexY;
            rect.w = spriteWidth;
            rect.h = spriteHeight;
        }
        else
        {
            rect.x = 0;
            rect.y = 0;
        }


        SDL.SDL_RenderCopy(myEngine.myRenderer,
            ResourceManager.Find(textureName), ref rect, ref destRect);

        #endregion

        //}
    }
}
