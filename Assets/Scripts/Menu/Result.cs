using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject goUI = null; // 활성화 비활성화 식으로 결과창을 보여줄것

    [SerializeField] Text[] textCount =null;


    [SerializeField] Text textScore = null;
    [SerializeField] Text textMaxCombo = null;


    ScoreMgr theScore;
    ComboMgr theCombo;
    TimingMgr theTiming; // 판정에 대한 기록이 필요하다
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

        int[] t_judgement = theTiming.GetJudgementRedcord(); // 타이밍메니저에서 만든 상세기록 받아오기(결과창에 띄우기 위해서)
        int t_currentScore = theScore.GetCurrentScore(); // 스코어메니저에서 현재 점수가 담겨있는 변수를 받아오기
        int t_maxCombo = theCombo.GetMaxCombo(); // 콤보메니저에서 현재 콤보가 담겨있는 변수를 받아오기

        for (int i = 0; i < textCount.Length; i++) // 텍스트를 매칭시켜서 대입시키기 위한 for문
        {
            textCount[i].text = t_judgement[i].ToString();
        }

        textScore.text = t_currentScore.ToString();
        textMaxCombo.text = t_maxCombo.ToString();


    }
}
