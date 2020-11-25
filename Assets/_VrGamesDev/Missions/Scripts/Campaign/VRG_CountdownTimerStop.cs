//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_CountdownTimerStop : VRG_Base
    {
        //[Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]

        [SerializeField] private VRG_CountdownTimer m_CountdownTimer = null;

        private void OnEnable()
        {
            this.m_CountdownTimer.StopTimer();
        }
    }
}