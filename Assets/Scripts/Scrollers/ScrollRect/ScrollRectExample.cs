using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EasingCore;
using FancyScrollView;

namespace Test {
    public class ScrollRectExample : MonoBehaviour
    {
        [SerializeField] private Ease ease;
        [SerializeField] private TestScrollRect scrollRect;

        private List<TestCellData> data;

        private void Start()
        {
            GenerateData();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                int rand = Random.Range(0, 49);
                Debug.Log(rand);
                scrollRect.ScrollTo(rand, 1, ease, Alignment.Middle);
            }
        }

        private void GenerateData()
        {
            data = Enumerable.Range(0, 50)
                   .Select(x => new TestCellData { Number = x })
                   .ToList();
            scrollRect.UpdateData(data);
        }

        private void Swap(int from, int to)
        {
            (data[from], data[to]) = (data[to], data[from]);
        }
    }
}
