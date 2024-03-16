using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EasingCore;

namespace Test {
    public class ScrollRectExample : MonoBehaviour
    {
        [SerializeField] private TestScrollRect scrollRect;

        private List<TestCellData> data;
        private WaitForSeconds waitForSeconds = new WaitForSeconds(2.5f);

        private void Start()
        {
            GenerateData();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                scrollRect.ScrollTo(20, 1, Ease.Linear, Alignment.Middle);
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
