using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    #region Singleton
    private static Death _instance;

    public static Death Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Death>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public GameObject panel;
    
    // Update is called once per frame
    public void Dead()
    {
        panel.SetActive(true);
    }
}
