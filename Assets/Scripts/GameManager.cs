using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region SingletoneUI
    public static GameManager instance = null;
    public static GameManager GetInstance()
    {
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@GameManager"); // @ObjectManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<GameManager>(); // ObjectManager��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
        }
        return instance;
    }
    #endregion

    public int curScore;
    public int totalScore;
   
    private string playerName = null;

    public void SetScore()
    {
        totalScore = 5;
        curScore = 5;
    }

}
