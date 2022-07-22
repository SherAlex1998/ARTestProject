using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsForIngosick : MonoBehaviour
{
    [SerializeField] private Material[] IngosickMaterials;
    [SerializeField] private Material[] DoorMaterials;
    [SerializeField] private AudioClip[] _clips;
    private AudioSource _audioSource;
    void Awake() => _audioSource = GetComponent<AudioSource>();
    private void PlayClip(int i)
    {
        _audioSource.clip = _clips[i];
        _audioSource.Play();
    }
    void Appearing()
    {
       
        Debug.Log("Appearing");
        StartCoroutine(AppearingRoutine());
    }
    void DoorDisappearing()
    {
        Debug.Log("Disappearing");
        foreach (var mat in DoorMaterials) mat.SetFloat("_alpha", 0);
    }
    void DoorAppearing()
    {
        Debug.Log("Disappearing");
        foreach (var mat in DoorMaterials) mat.SetFloat("_alpha", 1);
    }
    void Disappearing()
    {
        Debug.Log("Disappearing");
        StartCoroutine(DisappearingRoutine());
    }
    IEnumerator DisappearingRoutine()
    {
        Debug.Log("DisappearingRoutineStart");
        var lerp = 1f;
        while (lerp >= 0)
        {
            Debug.Log("DisappearingRoutineIn");
            yield return new WaitForFixedUpdate();
            lerp -= Time.fixedDeltaTime*5;
            foreach (var mat in IngosickMaterials) mat.SetFloat("_alpha", lerp);
        }

        foreach (var mat in IngosickMaterials) mat.SetFloat("_alpha", 0);
        Debug.Log("DisappearingRoutineEnd");
    }
    IEnumerator AppearingRoutine()
    {
        Debug.Log("AppearingRoutineStart");
        foreach (var mat in IngosickMaterials) mat.SetFloat("_alpha", 0);
        var lerp = 0f;
        while (lerp <= 1)
        {
            Debug.Log("AppearingRoutineIn");
            yield return new WaitForFixedUpdate();
            lerp += Time.fixedDeltaTime * 5;
            foreach (var mat in IngosickMaterials) mat.SetFloat("_alpha", lerp);
        }

        foreach (var mat in IngosickMaterials) mat.SetFloat("_alpha", 1);
        Debug.Log("AppearingRoutineEnd");
    }
}
