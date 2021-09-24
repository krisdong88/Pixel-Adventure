using UnityEngine;

public interface IInteractable 
{
    void Interact(Collision2D collision2D);

    bool CheckInteraction(Vector2 interactor);

    bool IfAbove(Vector2 interactor);

    bool IfBelow(Vector2 interactor);
}
