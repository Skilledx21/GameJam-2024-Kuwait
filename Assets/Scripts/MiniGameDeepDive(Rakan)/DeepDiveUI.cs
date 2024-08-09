using ArabicSupport;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeepDiveUI : MonoBehaviour
{
    const int _MAINMENUINDEX = 0;
    public static DeepDiveUI Instance;
    
    
    [SerializeField] Text _GameText;
    [SerializeField] Text _ButtonText;

    [SerializeField] GameObject _Hint;

    [SerializeField] Text _WinText;
    [SerializeField] Text _LoseText;
    [SerializeField] Text _LoseTextBtn;

    [SerializeField] Text _Pearls;
    [SerializeField] Text _PearlsLeft;

    [SerializeField] GameObject _WinPanel;
    [SerializeField] GameObject _LosePanel;

    public bool isStarted;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _GameText.text = ArabicFixer.Fix(_GameText.text);
        _ButtonText.text = ArabicFixer.Fix(_ButtonText.text);
        _WinText.text = ArabicFixer.Fix(_WinText.text);
        _LoseText.text = ArabicFixer.Fix(_LoseText.text);
        _LoseTextBtn.text = ArabicFixer.Fix(_LoseTextBtn.text);
        _Pearls.text = ArabicFixer.Fix(_Pearls.text);
        _PearlsLeft.text = ArabicFixer.Fix(_PearlsLeft.text);

        _Hint.SetActive(true);

        _WinPanel.SetActive(false);
        _LosePanel.SetActive(false);
    }

    private void Update()
    {
        _Pearls.text = $"لؤلؤ: {GameManagerDeepDive.instance._pearlScore}";
        _PearlsLeft.text = $"باقي: {GameManagerDeepDive.instance._pearlsNeed}";
        _Pearls.text = ArabicFixer.Fix(_Pearls.text);
        _PearlsLeft.text = ArabicFixer.Fix(_PearlsLeft.text);
    }


    public void StartGame()
    {
        ClearAll();
        isStarted = true;
    }

    public void WinPanel()
    {
        ClearAll();
        _WinPanel.SetActive(true);
    }

    public void LosePanel()
    {
        ClearAll();
        GameManagerDeepDive.instance._lose = true;
        _LosePanel.SetActive(true);
        
    }

    public void ClearAll()
    {
        _LosePanel.SetActive(false);
        _WinPanel.SetActive(false);
        _Hint.SetActive(false);
    }


    public void Back()
    {
        GameManagerDeepDive.instance.GameOver();
    }
}
