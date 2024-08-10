using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class keysgained : MonoBehaviour
{
    public Text keysgainedtext;
    public Text keysgainedamount;
    void Start()
    {

        
        keysgainedtext.text = ArabicFixer.Fix(keysgainedtext.text);
        keysgainedamount.text = GameManager.Instance.keysGained.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
