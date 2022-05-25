using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyPrefab;
    public MoneyManager money;
    public SoundManager sound;

    void Start()
    {
        money = FindObjectOfType<MoneyManager>();
        sound = FindObjectOfType<SoundManager>();
    }

    public void SpawnE()
    {
        if (money.floatMoney >= money.spawnCost1 && !money.didSpawn1)
        {
            Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            money.floatMoney -= money.spawnCost1;
            sound.Play("spawn");
            money.didSpawn1 = true;
        }
        else
        {
            sound.Play("denied");
            money.cannotSpawn1 = true;
        }
    }

    public void SpawnE2()
    {
        if (money.floatMoney >= money.spawnCost2 && !money.didSpawn2)
        {
            Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            money.floatMoney -= money.spawnCost2;
            sound.Play("spawn");
            money.didSpawn2 = true;
        }
        else
        {
            sound.Play("denied");
            money.cannotSpawn2 = true;
        }
    }

    public void SpawnE3()
    {
        if (money.floatMoney >= money.spawnCost3 && !money.didSpawn3)
        {
            Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            money.floatMoney -= money.spawnCost3;
            sound.Play("spawn");
            money.didSpawn3 = true;
        }
        else
        {
            sound.Play("denied");
            money.cannotSpawn3 = true;
        }
    }
}
