using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpen = false;

    [SerializeField] private bool strongDoor = false;
    [SerializeField] private GameObject doorObject;

    public void OpenDoor()
    {
        _isOpen = true;
        doorObject.SetActive(false); // Disable the door object to simulate opening
        Invoke(nameof(CloseDoor), 2f); // Close the door after 2 seconds
        Debug.Log("Door opened");
    }

    private void CloseDoor()
    {
        _isOpen = false;
        doorObject.SetActive(true); // Enable the door object to simulate closing
    }

    public bool GetStrongDoor() => strongDoor;
    public bool GetIsOpen() => _isOpen;


}
