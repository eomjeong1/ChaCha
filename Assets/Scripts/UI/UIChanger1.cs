using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIChanger1 : MonoBehaviour
{
    public VideoPlayer vid;
    int currentGame;
    public string curScene;

    public Button btnSkip;

    void Start()
    {
        this.currentGame = ScenesManager.GetInstance().currentGame;

        btnSkip.onClick.AddListener(OnSkip);
        btnSkip.gameObject.SetActive(false);
        vid = GetComponentInChildren<VideoPlayer>();

        curScene = $"Game{currentGame}";

        if (currentGame > 5)
            curScene = "Result";

        vid.clip = Resources.Load<VideoClip>($"Video/stage/{curScene}");

        Debug.Log($"������ ����� �� {curScene} ������ �̵��մϴ�.");

        vid.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log(curScene);
        ScenesManager.GetInstance().ChangeSceneString(curScene);
    }

    void OnSkip()
    {
        ScenesManager.GetInstance().ChangeSceneString(curScene);
    }
}
