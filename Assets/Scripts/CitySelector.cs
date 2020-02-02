using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        string selectedItem = GameManager.Instance.selected;
        CityStatus cityStatus = GetComponent<CityStatus>();

        switch (selectedItem)
        {
            case "Water":
                if (cityStatus.fireStatus>0)
                {
                    //GetComponentInChildren<>
                }
                break;
            case "Medicine":
                if (cityStatus.infectedStatus>0)
                {
                    Debug.Log(GameManager.Instance.selected);
                }
                break;
            default:
                Debug.Log("Invalid selection");
                break;
        }

        
        
        if (!cityStatus.isAlive)
        {

        }
    }
}
