using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
{
    public GameObject go;

    void Start()
    {
        var uiManager = UIManager.GetInstance();
        uiManager.SetEventSystem();
        uiManager.OpenUI("ResultUI");

        uiManager.uiList["ResultUI"].transform.SetParent(go.transform);
    }
}
