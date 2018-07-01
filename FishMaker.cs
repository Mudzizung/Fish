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

public class FishMaker : MonoBehaviour
{
    public Transform fishFloder;
    public Transform[] brithPositions;
    public GameObject[] fishPrefabs;


    private void Awake()
    {
        InvokeRepeating("MakeFish", 0, .8f);
    }
    void MakeFish()
    {
        //随机生成鱼的索引
        int finshIndex = Random.Range(0, fishPrefabs.Length);
        //随机一个生成鱼的地点
        int birthPos = Random.Range(0, brithPositions.Length);
        //获取到随机一个生成的鱼的数量
        int birthMaxNumber = fishPrefabs[finshIndex].GetComponent<Fish>().number;
        ////获取到随机一个生成的鱼的移动速度
        int maxSpeed = fishPrefabs[finshIndex].GetComponent<Fish>().moveSpeed;

        int birthNumber = Random.Range((birthMaxNumber / 2) + 1, birthMaxNumber);
        int speed = Random.Range(maxSpeed / 2, maxSpeed);

        //移动方式---------直行或者转弯
        int moveType = Random.Range(0, 2);
        int angleOffSet;   ////直行是的偏转角度
        int angleSpeed;     ///转弯运动时的角速度
        if (moveType == 0)
        {
            angleOffSet = Random.Range(-22, 22);
            StartCoroutine(StraightFish(birthPos, finshIndex, birthNumber, speed, angleOffSet));
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                angleSpeed = Random.Range(-15, -9);
            }
            else
            {
                angleSpeed = Random.Range(9,15);
            }
            StartCoroutine(TurnFish(birthPos, finshIndex, birthNumber, speed, angleSpeed));
        }
    }

    IEnumerator StraightFish(int birthPosIndex,int finshIndex,int num,int speed,int angleOffSet)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject fish = Instantiate(fishPrefabs[finshIndex]);
            fish.transform.SetParent(fishFloder, false);
            fish.transform.localPosition = brithPositions[birthPosIndex].localPosition;
            fish.transform.localRotation = brithPositions[birthPosIndex].localRotation;
            fish.transform.Rotate(0, 0, angleOffSet);
            fish.GetComponent<SpriteRenderer>().sortingOrder += i;
            fish.GetComponent<AutoMove>().speed = speed;
            yield return new WaitForSeconds(.5f);
        }
       
    }
    IEnumerator TurnFish(int birthPosIndex, int finshIndex, int num, int speed, int angleSpeed)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject fish = Instantiate(fishPrefabs[finshIndex]);
            fish.transform.SetParent(fishFloder, false);
            fish.transform.localPosition = brithPositions[birthPosIndex].localPosition;
            fish.transform.localRotation = brithPositions[birthPosIndex].localRotation;
            fish.GetComponent<SpriteRenderer>().sortingOrder += i;
            fish.GetComponent<AutoMove>().speed = speed;
            fish.AddComponent<AutoTurn>().turnSpeed = angleSpeed;
            Destroy(fish, 10);
            yield return new WaitForSeconds(.5f);
        }

    }

}

