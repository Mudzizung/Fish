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

public class Fish : MonoBehaviour
{
    public int exp;
    public int goldNum;

    public GameObject goldPrefab;

    public int moveSpeed;
    public int number;
    public int hp;

    public GameObject diePre;
    void TakeDanage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            GameControl.Instance.exp += exp;
            GameControl.Instance.goldNum += goldNum;
            AudioSourcesManager.Instance.PlayAudioSound(AudioSourcesManager.Instance.getGold);
            GameObject die = Instantiate(diePre);
            die.transform.SetParent(transform.parent,false);
            die.transform.position = transform.position;
            die.transform.rotation = transform.rotation;
            if (gameObject.GetComponent<PlayEffect>() != null)
            {
                gameObject.GetComponent<PlayEffect>().PlayEff();
            }
            GameObject goldGO = Instantiate(goldPrefab);
            goldGO.transform.SetParent(transform.parent, false);
            goldGO.transform.position = transform.position;
            goldGO.transform.rotation = transform.rotation;
            Destroy(gameObject);

        }
    }
}

