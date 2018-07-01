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

public class Bullet : MonoBehaviour
{
    public int speed;
    public int damage;

    public GameObject webPre;//对应生成的网

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fish")
        {
            GameObject web = Instantiate(webPre);
            web.transform.SetParent(gameObject.transform.parent,false);
            web.transform.position = transform.position;
            web.GetComponent<Web>().damage = damage;
            Destroy(gameObject);
            Destroy(web, web.GetComponent<Web>().durationTime);
        }
    }
}

