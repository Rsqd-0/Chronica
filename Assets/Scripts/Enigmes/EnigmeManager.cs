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
    
        public static int EnigmeNum = 0;
        
        private int lastEnigme = 3;
        
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
                GameObject.Find("Enigme2")
            };
            
            var enigmeCouronne = new[]
            {
                GameObject.Find("Couronne")
                //GameObject.Find("CeaserBust")
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
            secondTest[0].SetActive(false);
            enigmeCouronne[0].SetActive(false);
        }
    
        // Update is called once per frame
        private void Update()
        {
            if (EnigmeNum == lastEnigme) return;

            if (EnigmeNum == 1)
            {
                Debug.Log("gy");
                DictEnigme[EnigmeNum][0].SetActive(true);
                Debug.Log("test");
                return;
            }
            if (EnigmeNum == 2)
            {
                DictEnigme[EnigmeNum][0].SetActive(true);
                return;
            }

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
