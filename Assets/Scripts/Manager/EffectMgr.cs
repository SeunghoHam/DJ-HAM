using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectMgr : MonoBehaviour
{
    [SerializeField] Animator noteHitAnimator = null;
    string hit = "Hit";

    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementImage= null; // 교체할 이미지 변수
    [SerializeField] Sprite[] judgementSprite = null; // 스프라이트를 담을 변수

    [SerializeField] Animator comboAnimator = null;
    public void JudgeMentEffect(int p_num) // 파라미터 값에 맞는 판정 이미지 스프라이트로 교체한다.
    {
        judgementImage.sprite = judgementSprite[p_num];

        judgementAnimator.SetTrigger(hit); // hit 애니메이터 에 따른 다른 이미지
    }
    public void NoteHitEffect()
    {
        noteHitAnimator.SetTrigger(hit);
    }
    public void comboEffect()
    {
        comboAnimator.SetTrigger(hit);
    }
}
