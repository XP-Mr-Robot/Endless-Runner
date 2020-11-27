using System.Collections;

using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
    public class VRG_CampaignMisionPages : VRG_Base
    {
        [Header("From: Prefabs")]
        [SerializeField] private GameObject MissionPage = null;
        [SerializeField] private GameObject m_MissionButton = null;

        [Header("From: Components")]
        [SerializeField] private RectTransform m_RectTransform = null;
        [SerializeField] private GridLayoutGroup m_GridLayoutGroup = null;

        [Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]
        //[SerializeField]
        private bool m_FirstTime = true;
        //[SerializeField]
        private float m_PaddingX = 0.0f;
        //[SerializeField]
        private int m_Current = 0;
        //[SerializeField]
        private string m_Stars = "";
        //[SerializeField]
        private float m_Factor = 0.0f;





        // Use this for initialization use new to get 
        private new void Start()
        {
            // start your parent from VRG_Base
            base.Start();

            this.m_RectTransform = this.Encuentra(this.m_RectTransform);

            this.m_GridLayoutGroup = this.Encuentra(this.m_GridLayoutGroup);
        }



        // Use this for initialization use new to get 
        private void OnEnable()
        {
            bool bContinue = true;

            if (MissionPage == null)
            {
                bContinue = false;
                WAS_FullName("No mission group is defined");
            }

            if (m_MissionButton == null)
            {
                //bContinue = false;
                WAS_FullName("No mission button is defined");
            }

            if (bContinue)
            {
                // Start next frame, just in case you need at iterator
                StartCoroutine(this.OnEnable_IEnumerator());
            }
        }

        // Enumerator proxy
        private IEnumerator OnEnable_IEnumerator()
        {
            bool bStarCurrent = false;
            int iMissionGroupNumber = Mathf.CeilToInt((VRG_Game.missionTotal) / (float)VRG_Game.missionPerPages);
            int iCurrentMission = 0;


            if (this.m_FirstTime)
            {
                this.m_FirstTime = false;

                // init all the campaign variables
                VRG_Session.SetInt("Campaign", "Current", 1);
                VRG_Session.SetInt("Campaign", "Total", VRG_Game.missionTotal);
                this.m_Current = VRG_Session.GetInt("Campaign", "Max") + 1;


                // validate the total is not greater than allowed
                if (this.m_Current > VRG_Game.missionTotal)
                {
                    // if it is, reset it
                    this.m_Current = VRG_Game.missionTotal;
                    VRG_Session.SetInt("Campaign", "Max", this.m_Current);
                }

                this.m_Stars = VRG_Session.GetString("Campaign", "Stars");

                foreach(Transform child in this.transform)
                {
                    print(child.name);
                    Destroy(child.transform);
                }

                //Generate Missions
                for (int i = 0; i < iMissionGroupNumber; i++)
                {
                    GameObject MissionGroup = Instantiate(this.MissionPage, this.transform) as GameObject;

                    for (int j = 0; j < VRG_Game.missionPerPages; j++)
                    {
                        iCurrentMission++;
                        if (iCurrentMission > VRG_Game.missionTotal)
                        {
                            break;
                        }

                        GameObject GO_missionButton = Instantiate(this.m_MissionButton, MissionGroup.transform) as GameObject;

                        bStarCurrent = false;
                        if (this.m_Stars.Contains("|" + iCurrentMission + "|"))
                        {
                            bStarCurrent = true;
                        }

                        VRG_CampaignMisionButton MyClassButton = GO_missionButton.GetComponent<VRG_CampaignMisionButton>();
                        MyClassButton.Init(iCurrentMission, this.m_Current, bStarCurrent);                        
                    }
                    
                }

                
                //Adjust this
                this.m_Factor = (iMissionGroupNumber - 1) * this.m_GridLayoutGroup.cellSize.x + (iMissionGroupNumber - 1) * this.m_GridLayoutGroup.spacing.x;

                this.m_RectTransform.sizeDelta = new Vector2(this.m_Factor, 0);

                this.m_PaddingX = Mathf.Floor(this.m_Current / VRG_Game.missionPerPages)
                    * (this.m_GridLayoutGroup.cellSize.x + this.m_GridLayoutGroup.spacing.x) * (-1);

                this.m_RectTransform.anchoredPosition = new Vector2(this.m_PaddingX, 0);
            }

            // next frame
            yield return null;
        }
    }
}