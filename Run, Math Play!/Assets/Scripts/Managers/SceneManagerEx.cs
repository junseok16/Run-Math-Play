using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
    @class  : SceneManagerEx
    @date   : 2022-08-30
    @author : ≈π¡ÿºÆ
    @brief  : 
    @warning: 
 */

public class SceneManagerEx
{
    public BaseScene BaseScene
    {
        get { return GameObject.FindObjectOfType<BaseScene>(); }
    }

    public void LoadScene(Define.Scene nextScene)
    {
        Managers.Clear();
        SceneManager.LoadScene(GetSceneName(nextScene));
    }

    string GetSceneName(Define.Scene scene)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), scene);
        return name;
    }

    public void Clear()
    {
        BaseScene.Clear();
    }
}
