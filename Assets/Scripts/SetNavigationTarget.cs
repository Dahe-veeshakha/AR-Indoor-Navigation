
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
//using UnityEngine.UI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();
    [SerializeField]
    private Slider navigationYoffset;

    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 TargetPosition = Vector3.zero;

    private int currentFloor=1;

    private bool lineToggle = false; 

    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;
    }

    private void Update()
    {
        if (lineToggle && TargetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, TargetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            Vector3[] calculatedPathAndOffset = AddLineOffset();
            line.SetPositions(calculatedPathAndOffset);
        }
    }

    public void SetCurrentNavigationTarget(int selectedValue)
    {
            TargetPosition = Vector3.zero;
            string selectedText = navigationTargetDropDown.options[selectedValue].text;
            Target currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));
            if (currentTarget != null)
            {
                if (!line.enabled)
                {
                    ToggleLineVisibilty();
                }
                TargetPosition = currentTarget.PositionObject.transform.position;
            }
        
    }

    public void ToggleLineVisibilty()
    { 
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }

    public void ChangeActiveFloor(int floorNumber)
    {
        currentFloor = floorNumber;
        SetNavigationTargetDropDownOptions(currentFloor);
    }

    private Vector3[] AddLineOffset()
    {
        if (navigationYoffset.value == 0)
        {
            return path.corners;
        }

        Vector3[] calculatedLine = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++)
        {
            calculatedLine[i] = path.corners[i] + new Vector3(0, navigationYoffset.value, 0);
        }
        return calculatedLine;
    }

    private void SetNavigationTargetDropDownOptions(int floorNumber)
    {
        navigationTargetDropDown.ClearOptions();
        navigationTargetDropDown.value = 0;

        if (line.enabled)
        {
            ToggleLineVisibilty();
        }

        if (floorNumber == 1)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("R1"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("R2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("R3"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("R4"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Narmada"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("MathsStaff"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("StatsStaff"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("MathsHOD"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("StatsHOD"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("examination"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Prohibitedarea"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("StartPoint"));



        }
        if (floorNumber == 2)
        {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Electra1 "));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Electra2 "));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("IMCA"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("Cabin"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("SecondMainEntrance"));

        }
        navigationTargetDropDown.RefreshShownValue();
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private Camera TopDownCamera;
    [SerializeField]
    private GameObject navTargetObject;

    private NavMeshPath path;
    private LineRenderer line;

    private bool lineToggle = false;

    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if((Input.touchCount>0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            lineToggle = !lineToggle;
        }
        if (lineToggle)
        {
            NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
            line.enabled = true;
        }
    }
}*/