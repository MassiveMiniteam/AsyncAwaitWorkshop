using System;
using UnityEngine;

namespace Misc
{
    public class Rotate : MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        private void Update()
        {
            transform.Rotate (0 ,10*Time.deltaTime ,0);
        }
    }
}
