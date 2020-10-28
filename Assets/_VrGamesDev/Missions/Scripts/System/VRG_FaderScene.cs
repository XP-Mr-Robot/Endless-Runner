//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_FaderScene : VRG_Base
    {
        /// <summary>
        /// Luke, I'm your <a href="index.html#VrGamesDev.VRG_Fader">Fader</a>
        /// </summary>
        [Tooltip("Luke, I'm your Fader")]
        [SerializeField] private VRG_Fader m_VRG_Fader = null;

        [SerializeField] [SceneName] private string m_SceneToLoad = "[RELOAD SCENE]";

        public static string current { get { return SceneManager.GetActiveScene().name; } }

        // singletoning Pattern
        public static VRG_FaderScene Instance; void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                if (Instance.m_VRG_Fader == null)
                {
                    Instance.m_VRG_Fader = this.transform.GetComponentInChildren<VRG_Fader>();
                }

            }
            else 
            {
                Destroy(this.gameObject);
            }
        }

        // Use this for initialization
        // para decirle al engine que es una funcion nueva
        private void OnEnable()
        {
            // set the fade status
            Instance.m_VRG_Fader.SetAutoFade(false);

            // me entero cuando se cargue cada escena
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnDisable()
        {
            // libero todas las escenas
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        // called second
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            //WAS_FullName("OnSceneLoaded: " + scene.name + " | Total: " + SceneManager.sceneCount + " | Mode: " + mode);

            // if it needs to continue because the fade is on
            if (!Instance.m_VRG_Fader.inOut)
            {
                // activate the box object that hold the fader
                this.m_VRG_Fader.Fade(false);
            }

            // ... hazla activa
            SceneManager.SetActiveScene(scene);

            this.SetReady(true);
        }

        public static void Load(string valueLocal)
        {
            VRG_FaderScene.Load(valueLocal, 0);
        }

        public static void Load(string valueLocal, float delayLocal)
        {
            Instance.WAS_echo("Entered: Load");

            if (string.IsNullOrEmpty(valueLocal) || valueLocal == "[RELOAD SCENE]")
            {
                valueLocal = VRG_FaderScene.current;
            }

            // asigno la nueva escena que quiero
            Instance.m_SceneToLoad = valueLocal;

            // load en etapas la siguiente escena
            Instance.StartCoroutine(Instance.Load_IEnumerator(delayLocal));
        }

        private IEnumerator Load_IEnumerator(float valueLocal)
        {
            while (!Instance.isReady)
            {
                yield return null;
            }

            if (this.m_IsReady)
            {
                if (valueLocal > 0)
                {
                    yield return new WaitForSeconds(valueLocal);
                }

                // can't load another scene while this one is loading
                this.SetReady(false);

                // activate the box object that hold the fader
                this.m_VRG_Fader.Fade(true);

                // la cargo
                SceneManager.LoadSceneAsync(Instance.m_SceneToLoad);

            }
            yield return null;
        }
    }

}