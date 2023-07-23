using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePanel : BasePanel<ChoosePanel>
{
    public UIButton btnClose;
    public UIButton btnLeft;
    public UIButton btnRight;
    public UIButton btnStart;
    public List<UISprite> hp;
    public List<UISprite> speed;
    public List<UISprite> volume;

    public Transform modelPos;
    public PlaneInfo planeInfo; // 当前模型信息
    public GameObject planeModel; // 当前模型

    private float time = 0;
    private bool isSel = false;
    public Camera uiCamera;

    public override void Init()
    {
        btnClose.onClick.Add(new EventDelegate(() =>
        {
            Hide();
            BeginPanel.Instance.Show();
        }));
        // 左
        btnLeft.onClick.Add(new EventDelegate(() =>
        {
            // 修改模型索引
            --GameDataMgr.Instance.modelIndex;
            if (GameDataMgr.Instance.modelIndex < 0)
            {
                GameDataMgr.Instance.modelIndex = GameDataMgr.Instance.planeData.planeInfos.Count - 1;
            }

            ShowModel();
        }));
        // 右
        btnRight.onClick.Add(new EventDelegate(() =>
        {
            ++GameDataMgr.Instance.modelIndex;
            if (GameDataMgr.Instance.modelIndex > GameDataMgr.Instance.planeData.planeInfos.Count - 1)
            {
                GameDataMgr.Instance.modelIndex = 0;
            }

            ShowModel();
        }));
        btnStart.onClick.Add(new EventDelegate(() =>
        {
            SceneManager.LoadScene("GameScenes");
        }));


        Hide();
    }

    public override void Show()
    {
        base.Show();
        ShowModel();
    }

    public void ShowModel()
    {
        // 删除上一次记录
        Destroy(this.planeModel);
        for (int i = 0; i < 10; i++)
        {
            hp[i].gameObject.SetActive(false);
            speed[i].gameObject.SetActive(false);
            volume[i].gameObject.SetActive(false);
        }

        planeInfo = GameDataMgr.Instance.GetModelInfo();
        GameObject planeModel = Instantiate(Resources.Load<GameObject>(planeInfo.resPath));
        planeModel.transform.SetParent(modelPos);
        planeModel.transform.localPosition = Vector3.zero;
        planeModel.transform.localRotation = Quaternion.identity;
        planeModel.transform.localScale = Vector3.one * planeInfo.scale;
        this.planeModel = planeModel;

        // 显示属性
        for (int i = 0; i < planeInfo.hp; i++)
        {
            hp[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < planeInfo.speed; i++)
        {
            speed[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < planeInfo.volume; i++)
        {
            volume[i].gameObject.SetActive(true);
        }
    }


    private void Update()
    {
        // 模型上下浮动
        time += Time.deltaTime;
        planeModel.transform.Translate(Vector3.up * (Mathf.Sin(time) * 0.0005f), Space.World);

        #region 实现拖动旋转模型

        if (Input.GetMouseButtonDown(0))
        {
            //按下鼠标
            // 发送射线碰撞到物体返回true
            if (Physics.Raycast(uiCamera.ScreenPointToRay(Input.mousePosition), 1000, 1 << LayerMask.NameToLayer("UI")))
            {
                isSel = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSel = false;
        }

        // 长按鼠标旋转
        if (isSel && Input.GetMouseButton(0))
        {
            modelPos.transform.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 5.0f, Vector3.up);
        }

        #endregion
    }
}