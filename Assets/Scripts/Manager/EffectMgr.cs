using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectMgr : MonoBehaviour
{
    [SerializeField] Animator noteHitAnimator = null;
    string hit = "Hit";

    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementImage= null; // ��ü�� �̹��� ����
    [SerializeField] Sprite[] judgementSprite = null; // ��������Ʈ�� ���� ����

    [SerializeField] Animator comboAnimator = null;
    public void JudgeMentEffect(int p_num) // �Ķ���� ���� �´� ���� �̹��� ��������Ʈ�� ��ü�Ѵ�.
    {
        judgementImage.sprite = judgementSprite[p_num];

        judgementAnimator.SetTrigger(hit); // hit �ִϸ����� �� ���� �ٸ� �̹���
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
