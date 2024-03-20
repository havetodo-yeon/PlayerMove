﻿public enum RenderOrder
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
    public SpriteRenderer()
    {
        renderOrder = RenderOrder.None;
    }

    public char Shape;
    public RenderOrder renderOrder;

    public override void Render()
    {
        Console.SetCursorPosition(transform.x, transform.y);
        Console.Write(Shape);
    }
}
