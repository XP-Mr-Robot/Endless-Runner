using System.Collections;

using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_Game_UI : VRG_Base
    {
        [SerializeField] private Transform[] m_Except = null;

        [Header("From: Debug")]
        [SerializeField] private Text[] m_Text = null;
        [SerializeField] private Button[] m_Button = null;

        private void OnEnable()
        {
            // Para empezar en el siguiente ciclo
            StartCoroutine(this.OnEnable_IEnumerator());
        }

        // Enumerator proxy
        private IEnumerator OnEnable_IEnumerator()
        {
            bool bContinue = false;
            bool bChildIncluded = true;

            while (VRG_Game.Instance == null)
            {
                yield return null;
            }

            if (VRG_Game.font != null)
            {
                this.m_Text = this.GetComponentsInChildren<Text>(true);
                foreach (Text child in this.m_Text)
                {
                    bContinue = true;
                    foreach (Transform childExcept in this.m_Except)
                    {
                        if (childExcept.Equals(child.transform))
                        {
                            bContinue = false;
                        }
                    }

                    if (bContinue && child.gameObject.GetComponentInParent<Button>() == null)
                    {
                        child.font = VRG_Game.font;
                    }
                }
            }



            this.m_Button = this.GetComponentsInChildren<Button>(true);
            foreach (Button child in this.m_Button)
            {
                bContinue = true;
                foreach (Transform childExcept in this.m_Except)
                {
                    if (childExcept.Equals(child.transform))
                    {
                        bContinue = false;
                    }
                }

                if (!bContinue)
                {
                    continue;
                }

                ColorBlock colors = child.colors;

                colors.normalColor = VRG_Game.buttonNormal;
                colors.highlightedColor = VRG_Game.buttonHighlighted;
                colors.pressedColor = VRG_Game.buttonPressed;
                colors.disabledColor = VRG_Game.buttonDisabled;
#if UNITY_2019_1_OR_NEWER
                colors.selectedColor = VRG_Game.buttonSelected;
#endif //UNITY_2019_1_OR_NEWER
                child.colors = colors;


                Text[] text = child.GetComponentsInChildren<Text>(true);
                foreach (Text childText in text)
                {
                    if (child.GetComponent<Image>().enabled)
                    {
                        childText.color = VRG_Game.buttonText;
                    }
                    else
                    {
                        childText.color = VRG_Game.iconText;
                    }

                    if (VRG_Game.font != null)
                    {
                        childText.font = VRG_Game.font;
                    }
                }


                foreach (Transform childTransform in child.transform)
                {
                    Image image = childTransform.GetComponent<Image>();
                    if (image != null)
                    {

                        bChildIncluded = true;
                        foreach (Transform childExcept in this.m_Except)
                        {
                            if (childExcept.Equals(image.transform))
                            {
                                bChildIncluded = false;
                                break;
                            }
                        }

                        if (bChildIncluded)
                        {
                            image.color = VRG_Game.iconBackground;
                        
                            bool bChildFound = false;
                            foreach (Transform childIcon in childTransform)
                            {
                                Image icon = childIcon.GetComponent<Image>();
                                if (icon != null)
                                {
                                    bChildIncluded = true;
                                    foreach (Transform childExcept in this.m_Except)
                                    {
                                        if (childExcept.Equals(icon.transform))
                                        {
                                            bChildIncluded = false;
                                            break;
                                        }
                                    }

                                    if (bChildIncluded)
                                    {
                                        icon.color = VRG_Game.iconColor;
                                    }

                                    bChildFound = true;
                                }

                                if (bChildFound)
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }


            }

                // regreso, equivale a un void
                yield return null;
        }

    }
}