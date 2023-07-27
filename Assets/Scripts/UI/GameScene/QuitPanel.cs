using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public UIButton btnSure;
    public UIButton btnCancel;
    public override void Init()
    {
        btnSure.onClick.Add(new EventDelegate(() =>
        {
            Hide();
            SceneManager.LoadScene("BeginScenes");
        }));
        btnCancel.onClick.Add(new EventDelegate(() =>
        {
            Hide();
            Time.timeScale = 1;
        }));
        Hide();
    }
}
