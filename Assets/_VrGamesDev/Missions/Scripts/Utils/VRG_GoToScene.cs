using System.Collections;

using UnityEngine;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_GoToScene : VRG_Base
    {
        [Tooltip("The time in seconds to wait before loading the scene, 0 seconds is recommended")]
        [SerializeField] private float m_Delay = 0.0f;

        [Tooltip("The name of the scene to load")]
        [SerializeField] [SceneName] private string m_Scene = "[RELOAD SCENE]";

        private void OnEnable()
        {
            VRG_FaderScene.Load(this.m_Scene, this.m_Delay);
        }

    }
}