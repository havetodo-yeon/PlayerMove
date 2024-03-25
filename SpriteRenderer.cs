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

    public SpriteRenderer()
    {
        renderOrder = RenderOrder.None;
        textureName = "";
        colorKey = new SDL.SDL_Color();
        colorKey.r = 0;
        colorKey.g = 0;
        colorKey.b = 0;
        colorKey.a = 0;
    }

    public void Load(string _textureName)
    {
        textureName = _textureName;

        ResourceManager.Load(textureName);

    }


    public char Shape;
    public RenderOrder renderOrder;

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

            SDL.SDL_QueryTexture(ResourceManager.Load(textureName),
                out format, out access, out rect.w, out rect.h);  // 그래픽 카드에서 정보 가져옴

            SDL.SDL_RenderCopy(myEngine.myRenderer, ResourceManager.Load(textureName),
                ref rect, ref destRect);
        //}
    }
}
