using System.Collections;
using System.Collections.Generic;
using UITemplates.Scrollers.Data;
using UnityEngine;
using TMPro;

namespace UITemplates.Scrollers.Infinity
{
    public class ElementCell : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private TMP_Text numberText;

        private BaseElementData _data;

        public RectTransform RectTransform => rectTransform;

        public void SetData(BaseElementData data)
        {
            _data = data;
            ApplyData(_data);
        }

        private void ApplyData(BaseElementData data)
        {
            TestData testData = (TestData)data;
            numberText.text = $"{testData.Number}";
        }
    }
}
