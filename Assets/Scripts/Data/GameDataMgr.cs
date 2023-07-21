using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    public MusicData musicData;
    
    private GameDataMgr()
    {
        // 初始化读取数据
        musicData = XmlDataManager.Instance.Load(typeof(MusicData), "musicData.xml") as MusicData;
    }

    public void SaveMusicData()
    {
        XmlDataManager.Instance.Save(musicData, "musicData.xml");
    }

    #region 音效修改
    // 音乐开关
    public void ChangeMusicOpen(bool isOpen)
    {
        musicData.musicOpen = isOpen;
    }
    // 音效开关
    public void ChangeSoundOpen(bool isOpen)
    {
        musicData.soundOpen = isOpen;
    }
    // 音乐大小
    public void ChangeMusicVolume(float volume)
    {
        musicData.musicVolume = volume;
    }
    // 音效大小
    public void ChangeSoundVolume(float volume)
    {
        musicData.soundVolume = volume;
    }

    #endregion
    
}