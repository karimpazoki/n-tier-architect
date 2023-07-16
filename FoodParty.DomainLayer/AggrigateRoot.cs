using FoodParty.DomainLayer.Contracts;

namespace FoodParty.DomainLayer;

public abstract class AggrigateRoot<TKey>: EntityBase<TKey>, IAggrigateRoot
{
    protected AggrigateRoot(){}
}