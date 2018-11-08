using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GoHome
{

    public class PlayerController : MonoBehaviour
    {
        public Rigidbody rigid;
        public float speed = 10f;
        public float maxVelocity = 20f;

        public void Move(float inputH, float inputV)
        {
            //direction on x,y,z is equal to new direction via input
            Vector3 direction = new Vector3(inputH, 0, inputV);
            //adds velocity by timing direction with speed
            rigid.velocity = direction * speed;
        }
        void Constraint()
        {

        }
        public void OnTriggerEnter(Collider other)
        {
            Collectables collectable = other.GetComponent<Collectables>();
            if (collectable)
            {
                collectable.Collect();
            }
        }
    }
}
