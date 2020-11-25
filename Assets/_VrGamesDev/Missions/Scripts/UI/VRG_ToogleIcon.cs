//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_ToogleIcon : VRG_Base
    {
        [Header("From: Icon")]
        [SerializeField] private Image m_Image = null;
        [SerializeField] private Sprite m_On = null;
        [SerializeField] private Sprite m_Off = null;

        [Header("From: Session")]
        [SerializeField] private string m_Object = "";
        [SerializeField] private string m_Data = "";


        [Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]
        //[SerializeField]
        private bool m_OnOff = true;


        private void Awake()
        {
            if (this.m_Object == "" && this.m_Data == "")
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.m_OnOff = VRG_Session.GetBool(this.m_Object, this.m_Data);
            }
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
            if (
                this.m_On != null &&
                this.m_Off != null &&
                this.m_Image != null
                )
            {
                this.m_OnOff = !this.m_OnOff;

                if (this.m_OnOff)
                {
                    this.m_Image.sprite = this.m_On;
                }
                else
                {
                    this.m_Image.sprite = this.m_Off;
                }

                // next frame
                yield return null;
            }

            this.gameObject.SetActive(false);

            // next frame
            yield return null;
        }




    }
}