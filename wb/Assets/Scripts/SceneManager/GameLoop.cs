using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

    private SceneStateController controller = null;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);//这样加载新场景的时候，放到一个不释放的名称下面
    }

    // Use this for initialization
    void Start()
    {
        Invoke("ScenesStart", 0.5f);
    }
    private void ScenesStart()
    {
        controller = new SceneStateController();
        controller.SetState(new StartState(controller), false);
    }
    // Update is called once per frame
    void Update()
    {
        if (controller != null)
            controller.StateUpdate();
    }
}
