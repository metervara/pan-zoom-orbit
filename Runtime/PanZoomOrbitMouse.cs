using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metervara.Interaction
{
    public class PanZoomOrbitMouse : PanZoomOrbit
    {
        public float zoomSpeed = 1;
        public float orbitSpeed = 10;
        private bool isDragging = false;
        private Vector3 previousMousePosition;
        private Vector3 startMousePosition;
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                previousMousePosition = Input.mousePosition;
                startMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

            if (isDragging)
            {
                Pan(previousMousePosition, Input.mousePosition);
                previousMousePosition = Input.mousePosition;
            }

            if (scrollDelta != 0 && Input.GetKey(KeyCode.LeftAlt))
            {
                Zoom(Input.mousePosition, scrollDelta * zoomSpeed);
            }

            if (scrollDelta != 0 && Input.GetKey(KeyCode.LeftControl))
            {
                Orbit(Input.mousePosition, scrollDelta * orbitSpeed);
            }
        }
    }
}