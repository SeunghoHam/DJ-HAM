using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboMgr : MonoBehaviour
{
    [SerializeField] GameObject goComboImage = null;
    [SerializeField] UnityEngine.UI.Text textCombo = null;

    int currentCombo = 0;
    int maxCombo = 0;
    // Start is called before the first frame update
    void Start()
    {
        textCombo.gameObject.SetActive(false);
        goComboImage.gameObject.SetActive(false);
    }

    public void IncreaseCombo(int p_num = 1) // �޺� ������ 1�� �⺻���� �Ѵ�
    {
        Debug.Log("���� �޺�  =   "  + currentCombo);
        currentCombo += p_num;
        textCombo.text =  currentCombo.ToString();


        if (maxCombo < currentCombo)
            maxCombo = currentCombo;
        if(currentCombo > 2)
        {
            textCombo.gameObject.SetActive(true);
            goComboImage.gameObject.SetActive(true);
        }
    }
    public int GetCurrentCombo() // ��Ƽ�� ��ȯ
    {
        
        return currentCombo; // ���� �޺����� ��ȯ
    }
    public void ResetCombo()
    {
        currentCombo = 0;
        textCombo.text = "0";
        textCombo.gameObject.SetActive(false);
        goComboImage.gameObject.SetActive(false);
    }

    public int GetMaxCombo()
    {
        return maxCombo;
    }
}
