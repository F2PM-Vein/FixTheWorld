using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EpidemicPrefab : MonoBehaviour
{
    public enum EpidemicType
    {
        Fire, Virus
    }

    public EpidemicType epidemicType;

    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CityStatus cityStatus = this.transform.parent.parent.GetComponent<CityStatus>();

        switch (epidemicType)
        {
            case EpidemicType.Fire:
                textMesh.text = cityStatus.fireStatus + "/3";
                break;
            case EpidemicType.Virus:
                textMesh.text = cityStatus.infectedStatus + "/3";
                break;
            default:
                Debug.Log("Epidemic type not set");
                break;
        }
    }
}
