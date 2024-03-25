using SDL2;

class ResourceManager
{   
    protected static Dictionary<string, IntPtr> Database = new Dictionary<string, IntPtr>();
    #region 움직이는 모션 아닌 경우
    /*    

        public static IntPtr Load(string _filename)
        {
            if (!Database.ContainsKey(_filename))
            {
                string Dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                IntPtr mySurface = SDL.SDL_LoadBMP(Dir + "/data/" + _filename);
                IntPtr myTexture = SDL.SDL_CreateTextureFromSurface(Engine.GetInstance().myRenderer, mySurface);

                Database[_filename] = myTexture;

                SDL.SDL_FreeSurface(mySurface);

            }

            return Database[_filename];
        }
    */
    #endregion

    #region 움직이는 모션
    public static IntPtr Load(string _filename, SDL.SDL_Color _ColorKey)
    {
        if (!Database.ContainsKey(_filename))
        {
            string Dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            unsafe
            {
                SDL.SDL_Surface* mySurface = (SDL.SDL_Surface*)SDL.SDL_LoadBMP(Dir + "/data/" + _filename);
                SDL.SDL_SetColorKey((IntPtr)mySurface, 1, SDL.SDL_MapRGBA(mySurface->format, _ColorKey.r, _ColorKey.g,
                    _ColorKey.b, _ColorKey.a));
                IntPtr myTexture = SDL.SDL_CreateTextureFromSurface(Engine.GetInstance().myRenderer, (IntPtr)mySurface);

                Database[_filename] = myTexture;

                SDL.SDL_FreeSurface((IntPtr)mySurface);
            }
        }
        return Database[_filename];
    }

    public static IntPtr Find(string _filename)
    {
        return Database[_filename];
    }
    #endregion
}
