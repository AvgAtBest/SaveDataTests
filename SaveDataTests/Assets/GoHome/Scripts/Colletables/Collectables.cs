using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoHome
{
    public class Collectables : MonoBehaviour
    {
        public int value = 1;
        public void Collect()
        {
            GameManager.Instance.AddScore(value);
            Destroy(gameObject);

        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
