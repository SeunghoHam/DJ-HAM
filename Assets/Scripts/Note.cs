using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400f;

    UnityEngine.UI.Image noteImage;

    // Start is called before the first frame update
    void Start() // �Լ����� Start - > OnEnbale :: ��ü�� Ȱ��ȭ �� ������ ȣ���ϴ� �Լ�
    {
        // ť ����� �� OnEnable �� �Լ� �����ϰ�
        //if(noteImage= null) // ��Ʈ �̹����� �������� ����������
        //    noteImage = GetComponent<UnityEngine.UI.Image>();

        //noteImage.enabled = true; // ��Ʈ�̹����� true �� �ʱ�ȭ

        noteImage = GetComponent<UnityEngine.UI.Image>();
    }

  
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }
    public bool GetNoteFlag()
    {
        return noteImage.enabled; // ��Ʈ�� �̹����� ���̰� ��ȯ
    }
    
}
