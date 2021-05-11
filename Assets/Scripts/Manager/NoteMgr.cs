using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMgr : MonoBehaviour
{
    public int bpm = 0; // 1분에 bpm 갯수만큼 노트 생성
    double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null; // 노트가 생성될 격체
    [SerializeField] GameObject goNote = null; // 노트 프리팹을 담고 있던 객체

    TimingMgr theTimingMgr;
    public ComboMgr theComboMgr;
    public EffectMgr theEffectMgr;
    // Start is called before the first frame update
    void Start()
    {
        theTimingMgr = GetComponent<TimingMgr>();
        //theComboMgr = GetComponent<ComboMgr>();
        //theEffectMgr = GetComponent<EffectMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            //GameObject t_note = ObjectPool.instance.noteQueue.Dequeue(); // 오브젝트풀의 인스턴스의 noteQueue에서 Dequue 키워드로 Queue에 담긴 객체를 가져온다
            //t_note.transform.position = tfNoteAppear.position; // 생성된 t_note 에 적절한 값을주고
            //t_note.SetActive(true); // 활성화 시켜줌  
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            theTimingMgr.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // 노트가 화면 밖에서 나갔을 때 파괴되도록
    {
        if (collision.CompareTag("Note"))
        {
            // if(collision.GetComponent<Note>().GetNoteFlag())
            //   theEffectMgr.JudgeMentEffect(4); // 4번째 배열 = 미스

            //theComboMgr.ResetCombo();


            theTimingMgr.MissRecord();
            theTimingMgr.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            //theEffectMgr.JudgeMentEffect(3); // 판정선 지났을때 MISS 띄우기
            //삭제가 아닌 큐에서 비활성화 시키기
            //ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }
    }
}
