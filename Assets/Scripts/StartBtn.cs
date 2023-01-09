using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    public Button start;
    public Button main;

    Sticker[] stickers;
    public StickerManager stickerManager;

    void Start()
    {

        if (start != null)
            start.onClick.AddListener(BtnStart);

        if(main != null)
            main.onClick.AddListener(() => { ScenesManager.GetInstance().ChangeScene(Scene.Main); });
    }

    void BtnStart()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Changer1);
        ScenesManager.GetInstance().currentGame = 1;
        GameManager.GetInstance().curScore = 5;


        stickerManager = StickerManager.GetInstance();

        for (int i = 1; i <= 5; i++)
        {
            stickers = stickerManager.stickerList[i];
            for (int x = 0; x < stickers.Length; x++)
            {
                stickers[x].isCheck = false;
            }
        }

        Debug.Log($"출발! / 현재 사과: {GameManager.GetInstance().curScore}개");
    }
}
