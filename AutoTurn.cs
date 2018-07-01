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

public class AutoTurn : MonoBehaviour
{
    public float turnSpeed = 10f;
    private void Update()
    {
        transform.Rotate(transform.forward, turnSpeed * Time.deltaTime);
    }
}

