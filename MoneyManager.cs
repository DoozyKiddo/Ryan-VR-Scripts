using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MoneyManager : MonoBehaviour
{

    public static MoneyManager instance;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI spawnText1;
    public TextMeshProUGUI spawnText2;
    public TextMeshProUGUI spawnText3;
    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI upgradeCostText;
    public GameObject upgradeButton;
    public GameObject spawnButton1;
    public GameObject spawnButton2;
    public GameObject spawnButton3;
    public GameObject resetButton;
    public Image upgradeBorder;
    public Image resetBorder;
    public Image spawnBorder1;
    public Image spawnBorder2;
    public Image spawnBorder3;
    public Image cooldown1;
    public Image cooldown2;
    public Image cooldown3;

    public bool didUpgrade = false;
    public int didUpgradeTime = 0;
    public bool cannotUpgrade = false;
    public int cannotUpgradeTime = 0;

    public bool didSpawn1 = false;
    public int didSpawn1Time = 0;
    public bool cannotSpawn1 = false;
    public int cannotSpawn1Time = 0;

    public bool didSpawn2 = false;
    public int didSpawn2Time = 0;
    public bool cannotSpawn2 = false;
    public int cannotSpawn2Time = 0;

    public bool didSpawn3 = false;
    public int didSpawn3Time = 0;
    public bool cannotSpawn3 = false;
    public int cannotSpawn3Time = 0;

    public float floatMoney = 0.0f;
    public float income = 0.3f;
    int money = 0;
    public int maxMoney = 1000;
    public int level = 1;

    public int spawnCost1 = 100;
    public int spawnCost2 = 500;
    public int spawnCost3 = 1500;
    public int upgradeCost = 300;

    public int spawnCooldown1 = 100;
    public int spawnCooldown2 = 250;
    public int spawnCooldown3 = 500;

    public EventSystem eventSystem;

    private void Awake()
    {
        instance = this;
        moneyText = GetComponent<TextMeshProUGUI>();
        upgradeCostText.outlineWidth = 0.25f;
        spawnText1.outlineWidth = 0.25f;
        spawnText2.outlineWidth = 0.25f;
        spawnText3.outlineWidth = 0.25f;
        spawnBorder1.color = Color.black;
        spawnBorder2.color = Color.black;
        spawnBorder3.color = Color.black;
        upgradeBorder.color = Color.black;
        resetBorder.color = Color.black;
        eventSystem = EventSystem.current;
        cooldown1.fillAmount = 0f;
        cooldown2.fillAmount = 0f;
        cooldown3.fillAmount = 0f;
    }
    /*
    public void did(boolean did, int time, Image border)
    {
        if (did)
        {
            if (time >= 24)
            {
                border.color = Color.black;
                did = false;
                time = 0;
            }
            else if ((7 >= time && time >= 0) || (23 >= time && time >= 16))
            {
                border.color = new Color(38f / 255f, 141f / 255f, 38f / 255f, 1f);
                time++;
            }
            else if (15 >= time && time >= 8)
            {
                border.color = Color.black;
                time++;
            }
            else
            {
                time++;
            }
        }
    }*/

    // FixedUpdate called once every 0.02 seconds
    public void FixedUpdate()
    {
        // control money rate by changing how much floatMoney increases by here
        if (money < maxMoney)
            floatMoney += income;
        money = (int)Mathf.Floor(floatMoney);
        moneyText.text = money.ToString() + " / " + maxMoney.ToString();
        levelText.text = "Snow Bank Level: " + level + " / 5";

        if (level >= 5)
        {
            upgradeText.text = "Bank Fully Upgraded!";
            upgradeBorder.color = Color.gray;
            upgradeCostText.text = "";
        }
        else if (upgradeCost <= money)
        {
            upgradeCostText.text = "" + upgradeCost;
            levelText.text += "\nCan upgrade!";
        }
        else
        {
            upgradeCostText.text = "" + upgradeCost;
        }

        if (eventSystem.currentSelectedGameObject == upgradeButton)
        {
            upgradeBorder.color = new Color(0f, 204f / 255f, 204f / 255f, 1f);
            spawnBorder1.color = Color.black;
            spawnBorder2.color = Color.black;
            spawnBorder3.color = Color.black;
            resetBorder.color = Color.black;
        }
        else if (eventSystem.currentSelectedGameObject == spawnButton1)
        {
            spawnBorder1.color = new Color(0f, 204f / 255f, 204f / 255f, 1f);
            upgradeBorder.color = Color.black;
            spawnBorder2.color = Color.black;
            spawnBorder3.color = Color.black;
            resetBorder.color = Color.black;
        }
        else if (eventSystem.currentSelectedGameObject == spawnButton2)
        {
            spawnBorder2.color = new Color(0f, 204f / 255f, 204f / 255f, 1f);
            spawnBorder1.color = Color.black;
            upgradeBorder.color = Color.black;
            spawnBorder3.color = Color.black;
            resetBorder.color = Color.black;
        }
        else if (eventSystem.currentSelectedGameObject == spawnButton3)
        {
            spawnBorder3.color = new Color(0f, 204f / 255f, 204f / 255f, 1f);
            spawnBorder1.color = Color.black;
            spawnBorder2.color = Color.black;
            upgradeBorder.color = Color.black;
            resetBorder.color = Color.black;
        }
        else if (eventSystem.currentSelectedGameObject == resetButton)
        {
            resetBorder.color = new Color(0f, 204f / 255f, 204f / 255f, 1f);
            spawnBorder1.color = Color.black;
            spawnBorder2.color = Color.black;
            spawnBorder3.color = Color.black;
            upgradeBorder.color = Color.black;
        }

        if (didUpgrade)
        {
            if (didUpgradeTime >= 24)
            {
                upgradeBorder.color = Color.black;
                didUpgrade = false;
                didUpgradeTime = 0;
            }
            else if ((7 >= didUpgradeTime && didUpgradeTime >= 0) || (23 >= didUpgradeTime && didUpgradeTime >= 16))
            {
                upgradeBorder.color = new Color(38f / 255f, 141f / 255f, 38f / 255f, 1f);
                didUpgradeTime++;
            }
            else if (15 >= didUpgradeTime && didUpgradeTime >= 8)
            {
                upgradeBorder.color = Color.black;
                didUpgradeTime++;
            }
            else
            {
                didUpgradeTime++;
            }
        }

        if (didSpawn1)
        {
            if (didSpawn1Time == 0)
            {
                cooldown1.fillAmount = 1f;
            }
            if (didSpawn1Time >= spawnCooldown1)
            {
                spawnBorder1.color = Color.black;
                didSpawn1 = false;
                didSpawn1Time = 0;
            }
            else if (didSpawn1Time >= 24 || (15 >= didSpawn1Time && didSpawn1Time >= 8))
            {
                spawnBorder1.color = Color.gray;
                didSpawn1Time++;
                cooldown1.fillAmount -= 1f / spawnCooldown1;
            }
            else if ((7 >= didSpawn1Time && didSpawn1Time >= 0) || (23 >= didSpawn1Time && didSpawn1Time >= 16))
            {
                spawnBorder1.color = new Color(38f / 255f, 141f / 255f, 38f / 255f, 1f);
                didSpawn1Time++;
                cooldown1.fillAmount -= 1f / spawnCooldown1;
            }
        }

        if (didSpawn2)
        {
            if (didSpawn2Time == 0)
            {
                cooldown2.fillAmount = 1f;
            }
            if (didSpawn2Time >= spawnCooldown2)
            {
                spawnBorder2.color = Color.black;
                didSpawn2 = false;
                didSpawn2Time = 0;
            }
            else if (didSpawn2Time >= 24 || (15 >= didSpawn2Time && didSpawn2Time >= 8))
            {
                spawnBorder2.color = Color.gray;
                didSpawn2Time++;
                cooldown2.fillAmount -= 1f / spawnCooldown2;
            }
            else if ((7 >= didSpawn2Time && didSpawn2Time >= 0) || (23 >= didSpawn2Time && didSpawn2Time >= 16))
            {
                spawnBorder2.color = new Color(38f / 255f, 141f / 255f, 38f / 255f, 1f);
                didSpawn2Time++;
                cooldown2.fillAmount -= 1f / spawnCooldown2;
            }
        }

        if (didSpawn3)
        {
            if (didSpawn3Time == 0)
            {
                cooldown3.fillAmount = 1f;
            }
            if (didSpawn3Time >= spawnCooldown3)
            {
                spawnBorder3.color = Color.black;
                didSpawn3 = false;
                didSpawn3Time = 0;
            }
            else if (didSpawn3Time >= 24 || (15 >= didSpawn3Time && didSpawn3Time >= 8))
            {
                spawnBorder3.color = Color.gray;
                didSpawn3Time++;
                cooldown3.fillAmount -= 1f / spawnCooldown3;
            }
            else if ((7 >= didSpawn3Time && didSpawn3Time >= 0) || (23 >= didSpawn3Time && didSpawn3Time >= 16))
            {
                spawnBorder3.color = new Color(38f / 255f, 141f / 255f, 38f / 255f, 1f);
                didSpawn3Time++;
                cooldown3.fillAmount -= 1f / spawnCooldown3;
            }
        }

        if (cannotUpgrade)
        {
            if (money > upgradeCost || cannotUpgradeTime >= 24)
            {
                upgradeBorder.color = Color.black;
                cannotUpgrade = false;
                cannotUpgradeTime = 0;
            }
            else if ((7 >= cannotUpgradeTime && cannotUpgradeTime >= 0) || (23 >= cannotUpgradeTime && cannotUpgradeTime >= 16))
            {
                upgradeBorder.color = new Color(139f / 255f, 0f, 0f, 1f);
                cannotUpgradeTime++;
            }
            else if (15 >= cannotUpgradeTime && cannotUpgradeTime >= 8)
            {
                upgradeBorder.color = Color.black;
                cannotUpgradeTime++;
            }
            else
            {
                cannotUpgradeTime++;
            }
        }

        if (cannotSpawn1)
        {
            Color colorSpawn1;
            if (didSpawn1)
            {
                colorSpawn1 = Color.gray;
            }
            else
            {
                colorSpawn1 = Color.black;
            }

            if (money > spawnCost1 || cannotSpawn1Time >= 24)
            {
                spawnBorder1.color = colorSpawn1;
                cannotSpawn1 = false;
                cannotSpawn1Time = 0;
            }
            else if ((7 >= cannotSpawn1Time && cannotSpawn1Time >= 0) || (23 >= cannotSpawn1Time && cannotSpawn1Time >= 16))
            {
                spawnBorder1.color = new Color(139f / 255f, 0f, 0f, 1f);
                cannotSpawn1Time++;
            }
            else if (15 >= cannotSpawn1Time && cannotSpawn1Time >= 8)
            {
                spawnBorder1.color = colorSpawn1;
                cannotSpawn1Time++;
            }
            else
            {
                cannotSpawn1Time++;
            }
        }

        if (cannotSpawn2)
        {
            Color colorSpawn2;
            if (didSpawn2)
            {
                colorSpawn2 = Color.gray;
            }
            else
            {
                colorSpawn2 = Color.black;
            }
            if (money > spawnCost2 || cannotSpawn2Time >= 24)
            {
                spawnBorder2.color = colorSpawn2;
                cannotSpawn2 = false;
                cannotSpawn2Time = 0;
            }
            else if ((7 >= cannotSpawn2Time && cannotSpawn2Time >= 0) || (23 >= cannotSpawn2Time && cannotSpawn2Time >= 16))
            {
                spawnBorder2.color = new Color(139f / 255f, 0f, 0f, 1f);
                cannotSpawn2Time++;
            }
            else if (15 >= cannotSpawn2Time && cannotSpawn2Time >= 8)
            {
                spawnBorder2.color = colorSpawn2;
                cannotSpawn2Time++;
            }
            else
            {
                cannotSpawn2Time++;
            }
        }

        if (cannotSpawn3)
        {
            Color colorSpawn3;
            if (didSpawn3)
            {
                colorSpawn3 = Color.gray;
            }
            else
            {
                colorSpawn3 = Color.black;
            }
            if (money > spawnCost3 || cannotSpawn3Time >= 24)
            {
                spawnBorder3.color = colorSpawn3;
                cannotSpawn3 = false;
                cannotSpawn3Time = 0;
            }
            else if ((7 >= cannotSpawn3Time && cannotSpawn3Time >= 0) || (23 >= cannotSpawn3Time && cannotSpawn3Time >= 16))
            {
                spawnBorder3.color = new Color(139f / 255f, 0f, 0f, 1f);
                cannotSpawn3Time++;
            }
            else if (15 >= cannotSpawn3Time && cannotSpawn3Time >= 8)
            {
                spawnBorder3.color = colorSpawn3;
                cannotSpawn3Time++;
            }
            else
            {
                cannotSpawn3Time++;
            }
        }
    }
}