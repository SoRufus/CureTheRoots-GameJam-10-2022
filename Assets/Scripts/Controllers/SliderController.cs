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

    private CardsManager cardsManager = null;
    private string currentText = "";
    private int index = 0;
    private AudioSource audioSource = null;
    private void OnEnable()
    {
        if(cardsManager != null) cardsManager.ToggleCards(false);
    }
    private void Start()
    {
        cardsManager = CardsManager.Instance;
        if (cardsManager != null) cardsManager.ToggleCards(false);

        audioSource = GetComponent<AudioSource>();
        Refresh();
        StartCoroutine(ShowText());
    }

    private void NextDialogue()
    {
        index++;
        if (index == dialogue.Slides.Count)
        {
            StopAllCoroutines();
            if(NextScene == "")
            {
                if (cardsManager != null) cardsManager.ToggleCards(true);
                gameObject.SetActive(false);
                return;
            }
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
            audioSource.PlayOneShot(audioSource.clip);
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

    public void SkipDialogue()
    {
        if (slideText.text != dialogue.Slides[index].Text)
        {
            StopAllCoroutines();
            NextDialogueButton.SetActive(true);
            slideText.text = dialogue.Slides[index].Text;
            return;
        }
        NextDialogue();
    }
}
