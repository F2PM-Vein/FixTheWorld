using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City
{
    [CreateAssetMenu(menuName = "ScriptableObjects/City SO", fileName = "City", order = 1)]
    public class CitySO : ScriptableObject
    {
        [SerializeField]
        public List<Transform> cityNeighbours = new List<Transform>();
        public bool onFire;
        public bool Infected;
        public int cityID;
    }
}

