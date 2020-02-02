using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EpidemicPrefab : MonoBehaviour
{
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
        int fireStatus = cityStatus.fireStatus;
        textMesh.text = fireStatus + "/3";
    }
}
