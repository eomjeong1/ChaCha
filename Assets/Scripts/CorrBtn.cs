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
        //ScenesManager.GetInstance().currentGame = 5; //테스트용//
        SetOptionSc();
        cor.onClick.AddListener(Corr);
        incor.onClick.AddListener(Incorr);


        gameObject.SetActive(false); //테스트 끝나면 켜세요//
    }

    void SetOptionSc()
    {
        imgCor.sprite = Resources.Load<Sprite>($"Image/Stage{ScenesManager.GetInstance().currentGame}/Cor");
        imgIncor.sprite = Resources.Load<Sprite>($"Image/Stage{ScenesManager.GetInstance().currentGame}/Incor");
    }

    public void Incorr()
    {
        GameManager.GetInstance().curScore--;
        Debug.Log($"틀렸습니다. / 남은 사과: {GameManager.GetInstance().curScore}개");
        ScenesManager.GetInstance().isCorr = false;
        ScenesManager.GetInstance().ChangeScene(Scene.Changer2);

    }

    public void Corr()
    {
        Debug.Log($"정답입니다. / 남은 사과: {GameManager.GetInstance().curScore}개");
        ScenesManager.GetInstance().isCorr = true;
        ScenesManager.GetInstance().ChangeScene(Scene.Changer2);

    }
  
}
