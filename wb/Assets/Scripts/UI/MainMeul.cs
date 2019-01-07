using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMeul{

    public GameObject m_meul;

    public void Init() {
        m_meul.SetActive(false);
    }

    public void Show() {
        
        m_meul.SetActive(true);

    }
    public void Hide() {
        m_meul.SetActive(false);
    }

    public void BackGame() { }
    public void ExitGame() { }
    public void ReLoadGame() { }
}
