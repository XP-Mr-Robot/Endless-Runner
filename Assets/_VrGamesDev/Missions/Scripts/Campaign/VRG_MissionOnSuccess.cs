//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_MissionOnSuccess : VRG_Base
    {
        //[Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]

        [SerializeField] private VRG_CountdownTimer m_CountdownTimer = null;
        
        [SerializeField] private GameObject m_Pass = null;
        [SerializeField] private GameObject m_Star = null;

        private void OnEnable()
        {
            if (this.m_CountdownTimer != null)
            {
                if (this.m_CountdownTimer.star)
                {
                    this.m_Star.SetActive(true);
                }
                else
                {
                    this.m_Pass.SetActive(true);
                }
            }
            else
            {
                WAS_Error("You need a VRG_CountdownTimer");
            }
            //this.m_CountdownTimer.StopTimer();
        }
    }
}