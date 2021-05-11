using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{
    TimingMgr theTimingMgr;
    [SerializeField] KeyCode KeyCode;
    // Start is called before the first frame update
    void Start()
    {
        theTimingMgr = FindObjectOfType<TimingMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        // 키코드 맞춰서 ( D F J K )
        if(Input.GetKeyDown(KeyCode))
        {
            theTimingMgr.CheckTiming();
        } 
    }
}
