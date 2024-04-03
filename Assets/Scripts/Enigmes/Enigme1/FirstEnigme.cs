using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Enigmes.Enigme1
{
    public class FirstEnigme : MonoBehaviour
    {
        [SerializeField] private Collider item;
        private static int _nbSucces;
        private GameObject[] allItems;
        private bool startedCoroutine;
        private (GameObject, bool) inPlace = (null, false);
        private Coroutine coroutine;
        private void Start()
        {
            allItems = EnigmeManager.DictEnigme[0];
        }

        // Update is called once per frame
        private void Update()
        {
        
            if (_nbSucces != 3) return;
            EnigmeManager.EnigmeNum = 1;
            
            enabled = false;
        }
        /*
    private void OnTriggerEnter(Collider other)
    {
        if (!allItems.Contains(other.gameObject)) return;
        var o = other.gameObject.transform;
        o.position = gameObject.transform.position;
        o.rotation = Quaternion.identity;
        if (other != item) return;
        _nbSucces++;
    }
    */
     

        private void OnTriggerEnter(Collider other)
        {
            if (allItems.Contains(other.gameObject) && !inPlace.Item2)
            {
                coroutine = StartCoroutine(WaitForObjectRelease(other.gameObject));
            }
        }

        private IEnumerator WaitForObjectRelease(GameObject obj)
        {
            startedCoroutine = true;
            var grab = obj.GetComponent<XRGrabInteractable>();
            while (grab.isSelected) yield return new WaitForEndOfFrame(); // Attendre une frame
        

            // Une fois que l'objet est lâché, placer l'objet et incrémenter _nbSucces si nécessaire
            var rb = obj.GetComponent<Rigidbody>();
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            inPlace = (obj, true);
            if (obj == item.gameObject) _nbSucces++;
        
            startedCoroutine = false;
            yield return null;
        }

        private void OnTriggerStay(Collider other)
        {
            var obj = other.gameObject; 
            if (inPlace != (obj, true) || transform.position == obj.transform.position) return;
            var grab = obj.GetComponent<XRGrabInteractable>();
            if (grab.isSelected) return;
            var rb = obj.GetComponent<Rigidbody>();
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        private void OnTriggerExit(Collider other)
        {
            if (startedCoroutine)
            {
                StopCoroutine(coroutine);
                startedCoroutine = false;
            }

            if (other.gameObject == inPlace.Item1) inPlace = (null, false);
            if (other != item) return;
            _nbSucces--;
        }
    }
}
