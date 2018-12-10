using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 将这个脚本放到起始点，然后实例化出来的机器人作为他的子对象
/// </summary>

public class RobotManager : MonoBehaviour {
    
    private Robot mrobot;               
    public static RobotManager instance;
    private Animator mAnimator;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 初始化机器人数据，及调用资源加载类生成机器人,加载特效所需的参数
    /// 把机器人模型上的组件获取到控制器上
    /// </summary>
    /// <param name="hp"></param>
    /// <param name="maxhp"></param>
    /// <param name="speed"></param>
    /// <param name="damage"></param>
    /// <param name="name"></param>
    public void Init(float hp, float maxhp, float speed, float damage, string name,string prefab,string particle) {
        mrobot.Init(hp, maxhp, speed, damage, name,prefab,particle);
    }

    /// <summary>
    /// 更新（操控）机器人的行为
    /// </summary>
    private void Update()
    {
        
    }
}
