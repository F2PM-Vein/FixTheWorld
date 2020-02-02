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
                if (cityStatus.onFire)
                {
                    //GetComponentInChildren<>
                }
                break;
            case "Medicine":
                if (cityStatus.isInfected)
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
