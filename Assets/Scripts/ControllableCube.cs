using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableCube : MonoBehaviour
{
    [SerializeField] Material highlightMaterial;
    Material defaultMaterial;
    Renderer renderer;


    bool isSelected = false;

    const float MOVEMENT_SPEED = 1f;

    void Start(){
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;

        InputManager.Instance.InitCube(this);
        InputManager.Instance.selectCubes += SelectCubes;
        InputManager.Instance.moveSelectedCubes += MoveIfSelected;
    }

    public void SelectCubes(List<ControllableCube> Cubes){
        if (Cubes.Contains(this))
        {
            GetSelected();
        }else
        {
            GetUnselected();
        }
    }

    void GetSelected(){
        if (!isSelected)
        {
            isSelected = true;
            renderer.material = highlightMaterial;
        }
    }

    void GetUnselected(){
        if (isSelected)
        {
            isSelected = false;
            renderer.material = defaultMaterial;
        }
    }

    void MoveIfSelected(Vector3 Direction){
        if (isSelected)
        {
            transform.Translate(Direction * MOVEMENT_SPEED * Time.deltaTime);
        }
    }
}
