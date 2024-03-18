class GameObject
{
    public Transform transform; // 2024-03-18 Update Transform.cs, Component.cs
    public List<Component> components;
    public string name;

    public GameObject()
    {
        name = "";
        transform = new Transform();
        components = new List<Component>();

        components.Add(transform);
    }

    // 2024-03-18 Update GameObject.cs like Unity Engine
    public T? GetComponent<T>() where T : Component
    {
        int findIndex = -1;
        for(int i = 0; i < components.Count; i++)
        {
            if(components[i] is T)
            {
                findIndex = i;
                break;
            }
        }
        if (findIndex > 0)
        {
            return (T)components[findIndex];
        }
        else
        {
            return null;
        }
    }

    public T AddComponent<T> () where T : Component, new()   // 생성자가 없으면 동작 X
    {
        T newT = new T();
        newT.gameObject = this;
        newT.transform = transform; // 자신의 transform과 연결, transform이 무조건 자신에게 있다는 전제
        components.Add(newT);

        return newT;
    }

/*    public void RemoveComponent<T>() where T : Component  // 유니티 엔진에 없는 기능이라 주석 처리
    {
        for (int i = 0; i < components.Count; i++)
        {
            if (components[i] is T)
            {
                components.RemoveAt(i);
                break;
            }
        }
    }*/

}