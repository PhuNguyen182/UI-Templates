using System.Collections;
using System.Collections.Generic;
using UITemplates.Scrollers.Data;
using UITemplates.Scrollers.Infinity;
using UnityEngine;

public class ExampleScrollView : MonoBehaviour
{
    [SerializeField] private List<TestData> testDatas;
    [SerializeField] private HorizontalInfinityScroller scroller;

    private void Start()
    {
        scroller.SetDataCollection(testDatas);
        scroller.gameObject.SetActive(true);
    }
}
