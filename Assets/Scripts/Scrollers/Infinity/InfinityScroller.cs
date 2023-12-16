using System.Collections;
using System.Collections.Generic;
using UITemplates.Scrollers.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UITemplates.Scrollers.Infinity
{
    public abstract class InfinityScroller : MonoBehaviour
    {
        [SerializeField] protected ScrollRect scrollRect;
        [SerializeField] protected ElementCell cellPrefab;
        [SerializeField] protected RectTransform viewportTransform;
        [SerializeField] protected RectTransform contentTransform;

        protected int itemToAdd = 0;
        protected bool isUpdated = false;
        protected Vector2 oldVelocity;
        protected List<TestData> elementDatas;

        private IEnumerator Start()
        {
            yield return null;

            CalculateItemToAdd();
            SpawnElement();
            CalculateStartPosition();
        }

        private void Update()
        {
            ResetUpdate();
            UpdatePosition();
        }

        protected void SpawnElement()
        {
            for (int i = 0; i < itemToAdd; i++)
            {
                var item = SimplePool.Spawn(cellPrefab);
                item.transform.localScale = Vector3.one;
                item.transform.SetParent(contentTransform, false);
                item.RectTransform.SetAsLastSibling();
                item.SetData(elementDatas[i % elementDatas.Count]);
            }

            for (int i = 0; i < itemToAdd; i++)
            {
                int num = elementDatas.Count - i - 1;

                while (num < 0)
                {
                    num += elementDatas.Count;
                }

                var item = SimplePool.Spawn(cellPrefab);
                item.transform.localScale = Vector3.one;
                item.transform.SetParent(contentTransform, false);
                item.RectTransform.SetAsFirstSibling();
                item.SetData(elementDatas[num]);
            }
        }

        protected void ForceUpdate()
        {
            Canvas.ForceUpdateCanvases();
            oldVelocity = scrollRect.velocity;
            isUpdated = true;
        }

        protected void ResetUpdate()
        {
            if (isUpdated)
            {
                isUpdated = false;
                scrollRect.velocity = oldVelocity;
            }
        }

        protected abstract void CalculateItemToAdd();
        protected abstract void UpdatePosition();
        protected abstract void CalculateStartPosition();

        public void SetDataCollection(List<TestData> datas)
        {
            elementDatas = datas;
        }
    }
}
