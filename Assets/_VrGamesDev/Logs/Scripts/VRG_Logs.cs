using System;
using System.Collections.Generic;
using System.IO;

using System.Diagnostics;

using Unity.RemoteConfig;

using UnityEngine;


namespace VrGamesDev.Logs
{
    public class VRG_Logs : VRG_Base
    {

        /// <summary>
        /// Singleton pattern, Instance is the variable that save the data from every class.
        /// </summary>
        public static VRG_Logs Instance;

        private void Awake()
        {
            // I will check if I am the first singletong
            if (Instance == null)
            {
                // ... since i am the one, I declare myself as the one
                Instance = this;

                // ... and I will not get destroyed
                DontDestroyOnLoad(this);

                // Add a listener to apply settings when successfully retrieved: 
                ConfigManager.FetchCompleted += ApplyRemoteSettings;
            }
            else
            {
                // I am not the one... I will walk to the eternal darkness
                Destroy(this.gameObject);
            }
        }

        // close the stream and save the file
        private void OnDestroy()
        {
        }

        // overrided method, called on the remote settings when it comes from the server
        protected override void RemoteSettings_Remote()
        {  
        }

        // it will not start saving until it is properly inited
        private void Init()
        {
        }

        /// <summary>
        /// Do the work you are supposed to do, Save logs to the file, easy and clean 
        /// </summary>
        /// <param name="valueLocal">The string message to send to the log file</param>
        /// <param name="fromWhereLocal">Helps to understand who summon the log</param>
        /// <param name="ENUM_VerboseLocal">Custom Verbose level, the higher the less likely it will be to be saved</param>
        public static void Do(string valueLocal, string fromWhereLocal, ENUM_Verbose ENUM_VerboseLocal)
        {
            
        }
    }
}