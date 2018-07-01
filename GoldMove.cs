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

public class GoldMove : MonoBehaviour
{
    private GameObject goldCollect;

    private void Start()
    {
        goldCollect = GameObject.Find("GoldCollect");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goldCollect.transform.position, 100 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GoldCollect")
        {
            Destroy(gameObject);
        }
    }
}

