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
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadNewScene()
    {
        PlayerPrefs.DeleteKey("gold");
        PlayerPrefs.DeleteKey("lv");
        PlayerPrefs.DeleteKey("bigTime");
        PlayerPrefs.DeleteKey("smallTime");
        PlayerPrefs.DeleteKey("exp");
        SceneManager.LoadScene(1);
    }

    public void LoadOldScene()
    {
        SceneManager.LoadScene(1);

    }
}

