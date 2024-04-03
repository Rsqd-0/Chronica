using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Enigmes
{
    public class EnigmeManager : MonoBehaviour
    {
        [SerializeField] private AudioSource source;
        
        public static readonly Dictionary<int, GameObject[]> DictEnigme = new();
    
        public static int EnigmeNum;
        
        private int lastEnigme;
        
        private void Awake()
        {
            var firstEnigme = new[]
            {
                GameObject.Find("Queteur"),
                GameObject.Find("Edile"),
                GameObject.Find("Preteur")
            };
            
             var secondTest = new[]
            
            {
                GameObject.Find("Enigme2") // TODO : Set Active
            };
            
            var enigmeCouronne = new[]
            {
                GameObject.Find("Couronne"),
                GameObject.Find("CeaserBust")
            };
            
            var lastEnigmeList = new[]
            {
                GameObject.Find("Poinçon"),
                GameObject.Find("Halberd"),
                GameObject.Find("2HandSword"),
                GameObject.Find("Mace"),
                GameObject.Find("Bow"),
            };
            DictEnigme.Add(0, firstEnigme);
            DictEnigme.Add(1, secondTest);
            DictEnigme.Add(2, enigmeCouronne);
            DictEnigme.Add(3,lastEnigmeList);
            foreach (var item in DictEnigme[0])
            {
                item.GetComponent<XRGrabInteractable>().enabled = true;
            }
            foreach (var enigmeObject in DictEnigme.Values.Where(objectList => objectList != DictEnigme[0])
                         .SelectMany(objectList => objectList))
            {
                if (enigmeObject.TryGetComponent<XRGrabInteractable>(out var interactable))
                {
                    interactable.enabled = false;
                }
                else
                {
                    enigmeObject.SetActive(false);
                }
                
            }
        }
    
        // Update is called once per frame
        private void Update()
        {
            if (EnigmeNum == lastEnigme) return;
            foreach (var lastObject in DictEnigme[lastEnigme])
            {
                if (lastObject.TryGetComponent<XRGrabInteractable>(out var interactable))
                {
                    interactable.enabled = false;
                }
                else
                {
                    //lastObject.SetActive(false);
                }
            }
            lastEnigme = EnigmeNum;
            if (!DictEnigme.Keys.Contains(EnigmeNum)) return;
            foreach (var nextObject in DictEnigme[EnigmeNum])
            {
                if (nextObject.TryGetComponent<XRGrabInteractable>(out var interactable))
                {
                    interactable.enabled = true;
                }
                else
                {
                    nextObject.SetActive(true);
                }
            }
            
        }

        public void Success()
        {
            EnigmeNum++;
            source.Play();
        }
    }
}
