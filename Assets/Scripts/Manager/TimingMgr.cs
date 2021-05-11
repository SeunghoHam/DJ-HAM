using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingMgr : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null; // ���������� �߽� �� ���� ������
    [SerializeField] RectTransform[] timingRect = null;

    Vector2[] timingBoxs = null; // ���� ���� �ǵ��� �� timingBoxs



    int[] judgementRecord = new int[5]; // �������� ����� �迭����

    // ���� ������Ʈ
    EffectMgr theEffect;
    ComboMgr theComboMgr;
    ScoreMgr theScoreMgr;

    // Start is called before the first frame update
    void Start()
    {
        theEffect = FindObjectOfType<EffectMgr>();
        theScoreMgr = FindObjectOfType<ScoreMgr>();
        theComboMgr = FindObjectOfType<ComboMgr>();
        // Ÿ�̹� �ڽ� ����
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.height / 2,
                                Center.localPosition.y + timingRect[i].rect.height / 2);

            //Debug.Log(timingBoxs[i].x +     "       " + timingBoxs[i].y);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    // 0 ��° Ÿ�̹� �ڽ��� �������� �������� n+ ��° �ϼ��� �а�
    public void CheckTiming()
    {

        for (int i = 0; i < boxNoteList.Count; i++) // ������ ��Ʈ�� ����
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y; // �� ��Ʈ�� y ��ǥ ���ιޱ�

            // �������� �ּҰ� <= ��Ʈ�� x �� <= �������� �ִ밪

            // ���� ������ŭ �ݺ� -> ��� ���� ������ �ִ��� Ȯ��
            for (int y = 0; y < timingBoxs.Length; y++)
            {
                //Debug.Log("timingboxs[0].y = " + timingBoxs[0].y); // Ÿ�̹� �ڽ� �ϳ��� ����? 50������
                //Debug.Log("timingboxs[1].y = " + timingBoxs[1].y); // Ÿ�̹� �ڽ� �ϳ��� ����? 50������
                //Debug.Log("timingboxs[2].y = " + timingBoxs[2].y); // Ÿ�̹� �ڽ� �ϳ��� ����? 50������
                // Ÿ�̹� �ڽ��� ���� �ǵ��� �� Vector2, t_notePosY�� float�� boxlist[i]��°�� y ��ǥ
                // ��Ʈ�� x ���� �������� �ȿ� ���� �ִ��� �� ���� ������ �ּ� x �ִ� y�� ��
                //if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y) // ���� �����
                //if (timingBoxs[y].x >=t_notePosY && t_notePosY <= timingBoxs[y].y)
                if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                {
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);


                    //if(y <timingBoxs.Length -1) // �� �ʿ���� bad�� ���� ������ �ʾ���
                    theEffect.NoteHitEffect(); // ��Ʈ Ÿ�ݽ� ����Ʈ 

                    theEffect.JudgeMentEffect(y); // MAX 100% ���� ����Ʈ
                    theEffect.comboEffect();

                    // ��������
                    theScoreMgr.IncreaseScore(y); // y = ������ �������� ��
                    //theComboMgr.IncreaseCombo();
                    //theScoreMgr.IncreaseScore(y); // y = judgement :: ������ �������� ��




                    judgementRecord[y]++;// ���� ���



                    Debug.Log("hit + " + y);
                    return;
                }





            }
        }
        theEffect.JudgeMentEffect(timingBoxs.Length); // ������ �迭 ( �̽� ) 
        MissRecord(); // �̽��߻��� �̽����� ���
        //theComboMgr.ResetCombo();// �޺� �ʱ�ȭ
        Debug.Log("miss");
    }

    public int[] GetJudgementRedcord()
    {
        return judgementRecord;
    }

    public void MissRecord()
    {
        judgementRecord[4]++;
    }

}
