using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UIProfile : MonoBehaviour
{
    // �ʿ��� ����
    GameManager gameManager;
    ScenesManager sM;
    UISticker uiSticker;

    // ��ư
    public Button hint;
    public Button guide;
    public Button closehint;

    // �̹���
    public Image hintBg;
    public Image[] apple = new Image[5];
    
    // ��Ʈ �ؽ�Ʈ �迭
    string[] hinttxtList = { "�ֺ��� �ϰ� ���� ��, �԰� ���� �͵��� ������ �� ������ �����ؿ�.", "�ʷϺ� ��ȣ�� �� ���� �ʾҴٸ� ���� ��ȣ�� ��ٷȴٰ� �������� �� ����?", 
        "�ҸӴ� �ڿ� �ִ� ���� ���� �����? �����ϳ׿�!" , "�������̶� ������ ���� ���ؼ� ���� �� ���ڴµ���?" , "�ƹ��� ������������ ȥ�ڼ� ���󰡸� �ȵſ�!"};
    public Text hinttxt;

    public Text directtxt;
    public string[] directtxts = { "�ٴڿ� ȭ��ǥ�� ������! ���� �����?", "�ٴڿ� ��ٸ���� �ǳʱ��ư�� ������! ��� �ұ��?",
        "�ҸӴϰ� �����̽ôµ� �ҸӴ� ��ư�� �ٽ� ���������?", "�ٴڿ� ȭ��ǥ�� ������! ������� �����, ���Ƽ� �����?", 
        "������������ ���� ������ �Ͻô��� �ѹ� �� ���������?" };

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();

        

        if (hint != null)
        {
            hint.onClick.AddListener(HintBtn);
        }
        if (closehint != null)
        {
            closehint.gameObject.SetActive(false);
            closehint.onClick.AddListener(CloseBtn);
        }
        if (hintBg != null)
        {
            hintBg.gameObject.SetActive(false);
        }
        CreateApple();
        LoseApple();
        GetHinttxt();
        StartCoroutine(CheckDirect());
    }
    IEnumerator CheckDirect()
    {
        while (false)
        {           uiSticker = null;
            if (uiSticker == null)
                Debug.Log("null");
            if (uiSticker.needDirect)
            {
                uiSticker.needDirect = false;
                directtxt.text = directtxts[sM.currentGame - 1];
                Debug.Log("�𷺼� ����");
                break;
            }
            else
            {
                directtxt.gameObject.SetActive(false);
            }
        }
        yield return true;
    }
    
    // ��Ʈ��ư ����
    public void HintBtn()
    { 
        hint.gameObject.SetActive(false);
        closehint.gameObject.SetActive(true);
        hintBg.gameObject.SetActive(true);
        hintBg.sprite = Resources.Load<Sprite>("Image/UIProfile/Hint");
    }

    // ��Ʈ �ݱ��ư ����
    public void CloseBtn()
    {
        hint.gameObject.SetActive(true);
        closehint.gameObject.SetActive(false);
        hintBg.gameObject.SetActive(false);
    }

    // ��� ǥ���ϱ�
    void CreateApple()
    {
        for (int i = 0; i < apple.Length; i++)
        {
            apple[i] = GetComponentsInChildren<Image>()[i];
            apple[i].sprite = Resources.Load<Sprite>($"Image/UIProfile/Apple");
            Debug.Log($"{i + 1}��°��� ����");


        }
    }

    // ��� �Ҵ� �� ǥ���ϱ�
    void LoseApple()
    {
        for (int i = 0; i < apple.Length; i++)
        {
            if (i < gameManager.curScore)
            {
                apple[i].gameObject.SetActive(true);
            }
            else
            {
                apple[i].sprite = Resources.Load<Sprite>($"Image/UIProfile/LApple");
                Debug.Log($"��� -1");
            }
        }
    }

    // ��Ʈ �ؽ�Ʈ �迭�ϱ�
    public void GetHinttxt()
    {
        sM = ScenesManager.GetInstance();

        int i = sM.currentGame;
            hinttxt.text = hinttxtList[i-1];
        
    }
}
