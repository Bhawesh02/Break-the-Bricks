using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseParent : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Closeparent);
    }

    private void Closeparent()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
