//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    [RequireComponent(typeof(Text))]
    public class VRG_CountdownTimer : VRG_Base
    {
        [Header("FROM: Star")]
        [SerializeField] private Image m_Star = null;
        [SerializeField] private Color m_StarOn = new Color(1.0f, 0.796f, 0.0f, 1.0f);
        [SerializeField] private Color m_StarOff = new Color(0.796f, 0.796f, 0.796f, 1.0f);
        public bool star { get { return this.m_TimeCurrent <= 0? false : true; } }


        [Header("FROM: Clock")]
        [SerializeField] private float m_Time = 5.0f;
        [SerializeField] private int m_Decimals = 2;


        [Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]
        [SerializeField] private Text m_Text = null;
        [SerializeField] private float m_TimeCurrent = 0.0f;

        private Coroutine m_Coroutine;


        // Use this for initialization use new to get 
        private new void Start()
        {
            this.m_Text = this.Encuentra(this.m_Text);

            this.m_Text.text = this.m_Time.ToString("F" + this.m_Decimals.ToString());

            base.Start();

        }

        public void StartTimer()
        {
            this.m_TimeCurrent = this.m_Time;

            // Start next frame, just in case you need at iterator
            this.m_Coroutine = StartCoroutine(this.StartTimer_IEnumerator());
        }

        // Enumerator proxy
        private IEnumerator StartTimer_IEnumerator()
        {
            while (this.m_TimeCurrent > 0)
            {
                this.m_TimeCurrent -= Time.deltaTime;

                if (this.m_TimeCurrent <= 0.0f)
                {
                    this.m_TimeCurrent = 0.0f;
                }

                this.m_Text.text = this.m_TimeCurrent.ToString("F" + this.m_Decimals.ToString());

                // next frame
                yield return null;
            }


            this.m_Star.color = this.m_StarOff;

            // next frame
            yield return null;
        }

        
        public void StopTimer()
        {
            StopCoroutine(this.m_Coroutine);
        }
        

    }
}