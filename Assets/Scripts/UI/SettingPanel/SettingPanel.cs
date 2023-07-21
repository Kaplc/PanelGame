using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BasePanel<SettingPanel>
{
    public UIButton btnClose;
    public UISlider sldMusic;
    public UISlider sldSound;
    public UIToggle tgMusic;
    public UIToggle tgSound;
    
    public override void Init()
    {
        // 关闭按钮
        btnClose.onClick.Add(new EventDelegate(() =>
        {
            Hide();
        }));
        // 音乐拖动条
        sldMusic.onChange.Add(new EventDelegate(() =>
        {
            if (sldMusic.value <= 0.005f)
            {
                sldMusic.value = 0.005f;
            }
            Music.Instance.ChangeMusicVolume(sldMusic.value);
            GameDataMgr.Instance.ChangeMusicVolume(sldMusic.value);
        }));
        // 音效拖动条
        sldSound.onChange.Add(new EventDelegate(() =>
        {
            if (sldSound.value <= 0.005f)
            {
                sldSound.value = 0.005f;
            }
            GameDataMgr.Instance.ChangeSoundVolume(sldSound.value);
        }));
        // 音乐单选框
        tgMusic.onChange.Add(new EventDelegate(() =>
        {
            Music.Instance.ChangeMusicOpen(tgMusic.value);
            GameDataMgr.Instance.ChangeMusicOpen(tgMusic.value);
        }));
        // 音效单选框
        tgSound.onChange.Add(new EventDelegate(() =>
        {
            GameDataMgr.Instance.ChangeSoundOpen(tgSound.value);
        }));
        
        Hide();
    }

    public override void Show()
    {
        base.Show();
        // 用读取的数据初始化
        MusicData musicData = GameDataMgr.Instance.musicData;
        sldMusic.value = musicData.musicVolume;
        sldSound.value = musicData.soundVolume;
        tgMusic.value = musicData.musicOpen;
        tgSound.value = musicData.soundOpen;
    }

    public override void Hide()
    {
        base.Hide();
        // 保存数据
        GameDataMgr.Instance.SaveMusicData();
    }
}
