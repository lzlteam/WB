using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop:MonoBehaviour {

    public string name;
    public bool IsOwn;
    public int allNum;


    public virtual void Use() { }
    public virtual void Add() { }
    public virtual void Dele() { }
    public virtual int GetAllNum() { return allNum;}

}
