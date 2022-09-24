using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SliderController : MonoBehaviour
{
    [SerializeField] private DialogueSO dialogue = null;
    [SerializeField] private Image slideImage = null;
    [SerializeField] private GameObject NextDialogueButton = null;
    [SerializeField] private TextMeshProUGUI slideText = null;
    [SerializeField] private float speed = 0.01f;
    [SerializeField] private string NextScene = "";


    private string currentText = "";
    private int index = 0;

    private void Start()
    {
        Refresh();
        StartCoroutine(ShowText());
    }

    public void NextDialogue()
    {
        index++;
        if (index == dialogue.Slides.Count)
        {
            CancelInvoke();
            SceneManager.LoadScene(NextScene);
        }
        NextDialogueButton.SetActive(false);
        Refresh();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
            if (index == dialogue.Slides.Count) yield return null;
            for (int i = 0; i < dialogue.Slides[index].Text.Length + 1; i++)
            {
            currentText = dialogue.Slides[index].Text.Substring(0, i);
            slideText.text = currentText;
            if (slideText.text == dialogue.Slides[index].Text) NextDialogueButton.SetActive(true);

            yield return new WaitForSeconds(speed);
            }
    }

    private void Refresh()
    {
        if (index == dialogue.Slides.Count) return;

        NextDialogueButton.SetActive(false);
        if (dialogue.Slides[index].Image != null)
        {
            slideImage.gameObject.SetActive(true);
            slideImage.sprite = dialogue.Slides[index].Image;
        }
        else
        {
            slideImage.gameObject.SetActive(false);
        }
    }
}
