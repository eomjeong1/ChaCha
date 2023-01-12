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
                new Sticker("¯������", "case1", false),
                new Sticker("������", "case1", false),
                new Sticker("��ǰ", "case1", false),
                new Sticker("����", "case1", false),
                new Sticker("�ʷϸ���", "case1", false),
                new Sticker("���̽�ũ������", "case1", false)
            });
        stickerList.Add(2, new Sticker[]
            {
                new Sticker("��ȣ��", "case1", false),
                new Sticker("ģ��", "case1", false),
                new Sticker("������", "case1", false),
                new Sticker("�ֵ��װ���", "case1", false),
                new Sticker("�̻���Ʈ��", "case1", false),
                new Sticker("�ڵ���", "case1", false)
            });
        stickerList.Add(3, new Sticker[]
            {
                new Sticker("���������ҸӴ�", "case1", false),
                new Sticker("�����Ѻ�����", "case1", false),
                new Sticker("�����ѻ��", "case1", false),
                new Sticker("���μ⹰", "case1", false),
                new Sticker("�ҸӴ���", "case1", false),
            });
        stickerList.Add(4, new Sticker[]
            {
                new Sticker("�ָ����̴���", "case1", false),
                new Sticker("����", "case1", false),
                new Sticker("�౸��", "case1", false),
                new Sticker("�����", "case1", false),
                new Sticker("��ũ������", "case1", false),
                new Sticker("��������", "case1", false)
            });
        stickerList.Add(5, new Sticker[]
            {
                new Sticker("���������", "case1", false),
                new Sticker("����", "case1", false),
                new Sticker("����", "case1", false),
                new Sticker("�츮��", "case1", false),
                new Sticker("ģ������", "case1", false)
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