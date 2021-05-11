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

    public void IncreaseCombo(int p_num = 1) // 콤보 증가량 1을 기본으로 한다
    {
        Debug.Log("현재 콤보  =   "  + currentCombo);
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
    public int GetCurrentCombo() // 인티져 반환
    {
        
        return currentCombo; // 현재 콤보값을 반환
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
