using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metervara.Interaction
{
    [RequireComponent(typeof(Camera))]
    public class PanZoomOrbit : MonoBehaviour
    {
        public bool pan = true;
        public bool zoom = true;
        public bool orbit = true;
        public LayerMask layerMask;
        protected Camera _camera;
        protected Camera Camera
        {
            get
            {
                if(!_camera)
                {
                    _camera = GetComponent<Camera>();
                }
                return _camera;
            }
        }

        public void Pan(Vector3 fromScreenPosition, Vector3 toScreenPosition)
        {
            if(!pan)
            {
                return;
            }
            Ray rayFrom = Camera.ScreenPointToRay(fromScreenPosition);
            Ray rayTo = Camera.ScreenPointToRay(toScreenPosition);
            RaycastHit hitFrom, hitTo;
            if(Physics.Raycast(rayFrom, out hitFrom, Mathf.Infinity, layerMask) && Physics.Raycast(rayTo, out hitTo, Mathf.Infinity, layerMask))
            {
                Vector3 dir = hitFrom.point - hitTo.point;
                transform.Translate(dir, Space.World);
            }
        }

        public void Zoom(Vector3 screenPosition, float zoomDistance)
        {
            if(!zoom)
            {
                return;
            }
            Ray ray = Camera.ScreenPointToRay(screenPosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                transform.Translate(ray.direction * zoomDistance, Space.World);
            }
        }

        public void ZoomMultiplyDistance(Vector3 screenPosition, float zoomMultiplier)
        {
            if(!zoom)
            {
                return;
            }
            Ray ray = Camera.ScreenPointToRay(screenPosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                var focalPint = hit.point;
                var newDistance = hit.distance / zoomMultiplier;
                var diff = hit.distance - newDistance;

                transform.Translate(ray.direction * diff, Space.World);
            }
        }

        public void Orbit(Vector3 screenPosition, float angle)
        {
            if(!orbit)
            {
                return;
            }
            Ray ray = Camera.ScreenPointToRay(screenPosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                OrbitWorldPoint(hit.point, angle);
            }
        }

        public void OrbitWorldPoint(Vector3 worldPosition, float angle)
        {
            if(!orbit)
            {
                return;
            }
            transform.RotateAround(worldPosition, Vector3.up, angle);
        }
    }
}
