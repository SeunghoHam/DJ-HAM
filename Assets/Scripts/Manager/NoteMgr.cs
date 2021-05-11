using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMgr : MonoBehaviour
{
    public int bpm = 0; // 1�п� bpm ������ŭ ��Ʈ ����
    double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null; // ��Ʈ�� ������ ��ü
    [SerializeField] GameObject goNote = null; // ��Ʈ �������� ��� �ִ� ��ü

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
            //GameObject t_note = ObjectPool.instance.noteQueue.Dequeue(); // ������ƮǮ�� �ν��Ͻ��� noteQueue���� Dequue Ű����� Queue�� ��� ��ü�� �����´�
            //t_note.transform.position = tfNoteAppear.position; // ������ t_note �� ������ �����ְ�
            //t_note.SetActive(true); // Ȱ��ȭ ������  
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            theTimingMgr.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // ��Ʈ�� ȭ�� �ۿ��� ������ �� �ı��ǵ���
    {
        if (collision.CompareTag("Note"))
        {
            // if(collision.GetComponent<Note>().GetNoteFlag())
            //   theEffectMgr.JudgeMentEffect(4); // 4��° �迭 = �̽�

            //theComboMgr.ResetCombo();


            theTimingMgr.MissRecord();
            theTimingMgr.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            //theEffectMgr.JudgeMentEffect(3); // ������ �������� MISS ����
            //������ �ƴ� ť���� ��Ȱ��ȭ ��Ű��
            //ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }
    }
}
