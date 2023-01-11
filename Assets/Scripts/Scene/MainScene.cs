using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    void Start()
    {
        var uiManager = UIManager.GetInstance();
        uiManager.SetEventSystem();
        uiManager.OpenUI("UIMain");
    }
}