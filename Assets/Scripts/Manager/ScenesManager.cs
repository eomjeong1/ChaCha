using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Main,
    Changer1,
    Changer2,
    Game1,
    Game2,
    Game3,
    Game4,
    Game5,
    Result
}

public class ScenesManager : MonoBehaviour
{
    public int currentGame;
    public bool isCorr;
    public bool[] isCor = new bool[5];
    
 

    #region Singletone
    private static ScenesManager instance = null;

    public static ScenesManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ScenesManager");
            instance = go.AddComponent<ScenesManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    #region Scene Control

    public Scene currentScene;

    public void ChangeScene(Scene scene)
    {
        ResetSetting();

        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());
    }

    public void ChangeSceneString(string scene)
    {
        ResetSetting();

        SceneManager.LoadScene(scene);
    }

    void ResetSetting()
    {
        UIManager.GetInstance().ClearList();
    }

    private GameObject GetGameObject()
    {
        return gameObject;
    }
    #endregion

}