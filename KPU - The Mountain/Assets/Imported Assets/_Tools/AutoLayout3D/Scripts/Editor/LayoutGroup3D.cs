using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoLayout3D
{
    public abstract class LayoutGroup3D : LayoutElement3D
    {
        [Header(" ")]
        public Padding padding;

        protected List<LayoutElement3D> elementList = new List<LayoutElement3D>();

        protected abstract void UpdateLayout();

        private void Update()
        {
            UpdateLayout();
        }
    }
}