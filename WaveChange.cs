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

public class WaveChange : MonoBehaviour
{
    public Texture[] texture;
    private int index = 0;
    private Material material;
  
    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        InvokeRepeating("ChangeMesh", 0, .1f);
    }

    private void ChangeMesh()
    {
        material.mainTexture = texture[index];
        index = (index + 1) % texture.Length;
    }
}

