using UnityEngine;

namespace CharacterEditor
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MeshRenderer m_Head;
        [SerializeField] private MeshRenderer m_Body;
        [SerializeField] private MeshRenderer m_ArmR;
        [SerializeField] private MeshRenderer m_ArmL;
        [SerializeField] private MeshRenderer m_LegR;
        [SerializeField] private MeshRenderer m_LegL;

        private void Start()
        {
            Load();
        }

        public void Load()
        {
            //Load materials from the MaterialManager and pass in the id pulled from each PlayerPref here
            m_Head.material = MaterialManager.Get(BodyTypes.Head, PlayerPrefs.GetInt("HeadMaterialID", 1));
            m_Body.material = MaterialManager.Get(BodyTypes.Body, PlayerPrefs.GetInt("BodyMaterialID", 1));
            m_ArmR.material = MaterialManager.Get(BodyTypes.Arm, PlayerPrefs.GetInt("ArmMaterialID", 1));
            m_ArmL.material = MaterialManager.Get(BodyTypes.Arm, PlayerPrefs.GetInt("ArmMaterialID", 1));
            m_LegR.material = MaterialManager.Get(BodyTypes.Leg, PlayerPrefs.GetInt("LegMaterialID", 1));
            m_LegL.material = MaterialManager.Get(BodyTypes.Leg, PlayerPrefs.GetInt("LegMaterialID", 1));
        }
    }
}