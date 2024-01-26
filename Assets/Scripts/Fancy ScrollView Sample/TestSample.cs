using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestSample : MonoBehaviour
{
    [SerializeField] private TestScrollview scrollview;

    private void Start()
    {
        var data = Enumerable.Range(0, 20)
                   .Select(i => new TestCellData { Number = i })
                   .ToList();
        scrollview.UpdateData(data);
    }
}
