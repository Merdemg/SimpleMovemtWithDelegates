using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static InputManager instance;
    public static InputManager Instance {
        get { if (instance == null) instance = FindObjectOfType<InputManager>(); return instance; }
    }



    List<ControllableCube> selectedCubes = new List<ControllableCube>();

    List<ControllableCube> allCubes = new List<ControllableCube>();

    Camera camera;

    public delegate void SelectCubes(List<ControllableCube> Cubes);
    public SelectCubes selectCubes;

    public delegate void MoveSelectedCubes(Vector3 Direction);
    public MoveSelectedCubes moveSelectedCubes;

    void Start()
    {
        camera = Camera.main;
    }

    public void InitCube(ControllableCube Cube){
        if (!allCubes.Contains(Cube))
        {
            allCubes.Add(Cube);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // Select all cubes
        {
            selectCubes?.Invoke(allCubes);
        }else if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button down");
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<ControllableCube>())
                {
                List<ControllableCube> selectedCubes = new List<ControllableCube> {hit.transform.GetComponent<ControllableCube>()};
                selectCubes?.Invoke(selectedCubes);
                }else
                {
                    selectCubes?.Invoke(new List<ControllableCube>());
                }
            }else
            {
                selectCubes?.Invoke(new List<ControllableCube>());
            }
        }


        Vector3 movementDir = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.W))
        {
            movementDir += new Vector3(0,0,1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDir += new Vector3(0,0,-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDir += new Vector3(1,0,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementDir += new Vector3(-1,0,0);
        }
        MoveCubes(movementDir);
    }

    void MoveCubes(Vector3 Direction){
        Direction.Normalize();
        moveSelectedCubes?.Invoke(Direction);
    }

}
