//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_MissionDigit : VRG_Base
    {
        //[Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]

        [SerializeField] private string m_SessionObject = "";
        [SerializeField] private string m_SessionData = "";
        [SerializeField] private string m_Text = "";

        [SerializeField] private Image[] m_Digits;

        [SerializeField] private Sprite[] m_Numbers;

        private void OnEnable()
        {
            // Start next frame, just in case you need at iterator
            StartCoroutine(this.OnEnable_IEnumerator());
        }

        // Enumerator proxy
        private IEnumerator OnEnable_IEnumerator()
        {
            if (this.m_Text.Trim() == "")
            {
                this.m_Text = VRG_Session.GetInt(this.m_SessionObject, this.m_SessionData).ToString();
            }

            foreach (Image child in this.m_Digits)
            {
                child.gameObject.SetActive(false);
            }

            int iMax = this.m_Text.Length > 3 ? 3 : this.m_Text.Length;

            int ii = 0;
            for (int i = iMax; i > 0; i--)
            {
                this.m_Digits[ii].gameObject.SetActive(true);

                this.m_Digits[ii].sprite = this.m_Numbers[int.Parse(this.m_Text.Substring(i - 1, 1))];

                ii++;
            }


            // next frame
            yield return null;
        }
    }
}