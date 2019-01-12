using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FileSave
{
    //定义存档路径
    static string dirpath = Application.persistentDataPath + "/Save";

    //定义存档文件路径
    static string filename = dirpath + "/GameData.sav";

    public void Save(Robot robot)
    {
        //创建存档文件夹
        IOHelper.CreateDirectory(dirpath);
        FileMessage m = new FileMessage(robot);
        //保存数据
        IOHelper.SetData(filename, m);
    }

    public FileMessage Read()
    {
        //读取数据
        return (FileMessage)IOHelper.GetData(filename, typeof(FileMessage));

    }
}
