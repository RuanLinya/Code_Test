using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Switch : MonoBehaviour
{
    public GameObject sceneParent1;
    public GameObject sceneParent2;
    public GameObject sceneParent3;
    public Button scene1Button;
    public Button scene2Button;
    public Button scene3Button;
    public TMPro.TMP_Text scene1ButtonText;
    public TMPro.TMP_Text scene2ButtonText;
    public TMPro.TMP_Text scene3ButtonText;
    private Color activeColor = Color.blue;
    private Color inactiveColor = Color.white;
    public Slider timelineSlider;
    public TMP_Text currentSceneText;


    private void Start()
    {
        timelineSlider.onValueChanged.AddListener(UpdateScene);
        UpdateScene(timelineSlider.value);

    }

    void UpdateScene(float value)
    {

        sceneParent1.SetActive(false);
        sceneParent2.SetActive(false);
        sceneParent3.SetActive(false);

        // Reset button colors
        scene1Button.image.color = inactiveColor;
        scene2Button.image.color = inactiveColor;
        scene3Button.image.color = inactiveColor;
        scene1ButtonText.color = Color.black;
        scene2ButtonText.color = Color.black;
        scene3ButtonText.color = Color.black;

        if (value < 1f)
        {
            sceneParent1.SetActive(true);
            currentSceneText.text = "Scene 1";
            scene1Button.image.color = activeColor;
            scene1ButtonText.color = Color.white;
        }
        else if (value < 2f)
        {
            sceneParent2.SetActive(true);
            currentSceneText.text = "Scene 2";
            scene2Button.image.color = activeColor;
            scene2ButtonText.color = Color.white;
        }
        else
        {
            sceneParent3.SetActive(true);
            currentSceneText.text = "Scene 3";
            scene3Button.image.color = activeColor;
            scene3ButtonText.color = Color.white;
        }
    }
    public void LoadScene1()
    {

        timelineSlider.value = 0.15f;
    }
}

