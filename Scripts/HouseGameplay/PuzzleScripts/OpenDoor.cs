using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour {

    private Animator anim;
    [SerializeField] private TextMeshProUGUI CodeText;
    string codeTextValue = "";
    public string safeCode;
    public int codeLength;
    public GameObject CodePanel;
    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
        CodePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update(){
        CodeText.text = codeTextValue;
        
        if(codeTextValue == safeCode){
            anim.SetTrigger("OpenDoor");
            CodePanel.SetActive(false);
        }
        if(codeTextValue.Length >= codeLength){
            codeTextValue = "";
        }

    }

    public void AddDigit(string digit){
        codeTextValue += digit;
    }
}
