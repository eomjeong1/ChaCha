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
                new Sticker("짱오락실", "간판사운드", false),
                new Sticker("오락기", "오락기사운드", false),
                new Sticker("상품", "사격상품사운드", false),
                new Sticker("숙제", "숙제사운드", false),
                new Sticker("초록망토", "옷가게사운드", false),
                new Sticker("아이스크림가게", "아이스크림사운드", false)
            });
        stickerList.Add(2, new Sticker[]
            {
                new Sticker("신호등", "신호등사운드", false),
                new Sticker("친구", "친구들사운드", false),
                new Sticker("강아지", "강아지사운드", false),
                new Sticker("핫도그가게", "핫도그사운드", false),
                new Sticker("이삿짐트럭", "트럭사운드", false),
                new Sticker("자동차", "자동차사운드", false)
            });
        stickerList.Add(3, new Sticker[]
            {
                new Sticker("지나가던할머니", "할머니사운드1", false),
                new Sticker("수상한봉고차", "봉고차사운드", false),
                new Sticker("수상한사람", "숨어있는사람사운드", false),
                new Sticker("벽인쇄물", "아이를찾습니다사운드", false),
                new Sticker("할머니짐", "짐가방사운드", false),
            });
        stickerList.Add(4, new Sticker[]
            {
                new Sticker("멀리보이는집", "집사운드", false),
                new Sticker("꼬깔", "꼬깔사운드", false),
                new Sticker("축구공", "축구공사운드", false),
                new Sticker("고양이", "고양이사운드", false),
                new Sticker("포크레인차", "포크레인사운드", false),
                new Sticker("안전제일", "안전제일사운드", false)
            });
        stickerList.Add(5, new Sticker[]
            {
                new Sticker("늑대아저씨", "늑대사운드1", false),
                new Sticker("과자", "과자사운드", false),
                new Sticker("게임", "게임사운드", false),
                new Sticker("우리집", "우리집사운드", false),
                new Sticker("친구네집", "친구집사운드", false)
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