//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev
{
    public class VRG_SFx : VRG_Base
    {
        [Tooltip("The clip to play")]
        [SerializeField] private AudioClip m_AudioClip = null;

        [Tooltip("The source of the audio to play, usually it is my own child")]
        [SerializeField] private AudioSource m_AudioSource;

        // Use this for initialization
        // para decirle al engine que es una funcion nueva
        private new void Start()
        {
            // para invocar al padre
            base.Start();

            // Para empezar en el siguiente ciclo
            StartCoroutine(this.Start_IEnumerator());
        }

        // Enumerator proxy
        private IEnumerator Start_IEnumerator()
        {
            this.m_AudioSource = this.Encuentra(this.m_AudioSource);

            this.m_AudioSource.clip = this.m_AudioClip;

            this.m_AudioSource.gameObject.SetActive(true);

            yield return new WaitForSeconds(this.m_AudioClip.length);

            Destroy(this.gameObject);

            // regreso, equivale a un void
            yield return null;
        }

    }
}