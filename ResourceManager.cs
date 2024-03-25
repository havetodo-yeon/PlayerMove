using SDL2;

class ResourceManager
{
    protected static Dictionary<string, IntPtr> Databases = new Dictionary<string, IntPtr>();

    public static IntPtr Load(string _filename)//, SDL.SDL_Color _ColorKey
    {
        if (!Databases.ContainsKey(_filename))
        {
            string Dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            IntPtr mySurface = SDL.SDL_LoadBMP(Dir + "/data/" + _filename);
            //SDL.SDL_SetColorKey(mySurface, 1, SDL.SDL_MapRGBA(0, _ColorKey.r, _ColorKey.g, _ColorKey.b, _ColorKey.a));
            IntPtr myTexture = SDL.SDL_CreateTextureFromSurface(Engine.GetInstance().myRenderer, mySurface);

            Databases[_filename] = myTexture;

            SDL.SDL_FreeSurface(mySurface);

        }

        return Databases[_filename];
    }
}
