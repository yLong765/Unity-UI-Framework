﻿using UnityEngine;
using UnityEngine.UI;

public class SceneLogin : SceneBase {

    private InputField playerName;
    private Text warnText;

    protected override void InitDate()
    {
        //初始化皮肤
        setSkinPath("UI/Scene/" + SceneType.SceneLogin.ToString());
    }

    protected override void InitViewDate()
    {
        //绑定界面UI
        playerName = skin.transform.Find("loginBackground/playerName").GetComponent<InputField>();
        warnText = skin.transform.Find("warnText").GetComponent<Text>();
    }

    protected override void onClick(GameObject BtObject)
    {
        if (BtObject.name.Equals("BtGameStart"))
        {
            string name = playerName.text;
            if (NameChick(name))
            {
                SceneMgr.Instance.Sequencer(SceneType.SceneMain, name);
            }
            else
            {
                warnText.text += "不符合规范";
                warnText.gameObject.SetActive(true);
            }                
        }
    }

    protected override void resEvent(object[] message)
    {
        Debug.Log("Login: " + message[0]);
    }

    private bool NameChick(string name)
    {
        //正则表达式

        if (name == null) return false;
        if (name.Equals("/0")) return false;
        if (name.Length < 0 || name.Length > 10) return false;

        return true;
    }

}
