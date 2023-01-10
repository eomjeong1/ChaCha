using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region SingletoneUI
    public static ObjectManager instance = null;
    public static ObjectManager GetInstance()
    {
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@ObjectManager"); // @ObjectManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<ObjectManager>(); // ObjectManager��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
        }
        return instance;
    }
    #endregion

   
    public GameObject CreateApple(string characterName)
    {
        Object characterObj = Resources.Load($"UI/{characterName}");// ���ҽ��������� Image - ĳ���Ͷ�� ģ���� �ε��Ұž�.
        
        
        GameObject character = (GameObject)Instantiate(characterObj); //�ҷ��� ĳ���Ͷ�� ģ���� �ν��Ͻ�ȭ �Ұž�.
        return character; // void�� return�� ��� �����ϴ�.
    }

}
