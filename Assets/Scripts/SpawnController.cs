using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public EnemyController[] enemyList;
    public Transform[] enemyCount;
    public int threatLevel;

    private int countList;
    private int enemyListSpawn;
    private int amountToSpawn;
    private int countSpawnVectorPos = 0;

    void Start()
    {
        countList = enemyCount.Length;
        var instanceTempEnemy = enemyList[0];
        var instanceEnemy = enemyList[0];
        var instanceEnemy2 = enemyList[1];
        var instanceEnemy3 = enemyList[2];

        switch (threatLevel){
            //Only Enemy threat 1
            case 0:
                instanceEnemy = enemyList[0];
                enemyListSpawn = 1;
                break;
            //Only Enemy threat 2
            case 1:
                instanceEnemy = enemyList[1];
                enemyListSpawn = 1;
                break;
            //Only Enemy threat 3
            case 2:
                instanceEnemy = enemyList[2];
                enemyListSpawn = 1;
                break;
            //Enemy threat 1 & 2
            case 3:
                enemyListSpawn = 2;
                break;
            //Enemy threat 1 & 2 & 3
            case 4:
                enemyListSpawn = 3;
                break;
            default:
                instanceEnemy = enemyList[0];
                enemyListSpawn = 1;
                break;
        }

        if (countList < enemyListSpawn){
            enemyListSpawn = countList;
        }

        amountToSpawn = Mathf.CeilToInt(countList / enemyListSpawn);
        for (int i = 0; i < enemyListSpawn; i++){            
            for (int c = 0; c < amountToSpawn; c++){
                switch (i){
                    case 0:
                        instanceTempEnemy = Instantiate(instanceEnemy);
                        break;
                    case 1:                        
                        instanceTempEnemy = Instantiate(instanceEnemy2);
                        break;
                    case 2:                        
                        instanceTempEnemy = Instantiate(instanceEnemy3);
                        break;
                }

                //instanceTempEnemy.GetComponent<EnemyController>().initTransform = enemyCount[c + countSpawnVectorPos];
                instanceTempEnemy.transform.position = enemyCount[c + countSpawnVectorPos].position;
                instanceTempEnemy.transform.position = new Vector3(instanceTempEnemy.transform.position.x, instanceTempEnemy.transform.position.y, instanceTempEnemy.transform.position.z);
            }
            countSpawnVectorPos+= amountToSpawn;
        }
    }
}
