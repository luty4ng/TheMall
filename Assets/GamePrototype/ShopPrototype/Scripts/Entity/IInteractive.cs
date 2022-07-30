public interface IInteractive
{
    string Name { get; }
    void OnInit();
    void OnHover();
    void OnPassEnter();
    void OnPassExit();
    void OnInteract();
    void OnDestroy();
}