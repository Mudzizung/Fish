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

public class DiePre : MonoBehaviour
{
    public float duringTime;

    private void Start()
    {
        Destroy(this.gameObject, duringTime);
    }
}

