using System.Collections;
using System.Collections.Generic;
using UITemplates.Scrollers.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UITemplates.Scrollers.Infinity
{
    public class VerticalInfinityScroller : InfinityScroller
    {
        [SerializeField] private VerticalLayoutGroup verticalLayout;

        protected override void CalculateItemToAdd()
        {
            itemToAdd = Mathf.CeilToInt(viewportTransform.rect.height /
                                        (cellPrefab.RectTransform.rect.height + verticalLayout.spacing));
        }

        protected override void CalculateStartPosition()
        {
            contentTransform.localPosition = new Vector3
            (
                contentTransform.localPosition.x,
                -cellPrefab.RectTransform.rect.height + verticalLayout.spacing,
                contentTransform.localPosition.z
            );
        }

        protected override void UpdatePosition()
        {
            if (contentTransform.localPosition.y > 0)
            {
                ForceUpdate();
                contentTransform.localPosition -= new Vector3(0, elementDatas.Count *
                                                             (cellPrefab.RectTransform.rect.height + verticalLayout.spacing), 0);
            }

            else if (contentTransform.localPosition.y < -elementDatas.Count *
                                                        (cellPrefab.RectTransform.rect.height + verticalLayout.spacing))
            {
                ForceUpdate();
                contentTransform.localPosition += new Vector3(0, elementDatas.Count *
                                                                 (cellPrefab.RectTransform.rect.height + verticalLayout.spacing), 0);
            }
        }
    }
}
