using UnityEngine;

public class Airplane : MonoBehaviour
{
    public class Airplane : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] float enginePower = 20f;
        [SerializeField] float liftBooster = 0.5f;
        [SerializeField] float drag = 0.001f;
        [SerializeField] float angularDrag = 0.001f;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            // Logic for airplane physics will go here
        }
    }
