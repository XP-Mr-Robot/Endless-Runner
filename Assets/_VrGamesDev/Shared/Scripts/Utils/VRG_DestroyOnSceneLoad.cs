﻿//using System;
using System.Collections;
//using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev
{
    public class VRG_DestroyOnSceneLoad : VRG_Base
    {
        // Use this for initialization
        // para decirle al engine que es una funcion nueva
        private void OnEnable()
        {
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
            Object.Destroy(this.gameObject);
        }

    }
}









/*
        // [RequireComponent(typeof(Rigidbody))]
        // [System.Serializable]

        [Header("From: App Info")]

        [Tooltip("Force to send analytics: For Editor testing")]
        [SerializeField] private bool m_isAnal = false;
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


        private void OnDisable()
        {
            print("OnDisable");
        }


        // Use this for initialization use new to get 
        private new void Start()
        {
            print("Start");

            // Start with in full verbose mode
            this.m_Verbose = ENUM_Verbose.DEBUG;

            // start your parent from VRG_Base
            base.Start();

            // Start next frame, just in case you need at iterator
            StartCoroutine(this.Start_IEnumerator());
        }

    */
