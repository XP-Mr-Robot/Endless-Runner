using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev
{
    public class VRG_LoadFromSession : VRG_Base
    {
        [SerializeField] private ENUM_DataType m_DataType;

        [SerializeField] private string m_SessionObject;
        [SerializeField] private string m_SessionData;

        [SerializeField] private Text m_Text = null;

        private void Awake()
        {
            this.m_Text = this.Encuentra(this.m_Text);
        }


        // Use this for initialization use new to get 
        private void OnEnable()
        {
            switch (this.m_DataType)
            {
                case ENUM_DataType.STRING:
                    this.m_Text.text = VRG_Session.GetString(this.m_SessionObject, this.m_SessionData);
                    break;

                case ENUM_DataType.INT:
                    this.m_Text.text = VRG_Session.GetInt(this.m_SessionObject, this.m_SessionData).ToString();
                    break;

                case ENUM_DataType.FLOAT:
                    this.m_Text.text = VRG_Session.GetFloat(this.m_SessionObject, this.m_SessionData).ToString();
                    break;

                case ENUM_DataType.BOOL:
                    this.m_Text.text = VRG_Session.GetBool(this.m_SessionObject, this.m_SessionData).ToString();
                    break;
            }
        }

    }
}