using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    public GameObject mainGroup;
    public Button btnStart;
    public Button btnGuide;
    public Button btnToMain;
    public Image imgGuide;

    public Image imgNext;
    public Image imgBefore;
    public Button btnNext;
    public Button btnBefore;

    Sticker[] stickers;
    StickerManager stickerManager;
    ScenesManager scenesManager;

    public bool page;

    void Start()
    {
        page = true;

        scenesManager = ScenesManager.GetInstance();
        stickerManager = StickerManager.GetInstance();

        if (btnStart != null)
            btnStart.onClick.AddListener(OnClickStart);

        if (btnGuide != null)
            btnGuide.onClick.AddListener(OnClickGuide);

        if (btnToMain != null)
            btnToMain.onClick.AddListener(OnClickToMain);

        if (btnNext != null)
            btnNext.onClick.AddListener(OnClickNext);

        if (btnBefore != null)
            btnBefore.onClick.AddListener(OnClickBefore);

        btnToMain.gameObject.SetActive(false);
        imgGuide.gameObject.SetActive(false);
    }

    void OnClickStart()
    {
        scenesManager.ChangeScene(Scene.Changer1);    // Changer1 씬으로 이동
        scenesManager.currentGame = 1;                // currentGame을 1로 초기화 (씬넘버 관리하는 변수 초기화)
        GameManager.GetInstance().curScore = 5;       // curScore를 5로 초기화 (점수 관리하는 변수 초기화)

        // stickerList의 sticker[1~5].isCheck를 전부 false로 초기화
        // (게임씬의 스티커를 클릭하지 않은 상태로 되돌립니다)
        for (int i = 1; i <= 5; i++)
        {
            stickers = stickerManager.stickerList[i];
            for (int x = 0; x < stickers.Length; x++)
            {
                stickers[x].isCheck = false;
            }
        }
        Debug.Log($"출발! / 현재 사과: {GameManager.GetInstance().curScore}개"); //점수 초기화 확인용
    }

    void OnClickGuide()
    {
        imgGuide.gameObject.SetActive(true);
        mainGroup.SetActive(false);
    }

    void OnClickToMain()
    {
        imgGuide.gameObject.SetActive(false);
        mainGroup.SetActive(true);
    }

    void OnClickNext()
    {
        if (page)
        {
            btnToMain.gameObject.SetActive(true);

            imgBefore.sprite = Resources.Load<Sprite>($"Image/UIMain/Before1");
            imgNext.sprite = Resources.Load<Sprite>($"Image/UIMain/Next2");
            imgGuide.sprite = Resources.Load<Sprite>($"Image/UIMain/Guide1");

            page = false;
        }
    }

    void OnClickBefore()
    {
        if (!page)
        {
            btnToMain.gameObject.SetActive(false);

            imgBefore.sprite = Resources.Load<Sprite>($"Image/UIMain/Before2");
            imgNext.sprite = Resources.Load<Sprite>($"Image/UIMain/Next1");
            imgGuide.sprite = Resources.Load<Sprite>($"Image/UIMain/Guide2");

            page = true;
        }
    }
}
