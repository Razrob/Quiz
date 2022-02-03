using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace Quiz
{
    public class EffectsProducer : SystemBase
    {
        [SerializeField] private AnimationCurve _correctBounceCurve;
        [SerializeField] private float _correctBounceDuration;

        [SerializeField] private float _incorrectEffectDuration;
        [SerializeField] private float _incorrectEffectStrength;
        [SerializeField] private int _incorrectEffectVibrato;

        private bool _effectInProgress;

        protected override void Initialize()
        {
            commonData.UserInteractData.OnCorrectChoiceReceive += OnCorrectChoiceReceive;
            commonData.UserInteractData.OnIncorrectChoiceReceive += OnIncorrectChoiceReceive;
        }

        private void OnCorrectChoiceReceive(CellData cellData)
        {
            if (_effectInProgress)
                return;

            _effectInProgress = true;

            CellPresenter cellPresenter = cellData.AttachedCellPresenter;
            DOTween.To(() => 0f, time => cellPresenter.Image.transform.localScale = Vector3.one * _correctBounceCurve.Evaluate(time),
                1f, _correctBounceDuration)
                .OnComplete(() => _effectInProgress = false);
        }

        private void OnIncorrectChoiceReceive(CellData cellData)
        {
            if (_effectInProgress)
                return;

            _effectInProgress = true;

            CellPresenter cellPresenter = cellData.AttachedCellPresenter;
            cellPresenter.Image.transform.DOShakePosition(_incorrectEffectDuration, _incorrectEffectStrength, _incorrectEffectVibrato)
                .OnComplete(() => _effectInProgress = false);
        }
    }
}