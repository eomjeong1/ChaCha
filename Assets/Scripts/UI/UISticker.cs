using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISticker : MonoBehaviour
{
    public AudioSource[] audioPlayer;
    AudioClip[] audioClips;
    public Button[] btnSound;
    public Image[] imgSc;

    public GameObject btnOption;

    bool lookGranMa;
    bool lookUncle;
    public AudioSource CallPlayer;
    public AudioClip granMaSound;
    public AudioClip uncleSound;

    Sticker[] stickers;

    public StickerManager stickerManager;
    
    public ScenesManager scenesManager;
    
    private void Start()
    {
        stickerManager = StickerManager.GetInstance();
        
       
        //ScenesManager.GetInstance().currentGame = 4; //�׽�Ʈ��//
        stickers = stickerManager.stickerList[ScenesManager.GetInstance().currentGame];
        Debug.Log($"�������� {ScenesManager.GetInstance().currentGame}");
        /////////�̰� �����ߴµ� �Լ� �� ��/////////

        audioPlayer = new AudioSource[stickers.Length];
        audioClips = new AudioClip[stickers.Length];
        btnSound = new Button[stickers.Length];
        imgSc = new Image[stickers.Length];

        Debug.Log($"{stickers.Length}");

        for (int i = 0; i < stickers.Length; i++)
        {
            Debug.Log($"{i}");
            imgSc[i] = GetComponentsInChildren<Image>()[i];
            imgSc[i].sprite = Resources.Load<Sprite>($"Image/Stage{ScenesManager.GetInstance().currentGame}/{stickers[i].stickerName}");
            Debug.Log($"{stickers[i].stickerName} ����");

            imgSc[i].gameObject.AddComponent<AudioSource>();
            audioPlayer[i] = imgSc[i].gameObject.GetComponent<AudioSource>();
            audioClips[i] = Resources.Load<AudioClip>($"Sound/{stickers[i].stickerSound}");
            audioPlayer[i].clip = audioClips[i];
            audioPlayer[i].Stop();

            int idx = i;
            btnSound[i] = imgSc[i].gameObject.GetComponent<Button>();
            btnSound[i].onClick.AddListener(()=> { PlaySound(idx); });
            btnSound[i].onClick.AddListener(()=> { IsCheckTrue(idx); });
            btnSound[i].onClick.AddListener(IsCheckBool);
        }
    }

    public void PlaySound(int num)
    {
        audioPlayer[num].Play();
    }

    public void IsCheckTrue(int num)
    {
        stickers[num].isCheck = true;
        Debug.Log($"{stickers[num].stickerName}�� Ȯ���߽��ϴ�.");
    }

    public void IsCheckBool()
    {
        //for (int i = 0; i < stickers.Length; i++)
        //{
        //    Debug.Log($"{stickers[i].stickerName}�� Ȯ���߳�? : {stickers[i].isCheck}");
        //}

        for (int i = 0; i < stickers.Length; i++)
        {
            if (stickers[i].isCheck == false)
                return;
        }

        OpenOption();
    }

    public void OpenOption()
    {
        
        
        if (ScenesManager.GetInstance().currentGame == 3) 
        {           
            lookGranMa = true;
            Debug.Log("lookGranMa = true");
            GrandMaCall();

        }
        if (ScenesManager.GetInstance().currentGame == 5)
        {
            lookUncle = true;
            Debug.Log("lookUncle = true");
            UncleCall();
        }
        else
        {
            btnOption.SetActive(true);
        }
    }
    IEnumerator GrandMaCall()
    {
        CallPlayer.clip = granMaSound;
        CallPlayer.Play();
        float waitTime = 4.0f;
        waitTime = waitTime - Time.deltaTime;
        if (waitTime == 0.0f)
        {
            btnOption.SetActive(true);
            lookGranMa = false;
        }
        yield return null;

    }

    IEnumerator UncleCall()
    {
        CallPlayer.clip = uncleSound;
        CallPlayer.Play();
        float waitTime = 4.0f;
        waitTime = waitTime - Time.deltaTime;
        if (waitTime == 0.0f)
        {
            btnOption.SetActive(true); 
            lookUncle = false;
        }
        yield return null;
        
    }
}
