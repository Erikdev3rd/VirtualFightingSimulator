using UnityEngine;
using System;
using System.IO;

class SaveLoad
{
    public static void SaveData(int _waveNumber, string _file)
    {
        string path = Application.dataPath + @"\Textfiles" + _file;
        // Create a file to write to.
        string createText = _waveNumber + Environment.NewLine;
        File.WriteAllText(path, createText);
    }

    public static int Load(string _file)
    {
        string path = Application.dataPath + @"\Textfiles" + _file;
        // Open the file to read from.
        int readText = Int32.Parse(File.ReadAllText(path));
        return readText;
    }
}
