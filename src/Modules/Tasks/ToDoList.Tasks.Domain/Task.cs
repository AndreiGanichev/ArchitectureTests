using ToDoList.BuildingBlocks;
using ToDoList.Tasks.Domain.Events;
using ToDoList.Tasks.Domain.Exceptions;

namespace ToDoList.Tasks.Domain;

public class Task : Entity, IAggregateRoot
{
    private readonly List<Observer> _observers;

    public Guid Id { get; }
    public Title Title { get; private set; }
    public Reminder? Reminder { get; private set; }
    public IReadOnlyList<Observer> Observers => _observers.AsReadOnly();

    private Task(Guid id, Title title)
    {
        Id = id;
        Title = title;
    }

    public static Task Create(Title title) => new(Guid.NewGuid(), title);

    public void AddObserver(Guid observerId, ObserverRole role)
    {
        if (_observers.Any(o => o.Id == observerId))
        {
            throw new ObserverCanBeAddedOnlyOnceException();
        }
        
        var observer = Observer.Create(Id, observerId, role);
        _observers.Add(observer);
        
        AddDomainEvent(new ObserverAddedDomainEvent(Id, observerId, role));
    }
    public void ChangeObserverRole(Guid observerId, ObserverRole role)
    {
        var observer = _observers.SingleOrDefault() ?? throw new ObserverNotFoundException();

        observer.ChangeRole(role);
    }
}