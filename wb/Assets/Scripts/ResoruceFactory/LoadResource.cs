using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadResource
{

    public const string mRobotModelPath = "Charactor/Robot/";
    public const string mEnemyModelPath = "Charactor/Enemy/";
    public const string mSpritePath = "Sprite/";
    public const string mParticlePath = "Particle/";
    public const string mAudioClipPath = "AudioClip/";
    public const string mUIPath = "UI/";
    

    public GameObject LoadRobot(string name)
    {
        return Instantiation(mRobotModelPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return Instantiation(mEnemyModelPath + name);
    }

    public Sprite LoadSprite(string name) {

        return Resources.Load(mSpritePath + name) as Sprite;
    }

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load(mAudioClipPath + name, typeof(AudioClip)) as AudioClip;
    }

    public GameObject LoadParticle(string name) {
        return Instantiation(mParticlePath + name);
    }

    /// <summary>
    /// 加载需要实例化的对象
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private GameObject Instantiation(string path) {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null) {
            Debug.LogError("无法加载资源，路径:" + path);
            return null;
        }
        return UnityEngine.GameObject.Instantiate(o) as GameObject;
    }


    /// <summary>
    /// 加载不需要实例化的对象
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private UnityEngine.Object LoadAsset(string path) {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null){
            Debug.LogError("无法加载资源，路径:" + path);
            return null;
        }
        return o;
    }
}
