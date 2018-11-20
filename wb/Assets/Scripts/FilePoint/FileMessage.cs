using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileMessage{
    
    public float hp;
    public float x;
    public float y;
    public float z;

    public FileMessage(float h){
        hp = h;
    }
    public Dictionary<string, int> OwnProp = new Dictionary<string, int>() {
            { "test" , 1 }
    };
}
