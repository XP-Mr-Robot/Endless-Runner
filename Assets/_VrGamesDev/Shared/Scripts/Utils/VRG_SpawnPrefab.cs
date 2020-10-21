//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev
{
    public class VRG_SpawnPrefab : VRG_Base
    {
        [Tooltip("The Prefab to Spawn")]
        [SerializeField] private GameObject m_Prefab = null;

        // Use this for initialization
        // para decirle al engine que es una funcion nueva
        private void OnEnable()
        {
            Object.Instantiate(this.m_Prefab);

            this.gameObject.SetActive(false);
        }

    }
}