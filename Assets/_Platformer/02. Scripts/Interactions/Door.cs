using System.Collections;
using Platformer;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private SoundManager sound;

    [SerializeField] private FadeEvent fade;

    [SerializeField] private Vector3 houseInPos;
    [SerializeField] private Vector3 houseOutPos;

    [SerializeField] private GameObject[] insideObjs;
    [SerializeField] private GameObject[] outsideObjs;

    public bool IsInteracting { get; private set; }

    void Start()
    {
        sound = FindFirstObjectByType<SoundManager>();
    }

    public void Interact(Transform interactor = null)
    {
        StartCoroutine(InteractRoutine(interactor));
    }

    IEnumerator InteractRoutine(Transform interactor)
    {
        sound.SoundOneShot("Door Open");
        yield return StartCoroutine(fade.FadeRoutine(3, Color.black, true));
  
        var pos = IsInteracting ? houseOutPos : houseInPos;
        interactor.position = pos;
        
        foreach (var obj in insideObjs)
            obj.SetActive(!IsInteracting);
        
        foreach (var obj in outsideObjs)
            obj.SetActive(IsInteracting);

        IsInteracting = !IsInteracting;

        sound.SoundOneShot("Door Close");
        yield return new WaitForSeconds(1f);

        fade.Fade(3, Color.black, false);
    }

    public void UnInteract()
    {

    }
}