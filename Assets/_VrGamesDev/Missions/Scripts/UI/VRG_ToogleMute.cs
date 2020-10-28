//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_ToogleMute : VRG_Base
    {
        [Header("From: Mixer")]
        [SerializeField] private ENUM_AudioMixer m_Group = ENUM_AudioMixer.MASTER;

        [Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]
        //[SerializeField]
        private bool isMuted = false;

        private void Awake()
        {
            this.isMuted = VRG_Session.GetBool("Mute", VRG_DataBase.GetAudioMixerGroup(this.m_Group));

            this.gameObject.SetActive(false);
        }

        // Use this for initialization use new to get 
        private void OnEnable()
        {
            // Start next frame, just in case you need at iterator
            StartCoroutine(this.OnEnableIEnumerator());
        }

        // Enumerator proxy
        private IEnumerator OnEnableIEnumerator()
        {
            while (VRG_Game.Instance == null)
            {
                yield return null;
            }

            this.isMuted = !this.isMuted;

            VRG_Game.Mute(this.m_Group, this.isMuted);

            this.gameObject.SetActive(false);

            // next frame
            yield return null;
        }

    }
}