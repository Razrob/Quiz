using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    public class GameFinalizer : SystemBase
    {
        [SerializeField] private float targetAlfa;
        [SerializeField] private float duration;
        [SerializeField] private Button _resetButton;
        [SerializeField] private Image _darkScreen;

        protected override void Initialize()
        {
            if (commonData.SessionProcessData.LevelNumber != 3)
                return;

            commonData.UserInteractData.OnCorrectChoiceReceive += OnCorrectChoiceReceive;
            _resetButton.onClick.AddListener(OnReset);
        }

        private void OnCorrectChoiceReceive(CellData cellData)
        {
            _darkScreen.gameObject.SetActive(true);
            _darkScreen.DOColor(_darkScreen.color.SetAlfa(targetAlfa), duration)
                .OnComplete(() => _resetButton.gameObject.SetActive(true));
        }

        private void OnReset()
        {
            _resetButton.onClick.RemoveListener(OnReset);
            commonData.UserInteractData.OnCorrectChoiceReceive -= OnCorrectChoiceReceive;

            _resetButton.gameObject.SetActive(false);
            _darkScreen.gameObject.SetActive(false);
            _darkScreen.color = _darkScreen.color.SetAlfa(0f);

            attachedBootstrap.Reload();
        }
    }
}