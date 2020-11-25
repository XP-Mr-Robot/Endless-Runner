//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_CampaignFinishSettings : VRG_Base
    {
        //[Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]

        [SerializeField] private Image m_Image = null;

        [SerializeField] private VerticalLayoutGroup m_VerticalLayoutGroup = null;

        private void OnEnable()
        {
            // Start next frame, just in case you need at iterator
            StartCoroutine(this.OnEnable_IEnumerator());
        }

        // Enumerator proxy
        private IEnumerator OnEnable_IEnumerator()
        {
            if (this.m_Image != null)
            {
                this.m_Image.enabled = false;
            }

            if (this.m_VerticalLayoutGroup != null)
            {
                this.m_VerticalLayoutGroup.childAlignment = TextAnchor.LowerCenter;
            }

            // next frame
            yield return null;
        }
    }
}