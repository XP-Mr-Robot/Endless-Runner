using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_DeactivateOnInstructions : VRG_Base
    {
        [SerializeField] private GameObject m_Deactivate = null;

        //[SerializeField]
        private string m_SessionObject = "Campaign";
        //[SerializeField]
        private string m_SessionData = "Instruction";


        // Use this for initialization use new to get 
        private void OnEnable()
        {
            if (this.m_Deactivate != null)
            {
                this.m_Deactivate.SetActive(!VRG_Session.GetBool(this.m_SessionObject, this.m_SessionData));

                VRG_Session.SetBool(this.m_SessionObject, this.m_SessionData, false);
            }

        }

    }
}