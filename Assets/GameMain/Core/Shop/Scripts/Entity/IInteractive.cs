public interface IInteractive
{
    string Name { get; }
    string SBelongWorld { get; }
    void OnInit();
    void OnHover();
    void OnPassEnter();
    void OnPassExit();
    void OnInteract();
    void OnDestroy();
    void OnUpdate();
}