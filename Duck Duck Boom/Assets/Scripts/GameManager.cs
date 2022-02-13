using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;
    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<GameManager>();
            }
            return _Instance;
        }
    }

    int enemiesKilled = 0;

    SpawnController[] camps;
    int totalCamps;
    int remainingCamps;

    private void Awake()
    {
        camps = FindObjectsOfType<SpawnController>();
        totalCamps = camps.Length;
        remainingCamps = totalCamps;
    }

    private void Update()
    {
        int emptyCamps = 0;
        foreach(SpawnController camp in camps)
        {
            if (camp.isEmpty)
                emptyCamps += 1;
        }

        remainingCamps = totalCamps - emptyCamps;
    }

    public int GetNumCampsRemaining()
    {
        return remainingCamps;
    }

    public void IncrementEnemiesKilled()
    {
        enemiesKilled += 1;
    }

    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }
}
