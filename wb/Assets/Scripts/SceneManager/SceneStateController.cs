using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController{
    private ISceneState mState;
    private AsyncOperation mAO;//异步加载场景
    private bool mIsRunStart = false;//是否启动当前状态,主要是判断场景是否加载完毕

    public void SetState(ISceneState state, bool isLoadScene) {
        if (mState != null)
        {
            mState.StateEnd();//让上一个场景状态做一下清理工作
        }
        mState = state;
        if (isLoadScene)
        {
            mAO = SceneManager.LoadSceneAsync(mState.getName());
            //Debug.Log("1");
            mIsRunStart = false;
        }
        else
        {
            mState.StateStart();//启动当前状态的初始化操作
            mIsRunStart = true;
        }

    } //设置场景状态，加载场景，清理上一个场景等操作



    public void StateUpdate() {
        if (mAO != null && mAO.isDone == false) return;//当前场景正在加载但是没有完成,直接返回

        if (mIsRunStart == false && mAO != null && mAO.isDone == true)//同样判断当前场景是否加载完,但是需要跳过初始场景
        {
            mState.StateStart();
            mIsRunStart = true;
        }

        if (mState != null)
        {
            mState.StateUpdate();
        }
    } //更新场景，当场景加载完毕时，启动初始化方法，初始化场景
}
