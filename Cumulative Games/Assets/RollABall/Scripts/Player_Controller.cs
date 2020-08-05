using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;

    static bool isMatchingParenthesis(char char1, char char2)
    {
        if (char1 == '(' && char2 == ')')
            return true;
        else
            return false;
    }

    public static bool getResult(string obtainedString)
    {
        char[] exp = obtainedString.ToCharArray();
        Stack<char> str = new Stack<char>();

        for (int i = 0; i < exp.Length; i++)
        {

            /*If the exp[i] is a starting  
                parenthesis then push it*/
            if (exp[i] == '(')
                str.Push(exp[i]);

            /* If exp[i] is an ending parenthesis  
                then pop from stack and check if the  
                popped parenthesis is a matching pair*/
            if (exp[i] == ')')
            {

                /* If we see an ending parenthesis without  
                    a pair then return false*/
                if (str.Count == 0)
                {
                    return false;
                }

                /* Pop the top element from stack, if  
                    it is not a pair parenthesis of character  
                    then there is a mismatch. This happens for  
                    expressions like {(}) */
                else if (!isMatchingParenthesis(str.Pop(), exp[i]))
                {
                    return false;
                }
            }
        }

        if (str.Count == 0)
            return true; /*balanced*/
        else
        { /*not balanced*/
            return false;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText(count);
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        TextMesh gameObj = other.gameObject.GetComponentInChildren<TextMesh>();
        int i = 0;
        int numOfMatchingParenthesis = 0;
        bool[] arr = new bool[10];

        if (other.gameObject.CompareTag("Cube") && i < 10)
        {
            Debug.Log(getResult(gameObj.text));
            if (getResult(gameObj.text))
            {
                arr[i] = true;
                other.gameObject.SetActive(false);
                count = count + 1;
                i = i + 1;
                Debug.Log(gameObj.text);
                SetCountText(count);
            }
            else
            {
                arr[i] = false;
                i = i + 1;
            }
        }
        for (int j = 0; j < arr.Length; j++)
        {
            if (arr[j] == true)
                numOfMatchingParenthesis += 1;
        }

        if (numOfMatchingParenthesis > 0 && i >= 10)
            SetCountText(numOfMatchingParenthesis);
    }


    void SetCountText(int check)
    {
        countText.text = "Count: " + count.ToString();
        Debug.Log(GenerateSpwan.allValidString);
        if (check >= GenerateSpwan.allValidString)
        {
            winText.text = "Congratulation!!! You have Spawn all " + check + " collectible objects";
        }
    }
}
