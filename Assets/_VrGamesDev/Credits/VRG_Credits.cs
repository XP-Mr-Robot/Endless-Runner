using System.Collections;

using UnityEngine;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    /// <summary>
    /// Scroll a RectTransform to produce a credits scrolling effect
    /// </summary>
    public class VRG_Credits : VRG_Base
    {
        [Header("From: Components")]
        /// <summary>
        /// The time it will wait to perform the actions
        /// </summary>
        [Tooltip("The time it will wait to perform the actions")]
        [SerializeField] private float m_Delay = 2.0f;

        /// <summary>
        /// From UI: The Body text container as a RectTransform, the information from credits will be displayed here
        /// </summary>
        [Tooltip("From UI: The Body text container as a RectTransform, the information from credits will be displayed here")]
        [SerializeField] private RectTransform m_Content = null;

        /// <summary>
        /// The speed of scrolling
        /// </summary>
        [Tooltip("The speed of scrolling")]
        [SerializeField] private float m_Speed = 1.0f;

        /// <summary>
        /// The minimum height, it recalculate de speed based on the height of the screen
        /// </summary>
        [Tooltip("The minimum height, it recalculate de speed based on the height of the screen")]
        [SerializeField] private float m_Height = 800.0f;


        [Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]
        //[SerializeField]
        [Tooltip("The y height that is displaying")]
        private float m_YCurrent = 0.0f;

        //[SerializeField]
        [Tooltip("The height includig all the content")]
        private float m_YMax = 0.0f;


        private void Awake()
        {
            // get all the childs
            Transform[] myChilds = this.transform.GetComponentsInChildren<Transform>();

            // calculate the max childs lenght as height
            this.m_YMax = myChilds.Length * 50;

            // set it
            this.m_Content.sizeDelta = new Vector2(this.m_Content.sizeDelta.x, this.m_YMax);
        }



        // start the do "do your thing" thing
        protected void OnEnable()
        {
            StartCoroutine(this.Do());
        }

        /// <summary>
        /// <strong><em>DO your thing: </em></strong> Scroll the credits
        /// </summary>
        protected IEnumerator Do()
        {
            // the delay to start the scrolling
            yield return new WaitForSeconds(this.m_Delay);

            // calculate speed based on screen height
            float fScreenSpeed = Screen.height / this.m_Height;

            // start from the begginng
            this.m_YCurrent = 0.0f;

            // send the content to the beggining
            this.m_Content.anchoredPosition = new Vector2(0, this.m_YCurrent);

            // while there are still content
            while (this.m_Content.offsetMin.y < 0 )
            {
                // move it 
                this.m_Content.anchoredPosition = new Vector2(0, (this.m_YCurrent++ * this.m_Speed * fScreenSpeed));

                // return, it is like a void
                yield return null;
            }

            // return, it is like a void
            yield return null;
        }

    }
}