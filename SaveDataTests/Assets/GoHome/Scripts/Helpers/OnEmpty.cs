using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoHome
{

    public class OnEmpty : MonoBehaviour
    {
        public UnityEvent onEmpty;

        void Update()
        {
            //if there is no children components left
            if (transform.childCount == 0)
            {
                //Invoke the UnityEvent
                onEmpty.Invoke();
                //Disable gameobject
                gameObject.SetActive(false);

            }

        }
    }
}
