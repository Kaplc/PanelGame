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
            
        }));
        // 音效拖动条
        sldSound.onChange.Add(new EventDelegate(() =>
        {
            
        }));
        // 音乐单选框
        tgMusic.onChange.Add(new EventDelegate(() =>
        {
            
        }));
        // 音效单选框
        tgSound.onChange.Add(new EventDelegate(() =>
        {
            
        }));
        
        Hide();
    }
}
