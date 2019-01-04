using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioController : GameManager
{

    private AudioClip m_BackGroundMusic;
    private List<AudioClip> m_AudioClip;

    public static MainAudioController instance;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 初始化音频，将音频片段加载进来,然后加入到音频列表里面
    /// </summary>
    public void Init() {
        //mBackGroundMusic = LoadResource.instance.LoadAudioClip("BackGroundMusic");
    }

    /// <summary>
    /// 根据name，判断需要获取的音频片段
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public AudioClip GetAudioClip(string name) {

        return m_AudioClip[0];
    }

}
