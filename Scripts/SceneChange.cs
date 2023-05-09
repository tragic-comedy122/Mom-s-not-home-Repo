using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneChange Instance;
    
    public enum Scene
    {
        Title,Room_One,Room_Two,Room_Three,Drawer_Puzzle,Cabinet_Puzzle
    }
}
