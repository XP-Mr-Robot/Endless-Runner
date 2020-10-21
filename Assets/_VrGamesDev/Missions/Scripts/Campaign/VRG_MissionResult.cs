//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_MissionResult : VRG_Base
    {
        //[Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]

        
        [SerializeField] private ENUM_Mission m_Mission = ENUM_Mission.FAIL;

        [SerializeField] private VRG_CountdownTimer m_CountdownTimer = null;
        
        private void OnEnable()
        {
            switch (this.m_Mission)
            {
                case ENUM_Mission.FAIL:
                    break;
                case ENUM_Mission.NEXT:
                    VRG_Game.Next();
                    break;
                case ENUM_Mission.PASS:
                    VRG_Game.Pass();
                    break;
                case ENUM_Mission.STAR:
                    VRG_Game.Star();
                    break;
            }
        }
    }
}