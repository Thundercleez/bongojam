using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static bool shuttingDown = false;
    private static object _Lock = new object();
    private static T instance;

    public static T Instance
    {
        get
        {
            if (shuttingDown)
            {
                return null;
            }

            lock (_Lock)
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " Singleton";
                        singletonObject.SendMessage("Awake");

                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return instance;
            }
        }
    }


    private void OnApplicationQuit()
    {
        shuttingDown = true;
    }


    private void OnDestroy()
    {
        shuttingDown = true;
    }
}
