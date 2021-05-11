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
    public Queue<GameObject> noteQueue = new Queue<GameObject>(); // Queue = ���Լ��� �ڷ��� 
   
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        noteQueue = InsertQueue(objectInfo[0]); // ��ȯ�� Queue���� noteQueue�� �ִ´�.
    }

    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo) // Queue�� ���Ͻ�Ű�� �Լ� �Ķ���ͷ� ������Ʈ ������ �޴´�
    {
        Queue<GameObject> t_queue = new Queue<GameObject>(); // �ӽ� Queue ���� ������Ʈ�� ����

        for (int i = 0; i < p_objectInfo.count; i++) // ������Ʈ�� ������ŭ �ݺ��� ����
        {
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab, transform.position, Quaternion.identity); // ������ ����(��Ʈ). �ʿ��Ҷ����� ��ġ������ �ִ½�����. ��Ȱ��ȭ���ѳ��� �Ⱥ���
            t_clone.SetActive(false);

            // ���� ��Ʈ�� ��Ʈ �Ŵ��� ��ũ��Ʈ�� �پ��ִ� ��Ʈ�Ŵ����� �θ𿴴�.
            if (p_objectInfo.tfPoolParent != null) // �θ� ��ü�� �����Ѵٸ� �� 
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent);
            else // �θ� ��ü�� �������� �ʴٸ� �� ��ũ��Ʈ�� �پ��ִ� ��ü�� �θ�� �Ѵ�.
                t_clone.transform.SetParent(this.transform);

            t_queue.Enqueue(t_clone); // ������ ��ü�� Queue�� �ִ´�
        }
        // �ݺ����� �� ���ٸ� Queue ���� ī��Ʈ ������ŭ�� ��ü�� ����ִ�.


        return t_queue; // �� Queue�� ���Ͻ�Ų��.
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
