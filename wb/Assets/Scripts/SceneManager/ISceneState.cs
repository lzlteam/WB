using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISceneState{

    private string mSceneName;
    protected SceneStateController mController;

    public ISceneState(string stateName, SceneStateController controller) {
        mSceneName = stateName;
        mController = controller;
    } //构造函数


    public string getName() {
        return mSceneName;
    }
    public virtual void StateStart() { }    //初始化场景(一些数据，对象等)
    public virtual void StateUpdate() { } //更新场景
    public virtual void StateEnd() { }      //清理场景，保存数据等


}
