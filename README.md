# ArchitectureTests

> While software architects are interested in exploring evolutionary architectures, we aren’t attempting to model biological evolution. Theoretically, we could build an architecture that randomly changed one of its bits (mutation) and redeployed itself. After a few million years, we would likely have a very interesting architecture. However, we don’t have millions of years to wait.
We want our architecture to **evolve in a guided way**, so we place constraints on different aspects of the architecture to reign in undesirable evolutionary directions. A good example is dog breeding: By selecting the characteristics we want, we can create a vast number of different shaped canines in a relatively short amount of time.

Проект предназначен для демонстрации возможностей архитектурных тестов. Представляет собой приложение для ведения списка дел. Реализован в виде модульного монолита. Внутри модулей используется Clean architecture.

![Архитектура](docs/high-level-architecture.png)

Архитектурные тесты реализованы с помощью:
1. [ArchUnitNet](https://github.com/TNG/ArchUnitNET)
2. [NetArchTest](https://github.com/BenMorris/NetArchTest)

## Источники

### Архитектура

1. Building Evolutionary Architectures. Neal Ford, Rebecca Parsons, Patrick Kua
1. Clean Architecture: A Craftsman's Guide to Software Structure and Design. Robert C. Martin
1. [Who Needs an Architect?](https://martinfowler.com/ieeeSoftware/whoNeedsArchitect.pdf) Martin Fowler
1. [Is High Quality Software Worth the Cost?](https://martinfowler.com/articles/is-quality-worth-cost.html) Martin Fowler
1. [Vertical Slice Architecture](https://jimmybogard.com/vertical-slice-architecture/) Jimmy Bogard
1. [PresentationDomainDataLayering](https://martinfowler.com/bliki/PresentationDomainDataLayering.html) Martin Fowler

### Архитектурные тесты

1. [Unit Test Your Architecture with ArchUnit](https://blogs.oracle.com/javamagazine/post/unit-test-your-architecture-with-archunit) Jonas Havers
1. [Writing ArchUnit style tests for .NET and C# for self testing architecture rules](https://www.ben-morris.com/writing-archunit-style-tests-for-net-and-c-for-self-testing-architectures/)

### Идеи для проверок

1. HttpClient создается только с помощью [IHttClientFactory](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests?WT.mc_id=DT-MVP-5003978#issues-with-the-original-httpclient-class-available-in-net)
1. Все enpoints возвращают ошибку в формате [Problem Details](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.problemdetails?view=aspnetcore-7.0)
1. Все модели запросов/ответов сериализуемы. Актуально в случае кастомных типов, для которых не поддерживается сериализация "из коробки".
1. При логирование используется шаблон с параметрами, а не интерполяция строк.