using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsUI{

    public GameObject m_TipsUI;

    private Text m_Text;
    

    /// <summary>
    /// 初始化提示UI
    /// </summary>
    public void Init() {
        m_Text = m_TipsUI.GetComponentInChildren<Text>();
        m_Text.text = "";
    }
	
}
