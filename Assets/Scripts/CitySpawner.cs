using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CitySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //add txt to GM
        if (GameManager.Instance.txtDays == null)
        {
            var txtParent = GameObject.Find("PNL_GameUI").GetComponentInChildren<TextMeshPro>();
            GameManager.Instance.txtDays.SetText(txtParent.text);
        }

        //Add cities to List
        if (GameManager.Instance.citiesList.Count == 0)
        {
            var cityParent = GameObject.Find("PNL_Cities");
            if (cityParent != null)
            {
                for (int i = 0; i < cityParent.transform.childCount; ++i)
                {
                    GameManager.Instance.citiesList.Add(cityParent.transform.GetChild(i));
                }
            }
        }

       //The first Epidemic
      if (GameManager.Instance.epidemicStarted == false)
            {
            GameManager.Instance.epidemicSpreadResult = Random.Range(0,GameManager.Instance.epidemicsList.Count);
            int start = Random.Range(0, GameManager.Instance.citiesList.Count);
            Instantiate(GameManager.Instance.prefab, GameManager.Instance.citiesList[start].transform);
            GameManager.Instance.epidemicStarted = true;

            }

        }
}
