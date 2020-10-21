//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_SetBackgroundColor : VRG_Base
    {

        // Use this for initialization use new to get 
        private void OnEnable()
        {
            // Start next frame, just in case you need at iterator
            StartCoroutine(this.OnEnable_IEnumerator());
        }

        // Enumerator proxy
        private IEnumerator OnEnable_IEnumerator()
        {
            while (VRG_Game.Instance == null)
            {
                yield return null;
            }

            Image myImage = this.gameObject.GetComponent<Image>();

            if (myImage != null)
            {
                myImage.color = VRG_Game.backgroundColor;
            }



            // next frame
            yield return null;
        }

    }
}