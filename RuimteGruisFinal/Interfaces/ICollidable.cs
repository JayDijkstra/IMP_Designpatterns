using Microsoft.Xna.Framework;
namespace RuimteGruisFinal
{
    public interface ICollidable
    {
        Rectangle BoundingBox { get; }
        int Damage { get;  }
        void OnCollision(ICollidable gameObject);
    }
}
