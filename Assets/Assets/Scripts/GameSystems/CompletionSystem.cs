using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionSystem : MonoBehaviour
{
    private int MaxEnemyOnTheMap;
    public int enemyDied;
    [SerializeField] public GameStartManager startManager;

    private void Start()
    {
        enemyDied = 0;
        MaxEnemyOnTheMap = startManager.enemyNum;
    }
    
    public float CalculatePercent()//make normally with change the int to byte or uint or short
    {
        float val = ((float)enemyDied / (float)MaxEnemyOnTheMap) * 100;
        print("MaxEneemyOnDaMapVal: " + MaxEnemyOnTheMap);
        print("Enemy died: " + enemyDied);
        print("Value: " + val);
        CheckCompletion(val);
        return val;
    }

    private void CheckCompletion(float value)
    {
        if(value >= 100)
        {
            print("Completed da map");
            startManager.StopGame();
        }
    }

  
}
