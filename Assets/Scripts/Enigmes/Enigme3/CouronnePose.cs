using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Enigmes.Enigme3
{
    public class CouronnePose : MonoBehaviour
    {
        [SerializeField] private Collider item;

        private bool isPutOn;
    
        // Update is called once per frame
        private void Update()
        {
            if (!isPutOn) return;
            EnigmeManager.EnigmeNum++;
            enabled = false;
        }

        private void OnTriggerStay(Collider other)
        {
            var obj = other.gameObject;
            if (obj != item.gameObject) return;
            var grab = obj.GetComponent<XRGrabInteractable>();
            if (grab.isSelected) return;
            var rb = obj.GetComponent<Rigidbody>();
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            isPutOn = true;
        }
    
    }
}
