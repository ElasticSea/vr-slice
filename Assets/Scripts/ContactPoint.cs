using UnityEngine;

public class ContactPoint : MonoBehaviour
{
    [SerializeField] private KatanaCut katana;

    private Vector3 lastPosition;
    private float velocity;

    private void FixedUpdate()
    {
        velocity = Vector3.Distance(transform.position, lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        var sliceable = other.gameObject.GetComponent<Sliceable>();
        if (sliceable)
        {
            katana.Cut(transform.position, sliceable, velocity);
        }
    }
}