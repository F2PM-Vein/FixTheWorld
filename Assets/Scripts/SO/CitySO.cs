using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City
{
    [SerializeField]
    public enum State
    {
        ALIVE,DEAD
    }
    [CreateAssetMenu(menuName = "ScriptableObjects/City SO", fileName = "City", order = 1)]
    public class CitySO : ScriptableObject
    {
        public bool onFire;
        public bool Infected;
        public int cityID;
    }
}

