using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public GameObject go;

    void Start()
    {
        var uiManager = UIManager.GetInstance();
        uiManager.SetEventSystem();
        uiManager.OpenUI("UIMain");

        uiManager.uiList["UIMain"].transform.SetParent(go.transform);
    }
}