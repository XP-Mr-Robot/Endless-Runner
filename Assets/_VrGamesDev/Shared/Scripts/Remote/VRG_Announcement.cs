using System.Collections;using UnityEngine;using UnityEngine.UI;namespace VrGamesDev{    /// <summary>    /// This class retrieve the cloud server Remote config data    /// and display a full screen pop up announcement to the user    /// Just drop the prefab in the scene you want to display the announcement    /// </summary>    public class VRG_Announcement : VRG_Base    {
        /// <summary>        /// From UI: The Body text container        /// </summary>        [Tooltip("From UI: The Body text container")]        [SerializeField] private float m_ContentHeight = 500.0f;



        //[Header("From: UI")]
        [Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]

        /// <summary>        /// From UI: The Body text container        /// </summary>        [Tooltip("From UI: The Body text container")]        [SerializeField] private RectTransform m_Content = null;

        /// <summary>        /// From UI: The date text container        /// </summary>        [Tooltip("From UI: The date text container")]        [SerializeField] private Text m_UI_Date = null;        /// <summary>        /// From UI: The Title text container        /// </summary>        [Tooltip("From UI: The Title text container")]        [SerializeField] private Text m_UI_Title = null;                /// <summary>        /// From UI: The Body text container        /// </summary>        [Tooltip("From UI: The Body text container")]        [SerializeField] private Text m_UI_Body = null;



        [Header("From: Settings")]        [Tooltip("From VRG_Remote: How many times will show to the user, 0 for infinite")]
        //[SerializeField]
        private string m_Settings_Repeat = "VRG_Announcement.repeat";

        [Tooltip("From VRG_Remote: The date, this is when the anncouncement was made")]
        //[SerializeField]
        private string m_Settings_Date = "VRG_Announcement.date";        [Tooltip("From VRG_Remote: The title of the current anncouncement")]
        //[SerializeField]
        private string m_Settings_Title = "VRG_Announcement.title";        [Tooltip("From VRG_Remote: The body of the message")]
        //[SerializeField]
        private string m_Settings_Body = "VRG_Announcement.body";



        private void OnEnable()        {
            this.UI_Activate(false);

            // play the waits and delays
            StartCoroutine(OnEnable_IEnumerator());        }        // when activated Do your thing, load the scene        private IEnumerator OnEnable_IEnumerator()        {
            yield return null;
            yield return null;

            this.GetRemoteData();
            this.m_Content.offsetMax = new Vector2(this.m_Content.offsetMax.x, 0.0f);
            float fHeight = this.m_UI_Body.preferredHeight - this.m_ContentHeight;
            if (fHeight < 0.0f)
            {
                fHeight = 0.0f;
            }
            this.m_Content.sizeDelta = new Vector2(this.m_Content.sizeDelta.x, fHeight);
            // ... wait until next frame
            yield return null;        }
        // the function called when there is a remote setting        protected override void RemoteSettings_Remote()        {
            bool bShow = false;

            this.StopRemoteData();
            this.UI_Activate(true);            int iRepeat = VRG_Remote.GetInt(this.m_Settings_Repeat);            WAS_echo("INSIDE: " + this.m_Settings_Repeat + ") "+ iRepeat + " - " + Animator.StringToHash(iRepeat.ToString()) );            string sDate = VRG_Remote.GetString(this.m_Settings_Date).Trim();            WAS_echo("INSIDE: " + this.m_Settings_Date + ") " + sDate + " - " + Animator.StringToHash(sDate));            string sTitle = VRG_Remote.GetString(this.m_Settings_Title).Trim();            WAS_echo("INSIDE: " + this.m_Settings_Title + ") " + sTitle + " - " + Animator.StringToHash(sTitle));            string sBody = VRG_Remote.GetString(this.m_Settings_Body).Trim();            WAS_echo("INSIDE: " + this.m_Settings_Body + ") " + sBody + " - " + Animator.StringToHash(sBody));            int iLocalRepeat = VRG_Session.GetInt("VRG_Announcement", "repeat");            WAS_echo("INSIDE: " + iRepeat + " > " + iLocalRepeat);            int iHash = Animator.StringToHash(sDate + sTitle + sBody);            WAS_echo("Inside: Hash = " + iHash);            int sLocalHash = VRG_Session.GetInt("VRG_Announcement", "hash");            if (sLocalHash != iHash)            {                iLocalRepeat = 0;            }            if (                (iRepeat == 0 || iRepeat > iLocalRepeat)                && sDate != ""                && sTitle != ""                && sBody != ""                )            {                bShow = true;                this.m_UI_Date.text = sDate;                this.m_UI_Title.text = sTitle;                this.m_UI_Body.text = sBody.Replace("<br>", "\n");                if (sLocalHash != iHash)                {                    WAS_echo("sLocalHash = " + sLocalHash);                    VRG_Session.SetInt("VRG_Announcement", "hash", iHash);                    VRG_Session.SetInt("VRG_Announcement", "repeat", 1);                }                else                {                    WAS_echo("iLocalRepeat = " + iLocalRepeat);                    VRG_Session.Add("VRG_Announcement", "repeat");                }            }            this.UI_Activate(bShow);                    }        // Activate the slider and the messages of the UI        private void UI_Activate(bool valueLocal)        {            WAS_echo("UI_Activate turn = " + valueLocal, ENUM_Verbose.LOGS);            if (this != null)            {                if (this.transform != null && this.isActiveAndEnabled)                {                    foreach (Transform child in this.transform)                    {                        child.gameObject.SetActive(valueLocal);                    }                }            }        }    }}