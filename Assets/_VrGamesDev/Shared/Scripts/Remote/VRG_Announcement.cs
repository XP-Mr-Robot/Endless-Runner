using System.Collections;
        /// <summary>



        //[Header("From: UI")]
        [Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]

        /// <summary>

        /// <summary>



        [Header("From: Settings")]
        //[SerializeField]
        private string m_Settings_Repeat = "VRG_Announcement.repeat";

        [Tooltip("From VRG_Remote: The date, this is when the anncouncement was made")]
        //[SerializeField]
        private string m_Settings_Date = "VRG_Announcement.date";
        //[SerializeField]
        private string m_Settings_Title = "VRG_Announcement.title";
        //[SerializeField]
        private string m_Settings_Body = "VRG_Announcement.body";



        private void OnEnable()
            this.UI_Activate(false);

            // play the waits and delays
            StartCoroutine(OnEnable_IEnumerator());
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

            yield return null;

            bool bShow = false;

            this.StopRemoteData();
