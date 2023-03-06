using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clicking : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //Why not simple button clicking options?

    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private AudioClip _compressClip, _uncompressClip;
    [SerializeField] private AudioSource _source;
    [SerializeField] private GameObject _instructionsPage; // reference to the instructions page game object
    [SerializeField] private GameObject _closeButton; // reference to the close button game object
    private bool _instructionsVisible = false; // flag to track if instructions page is visible

    public void OnPointerDown(PointerEventData eventData)
    {
        _img.sprite = _pressed;
        _source.PlayOneShot(_compressClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _img.sprite = _default;
        _source.PlayOneShot(_uncompressClip);
    }

    public void IWasClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void InstructionsClicked()
    {
        // toggle the visibility of the instructions page
        _instructionsVisible = !_instructionsVisible;
        _instructionsPage.SetActive(_instructionsVisible);
    }

    public void CloseClicked()
    {
        // disable the instructions page and reset the flag
        _instructionsVisible = false;
        _instructionsPage.SetActive(false);
    }
}
