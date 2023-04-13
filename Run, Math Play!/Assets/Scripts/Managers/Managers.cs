using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers _managers;

    static Managers GetManagers { get { Initialize(); return _managers; } }

    GameObject _player = null;
    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();
    SceneManagerEx _scene = new SceneManagerEx();
    SoundManager _sound = new SoundManager();
    PoolManager _pool = new PoolManager();
    DataManager _data = new DataManager();

    public static GameObject GetPlayer { get { return GetManagers._player; } }
    public static GameObject SetPlayer { set { GetManagers._player = value; } }


    public static InputManager GetInputManager { get { return GetManagers._input;  } }
    public static ResourceManager GetResourceManager { get { return GetManagers._resource;  } }
    public static UIManager GetUIManager { get { return GetManagers._ui; } }
    public static SceneManagerEx GetSceneManager { get { return GetManagers._scene; } }
    public static SoundManager GetSoundManager { get { return GetManagers._sound; } }
    public static PoolManager GetPoolManager { get { return GetManagers._pool; } }
    public static DataManager GetDataManager { get { return GetManagers._data; } }

    void Start() { Initialize(); }

    void Update() { _input.OnUpdate(); }

    static void Initialize()
    {
        if (_managers == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
                go.AddComponent<WJ_Mathpid>();
                go.AddComponent<WJ_Conn>();
            }

            DontDestroyOnLoad(go);
            
            _managers = go.GetComponent<Managers>();
            _managers._data.Initialize();
            _managers._pool.Initialize();
            _managers._sound.Initialize();
        }
    }

    public static void Clear()
    {
        GetSoundManager.Clear();
        GetInputManager.Clear();
        GetSceneManager.Clear();
        GetUIManager.Clear();
        GetPoolManager.Clear();
    }
}
