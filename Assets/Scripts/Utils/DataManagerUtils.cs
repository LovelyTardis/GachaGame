using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;
using System;

public static class DataManagerUtils 
{
    /// <summary>
    /// Returns a GameSettings Class
    /// </summary>
    /// <param name="path">path of the file</param>
    /// <returns></returns>
    public static T LoadFile<T>(string path)
    {
        if (File.Exists(Application.persistentDataPath + path))
        {
            //After knowing the file exists, we open the file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);
            T data = (T)bf.Deserialize(file);
            file.Close();
            //And we load our data
            return data;
        }
        return default;
    }
    /// <summary>
    /// Serialize the GameSettings Values to .dat file and Create the file on the path
    /// </summary>
    /// <param name="gameSettings">Data to save</param>
    /// <param name="path">path of the file</param>
    public static void SaveFile<T>(T data, string path)
    {
        //We create the file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + path);

        //We Serialize the file and close the document
        bf.Serialize(file,data);
        file.Close();
    }
}
