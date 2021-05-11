using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject goUI = null; // Ȱ��ȭ ��Ȱ��ȭ ������ ���â�� �����ٰ�

    [SerializeField] Text[] textCount =null;


    [SerializeField] Text textScore = null;
    [SerializeField] Text textMaxCombo = null;


    ScoreMgr theScore;
    ComboMgr theCombo;
    TimingMgr theTiming; // ������ ���� ����� �ʿ��ϴ�
    // Start is called before the first frame update
    void Start()
    {
        theScore = FindObjectOfType<ScoreMgr>();
        theCombo = FindObjectOfType<ComboMgr>();
        theTiming = FindObjectOfType<TimingMgr>();
    }

    public void ShowResult()
    {
        goUI.SetActive(true);

        for (int i = 0; i < textCount.Length; i++)
            textCount[i].text = "0";


        textScore.text = "0";
        textMaxCombo.text = "0";

        int[] t_judgement = theTiming.GetJudgementRedcord(); // Ÿ�ָ̹޴������� ���� �󼼱�� �޾ƿ���(���â�� ���� ���ؼ�)
        int t_currentScore = theScore.GetCurrentScore(); // ���ھ�޴������� ���� ������ ����ִ� ������ �޾ƿ���
        int t_maxCombo = theCombo.GetMaxCombo(); // �޺��޴������� ���� �޺��� ����ִ� ������ �޾ƿ���

        for (int i = 0; i < textCount.Length; i++) // �ؽ�Ʈ�� ��Ī���Ѽ� ���Խ�Ű�� ���� for��
        {
            textCount[i].text = t_judgement[i].ToString();
        }

        textScore.text = t_currentScore.ToString();
        textMaxCombo.text = t_maxCombo.ToString();


    }
}
