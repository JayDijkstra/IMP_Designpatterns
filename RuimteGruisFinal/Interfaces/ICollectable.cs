using Microsoft.Xna.Framework;
namespace RuimteGruisFinal
{
    public interface ICollectable
    {
		bool PickedUp { get; set; }
		void OnPickup(Ship ship, World world);
    }
}
