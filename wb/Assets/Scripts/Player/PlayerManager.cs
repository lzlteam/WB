using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager instance;
    private float hp;

    private void Awake()
    {
        instance = this;
        hp = 100;
    }

    public void Move() { }

    public float GetHp() {
        return hp;
    }
    public void HpDown() { }
    public void HpUp() { }

    

}
