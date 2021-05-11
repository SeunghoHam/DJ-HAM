using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingMgr : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null; // 판정범위의 중심 이 센터 프레임
    [SerializeField] RectTransform[] timingRect = null;

    Vector2[] timingBoxs = null; // 실제 판정 판독에 쓸 timingBoxs



    int[] judgementRecord = new int[5]; // 판정들을 기록할 배열변수

    // 참조 오브젝트
    EffectMgr theEffect;
    ComboMgr theComboMgr;
    ScoreMgr theScoreMgr;

    // Start is called before the first frame update
    void Start()
    {
        theEffect = FindObjectOfType<EffectMgr>();
        theScoreMgr = FindObjectOfType<ScoreMgr>();
        theComboMgr = FindObjectOfType<ComboMgr>();
        // 타이밍 박스 설정
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
    // 0 번째 타이밍 박스는 가장좁은 판정범위 n+ 번째 일수록 넓게
    public void CheckTiming()
    {

        for (int i = 0; i < boxNoteList.Count; i++) // 생성된 노트의 갯수
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y; // 각 노트의 y 좌표 따로받기

            // 판정범위 최소값 <= 노트의 x 값 <= 판정범위 최대값

            // 판정 범위만큼 반복 -> 어느 판정 범위에 있는지 확인
            for (int y = 0; y < timingBoxs.Length; y++)
            {
                //Debug.Log("timingboxs[0].y = " + timingBoxs[0].y); // 타이밍 박스 하나로 고정? 50값나옴
                //Debug.Log("timingboxs[1].y = " + timingBoxs[1].y); // 타이밍 박스 하나로 고정? 50값나옴
                //Debug.Log("timingboxs[2].y = " + timingBoxs[2].y); // 타이밍 박스 하나로 고정? 50값나옴
                // 타이밍 박스는 실제 판독에 쓸 Vector2, t_notePosY는 float형 boxlist[i]번째의 y 좌표
                // 노트의 x 값이 판정범위 안에 들어와 있는지 각 판정 범위에 최소 x 최대 y를 비교
                //if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y) // 여기 고민좀
                //if (timingBoxs[y].x >=t_notePosY && t_notePosY <= timingBoxs[y].y)
                if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                {
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);


                    //if(y <timingBoxs.Length -1) // 난 필요없음 bad를 딱히 만들지 않았음
                    theEffect.NoteHitEffect(); // 노트 타격시 이펙트 

                    theEffect.JudgeMentEffect(y); // MAX 100% 같은 이펙트
                    theEffect.comboEffect();

                    // 점수증가
                    theScoreMgr.IncreaseScore(y); // y = 판정을 결정지은 값
                    //theComboMgr.IncreaseCombo();
                    //theScoreMgr.IncreaseScore(y); // y = judgement :: 판정을 결정지은 값




                    judgementRecord[y]++;// 판정 기록



                    Debug.Log("hit + " + y);
                    return;
                }





            }
        }
        theEffect.JudgeMentEffect(timingBoxs.Length); // 마지막 배열 ( 미스 ) 
        MissRecord(); // 미스발생시 미스갯수 기록
        //theComboMgr.ResetCombo();// 콤보 초기화
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
