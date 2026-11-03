# Design Patterns Notes

Tracking the 23 classic GoF design patterns as I learn them in this project.

## Creational — object creation mechanisms

| Pattern | Description | Status |
|---|---|---|
| Singleton | Ensure a class has only one instance, with global access to it. | ✅ `Patterns/Creational/Singleton` |
| Factory Method | Delegate object creation to subclasses instead of calling `new` directly. | Not started |
| Abstract Factory | Produce families of related objects without specifying their concrete classes. | Not started |
| Builder | Construct a complex object step by step, separating construction from representation. | Not started |
| Prototype | Create new objects by cloning an existing instance instead of instantiating a class. | Not started |

## Structural — composing classes and objects

| Pattern | Description | Status |
|---|---|---|
| Adapter | Convert one interface into another that a client expects. | Not started |
| Bridge | Decouple an abstraction from its implementation so both can vary independently. | Not started |
| Composite | Compose objects into tree structures and treat individual objects and compositions uniformly. | Not started |
| Decorator | Attach new behavior to an object dynamically by wrapping it. | Not started |
| Facade | Provide a simplified interface to a complex subsystem. | Not started |
| Flyweight | Share common state across many fine-grained objects to reduce memory use. | Not started |
| Proxy | Provide a stand-in for another object to control access to it. | Not started |

## Behavioral — communication between objects

| Pattern | Description | Status |
|---|---|---|
| Chain of Responsibility | Pass a request along a chain of handlers until one handles it. | Not started |
| Command | Encapsulate a request as an object, allowing queuing, logging, and undo. | Not started |
| Interpreter | Define a representation for a grammar and an interpreter to evaluate it. | Not started |
| Iterator | Access elements of a collection sequentially without exposing its structure. | Not started |
| Mediator | Centralize complex communication between related objects. | Not started |
| Memento | Capture and restore an object's internal state without violating encapsulation. | Not started |
| Observer | Notify multiple dependent objects automatically when one object's state changes. | Not started |
| State | Alter an object's behavior when its internal state changes. | Not started |
| Strategy | Define a family of interchangeable algorithms and select one at runtime. | Not started |
| Template Method | Define the skeleton of an algorithm, letting subclasses override specific steps. | Not started |
| Visitor | Separate an algorithm from the object structure it operates on. | Not started |

## Project layout convention

```
Patterns/
  Creational/<PatternName>/
  Structural/<PatternName>/
  Behavioral/<PatternName>/
```

Each pattern folder holds its implementation; `Program.cs` runs demos.


dotnet run                    # run all pattern demos
dotnet run -- singleton       # run just Singleton
dotnet run -- factory         # run just Factory Method
dotnet run -- --list          # list available pattern keys





