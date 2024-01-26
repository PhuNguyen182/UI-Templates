using FancyScrollView;
using FancyScrollView.Example03;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

partial class TestCell : FancyCell<TestCellData>
{
    [SerializeField] private Animator cellAnimator;
    [SerializeField] private TMP_Text messageText;

    private float _currentPosition = 0;

    private static int _scrollHask = Animator.StringToHash("Scroll");

    private void OnEnable()
    {
        UpdatePosition(_currentPosition);
    }

    public override void UpdateContent(TestCellData itemData)
    {
        messageText.text = $"{itemData.Number}";
    }

    public override void UpdatePosition(float position)
    {
        _currentPosition = position;

        if (cellAnimator.isActiveAndEnabled)
        {
            cellAnimator.Play(_scrollHask, 0, position);
        }

        cellAnimator.speed = 0;
    }
}
