using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev.Missions
{
	public class VRG_Game : VRG_Base
	{

		[Tooltip("My Home Scene")]
		[SerializeField] [SceneName] private string m_Home = "";

		[Header("From: Social Media")]
		[Tooltip("Your twitter username that will appear after the https://twitter.com/[YOUR_TWITTER_PAGE_NAME]")]
		[SerializeField] private string m_Twitter = "[YOUR_TWITTER_PAGE_NAME]";
		// VrGamesDev

		[Tooltip("Facebook page after the https://facebook.com/[YOUR_FACEBOOK_PAGE_ID]")]
		[SerializeField] private string m_Facebook = "[YOUR_FACEBOOK_PAGE_ID]";
		// Broken-Reality-Online-59102545769

		[Tooltip("if you give support by email")]
		[SerializeField] private string m_Mail = "[YOUR_SUPPORT_EMAIL]";

		[Tooltip("if you want to show your players your company")]
		[SerializeField] private string m_Web = "[YOUR_WEBCOMPANY_URL]";


		[Header("From: Campaing")]
		[Tooltip("The total missions in your game")]
		[SerializeField] private int m_MissionTotal = 3;
		[SerializeField] public static int missionTotal { get { return Instance.m_MissionTotal; } }

		[Tooltip("The missions shown per page")]
		[SerializeField] private int m_MissionPerPages = 3;
		[SerializeField] public static int missionPerPages { get { return Instance.m_MissionPerPages; } }


		

		[Header("From: Text")]
		[SerializeField] private Font m_Font;
		[SerializeField] public static Font font { get { return Instance.m_Font; } }

		[SerializeField] private Color m_BackgroundColor = new Color(0.792f, 0.282f, 0.537f, 0.961f); // 49, 72, 137
		[SerializeField] public static Color backgroundColor { get { return Instance.m_BackgroundColor; } set { Instance.m_BackgroundColor = value; } }



		[Header("From: Icon")]
		[SerializeField] private Color m_IconBackground = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		[SerializeField] public static Color iconBackground { get { return Instance.m_IconBackground; } set { Instance.m_IconBackground = value; } }

		[SerializeField] private Color m_IconColor = new Color(0.192f, 0.282f, 0.537f, 1.0f); 
		[SerializeField] public static Color iconColor { get { return Instance.m_IconColor; } set { Instance.m_IconColor = value; } }

		[SerializeField] private Color m_IconText = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		[SerializeField] public static Color iconText { get { return Instance.m_IconText; } set { Instance.m_IconText = value; } }



		[Header("From: Button")]
		[SerializeField] private Color m_ButtonText = new Color(0.20f, 0.20f, 0.20f, 1.0f);
		[SerializeField] public static Color buttonText { get { return Instance.m_ButtonText; } set { Instance.m_ButtonText = value; } }

		[SerializeField] private Color m_ButtonNormal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		[SerializeField] public static Color buttonNormal { get { return Instance.m_ButtonNormal; } set { Instance.m_ButtonNormal = value; } }

		[SerializeField] private Color m_ButtonHighlighted = new Color(0.80f, 0.80f, 0.80f, 1.0f);
		[SerializeField] public static Color buttonHighlighted { get { return Instance.m_ButtonHighlighted; } set { Instance.m_ButtonHighlighted = value; } }

		[SerializeField] private Color m_ButtonPressed = new Color(0.7f, 0.7f, 0.7f, 1.0f);
		[SerializeField] public static Color buttonPressed { get { return Instance.m_ButtonPressed; } set { Instance.m_ButtonPressed = value; } }

		[SerializeField] private Color m_ButtonSelected = new Color(0.80f, 0.80f, 0.80f, 1.0f);
		[SerializeField] public static Color buttonSelected { get { return Instance.m_ButtonSelected; } set { Instance.m_ButtonSelected = value; } }

		[SerializeField] private Color m_ButtonDisabled = new Color(0.65f, 0.65f, 0.65f, 0.50f);
		[SerializeField] public static Color buttonDisabled { get { return Instance.m_ButtonDisabled; } set { Instance.m_ButtonDisabled = value; } }




		[Header("From: Audio")]
		[Tooltip("The base AudioMixer")]
		[SerializeField] private AudioMixer m_AudioMixer;
		//[SerializeField] public static AudioMixer audioMixer { get { return Instance.m_AudioMixer; } }

		[Tooltip("The music group volume array")]
		[Range(-80.0f, 20.0f)]
		[SerializeField] private List<float> m_AudioVolumes;








		[Header("FROM Debug:  - DO NOT EDIT unless you understand what is going on - ")]

		[Tooltip("Twitter URL")]
		[SerializeField] private string m_UrlTwitter = "https://twitter.com/";

		[Tooltip("Facebook URL")]
		[SerializeField] private string m_UrlFacebook = "https://facebook.com/";

		[Tooltip("The max level of the campaing")]
		[SerializeField] private int m_CampaingMax = 0;

		[Tooltip("Current level loaded")]
		[SerializeField] private int m_CampaingCurrent = 0;

		[Tooltip("Total possible")]
		[SerializeField] private int m_CampaingTotal = 0;

		[Tooltip("The levels with stars")]
		[SerializeField] private string m_CampaingStars = "";



		// singletoning Pattern
		public static VRG_Game Instance; void Awake()
		{
			// Checking if I am the first instance
			if (Instance == null)
			{
				// I am the one
				Instance = this;

				// ... and I will live forever
				DontDestroyOnLoad(this);

				if (this.m_AudioMixer == null)
                {
					WAS_FullName("VRG_GAME needs an AudioMixer");
                }
                else
                {
					float fVolume;

					for (int i = 0; i < (int)ENUM_AudioMixer.COUNT; i++)
                    {
						this.m_AudioMixer.GetFloat(VRG_DataBase.GetAudioMixerGroup(i), out fVolume);

						this.m_AudioVolumes.Add(fVolume);
                    }
				}
			}
			else
			{
				// I am not worthy
				Destroy(this.gameObject);
			}
		}

		private new void Start()
        {
			base.Start();

			this.InitVolumes();
		}


		private void InitVolumes()
        {
			for (int i = 0; i < (int)ENUM_AudioMixer.COUNT; i++)
			{
				VRG_Game.Mute(i, VRG_Session.GetBool("Mute", VRG_DataBase.GetAudioMixerGroup(i)));
			}
		}


		public static void Mute(ENUM_AudioMixer audioLocal, bool valueLocal) => VRG_Game.Mute((int)audioLocal, valueLocal);
		public static void Mute(int audioLocal, bool valueLocal)
		{
			float fVolume = Instance.m_AudioVolumes[audioLocal];
			if (valueLocal)
            {
				fVolume = -80;
			}

			Instance.m_AudioMixer.SetFloat(VRG_DataBase.GetAudioMixerGroup(audioLocal), fVolume);

			VRG_Session.SetBool("Mute", VRG_DataBase.GetAudioMixerGroup(audioLocal), valueLocal);

		}








		public static void OpenUrl(ENUM_ExternalURL valueLocal)
        {
			string sWWW = "";

			switch (valueLocal)
            {
				case ENUM_ExternalURL.TWITTER:
					sWWW = Instance.m_UrlTwitter + Instance.m_Twitter;
					break;

				case ENUM_ExternalURL.FACEBOOK:
					sWWW = Instance.m_UrlFacebook + Instance.m_Facebook;
					break;
			}

			if (sWWW != "")
            {
				VRG_Game.OpenUrl(sWWW);
			}
		}
		public static void OpenUrl(string valueLocal)
		{
			Application.OpenURL(System.Uri.EscapeUriString(valueLocal));
		}






		public static bool Integrity()
		{
			bool bReturn = true;

			Instance.m_CampaingMax = VRG_Session.GetInt("Campaign", "Max");
			Instance.m_CampaingCurrent = VRG_Session.GetInt("Campaign", "Current");
			Instance.m_CampaingTotal = VRG_Session.GetInt("Campaign", "Total");

			if (
					Instance.m_CampaingCurrent > Instance.m_CampaingTotal
					|| Instance.m_CampaingMax > Instance.m_CampaingTotal
					|| Instance.m_CampaingCurrent > Instance.m_CampaingMax + 1
					|| Instance.m_CampaingCurrent < 1
				)
			{
				bReturn = false;
			}

			return bReturn;
		}

		public static void Pass()
		{
			Instance.m_CampaingMax = VRG_Session.GetInt("Campaign", "Max");
			Instance.m_CampaingCurrent = VRG_Session.GetInt("Campaign", "Current");
			Instance.m_CampaingTotal = VRG_Session.GetInt("Campaign", "Total");

			if (Instance.m_CampaingCurrent + 1 > Instance.m_CampaingTotal || Instance.m_CampaingMax > Instance.m_CampaingTotal)
			{
				print("HAK_Scenes.Load(Instance.m_Home);");
			}
			else
			{
				if (Instance.m_CampaingCurrent > Instance.m_CampaingMax)
				{
					Instance.m_CampaingMax = Instance.m_CampaingCurrent;
					VRG_Session.SetInt("Campaign", "Max", Instance.m_CampaingMax);
				}
			}
		}

		public static void Star()
		{
			Instance.m_CampaingMax = VRG_Session.GetInt("Campaign", "Max");
			Instance.m_CampaingCurrent = VRG_Session.GetInt("Campaign", "Current");
			Instance.m_CampaingStars = VRG_Session.GetString("Campaign", "Stars");
			Instance.m_CampaingTotal = VRG_Session.GetInt("Campaign", "Total");

			if (!Instance.m_CampaingStars.Contains("|" + Instance.m_CampaingCurrent + "|"))
			{
				Instance.m_CampaingStars = "|" + Instance.m_CampaingCurrent + "|" + Instance.m_CampaingStars;
								    	   
				VRG_Session.SetString("Campaign", "Stars", Instance.m_CampaingStars);

				VRG_Session.Add("Campaign", "StarTotal");
			}
			VRG_Game.Pass();
		}

		public static void Next()
		{
			Instance.m_CampaingCurrent = VRG_Session.Add("Campaign", "Current");
		}

		public static void Retry()
		{
			//Instance.m_CampaingCurrent = VRG_Session.Add("Campaign", "Current");
		}




	}
}