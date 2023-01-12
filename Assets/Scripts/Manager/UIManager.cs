using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    #region Singletone
    private static UIManager instance;

    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@UIManager");
            instance = go.AddComponent<UIManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    #region UI_Control
    public void SetEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == false)
        {
            GameObject go = new GameObject("@EventSystem");
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
        }
    }

    public Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();
    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false)
        {
            Object uiObj = Resources.Load("UI/" + uiName);
            GameObject uiObject = (GameObject)Instantiate(uiObj);

            uiList.Add(uiName, uiObject);
        }
        else
            uiList[uiName].SetActive(true);
    }

    public void CloseUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
            uiList[uiName].SetActive(false);
    }
    #endregion

    public void ClearList()
    {
        uiList.Clear();
    }
}
