using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBank : MonoBehaviour
{
    public MoneyManager money;
    public SoundManager sound;

    void Start()
    {
        money = FindObjectOfType<MoneyManager>();
        sound = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    public void Upgrade()
    {
        if (money.floatMoney >= money.upgradeCost && money.level < 5)
        {
            money.floatMoney -= money.upgradeCost;
            money.level++;
            money.upgradeCost += 150;
            money.income += 0.15f;
            money.maxMoney += 500;
            sound.Play("upgrade");
            money.didUpgrade = true;
        }
        else
        {
            sound.Play("denied");
            money.cannotUpgrade = true;
        }
    }
}
