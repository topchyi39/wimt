using UI.DragAndDrop;
using UI.Tools;

namespace Animals.Tails
{
    public class TailDropReceiver : OnDropReceiver<Tail>
    {
        protected override void OnObjectDropped(Tail tail)
        {
            // tail.SetVisible(false);
        }
    }
}