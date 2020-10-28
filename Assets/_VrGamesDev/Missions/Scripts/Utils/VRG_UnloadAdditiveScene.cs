using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_UnloadAdditiveScene : VRG_Base
    {
        [Tooltip("The name of the Scene to unload")]
        [SerializeField] [SceneName] private string m_Scene = "";

        [Tooltip("The time in seconds to wait before the unload")]
        [SerializeField] private float m_Delay = 0.1f;


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
            yield return new WaitForSeconds(this.m_Delay);

            SceneManager.UnloadSceneAsync(this.m_Scene);

            // regreso, equivale a un void
            yield return null;
        }



    }
}



























/*
        // [RequireComponent(typeof(Rigidbody))]
        // [System.Serializable]

        [Header("From: App Info")]

        public static bool isAnal { get { return Instance.m_isAnal; } }


        [Range(0.0f, 1)]

        [Tooltip("Lorep Ipsum")]
        [SerializeField] private bool m_Bool = true;
              
        [Space(10)]
        [Header("From: Debug")]

        [SerializeField]
        public bool m_Bool
        {
            get
            {
                return this.m_Bool;
            }
            set
            {
            //    this.m_Bool = value;
            }
        }



        // singletoning
        // public static VRG_ClassSelf Instance; void Awake() { Instance = this; }


        // singletoning Pattern
        public static VRG_ClassSelf Instance; void Awake()
        {
            // reviso si soy el primero
            if (Instance == null)
            {
                // ... como lo soy, me hago el bueno
                Instance = this;

                // y no me destruyo
                DontDestroyOnLoad(this);
            }
            else
            {
                // como no lo soy, me voy
                Destroy(this.gameObject);
            }
        }

        private void Awake()
        {
            print("Awake");
        }

        private void OnEnable()
        {
            print("onEnable");
        }

        private void OnDisable()
        {
            print("OnDisable");
        }
    */
