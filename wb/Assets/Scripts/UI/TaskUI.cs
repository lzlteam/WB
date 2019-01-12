using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI{

    public GameObject m_TaskUI;

    private Image m_image;
    private Text m_text;

    /// <summary>
    /// 初始化任务UI
    /// </summary>
    public void Init()
    {
        m_image = m_TaskUI.GetComponentInChildren<Image>();
        m_text = m_TaskUI.GetComponentInChildren<Text>();

        m_text.text = "測試\n任務一";
        
    }

}
