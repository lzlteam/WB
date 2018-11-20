using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FileSave
{
    //定义存档路径
    static string dirpath = Application.persistentDataPath + "/Save";

    //定义存档文件路径
    static string filename = dirpath + "/GameData.sav";

    public void Save(float h){
        //创建存档文件夹
        IOHelper.CreateDirectory(dirpath);
        FileMessage m = new FileMessage(h);
        //保存数据
        IOHelper.SetData(filename, m);
    }

    public void Read() {
        //读取数据
        FileMessage m1 = (FileMessage)IOHelper.GetData(filename, typeof(FileMessage));
        Debug.Log(m1.hp);
        Debug.Log(m1.OwnProp["test"]);
    }
}