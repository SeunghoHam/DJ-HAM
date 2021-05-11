using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMgr : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text textScore = null;

    [SerializeField] int increaseScore = 10;
    int currentScore = 0;

    [SerializeField] float[] weight = null; // weight ?



    [SerializeField] int comboBonusScore = 10; // �޺��� ���� ���ʽ� ����

  
    //Animator myAnim;
    //string animScoreUp = "Hit"; //�ִϸ��̼��� �̸����� �Ҵ�?
    string hit = "Hit";

    // ������ �ö��� = �ùٸ��� ������ = �޺��� ������
    ComboMgr theCombo;
    Result theResult;
    // Start is called before the first frame update
    void Start()
    {
        theCombo = FindObjectOfType<ComboMgr>(); // Find 
        theResult = FindObjectOfType<Result>();
        //myAnim = GetComponent<Animator>(); // Get
        
        currentScore = 0;
        textScore.text = "0"; // �����ϸ� ������ 0
    }

    public void IncreaseScore(int p_JudgementState) // ������ ���� ����. �Ķ���ͷ� �������� �迭�� �ƴ� �迭������ = int
    {
        // �޺� ����
        theCombo.IncreaseCombo();

        // �޺� ���ʽ� ���� ���
        int t_currentCombo = theCombo.GetCurrentCombo(); // ���� �޺� �޾ƿ���
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore; // ���ʽ� ���� = ���� �޺� / 10 * �޺��� ���� ���ʽ� ����

        // ���� ����ġ ���
        int t_increaseScore = increaseScore + t_bonusComboScore;
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]);



        currentScore += t_increaseScore;
        textScore.text = currentScore.ToString();


        // �ִϸ��̼� ����
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
