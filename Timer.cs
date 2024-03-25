using System.Reflection;

class Timer
{
    public ulong excuteTime = 0;
    protected ulong elapsedTime = 0;

    public delegate void Callback();
    public Callback callback;

    public Timer(ulong _executeTime, Callback _callback)
    {
        SetTimer(_executeTime, _callback);
    }

    public void SetTimer(ulong _executeTime, Callback _callback)
    {
        excuteTime = _executeTime;
        callback = _callback;
    }

    public void Update()
    {
        elapsedTime += Engine.GetInstance().deltaTime;
        if(elapsedTime >= excuteTime)
        {
            // 실행
            // 함수를 등록해서 그 함수 실행되게 
            if(callback != null)
            {
                callback();
            }
            elapsedTime = 0;
        }
    }

}
