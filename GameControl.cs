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
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameControl : MonoBehaviour
{

    public GameObject wavePrefab;
    public Image BG;

    public Sprite[] bgs;
    private int bgIndex = 0;

    public GameObject lvPlusEffect;
    public GameObject addGoldEffect;
    public GameObject fireEffect;
    public GameObject changeWeaponEffect;

    public GameObject lvPlusGO;
    public Text lvPlusText;

    public Text LvNumText;
    public Text LvName;
    public Button back;
    public Button set;
    public Text gold;
    public Text bigTime;
    public Button bigTimeButton;
    public Text smallTime;
    public Slider expSlider;


    [HideInInspector]
    public int LvNum = 0;
    private float bigButtondown = 240;
    private float smallButtondown = 60;
    [HideInInspector]
    public float bigTimer;
    [HideInInspector]
    public float smallTimer;


    [HideInInspector]
    public int exp = 0;
    //[HideInInspector]
    public int goldNum = 10000;

    private string[] LvNames = { "塑 料", "废 铁", "青 铜", "白 银", "黄 金", "铂 金", "砖 石", "大 师", "宗 师", "王 者" };

    public Text pricetext;
    public GameObject[] gunGos;
    private int[] gunCosts = { 5, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
    private int count = 0;
    public int Lv = 0;
    public GameObject[] bullet0;
    public GameObject[] bullet1;
    public GameObject[] bullet2;
    public GameObject[] bullet3;
    public GameObject[] bullet4;

    public Transform bulletFlor;

    public Color normal;

    private static GameControl _instance;
    public static GameControl Instance
    {
        get
        {
            return _instance;
        }
       
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        goldNum=PlayerPrefs.GetInt("gold", goldNum);
        LvNum=PlayerPrefs.GetInt("lv", LvNum);
        bigTimer= PlayerPrefs.GetFloat("bigTime",bigTimer);
        smallTimer=PlayerPrefs.GetFloat("smallTime", smallTimer);
        exp=PlayerPrefs.GetInt("exp", exp);
        UpdateUI();
    }

    private void Update()
    {

        Changed();
        BulletToGun();
        UpdateUI();
        ChangeBG();
    }

    void UpdateUI()
    {
        bigButtondown -= Time.deltaTime;
        smallButtondown -= Time.deltaTime * 5;
        if (smallButtondown <= 0)
        {
            smallButtondown = 60;
            goldNum += 100;
        }
        if (bigButtondown <= 0)
        {
            bigTime.gameObject.SetActive(false);
            bigTimeButton.gameObject.SetActive(true);
        }
        while (exp >= 700 + LvNum * 50)
        {
            exp = exp - (700 + LvNum * 50);
            LvNum++;
            AudioSourcesManager.Instance.PlayAudioSound(AudioSourcesManager.Instance.lvPlus);
            Instantiate(lvPlusEffect);
            lvPlusGO.gameObject.SetActive(true);
            lvPlusText.text = LvNum.ToString();
            StartCoroutine(lvPlusGO.GetComponent<LvAddUI>().ShowUI(.9f));
        }
        LvNumText.text = LvNum.ToString();
        if (LvNum >= 99)
        {
            LvNum = 99;
        }
        expSlider.value = (float)exp / (1000 + LvNum * 100);
       // Debug.Log(expSlider.value);

        LvName.text = LvNames[LvNum / 10];
        bigTime.text = (int)bigButtondown + "s";
        smallTime.text = smallButtondown.ToString("0 0");
        gold.text = goldNum.ToString();

    }


    void BulletToGun()
    {
        GameObject[] currentBulletArr = bullet0;
        int bulletIndex;
        if (Input.GetMouseButtonDown(0)&&EventSystem.current.IsPointerOverGameObject()==false)
        {
            AudioSourcesManager.Instance.PlayAudioSound(AudioSourcesManager.Instance.fire);
            switch (count / 4)
            {
                case 0:
                    currentBulletArr = bullet0;
                    break;
                case 1:
                    currentBulletArr = bullet1;
                    break;
                case 2:
                    currentBulletArr = bullet2;
                    break;
                case 3:
                    currentBulletArr = bullet3;
                    break;
                case 4:
                    currentBulletArr = bullet4;
                    break;
            }
            bulletIndex = Lv % 10 > 9 ? 9 : Lv % 10;
            if (goldNum >= gunCosts[count])
            {
                Instantiate(fireEffect, GameObject.Find("firePos").transform.position,Quaternion.identity);
                GameObject bullet = Instantiate(currentBulletArr[bulletIndex]);
                goldNum -= gunCosts[count];
                bullet.transform.SetParent(bulletFlor);
                bullet.transform.position = GameObject.Find("firePos").transform.position;
                bullet.transform.rotation = GameObject.Find("firePos").transform.rotation;
                bullet.GetComponent<Bullet>().damage = gunCosts[count];
                bullet.AddComponent<AutoMove>().dir = Vector3.up;
                bullet.GetComponent<AutoMove>().speed = bullet.GetComponent<Bullet>().speed;
            }
            else
            {
                StartCoroutine(GoldNotEnough());
            }
           
           
        }

    }

    IEnumerator GoldNotEnough()
    {
        gold.color = Color.red;
        yield return new WaitForSeconds(.2f);
        gold.color = normal;
    }
 
    void ChangeBG()
    {
        if (LvNum / 10 != bgIndex)
        {
            GameObject go= Instantiate(wavePrefab);
            //go.GetComponent<>
            bgIndex++;
            BG.sprite = bgs[Random.Range(0,bgs.Length)];

        }
        
    }

    private void Changed()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            AddGun();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ReduceGun();
        }

    }
    public void AddGun()
    {
        gunGos[count / 4].SetActive(false);
        Instantiate(changeWeaponEffect);
        count++;
        count = count > gunCosts.Length-1 ? 0 : count;
        gunGos[count / 4].SetActive(true);
        pricetext.text = "$" + gunCosts[count];
    }
    public void ReduceGun()
    {
        gunGos[count / 4].SetActive(false);
        Instantiate(changeWeaponEffect);
        count++;
        count = count < 0 ? gunCosts.Length - 1 : 0;
        gunGos[count / 4].SetActive(true);
        pricetext.text = "$" + gunCosts[count];
    }
}

