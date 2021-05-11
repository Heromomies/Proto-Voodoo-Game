using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KnifeSpawner : MonoBehaviour
{
    public GameObject knife;
    public GameObject panelKnife;
    public Transform circleTransform; 
    public List<Image> imageKnife;
    
    public int numberMaxKnife;
    public float waitingTime;

    public TextMeshProUGUI textLaunchedKnife;
    
    private int _numberKnife;
    private int _numberLevel = 1;
    private int _launchedKnife;
    private float _timer;
    
    private void Start()
    {
        _numberKnife = numberMaxKnife;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        
        if (Input.GetMouseButtonDown(0) && numberMaxKnife > 0 && _timer > waitingTime)
        {
            Instantiate(knife, transform.position, Quaternion.identity);
            numberMaxKnife--;
            _timer = 0;
            imageKnife[numberMaxKnife].color = Color.black;
            _launchedKnife++;
            textLaunchedKnife.text = $"{_launchedKnife}";
        }

        if (numberMaxKnife <= 0)
        {
            NewLevel();
            _numberLevel++;
        }
    }

    void NewLevel()
    {
        numberMaxKnife += _numberKnife + _numberLevel;

        for (int i = 0; i < circleTransform.childCount; i++)
        {
            circleTransform.transform.GetChild(i).gameObject.SetActive(false);
        }
        
        
        foreach (var img in imageKnife)
        {
            img.color = Color.white;
        }
        
        Image image = Instantiate(imageKnife[0], transform.position, Quaternion.identity);
        image.transform.parent = panelKnife.transform;
        imageKnife.Add(image);
        
        panelKnife.GetComponent<VerticalLayoutGroup>().padding.top -= 40;
    }
}
