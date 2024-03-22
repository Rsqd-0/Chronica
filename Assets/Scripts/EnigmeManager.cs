using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnigmeManager : MonoBehaviour
{
        public static readonly Dictionary<int, List<GameObject>> DictEnigme = new();
    
        public static int EnigmeNum = 0;
        
        private int lastEnigme = 0;
        
        private void Awake()
        {
            var firstTest = new List<GameObject>
            {
                GameObject.Find("Queteur"),
                GameObject.Find("Edile"),
                GameObject.Find("Preteur")
            };
            var secondTest = new List<GameObject>
            {
                GameObject.Find("CeaserBust")
            };
            DictEnigme.Add(0, firstTest);
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
            if (EnigmeNum > 1) Application.Quit();
            if (EnigmeNum == lastEnigme) return;
            foreach (var lastObject in DictEnigme[lastEnigme])
            {
                lastObject.GetComponent<XRGrabInteractable>().enabled = false;
            }
            foreach (var nextObject in DictEnigme[EnigmeNum])
            {
                nextObject.GetComponent<XRGrabInteractable>().enabled = true;
            }
            lastEnigme++;
        }
}
