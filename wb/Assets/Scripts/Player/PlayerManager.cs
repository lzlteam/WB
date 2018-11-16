using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;
    private float hp;

    private void Awake()
    {
        instance = this;
    }

    public void Move() { }
    public void HpDown() { }
    public void HpUp() { }

}
