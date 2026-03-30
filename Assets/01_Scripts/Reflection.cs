using UnityEngine;

public class Reflection : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            collision.GetComponent<RaiderShoot>().ownObject = transform.parent.gameObject;
            collision.gameObject.GetComponent<MeshRenderer>().material = this.gameObject.GetComponent<MeshRenderer>().material;
            collision.gameObject.GetComponent<TrailRenderer>().material = this.gameObject.GetComponent<MeshRenderer>().material;
            collision.gameObject.GetComponent<RaiderShoot>().isFindTarget = false;
            Vector3 reverseDirection = -collision.gameObject.transform.forward;
            reverseDirection.y = 0;
            collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            collision.gameObject.transform.rotation = Quaternion.LookRotation(reverseDirection);
        }
    }
}