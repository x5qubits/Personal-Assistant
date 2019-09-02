using System.Speech.Recognition;

namespace puremvc.Engine.Listen.Interfaces
{
    public interface IListerner
    {
        IlistenEnums type { get; }
        void Start(bool isShortParse = false);
        void Stop();
        void LoadGramer(Grammar gramar, bool isUnload = false);
    }
}
