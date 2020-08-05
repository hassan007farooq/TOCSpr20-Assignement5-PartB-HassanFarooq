using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public GameObject IcyCube;
    private Rigidbody rb;
    private int countCaptured;
    private int countNonCaptured;
    public string invert;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countCaptured = 0;
        countNonCaptured = 0;
        winText.text = "";
        SetCountText();       
    }

    void FixedUpdate() 
    {
        // Our player get the rigid body and interact with the physiscs engine
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("IcyCube"))
        {
            string NameOfObject = other.gameObject.name;
            char Character = NameOfObject.Last();
            string cubeText = ("IcyCube" + Character);
            invert = "";
            Text name = GameObject.Find(cubeText + "/Canvas/CubeText").GetComponent<Text>();
        
            string cubeString = name.text.ToString();

            for (int i = cubeString.Length - 1; i >= 0; i--) //String Reverse  
            {
                invert = invert + cubeString[i].ToString();
            }

            Debug.Log(invert.Equals(cubeString));
            Debug.Log("Invert string is " + invert);
            Debug.Log("Cube String is   " + invert);

            if ((string.Equals(cubeString, invert)) == true) // Checking whether string is palindrome or not  
            {                
                other.gameObject.SetActive(false);
                countCaptured = countCaptured + 1;
            }
            else
            {
                countNonCaptured = countNonCaptured + 1;
            }
            Debug.Log(countCaptured);
            Debug.Log(countNonCaptured);
        }
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Captured Palindromes are : " + countCaptured.ToString();
        if((countCaptured + countNonCaptured) == 10)
        {
            winText.text = "You Collect all the Palindromes !!";
        }
    }
}
