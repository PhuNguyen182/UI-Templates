using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FancyScrollView;
using EasingCore;
using System;

namespace Test
{
    class Context : FancyScrollRectContext
    {
        public int SelectedIndex = -1;
        public Action<int> OnCellClicked;
    }

    public enum Alignment
    {
        Upper,
        Middle,
        Lower,
    }

    partial class TestScrollRect : FancyScrollRect<TestCellData, Context>
    {
        [SerializeField] private Scroller scroller;
        [SerializeField] private float cellSize;
        [SerializeField] private GameObject cellPrefab;
        [SerializeField] private TestScrollRectCell pivotCell;

        private bool _isChange = false;
        private TestScrollRectCell rectCell;

        protected override float CellSize => cellSize;

        protected override GameObject CellPrefab => cellPrefab;

        public static event Action<bool> OnCellAnimationSwitch;

        public float PaddingTop
        {
            get => paddingHead;
            set
            {
                paddingHead = value;
                Relayout();
            }
        }

        public float PaddingBottom
        {
            get => paddingTail;
            set
            {
                paddingTail = value;
                Relayout();
            }
        }

        public float Spacing
        {
            get => spacing;
            set
            {
                spacing = value;
                Relayout();
            }
        }

        private void OnEnable()
        {
            TestScrollRectCell.OnCellSelected += SetPlayerCell;
        }

        private void OnDisable()
        {
            TestScrollRectCell.OnCellSelected -= SetPlayerCell;
        }

        private void ExecuteCell()
        {
            if (rectCell != null)
            {
                pivotCell.gameObject.SetActive(rectCell.Position >= 0.9f);
            }
        }

        private void SetPlayerCell(TestScrollRectCell testCell)
        {
            rectCell = testCell;
            ExecuteCell();
        }

        public void UpdateData(IList<TestCellData> items)
        {
            UpdateContents(items);
        }

        public void ScrollTo(int index, float duration, Ease easing, Alignment alignment = Alignment.Middle)
        {
            UpdateSelection(index);
            ScrollTo(index, duration, easing, GetAlignment(alignment));
        }

        public void JumpTo(int index, Alignment alignment = Alignment.Middle)
        {
            UpdateSelection(index);
            JumpTo(index, GetAlignment(alignment));
        }

        private float GetAlignment(Alignment alignment)
        {
            switch (alignment)
            {
                case Alignment.Upper: return 0.0f;
                case Alignment.Middle: return 0.5f;
                case Alignment.Lower: return 1.0f;
                default: return GetAlignment(Alignment.Middle);
            }
        }

        public void UpdateSelection(int index)
        {
            if (Context.SelectedIndex == index)
            {
                return;
            }

            Context.SelectedIndex = index;
            Refresh();
        }

        public void SelectCell(int index)
        {
            if (index < 0 || index >= ItemsSource.Count || index == Context.SelectedIndex)
            {
                return;
            }

            UpdateSelection(index);
            scroller.ScrollTo(index, 2.5f, Ease.InOutSine);
        }
    }
}
