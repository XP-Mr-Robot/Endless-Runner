//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    [RequireComponent(typeof(VRG_GoToScene))]
    [RequireComponent(typeof(Image))]
    public class VRG_MissionIntegrity : VRG_Base
    {
        //[Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]

        [Tooltip("The go to scene object")]
        //[SerializeField]
        private VRG_GoToScene m_VRG_GoToScene = null;

        [Tooltip("Background Image")]
        //[SerializeField]
        private Image m_Image = null;


        protected VRG_GoToScene Encuentra(VRG_GoToScene valueLocal) => this.Encuentra(valueLocal, true);
        protected VRG_GoToScene Encuentra(VRG_GoToScene valueLocal, bool destroyLocal)
        {
            string sObjectFinder = "";

            if (valueLocal == null)
            {
                sObjectFinder = "VRG_GoToScene";

                if (destroyLocal)
                {
                    WAS_Warning(sObjectFinder);
                }

                valueLocal = GetComponentInChildren<VRG_GoToScene>();
            }

            if (valueLocal == null)
            {
                valueLocal = GetComponentInParent<VRG_GoToScene>();
            }

            if (valueLocal == null && destroyLocal)
            {
                WAS_Error("<color=red><b>DESTROYED: </b></color>" + sObjectFinder);
                this.SetReady(false);
                Destroy(this.gameObject);
            }

            return valueLocal;
        }

        private void Awake()
        {
            this.m_VRG_GoToScene = this.Encuentra(this.m_VRG_GoToScene, false);

            this.m_Image = this.Encuentra(this.m_Image, false);
           

            this.m_Image.enabled = true;
        }

        // Use this for initialization use new to get 
        private void OnEnable()
        {
            this.m_VRG_GoToScene = this.Encuentra(this.m_VRG_GoToScene);

            // Start next frame, just in case you need at iterator
            StartCoroutine(this.OnEnable_IEnumerator());
        }

        // Enumerator proxy
        private IEnumerator OnEnable_IEnumerator()
        {
            while (VRG_Game.Instance == null)
            {
                // next frame
                yield return null;
            }

            bool bValid = VRG_Game.Integrity();

            if (!bValid)
            {
                this.m_VRG_GoToScene.enabled = true;
            }
            else
            {
                foreach (Transform child in this.transform)
                {
                    child.gameObject.SetActive(true);
                }
//                this.gameObject.SetActive(false);
            }

            // next frame
            yield return null;
        }
    }
}