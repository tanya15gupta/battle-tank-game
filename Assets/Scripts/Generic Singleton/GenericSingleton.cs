using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    private static T Instance;
    public static T instance { get { return Instance; } }

    protected virtual void Awake()
	{
        if(Instance == null)
		{
			Instance = (T)this;
			return;
		}

		Destroy(this);
	}
}
