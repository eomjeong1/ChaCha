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

    public void ChooseStickerList()
    {
        stickerList = new Dictionary<int, Sticker[]>();
        stickerList.Add(1, new Sticker[]
            {
                new Sticker("짱오락실", "case1", false),
                new Sticker("오락기", "case1", false),
                new Sticker("상품", "case1", false),
                new Sticker("숙제", "case1", false),
                new Sticker("초록망토", "case1", false),
                new Sticker("아이스크림가게", "case1", false)
            });
        stickerList.Add(2, new Sticker[]
            {
                new Sticker("신호등", "case1", false),
                new Sticker("친구", "case1", false),
                new Sticker("강아지", "case1", false),
                new Sticker("핫도그가게", "case1", false),
                new Sticker("이삿짐트럭", "case1", false),
                new Sticker("자동차", "case1", false)
            });
        stickerList.Add(3, new Sticker[]
            {
                new Sticker("지나가던할머니", "case1", false),
                new Sticker("수상한봉고차", "case1", false),
                new Sticker("수상한사람", "case1", false),
                new Sticker("벽인쇄물", "case1", false),
                new Sticker("할머니짐", "case1", false),
            });
        stickerList.Add(4, new Sticker[]
            {
                new Sticker("멀리보이는집", "case1", false),
                new Sticker("꼬깔", "case1", false),
                new Sticker("축구공", "case1", false),
                new Sticker("고양이", "case1", false),
                new Sticker("포크레인차", "case1", false),
                new Sticker("안전제일", "case1", false)
            });
        stickerList.Add(5, new Sticker[]
            {
                new Sticker("늑대아저씨", "case1", false),
                new Sticker("과자", "case1", false),
                new Sticker("게임", "case1", false),
                new Sticker("우리집", "case1", false),
                new Sticker("친구네집", "case1", false)
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