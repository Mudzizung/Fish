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

public class DestoryGameObject : MonoBehaviour
{
	IEnumerator Start () 
	{
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
	}

}

