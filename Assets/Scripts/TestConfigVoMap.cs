﻿using UnityEngine;
using System.Collections;
using NsLib.Config;

public class TestConfigVoMap : MonoBehaviour {

    private float m_StartTime = 0f;
    private void OnReadEnd(IConfigVoMap<string> map) {
        float delta = Time.realtimeSinceStartup - m_StartTime;
        Debug.LogFormat("异步读取完成消耗：{0}", delta.ToString());
    }

    private void OnGUI() {

        if (GUI.Button(new Rect(100, 100, 150, 50), "加载全部")) {
            TextAsset asset = Resources.Load<TextAsset>("TaskStepCfg_Binary");
            if (asset != null) {
                ConfigVoMapMap<string, string, TaskStepVO> maps = new ConfigVoMapMap<string, string, TaskStepVO>();
                maps.LoadFromTextAsset(asset, true);
            }
        }

        if (GUI.Button(new Rect(250, 100, 150, 50), "加载索引")) {
            TextAsset asset = Resources.Load<TextAsset>("TaskStepCfg_Binary");
            if (asset != null) {
                ConfigVoMapMap<string, string, TaskStepVO> maps = new ConfigVoMapMap<string, string, TaskStepVO>();
                maps.LoadFromTextAsset(asset, false);
            }
        }

        if (GUI.Button(new Rect(400, 100, 150, 50), "预加载")) {
            TextAsset asset = Resources.Load<TextAsset>("TaskStepCfg_Binary");
            if (asset != null) {

                ConfigVoMapMap<string, string, TaskStepVO> maps = new ConfigVoMapMap<string, string, TaskStepVO>();
                m_StartTime = Time.realtimeSinceStartup;
                maps.Preload(asset, this, OnReadEnd, null);
            }
        }
    }
}