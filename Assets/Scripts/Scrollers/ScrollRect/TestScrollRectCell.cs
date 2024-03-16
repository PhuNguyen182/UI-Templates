using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FancyScrollView;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

namespace Test
{
    partial class TestScrollRectCell : FancyScrollRectCell<TestCellData, Context>
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button button;
        [SerializeField] private RectTransform cellRect;
        [SerializeField] private Animator cellAnimator;

        private static readonly int _normalScrollHash = Animator.StringToHash("Normal Scroll");

        private float position;
        private TestCellData _cellData;

        public float Position => position;
        public TestCellData Data => _cellData;
        public static event Action<TestScrollRectCell> OnCellSelected;

        private void OnEnable()
        {
            UpdatePosition(position);
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
                cellAnimator.Play(_normalScrollHash, 0, position);
                cellAnimator.speed = 0;
            }

            this.position = position;

            if (_cellData != null && _cellData.Number == 20)
                OnCellSelected?.Invoke(this);
        }
    }
}
