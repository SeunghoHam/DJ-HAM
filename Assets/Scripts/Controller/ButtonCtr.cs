using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtr : MonoBehaviour
{
    private SpriteRenderer theSpriteRenderer;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public TimingMgr theTimingMgr;

    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            theSpriteRenderer.sprite = pressedImage;
        }
        if(Input.GetKeyUp(keyToPress))
        {
            theSpriteRenderer.sprite = defaultImage;
        }
        
    }
}
