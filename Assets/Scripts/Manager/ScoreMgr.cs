using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMgr : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text textScore = null;

    [SerializeField] int increaseScore = 10;
    int currentScore = 0;

    [SerializeField] float[] weight = null; // weight ?



    [SerializeField] int comboBonusScore = 10; // 콤보에 따른 보너스 점수

  
    //Animator myAnim;
    //string animScoreUp = "Hit"; //애니메이션을 이름으로 할당?
    string hit = "Hit";

    // 점수가 올랐다 = 올바르게 눌렀다 = 콤보가 오른다
    ComboMgr theCombo;
    Result theResult;
    // Start is called before the first frame update
    void Start()
    {
        theCombo = FindObjectOfType<ComboMgr>(); // Find 
        theResult = FindObjectOfType<Result>();
        //myAnim = GetComponent<Animator>(); // Get
        
        currentScore = 0;
        textScore.text = "0"; // 시작하면 점수는 0
    }

    public void IncreaseScore(int p_JudgementState) // 판정에 따른 점수. 파라미터로 판정넣음 배열이 아닌 배열값으로 = int
    {
        // 콤보 증가
        theCombo.IncreaseCombo();

        // 콤보 보너스 점수 계산
        int t_currentCombo = theCombo.GetCurrentCombo(); // 현재 콤보 받아오기
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore; // 보너스 점수 = 현재 콤보 / 10 * 콤보에 따른 보너스 점수

        // 판정 가충치 계산
        int t_increaseScore = increaseScore + t_bonusComboScore;
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]);



        currentScore += t_increaseScore;
        textScore.text = currentScore.ToString();


        // 애니메이션 실행
        //myAnim.SetTrigger(animScoreUp);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
    // Update is called once per frame
    void Update()
    {
        if(currentScore >= 100)
        {
            theResult.ShowResult();
        }
    }
}
