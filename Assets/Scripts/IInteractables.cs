public enum ObjectType { KEY,DOOR}
public interface IInteractable 
{
    public void Interact();
    public bool CanInteract();
    public ObjectType Type();
}


