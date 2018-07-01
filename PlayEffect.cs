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

public class PlayEffect : MonoBehaviour
{
    public GameObject[] effectPrefabs;

    public void PlayEff()
    {
        foreach (GameObject effect in effectPrefabs)
        {
            Instantiate(effect);
        }
    }
}

