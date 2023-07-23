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
    private int icePrice = 50;
    private int firePrice = 50;
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
        if(Statics.time == 0)
        {
            Statics.time = 60;
            Statics.stage += 1;
            
        }
        if (Statics.time > 0)
        {
            Statics.time -= Time.deltaTime;
            timeText2.text = "TIME : " + Mathf.Ceil(Statics.time).ToString();
            timeText1.text = "TIME : " + Mathf.Ceil(Statics.time).ToString();
        }
        stageText1.text = "STAGE : " + Statics.stage.ToString();
        stageText2.text = "STAGE : " + Statics.stage.ToString();

        goldText1.text = "GOLD : " + Statics.gold.ToString();
        goldText2.text = "GOLD : " + Statics.gold.ToString();

        monsterCount.text = "Monster : " + Statics.monsterCount.ToString();
    }
}
