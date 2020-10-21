//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_OpenUrl : VRG_Base
    {
        [SerializeField] private ENUM_ExternalURL m_www = ENUM_ExternalURL.NONE;

        // Use this for initialization use new to get 
        private void OnEnable()
        {
            // Start next frame, just in case you need at iterator
            StartCoroutine(this.OnEnable_IEnumerator());
        }

        // Enumerator proxy
        private IEnumerator OnEnable_IEnumerator()
        {
            VRG_Game.OpenUrl(this.m_www);

            // next frame
            yield return null;

            this.gameObject.SetActive(false);

            // next frame
            yield return null;

        }
    }
}