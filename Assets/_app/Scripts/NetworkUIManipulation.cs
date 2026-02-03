using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

namespace MCounter
{
    public class NetworkUIManipulation : MonoBehaviour
    {
        [SerializeField] private UIDocument m_uiDocument;
        [SerializeField] private NetworkManager m_networkManager;
        private Button m_startButton, m_joinButton, m_exitButton;

        private void Awake()
        {
            m_startButton = m_uiDocument.rootVisualElement.Q("host_lobby") as Button;
            m_joinButton = m_uiDocument.rootVisualElement.Q("join_lobby") as Button;
            m_exitButton = m_uiDocument.rootVisualElement.Q("shut") as Button;
        }

        private void OnEnable()
        {
            m_startButton.clicked += () =>
            {
                m_networkManager.StartHost();
            };

            m_joinButton.clicked += () =>
            {
                m_networkManager.StartClient();
            };

            m_exitButton.clicked += () =>
            {
                m_networkManager.Shutdown();  
            };
        }
    }
}