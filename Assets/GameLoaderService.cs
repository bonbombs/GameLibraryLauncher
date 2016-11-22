using UnityEngine;
using System.Collections;
using System.Xml;
using System;

[Serializable]
public class GameLibrary
{
    public GameMetaData[] games;
}

[Serializable]
public class GameMetaData
{
    public string name;
    public string gamePath;
    public string thumbPath;
    public string desc;
}


public class GameLoaderService : Singleton<GameLoaderService> {

    protected GameLoaderService() { } // guarantee this will be always a singleton only - can't use the constructor!

    private GameLibrary m_gameLibrary;

    public GameLibrary gameLibrary { get { return m_gameLibrary; } }

    void Awake ()
    {
        LoadFromJSON("gamelibrary.json");
    }

    private void LoadFromJSON(string path)
    {
        string filePath = path.Replace(".json", "");
        TextAsset targetFile = Resources.Load<TextAsset>(filePath);
        m_gameLibrary = JsonUtility.FromJson<GameLibrary>(targetFile.text);
        Debug.Log(m_gameLibrary.games[0].name);
    }
}

