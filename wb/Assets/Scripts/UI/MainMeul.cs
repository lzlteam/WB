﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMeul : MonoBehaviour {

    public GameObject m_meul;

    public void Init() {
        m_meul.SetActive(false);
    }

    public void Show() { }
    public void Hide() { }

    public void BackGame() { }
    public void ExitGame() { }
    public void ReLoadGame() { }
}
