using UnityEngine;
using UnityEngine.SceneManagement;

namespace VrGamesDev.Missions
{
    public class VRG_Managers : VRG_Base
    {
        [SerializeField] private string m_GameManager = "VRG_Game";
        [SerializeField] [SceneName] private string m_Managers = "Managers";

        // Use this for initialization
        // para decirle al engine que es una funcion nueva
        private void Awake()
        {
            // I'm your father
            base.Start();

            // just do it if a manager is defined
            if (this.m_GameManager.Trim() != "")
            {
                // call scene to know when it is loaded
                SceneManager.sceneLoaded += OnSceneLoaded;

                // by default it's not
                bool bLoadTheCore = false;

                // try to find the main GameObject to
                if (GameObject.Find(this.m_GameManager) == null)
                {
                    bLoadTheCore = true;
                }

                // load or destroy this object 
                if (bLoadTheCore)
                {
                    SceneManager.LoadScene(this.m_Managers, LoadSceneMode.Additive);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }

        }

        // Destroy on call
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == this.m_Managers && this != null)
            {
                Destroy(this.gameObject);
            }
        }

    }
}