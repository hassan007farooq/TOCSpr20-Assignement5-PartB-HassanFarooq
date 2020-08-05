using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GenerateSpwan : MonoBehaviour
{
    public Canvas canvas;
    public GameObject sphere;
    public GameObject Cube;
    private int x_Axis;
    private int z_Axis;

    public static int allValidString = 0;
    private int spawnCount;
    private List<string> oneOfThird = new List<string>();


    private static System.Random random = new System.Random();
    public static string RandomString()
    {
        int lengthOfString = random.Next(9, 16);
        const string characters = "(h8)";
        string matchString = new string(Enumerable.Repeat(characters, lengthOfString).Select(s => s[random.Next(s.Length)]).ToArray());
        return "x" + matchString;
    }

    void Start()
    {
        int i = 0;
        while (i < 16)
        {
            string str = RandomString();
            if (Player_Controller.getResult(str))
            {
                oneOfThird.Add(str);
                i++;
            }
        }
        StartCoroutine(DropSpawn());
    }

    IEnumerator DropSpawn()
    {
        while (spawnCount <= 48)
        {
            if (oneOfThird.Any())
            {
                x_Axis = Random.Range(90, 900);
                z_Axis = Random.Range(75, 945);
                GameObject cubePosition = Instantiate(Cube, new Vector3(x_Axis, 35, z_Axis), Quaternion.identity);
                GameObject upperSphere = Instantiate(sphere, new Vector3(x_Axis, 45, z_Axis), Quaternion.identity);
                upperSphere.transform.parent = cubePosition.transform;
                GameObject childTxt = new GameObject();
                
                childTxt.transform.parent = upperSphere.transform;
                childTxt.name = "CubeText";

                //Create TextMesh and modify its properties
                TextMesh randText = childTxt.AddComponent<TextMesh>();

                foreach (var item in oneOfThird)
                {
                    randText.fontSize = 250;
                    randText.text = item;
                    randText.anchor = TextAnchor.MiddleCenter;
                    randText.alignment = TextAlignment.Center;
                    randText.transform.position = cubePosition.transform.position;

                    allValidString += 1;
                    oneOfThird.Remove(item);
                    Debug.Log(item);
                    break;
                }
                yield return new WaitForSeconds(0.01f);
                spawnCount += 1;
            }


            x_Axis = Random.Range(90, 900);
            z_Axis = Random.Range(75, 945);
            GameObject randomCubePosition = Instantiate(Cube, new Vector3(x_Axis, 35, z_Axis), Quaternion.identity);
            GameObject upperRandomSphere = Instantiate(sphere, new Vector3(x_Axis, 45, z_Axis), Quaternion.identity);

            upperRandomSphere.transform.parent = randomCubePosition.transform;
            GameObject childObj = new GameObject();

            //Make block to be parent of this gameobject
            childObj.transform.parent = upperRandomSphere.transform;
            childObj.name = "CubeText";

            //Create TextMesh and modify its properties
            TextMesh textMesh = childObj.AddComponent<TextMesh>();
            textMesh.fontSize = 250;
            
            string str = RandomString();
            if (Player_Controller.getResult(str)) {
                allValidString += 1;
            }

            textMesh.text = str;            
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.alignment = TextAlignment.Center;
            textMesh.transform.position = upperRandomSphere.transform.position;


            yield return new WaitForSeconds(0.01f);
            spawnCount += 1;

        }
    }
}
