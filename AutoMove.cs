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

public class AutoMove : MonoBehaviour
{
    [HideInInspector]
    public int speed = 1;
    [HideInInspector]
    public Vector3 dir = Vector3.right;
	void Update () 
	{
        transform.Translate(dir*speed*Time.deltaTime);
	}
}

