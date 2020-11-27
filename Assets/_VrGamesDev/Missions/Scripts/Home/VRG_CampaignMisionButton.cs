//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_CampaignMisionButton : VRG_Base
    {
        [SerializeField] private int m_Id = 0;
        [SerializeField] private bool m_Star = false;
        [SerializeField] private bool m_Interactable = true;

        [Header("From: Components")]
        [SerializeField] private Transform m_GoStar = null;
        [SerializeField] private Transform m_GoText = null;

        /*
        [SerializeField] private Transform m_GoSound = null;
        [SerializeField] private Transform m_GoAction = null;
        */

        //[Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]




        public void Init(int valueLocal, int currentLocal, bool starLocal)
        {
            // asignar el texto al centro del boton
            this.m_Id = valueLocal;
            Text textMission = this.m_GoText.GetComponentInChildren<Text>();
            textMission.text = this.m_Id.ToString();


            // activar o desactivar el boton
            Button button = this.GetComponent<Button>();
            this.m_Interactable = true;
            if (this.m_Id <= currentLocal)
            {
                this.m_Interactable = true;
            }
            button.interactable = this.m_Interactable;


            // si ya realizo la misión con estrella, desplegarla
            this.m_Star = (starLocal && button.interactable);
            this.m_GoStar.gameObject.SetActive(this.m_Star);
        }



        public override void OnClick()
        {
            VRG_Session.SetInt("Campaign", "Current", this.m_Id);
            print("OnClick: Campaign->Current = " + this.m_Id);
        }



    }
}