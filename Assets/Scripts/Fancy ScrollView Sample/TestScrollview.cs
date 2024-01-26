using FancyScrollView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class TestScrollview : FancyScrollView<TestCellData>
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Scroller scroller;

    protected override GameObject CellPrefab => cellPrefab;

    protected override void Initialize()
    {
        base.Initialize();
        scroller.OnValueChanged(UpdatePosition);
        scroller.OnSelectionChanged(UpdateSelection);
    }

    void UpdateSelection(int index)
    {
        Refresh();
    }

    public void UpdateData(List<TestCellData> datas)
    {
        UpdateContents(datas);
        scroller.SetTotalCount(datas.Count);
    }
}
