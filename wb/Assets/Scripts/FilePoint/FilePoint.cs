using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilePoint : MonoBehaviour {
    /// <summary>
    /// 存档
    /// </summary>
    /// <param name="h"></param>
    public void Save(float h) {
        FileSave fs = new FileSave();
        fs.Save(h);
    }

    /// <summary>
    /// 恢复血量
    /// </summary>
    public void Recover() {
        PlayerManager.instance.HpUp();
    }

    /// <summary>
    /// 读取存档
    /// </summary>
    public void Read() {
        FileSave fs = new FileSave();
        fs.Read();
    }

}
