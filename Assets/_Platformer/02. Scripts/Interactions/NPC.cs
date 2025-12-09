using System.Collections;
using TMPro;
using UnityEngine;

namespace Platformer
{
    public class NPC : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject dialogueUI;
        [SerializeField] private TextMeshProUGUI textUI;

        [SerializeField] private string dialogueText;

        [SerializeField] private float typingSpeed = 0.1f;

        public NPCUI npcUI;
        public NPCDataSO data;

        private Coroutine typingRoutine;

        public bool IsInteracting { get; private set; }

        public void Interact(Transform interactor = null)
        {
            npcUI.SetData(data.name, data.age, data.gender, data.job, data.description, data.icon);
            
            textUI.text = "";

            IsInteracting = true;
            dialogueUI.SetActive(true);

            typingRoutine = StartCoroutine(InteractRoutine());
        }

        IEnumerator InteractRoutine()
        {
            int textLength = dialogueText.Length;
            for (int i = 0; i < textLength; i++)
            {
                textUI.text += dialogueText[i];

                yield return new WaitForSeconds(typingSpeed);
            }
        }
        
        public void UnInteract()
        {
            StopCoroutine(typingRoutine);
            
            IsInteracting = false;
            dialogueUI.SetActive(false);
        }
    }
}