using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrBtn : MonoBehaviour
{
    public Button cor;
    public Button incor;

    public Image imgCor;
    public Image imgIncor;


    void Start()
    {
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
        ScenesManager.GetInstance().isCorr = false;
        ScenesManager.GetInstance().ChangeScene(Scene.Changer2);

    }

    public void Corr()
    {
        Debug.Log($"�����Դϴ�. / ���� ���: {GameManager.GetInstance().curScore}��");
        ScenesManager.GetInstance().isCorr = true;
        ScenesManager.GetInstance().ChangeScene(Scene.Changer2);

    }
  
}
