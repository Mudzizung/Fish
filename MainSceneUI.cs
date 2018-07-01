/***
  *Title:""��Ŀ
  *Description:
  *		����:
  *Author:D
  *Data:2018.03.18
  *
  *
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneUI : MonoBehaviour
{
    public GameObject settingPanel;


    public void Switch()
    {
        AudioSourcesManager.Instance.SwitchIsMute();
    }

    public void SettingButton()
    {
        settingPanel.SetActive(true);
    }

    public void CloseSettingButton()
    {
        settingPanel.SetActive(false);
    }

    public void BackMain()
    {
        PlayerPrefs.SetInt("gold", GameControl.Instance.goldNum);
        PlayerPrefs.SetInt("lv", GameControl.Instance.LvNum);
        PlayerPrefs.SetFloat("bigTime", GameControl.Instance.bigTimer);
        PlayerPrefs.SetFloat("smallTime", GameControl.Instance.smallTimer);
        PlayerPrefs.SetInt("exp", GameControl.Instance.exp);
        //int temp = AudioSourcesManager.Instance.IsMute == true ? 0 : 1;
        //PlayerPrefs.SetInt("mute", temp);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

