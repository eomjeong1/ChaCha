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
                new Sticker("¯������", "���ǻ���", false),
                new Sticker("������", "���������", false),
                new Sticker("��ǰ", "��ݻ�ǰ����", false),
                new Sticker("����", "��������", false),
                new Sticker("�ʷϸ���", "�ʰ��Ի���", false),
                new Sticker("���̽�ũ������", "���̽�ũ������", false)
            });
        stickerList.Add(2, new Sticker[]
            {
                new Sticker("��ȣ��", "��ȣ�����", false),
                new Sticker("ģ��", "ģ�������", false),
                new Sticker("������", "����������", false),
                new Sticker("�ֵ��װ���", "�ֵ��׻���", false),
                new Sticker("�̻���Ʈ��", "Ʈ������", false),
                new Sticker("�ڵ���", "�ڵ�������", false)
            });
        stickerList.Add(3, new Sticker[]
            {
                new Sticker("���������ҸӴ�", "�ҸӴϻ���1", false),
                new Sticker("�����Ѻ�����", "����������", false),
                new Sticker("�����ѻ��", "�����ִ»������", false),
                new Sticker("���μ⹰", "���̸�ã���ϴٻ���", false),
                new Sticker("�ҸӴ���", "���������", false),
            });
        stickerList.Add(4, new Sticker[]
            {
                new Sticker("�ָ����̴���", "������", false),
                new Sticker("����", "�������", false),
                new Sticker("�౸��", "�౸������", false),
                new Sticker("�����", "����̻���", false),
                new Sticker("��ũ������", "��ũ���λ���", false),
                new Sticker("��������", "�������ϻ���", false)
            });
        stickerList.Add(5, new Sticker[]
            {
                new Sticker("���������", "�������1", false),
                new Sticker("����", "���ڻ���", false),
                new Sticker("����", "���ӻ���", false),
                new Sticker("�츮��", "�츮������", false),
                new Sticker("ģ������", "ģ��������", false)
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