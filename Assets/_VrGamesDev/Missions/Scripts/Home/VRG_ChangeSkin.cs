//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_ChangeSkin : VRG_Base
    {
        [SerializeField] private VRG_Game_UI m_Game_UI = null;

        [SerializeField] private Image[] m_Images = null;


        // Use this for initialization use new to get 
        private void OnEnable()
        {
            // Start next frame, just in case you need at iterator
            StartCoroutine(this.OnEnable_IEnumerator());
        }

        // Enumerator proxy
        private IEnumerator OnEnable_IEnumerator()
        {
            if (this.m_Game_UI != null)
            {
                this.m_Game_UI.gameObject.SetActive(false);

                foreach (Image child in this.m_Images)
                {
                    child.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                }

                VRG_Game.backgroundColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                VRG_Game.iconBackground = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                VRG_Game.iconColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                VRG_Game.iconText = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                VRG_Game.buttonText = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                VRG_Game.buttonNormal = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                VRG_Game.buttonHighlighted = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                VRG_Game.buttonPressed = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                VRG_Game.buttonSelected = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                VRG_Game.buttonDisabled = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

                // next frame
                yield return null;

                this.m_Game_UI.gameObject.SetActive(true);
            }
            else
            {
                WAS_Error("NO Game UI Object to apply the change skin");
            }

            this.gameObject.SetActive(false);

            // next frame
            yield return null;
        }
    }
}