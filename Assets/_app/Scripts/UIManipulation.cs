using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace MCounter
{
    public class UIManipulation : MonoBehaviour
    {
        public static UIManipulation Singleton;

        [SerializeField] private UIDocument m_uiDocument;
        private Label m_number;
        private Button m_countBtn, m_resetBtn;

        private void Awake()
        {
            Singleton = this;
            Initialize();
        }

        private void Initialize()
        {
            m_number = m_uiDocument.rootVisualElement.Q("number") as Label;
            m_countBtn = m_uiDocument.rootVisualElement.Q("count_btn") as Button;
            m_resetBtn = m_uiDocument.rootVisualElement.Q("reset_btn") as Button;
        }

        public void SetNumber(int val) => m_number.text = val.ToString();
        public void ButtonCountListener(Action callback) => m_countBtn.clicked += callback;
        public void ButtonResetListener(Action callback) => m_resetBtn.clicked += callback;
    }
}