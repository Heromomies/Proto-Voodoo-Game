using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBall : MonoBehaviour
{
    #region Singleton
    private static SpawnerBall _instance;

    public static SpawnerBall Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<SpawnerBall>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public GameObject ball;
    
    public void SpawnBall()
    {
        Instantiate(ball, transform.position, Quaternion.identity);
    }
}
