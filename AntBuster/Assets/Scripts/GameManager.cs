using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header ("Camera")]
    public GameObject subCamera;
    [Header ("1")]
    public TMP_Text iceTower;
    public TMP_Text fireTower;
    public TMP_Text icePriceText;
    public TMP_Text firePriceText;
    public TMP_Text timeText2;
    public TMP_Text stageText2;
    public TMP_Text goldText2;
    public TMP_Text lifeText;
    private int icePrice = 100;
    private int firePrice = 100;
    [Header("2")]
    public TMP_Text timeText1;
    public TMP_Text stageText1;
    public TMP_Text goldText1;
    public TMP_Text monsterCount;

    // Start is called before the first frame update
    void Start()
    {
        subCamera.SetActive(false);
        iceTower.text = "IceTower";
        fireTower.text = "fireTower";
        icePriceText.text = "Price : " + icePrice;
        firePriceText.text = "Price : " + firePrice;
    }
    
    // Update is called once per frame
    void Update()
    {
        Statics.time -= Time.deltaTime;
        if (Statics.time <= 0)
        {//타임이 0보다 작아져서 다음스테이지로 넘어가야할때
            Debug.Log("초기화가 됐니?");
            MonSpawner.instance.monCount = 0;
            Statics.time = 99;
            Statics.stage += 1;
            Statics.life -= Statics.monsterCount;
            Statics.monsterCount = 0;
            Statics.MaxHp *= 1.1f;
            foreach (GameObject activeObject in MonSpawner.instance.Rest)
            {//instance.Rest의 있는 오브젝트 activeObject
                if (activeObject.activeSelf)
                {//만약 오브젝트가 아직 죽지않고 활성화된상태라면
                    activeObject.SetActive(false);
                    //비활성화시키고
                    activeObject.transform.rotation = Quaternion.Euler(Vector3.zero);
                    //로테이션값을 원래대로 돌리고
                    Rigidbody rb = activeObject.GetComponent<Rigidbody>();
                    rb.velocity = Vector3.forward* 10;
                    //벡터값을 원래대로 돌리고
                    MonSpawner.instance.InsertQueue(activeObject);
                    //다시 큐에 집어넣는다.
                }
            }
        }
        if (Statics.time > 0)
        {
            timeText2.text = "TIME : " + Mathf.Ceil(Statics.time).ToString();
            timeText1.text = "TIME : " + Mathf.Ceil(Statics.time).ToString();
        }
        stageText1.text = "STAGE : " + Statics.stage.ToString();
        stageText2.text = "STAGE : " + Statics.stage.ToString();

        goldText1.text = "GOLD : " + Statics.gold.ToString();
        goldText2.text = "GOLD : " + Statics.gold.ToString();

        lifeText.text = "LIFE : " + Statics.life.ToString();
        monsterCount.text = "Monster : " + Statics.monsterCount.ToString();
    }
}
