using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SearchScript : MonoBehaviour
{
	[SerializeField]
	private Canvas modal;

	private string activeImage;

	[SerializeField]
	private TMP_InputField input;
	[SerializeField]
	private Sprite placeholder;

	public void ShowModal()
    {
		modal.enabled = true;
		activeImage = "";
		input.text = "";
		modal.GetComponent<Animator>().SetTrigger("Show");
	}
	public void HideModal()
    {
		modal.enabled = false;
    }

    public void SaveSaga()
    {
		// Modal Save Saga
		if (string.IsNullOrEmpty(input.text)) return;
		SagasLoading.Instance.SaveNewSaga(input.text);
		modal.enabled = false;
	}
}
