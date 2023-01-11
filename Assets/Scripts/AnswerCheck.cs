using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheck : MonoBehaviour
{
    #region Singletone
    private static AnswerCheck instance = null;

    public static AnswerCheck GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@AnswerCheck");
            instance = go.AddComponent<AnswerCheck>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    ScenesManager sM;
    public bool StageCorr;
    public string[] answer = new string[5];
    // Start is called before the first frame update
    void Start()
    {
        sM = GetComponent<ScenesManager>();
        for (int i = 0; i < sM.currentGame; i++)
        {
            CheckAnswer(i);
        }

    }

    // Update is called once per frame
    public void CheckAnswer(int i)
    {
        answer[i] = $"{i}��������";
        if (sM.isCorr == true)
        {
            StageCorr = true;
            Debug.Log($"{i}�������� ����Ȯ��");
        }
        else
        {
            StageCorr = false;
            Debug.Log($"{i}�������� ����Ȯ��");
        }
        Debug.Log(answer + $"{StageCorr}");
    }

}
