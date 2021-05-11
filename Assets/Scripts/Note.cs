using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400f;

    UnityEngine.UI.Image noteImage;

    // Start is called before the first frame update
    void Start() // 함수변경 Start - > OnEnbale :: 객체가 활성화 될 때마다 호출하는 함수
    {
        // 큐 사용할 때 OnEnable 로 함수 변경하고
        //if(noteImage= null) // 노트 이미지가 없을때만 가져오도록
        //    noteImage = GetComponent<UnityEngine.UI.Image>();

        //noteImage.enabled = true; // 노트이미지를 true 로 초기화

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
        return noteImage.enabled; // 노트의 이미지를 보이게 반환
    }
    
}
