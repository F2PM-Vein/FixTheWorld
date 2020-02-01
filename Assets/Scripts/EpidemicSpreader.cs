﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpidemicSpread : MonoBehaviour
{
    public GameObject prefab;
    public bool epidemicStarted = false;
    //Instantiates epidemics 
    public void EpidemicSpread()
    {
        if (epidemicStarted == false)
        {
            int start = Random.Range(1, citiesList.Count);

            epidemicStarted = true;
        }

        Instantiate(prefab, transform);
        int epidemicResult = Random.Range(1, epidemicsList.Count);
        prefab.GetComponent<SpriteRenderer>();
        prefab.GetComponentInChildren<TextMeshProUGUI>().text = epidemicsList[epidemicResult].Name;

        prefab.name = epidemicsList[epidemicResult].Name;

        Debug.Log("Epidemic instantiated");

    }
}
