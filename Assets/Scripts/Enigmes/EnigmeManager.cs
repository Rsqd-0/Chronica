using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Enigmes
{
    public class EnigmeManager : MonoBehaviour
    {
        public static readonly Dictionary<int, List<GameObject>> DictEnigme = new();
    
        public static int EnigmeNum = 0;
        
        private int lastEnigme;
        
        private void Awake()
        {
            var firstEnigme = new List<GameObject>
            {
                GameObject.Find("Queteur"),
                GameObject.Find("Edile"),
                GameObject.Find("Preteur")
            };
            var secondTest = new List<GameObject>
            {
                GameObject.Find("CeaserBust")
            };
            DictEnigme.Add(0, firstEnigme);
            DictEnigme.Add(1, secondTest);
            foreach (var item in DictEnigme[0])
            {
                item.GetComponent<XRGrabInteractable>().enabled = true;
            }
            foreach (var enigmeObject in DictEnigme.Values.Where(objectList => objectList != DictEnigme[0])
                         .SelectMany(objectList => objectList))
            {
                enigmeObject.GetComponent<XRGrabInteractable>().enabled = false;
            }
        }
    
        // Update is called once per frame
        private void Update()
        {
            if (EnigmeNum == lastEnigme) return;
            foreach (var lastObject in DictEnigme[lastEnigme])
            {
                lastObject.GetComponent<XRGrabInteractable>().enabled = false;
            }
            lastEnigme++;
            if (!DictEnigme.Keys.Contains(EnigmeNum)) return;
            foreach (var nextObject in DictEnigme[EnigmeNum])
            {
                nextObject.GetComponent<XRGrabInteractable>().enabled = true;
            }
            
        }
    }
}
