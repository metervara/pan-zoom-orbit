using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metervara.Interaction
{
    public class PanZoomOrbitTouch : PanZoomOrbit
    {
        void Update()
        {
            if (Input.touchCount == 2)
            {
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);

                Vector2 previousPosition0 = touch0.position - touch0.deltaPosition;
                Vector2 previousPosition1 = touch1.position - touch1.deltaPosition;

                Vector2 center = Vector3.Lerp(touch0.position, touch1.position, 0.5f);
                Vector2 previousCenter = Vector3.Lerp(previousPosition0, previousPosition1, 0.5f);

                Pan(previousCenter, center);

                float touchDistance = (touch1.position - touch0.position).magnitude;
                float prevTouchDistance = (previousPosition1 - previousPosition0).magnitude;
                float touchChangeMultiplier = touchDistance / prevTouchDistance;

                ZoomMultiplyDistance(center, touchChangeMultiplier);

                RaycastHit hit0, hit1, prevHit0, prevHit1;
                Ray ray0 = Camera.ScreenPointToRay(touch0.position);
                Ray ray1 = Camera.ScreenPointToRay(touch1.position);
                Ray prevRay0 = Camera.ScreenPointToRay(previousPosition0);
                Ray prevRay1 = Camera.ScreenPointToRay(previousPosition1);

                if (Physics.Raycast(ray0, out hit0, Mathf.Infinity, layerMask) &&
                Physics.Raycast(ray1, out hit1, Mathf.Infinity, layerMask) &&
                Physics.Raycast(prevRay0, out prevHit0, Mathf.Infinity, layerMask) &&
                Physics.Raycast(prevRay1, out prevHit1, Mathf.Infinity, layerMask))
                {
                    var dir = hit1.point - hit0.point;
                    var prevDir = prevHit1.point - prevHit0.point;

                    var angle = Vector3.SignedAngle(dir, prevDir, Vector3.up);
                    // Orbit(center, angle);
                    OrbitWorldPoint(Vector3.Lerp(hit0.point, hit1.point, 0.5f), angle); // saves a raycast
                }
            }
        }
    }
}
