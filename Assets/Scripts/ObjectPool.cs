using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo
{
    public GameObject goPrefab;
    public int count;
    public Transform tfPoolParent;
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField] ObjectInfo[] objectInfo = null;

    public static ObjectPool instance;
    public Queue<GameObject> noteQueue = new Queue<GameObject>(); // Queue = 선입선출 자료형 
   
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        noteQueue = InsertQueue(objectInfo[0]); // 반환한 Queue값을 noteQueue에 넣는다.
    }

    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo) // Queue를 리턴시키는 함수 파라미터로 오브젝트 정보를 받는다
    {
        Queue<GameObject> t_queue = new Queue<GameObject>(); // 임시 Queue 게임 오브젝트로 생성

        for (int i = 0; i < p_objectInfo.count; i++) // 오브젝트의 갯수만큼 반복문 돌기
        {
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab, transform.position, Quaternion.identity); // 프리팹 생성(노트). 필요할때마다 위치정보를 주는식으로. 비활성화시켜놔서 안보임
            t_clone.SetActive(false);

            // 이전 노트는 노트 매니저 스크립트가 붙어있는 노트매니저가 부모였다.
            if (p_objectInfo.tfPoolParent != null) // 부모 객체가 존재한다면 그 
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent);
            else // 부모 객체가 존재하지 않다면 이 스크립트가 붙어있는 객체를 부모로 한다.
                t_clone.transform.SetParent(this.transform);

            t_queue.Enqueue(t_clone); // 생성한 객체를 Queue에 넣는다
        }
        // 반복문을 다 돈다면 Queue 에는 카운트 갯수만큼의 객체가 들어있다.


        return t_queue; // 이 Queue를 리턴시킨다.
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
