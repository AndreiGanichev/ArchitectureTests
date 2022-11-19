using ToDoList.BuildingBlocks.Domain;
using ToDoList.Tasks.Domain.Events;
using ToDoList.Tasks.Domain.Exceptions;

namespace ToDoList.Tasks.Domain;

public class Task : Entity, IAggregateRoot
{
    private readonly List<Observer> _observers = new();

    public Guid Id { get; }
    public Guid AuthorId { get; }
    public Title Title { get; private set; }
    public DateOnly Date  { get; private set; }
    public DateTimeOffset RemindAt { get; private set; }
    public IReadOnlyList<Observer> Observers => _observers.AsReadOnly();

    //public ToDoList.Notifications.Domain.PhoneNumber Phone { get; }

    private Task(Guid id, Guid authorId, Title title, DateOnly date, DateTimeOffset remindAt)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
        Date = date;
        RemindAt = remindAt;
        
        AddDomainEvent(new TaskCreatedDomainEvent(id, authorId, title, date, remindAt));
    }

    public static Task Create(Guid authorId, Title title, DateOnly date, DateTimeOffset remindAt) => new(Guid.NewGuid(), authorId, title, date, remindAt);

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