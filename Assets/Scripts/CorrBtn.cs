using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrBtn : MonoBehaviour
{
    public Button Cor;
    public Button incor;
    bool IsLose = false;
    UIProfile profile;

    void Start()
    {
        Cor.onClick.AddListener(Corr);
        incor.onClick.AddListener(Incorr);


        gameObject.SetActive(false);
    }

    public void Incorr()
    {
        GameManager.GetInstance().curScore--;
        Debug.Log($"틀렸습니다. / 남은 사과: {GameManager.GetInstance().curScore}개");
        ScenesManager.GetInstance().isCorr = false;
        ScenesManager.GetInstance().ChangeScene(Scene.Changer2);
        IsLose = true;
    }

    public void Corr()
    {
        Debug.Log($"정답입니다. / 남은 사과: {GameManager.GetInstance().curScore}개");
        ScenesManager.GetInstance().isCorr = true;
        ScenesManager.GetInstance().ChangeScene(Scene.Changer2);
        IsLose = false;
    }
    public void Check()
    {
        if (IsLose == true)
        {
            profile.LoseApple();
        }
    }
}
