﻿using SDL2;

class PlayerController : Component
{
    public SpriteRenderer spriteRenderer;

    public override void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        int oldX = transform.x;
        int oldY = transform.y;

        if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a))   // 프레임 단위로 입력받는 작업
        {
            transform.Translate(-1, 0);
            spriteRenderer.currentIndexY = 0;
        }
        if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d))
        {
            transform.Translate(1, 0);
            spriteRenderer.currentIndexY = 1;
        }
        if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_w))
        {
            transform.Translate(0, -1);
            spriteRenderer.currentIndexY = 2;
        }
        if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s))
        {
            transform.Translate(0, +1);
            spriteRenderer.currentIndexY = 3;
        }
        if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_ESCAPE))
        {
            //singleton pattern
            Engine.GetInstance().Stop();
        }

        transform.x = Math.Clamp(transform.x, 0, 80);
        transform.y = Math.Clamp(transform.y, 0, 80);

        // find new x, new y 해당 게임 오브젝트 탐색
        // 찾은 게임 오브젝트에서 Collider2D 그리고 충돌체크
        /* Collider2D 컴포넌트를 가지는 모든 게임 오브젝트를 찾는다
           자기 자신 제외, Player와 충돌하는 체크 */
        foreach(GameObject findGameObject in Engine.GetInstance().gameObjects)
        {
            if(findGameObject == gameObject)
            {
                continue;   // 자기 자신 제외
            }

            Collider2D? findComponent = findGameObject.GetComponent<Collider2D>();
            if (findComponent != null)
            {
                if (findComponent.Check(gameObject) && findComponent.isTrigger == false)
                {
                    // 충돌
                    transform.x = oldX;
                    transform.y = oldY;
                    //OnCollide(GameObject other);
                    break;
                }
                if(findComponent.Check(gameObject) && findComponent.isTrigger == true)
                {
                    OnTrigger(findGameObject);
                }
            }
        }
        
    }

    private void OnTrigger(GameObject other)
    {
        // 겹쳤을 때 처리 할 로직
        if(other.name == "Monster")
        {
            Engine.GetInstance().Find("GameManager").GetComponent<GameManager>().isGameOver = true;
            // Game Over
        }
        else if(other.name == "Goal")
        {
            Engine.GetInstance().Find("GameManager").GetComponent<GameManager>().isNextStage = true;
            // Next Stage
        }

    }
}
