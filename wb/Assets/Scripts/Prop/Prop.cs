using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop:MonoBehaviour {

    private string name;
    private bool IsOwn;
    private int allNum;


    public virtual void Use() { }
    public virtual void Add() { }
    public virtual void Dele() { }
    public virtual int GetAllNum() { return allNum;}

}
