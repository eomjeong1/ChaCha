using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIOption : MonoBehaviour
{
    public Button cor;
    public Button incor;

    public Image imgCor;
    public Image imgIncor;

    int curcor;
    ScenesManager scenesManager;

    void Start()
    {
        curcor = ScenesManager.GetInstance().currentGame - 1;
        scenesManager = ScenesManager.GetInstance();

        //ScenesManager.GetInstance().currentGame = 5; //�׽�Ʈ��//
        SetOptionSc();
        cor.onClick.AddListener(Corr);
        incor.onClick.AddListener(Incorr);


        gameObject.SetActive(false); //�׽�Ʈ ������ �Ѽ���//
    }

    void SetOptionSc()
    {
        imgCor.sprite = Resources.Load<Sprite>($"Image/Stage{ScenesManager.GetInstance().currentGame}/Cor");
        imgIncor.sprite = Resources.Load<Sprite>($"Image/Stage{ScenesManager.GetInstance().currentGame}/Incor");
    }

    public void Incorr()
    {
        GameManager.GetInstance().curScore--;
        Debug.Log($"Ʋ�Ƚ��ϴ�. / ���� ���: {GameManager.GetInstance().curScore}��");
        scenesManager.isCorr = false;
        scenesManager.isCor[curcor] = false;
        Debug.Log($"�� ���: {scenesManager.isCor[curcor]}");
        ScenesManager.GetInstance().ChangeScene(Scene.Changer2);

    }

    public void Corr()
    {
        Debug.Log($"�����Դϴ�. / ���� ���: {GameManager.GetInstance().curScore}��");
        scenesManager.isCorr = true;
        scenesManager.isCor[curcor] = true;
        Debug.Log($"�� ���: {scenesManager.isCor[curcor]}");
        ScenesManager.GetInstance().ChangeScene(Scene.Changer2);

    }
  
}
