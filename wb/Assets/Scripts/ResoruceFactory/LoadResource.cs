using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadResource
{

    public const string m_RobotModelPath = "Charactor/Robot/";
    public const string m_EnemyModelPath = "Charactor/Enemy/";
    public const string m_SpritePath = "Sprite/";
    public const string m_ParticlePath = "Particle/";
    public const string m_AudioClipPath = "AudioClip/";
    public const string m_UIPath = "UI/";
    

    public GameObject LoadRobot(string name)
    {
        return Instantiation(m_RobotModelPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return Instantiation(m_EnemyModelPath + name);
    }

    public Sprite LoadSprite(string name) {

        return Resources.Load(m_SpritePath + name) as Sprite;
    }

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load(m_AudioClipPath + name, typeof(AudioClip)) as AudioClip;
    }

    public GameObject LoadParticle(string name) {
        return Instantiation(m_ParticlePath + name);
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
