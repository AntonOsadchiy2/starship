using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera vcam;
    void FixedUpdate()
    {
        float scrollMove = Input.GetAxis("Mouse ScrollWheel");
        if (scrollMove > 0.1)
        {
            if (vcam.m_Lens.OrthographicSize >= 2)
            {
                vcam.m_Lens.OrthographicSize--;
            }
        }
        if (scrollMove < -0.1)
        {
            if (vcam.m_Lens.OrthographicSize <= 50)
            {
                vcam.m_Lens.OrthographicSize++;
            }
        }
    }
}
