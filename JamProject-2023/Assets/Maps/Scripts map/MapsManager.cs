using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapsManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<Maps> levelBuilding;
    //private void Awake()
    //{
    //    levelBuilding = GetComponentsInChildren<Maps>();
    //}
    void Start()
    {
        for (int i = 0; i < levelBuilding.Count; i++)
        {

            if (i == 0)
            {
                levelBuilding[i].LastLevel = null;
                if (i != levelBuilding.Count - 1)
                    levelBuilding[i].NextLevel = levelBuilding[i + 1];
                levelBuilding[i].StartLevel();


            }
            else
            {
               
                if (i != levelBuilding.Count - 1)
                {
                    levelBuilding[i].NextLevel = levelBuilding[i + 1];
                    levelBuilding[i].LastLevel = levelBuilding[i - 1];


                }
                else
                {
                    levelBuilding[i].LastLevel = levelBuilding[i - 1];
                    levelBuilding[i].NextLevel = levelBuilding[0];
                    levelBuilding[i].MyDoor.onTrigger.RemoveAllListeners();
                    levelBuilding[i].MyDoor.onTrigger.AddListener(Win);

                }
            }


            

        }
    }

    public void Win() 
    {
        SceneManager.LoadScene("Victoria");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}