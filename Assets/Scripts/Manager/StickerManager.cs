using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerManager : MonoBehaviour
{
    #region Singletone
    private static StickerManager instance;

    public static StickerManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@StickerManager");
            instance = go.AddComponent<StickerManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public Dictionary<int, Sticker[]> stickerList;

    public int stickerListIdx = 0;
    public bool openResult = false;

    private void Awake()
    {
        ChooseStickerList();
    }

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void ChooseStickerList()
    {
        stickerList = new Dictionary<int, Sticker[]>();
        stickerList.Add(1, new Sticker[]
            {
                new Sticker("간판", "case1", false),
                new Sticker("게임기", "case1", false),
                new Sticker("사격상품", "case1", false),
                new Sticker("숙제", "case1", false),
                new Sticker("옷가게", "case1", false),
                new Sticker("아이스크림", "case1", false)
            });
        stickerList.Add(2, new Sticker[]
            {
                new Sticker("신호등", "case1", false),
                new Sticker("친구들", "case1", false),
                new Sticker("강아지", "case1", false),
                new Sticker("핫도그가게", "case1", false)
            });
        stickerList.Add(3, new Sticker[]
            {
                new Sticker("할머니", "case1", false),
                new Sticker("봉고차", "case1", false),
                new Sticker("전봇대주변", "case1", false),
                new Sticker("벽에붙은경고문", "case1", false)
            });
        stickerList.Add(4, new Sticker[]
            {
                new Sticker("집", "case1", false),
                new Sticker("꼬깔", "case1", false),
                new Sticker("꼬깔2", "case1", false),
                new Sticker("꼬깔3", "case1", false),
                new Sticker("포크레인", "case1", false),
                new Sticker("안전제일", "case1", false)
            });
        stickerList.Add(5, new Sticker[]
            {
                new Sticker("옆집아저씨", "case1", false),
                new Sticker("집", "case1", false),
                new Sticker("과자", "case1", false)
            });
    }

    public void SetStickerList(int option)
    {
        stickerListIdx = option;
    }

    public Sticker[] GetStickerList()
    {
        return stickerList[stickerListIdx];
    }

}
