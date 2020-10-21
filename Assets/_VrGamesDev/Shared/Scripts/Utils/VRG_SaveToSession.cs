using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev
{
    public class VRG_SaveToSession : VRG_Base
    {
        [SerializeField] private ENUM_DataType m_DataType;

        [SerializeField] private string m_SessionObject;
        [SerializeField] private string m_SessionData;

        [SerializeField] private string m_Value;



        // Use this for initialization use new to get 
        private void OnEnable()
        {
            switch (this.m_DataType)
            {
                case ENUM_DataType.STRING:
                    VRG_Session.SetString(this.m_SessionObject, this.m_SessionData, this.m_Value);
                    break;

                case ENUM_DataType.INT:
                    VRG_Session.SetInt(this.m_SessionObject, this.m_SessionData, int.Parse(this.m_Value));
                    break;

                case ENUM_DataType.FLOAT:
                    VRG_Session.SetFloat(this.m_SessionObject, this.m_SessionData, float.Parse(this.m_Value));
                    break;

                case ENUM_DataType.BOOL:
                    VRG_Session.SetBool(this.m_SessionObject, this.m_SessionData, bool.Parse(this.m_Value));
                    break;
            }
        }

    }
}