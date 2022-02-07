namespace CnD.Scripts.Interfaces
{
    public interface ISpaceShipElement
    {
        void Accept(IVisitor visitor);
    }
}