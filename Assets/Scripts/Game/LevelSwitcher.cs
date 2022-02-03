using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    public class LevelSwitcher : SystemBase
    {
        [SerializeField] private float _switchDelay;

        protected override void Initialize()
        {
            if (commonData.SessionProcessData.LevelNumber == 3)
                return;

            commonData.UserInteractData.OnCorrectChoiceReceive += OnCorrectChoiceReceive;
        }

        private void OnCorrectChoiceReceive(CellData cellData)
        {
            commonData.UserInteractData.OnCorrectChoiceReceive -= OnCorrectChoiceReceive;

            DOTween.To(() => 0f, value => { }, 1f, _switchDelay)
                .OnComplete(() => attachedBootstrap.Reload());
        }
    }
}