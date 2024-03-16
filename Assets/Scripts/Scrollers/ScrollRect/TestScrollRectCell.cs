using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FancyScrollView;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

namespace Test
{
    partial class TestScrollRectCell : FancyScrollRectCell<TestCellData, Context>
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button button;
        [SerializeField] private RectTransform cellRect;
        [SerializeField] private Animator cellAnimator;

        private static int _isScrollableHash = Animator.StringToHash("IsScalable");
        private static int _normalScrollHash = Animator.StringToHash("Normal Scroll");
        private static int _scalableScrollHash = Animator.StringToHash("Scalable Scroll");

        private TestCellData _cellData;
        private Tween changeCellTween;
        private float position;
        private int currentStateHash;
        private bool _isScrollable = false;

        private void OnEnable()
        {
            UpdatePosition(position);
            TestScrollRect.OnCellAnimationSwitch += ChangeAnimation;
        }

        public override void Initialize()
        {
            button.onClick.AddListener(() => Context.OnCellClicked?.Invoke(Index));
        }

        public override void UpdateContent(TestCellData itemData)
        {
            _cellData = itemData;
            text.text = $"Item: {_cellData.Number}";
        }

        public override void UpdatePosition(float position)
        {
            if (cellAnimator.isActiveAndEnabled)
            {
                cellAnimator.Play(currentStateHash, 0, position);
                cellAnimator.speed = 0;
            }

            this.position = position;
        }

        private void ChangeAnimation(bool isScrollable)
        {
            currentStateHash = isScrollable ? _scalableScrollHash : _normalScrollHash;
            cellAnimator.SetBool(_isScrollableHash, isScrollable);
        }

        private void CreateTween()
        {
            changeCellTween ??= cellRect.DOSizeDelta(new Vector2(650, 100), 0.25f)
                                        .SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo);
        }

        private void OnDisable()
        {
            TestScrollRect.OnCellAnimationSwitch -= ChangeAnimation;
        }

        private void OnDestroy()
        {
            changeCellTween?.Kill();
        }
    }
}
