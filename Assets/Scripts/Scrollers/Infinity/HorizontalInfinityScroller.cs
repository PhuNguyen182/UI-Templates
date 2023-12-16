using System.Collections;
using System.Collections.Generic;
using UITemplates.Scrollers.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UITemplates.Scrollers.Infinity
{
    public class HorizontalInfinityScroller : InfinityScroller
    {
        [SerializeField] private HorizontalLayoutGroup horizontalLayout;

        protected override void CalculateItemToAdd()
        {
            itemToAdd = Mathf.CeilToInt(viewportTransform.rect.width /
                                        (cellPrefab.RectTransform.rect.width + horizontalLayout.spacing));
        }

        protected override void CalculateStartPosition()
        {
            contentTransform.localPosition = new Vector3
                (
                    -cellPrefab.RectTransform.rect.width + horizontalLayout.spacing,
                    contentTransform.localPosition.y,
                    contentTransform.localPosition.z
                );
        }

        protected override void UpdatePosition()
        {
            if (contentTransform.localPosition.x > 0)
            {
                ForceUpdate();
                contentTransform.localPosition -= new Vector3(elementDatas.Count *
                                                             (cellPrefab.RectTransform.rect.width + horizontalLayout.spacing), 0, 0);
            }

            else if (contentTransform.localPosition.x < -elementDatas.Count *
                                                        (cellPrefab.RectTransform.rect.width + horizontalLayout.spacing))
            {
                ForceUpdate();
                contentTransform.localPosition += new Vector3(elementDatas.Count *
                                                             (cellPrefab.RectTransform.rect.width + horizontalLayout.spacing), 0, 0);
            }
        }
    }
}
