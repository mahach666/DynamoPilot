# DynamoPilot Nodes

Набор пользовательских нод для Dynamo, интегрированных с Pilot-BIM.

## Структура проекта

```
DynamoPilot.Nodes/
├── HelloNode.cs          # Простая нода "Hello World"
├── MathNode.cs           # Математические операции
├── StringNode.cs         # Операции со строками
├── AllTypes.cs           # Выбор типов из репозитория Pilot
└── README.md             # Эта документация
```

## Как создать новую ноду

### 1. Базовая структура ноды

```csharp
using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System.Collections.Generic;

namespace DynamoPilot.Nodes
{
    [NodeName("Имя ноды")]
    [NodeCategory("Pilot.Категория")]
    [NodeDescription("Описание ноды")]
    [IsDesignScriptCompatible]
    [InPortNames("вход1", "вход2")]
    [InPortTypes("тип1", "тип2")]
    [InPortDescriptions("описание1", "описание2")]
    [OutPortNames("выход1", "выход2")]
    [OutPortTypes("тип1", "тип2")]
    [OutPortDescriptions("описание1", "описание2")]
    public class MyNode : NodeModel
    {
        // Конструктор для создания новой ноды
        public MyNode()
        {
            RegisterAllPorts();
        }

        // Конструктор для загрузки из .dyn файла
        [JsonConstructor]
        private MyNode(IEnumerable<PortModel> inPorts,
                      IEnumerable<PortModel> outPorts)
            : base(inPorts, outPorts) { }

        // Логика ноды
        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            // Ваша логика здесь
            return new[]
            {
                AstFactory.BuildAssignment(
                    GetAstIdentifierForOutputIndex(0),
                    AstFactory.BuildStringNode("результат"))
            };
        }
    }
}
```

### 2. Типы нод

#### Простая нода (без входов)
```csharp
public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
{
    return new[]
    {
        AstFactory.BuildAssignment(
            GetAstIdentifierForOutputIndex(0),
            AstFactory.BuildStringNode("Привет мир!"))
    };
}
```

#### Нода с входами
```csharp
public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
{
    var input1 = inputAstNodes[0];
    var input2 = inputAstNodes[1];
    
    return new[]
    {
        AstFactory.BuildAssignment(
            GetAstIdentifierForOutputIndex(0),
            AstFactory.BuildBinaryExpression(input1, input2, ProtoCore.DSASM.Operator.add))
    };
}
```

#### Dropdown нода
```csharp
public class MyDropdownNode : DSDropDownBase
{
    public MyDropdownNode() : base("Заголовок") { }

    [JsonConstructor]
    public MyDropdownNode(IEnumerable<PortModel> inPorts,
                         IEnumerable<PortModel> outPorts) : base("Заголовок") { }

    protected override SelectionState PopulateItemsCore(string currentSelection)
    {
        Items.Clear();
        Items.Add(new DynamoDropDownItem("Элемент 1", "значение1"));
        Items.Add(new DynamoDropDownItem("Элемент 2", "значение2"));
        return SelectionState.Done;
    }

    public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
    {
        return new[]
        {
            AstFactory.BuildAssignment(
                GetAstIdentifierForOutputIndex(0),
                AstFactory.BuildStringNode(SelectedIndex >= 0 ? Items[SelectedIndex].Name : ""))
        };
    }
}
```

### 3. Доступные типы данных

- `string` - строка
- `double` - число с плавающей точкой
- `int` - целое число
- `bool` - логическое значение
- `var` - любой тип

### 4. Операторы

```csharp
// Математические операции
ProtoCore.DSASM.Operator.add    // +
ProtoCore.DSASM.Operator.sub    // -
ProtoCore.DSASM.Operator.mul    // *
ProtoCore.DSASM.Operator.div    // /

// Сравнения
ProtoCore.DSASM.Operator.eq     // ==
ProtoCore.DSASM.Operator.ne     // !=
ProtoCore.DSASM.Operator.gt     // >
ProtoCore.DSASM.Operator.lt     // <
ProtoCore.DSASM.Operator.ge     // >=
ProtoCore.DSASM.Operator.le     // <=
```

### 5. Функции

```csharp
// Создание строки
AstFactory.BuildStringNode("текст")

// Создание числа
AstFactory.BuildDoubleNode(123.45)

// Создание целого числа
AstFactory.BuildIntNode(42)

// Вызов функции
AstFactory.BuildFunctionCall("ИмяФункции", new List<AssociativeNode> { параметр1, параметр2 })

// Создание null
AstFactory.BuildNullNode()
```

## Интеграция с Pilot

### Доступ к репозиторию

```csharp
using DynamoPilot.Data;

// В любой ноде можно получить доступ к репозиторию
if (StaticMetadata.ObjectsRepository != null)
{
    var types = StaticMetadata.ObjectsRepository.GetTypes();
    // Работа с типами Pilot
}
```

### Пример ноды для работы с Pilot

```csharp
[NodeName("Pilot Object Count")]
[NodeCategory("Pilot.Data")]
[NodeDescription("Подсчитывает количество объектов в Pilot")]
[IsDesignScriptCompatible]
[OutPortNames("count")]
[OutPortTypes("int")]
[OutPortDescriptions("Количество объектов")]
public class PilotObjectCountNode : NodeModel
{
    public PilotObjectCountNode()
    {
        RegisterAllPorts();
    }

    [JsonConstructor]
    private PilotObjectCountNode(IEnumerable<PortModel> inPorts,
                                IEnumerable<PortModel> outPorts)
        : base(inPorts, outPorts) { }

    public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> _)
    {
        int count = 0;
        
        if (StaticMetadata.ObjectsRepository != null)
        {
            try
            {
                count = StaticMetadata.ObjectsRepository.GetTypes().Count();
            }
            catch
            {
                count = -1; // Ошибка
            }
        }

        return new[]
        {
            AstFactory.BuildAssignment(
                GetAstIdentifierForOutputIndex(0),
                AstFactory.BuildIntNode(count))
        };
    }
}
```

## Сборка и развертывание

1. Соберите проект:
   ```bash
   dotnet build src/DynamoPilot.Nodes/DynamoPilot.Nodes.csproj
   ```

2. Файлы автоматически копируются в папку пакета:
   ```
   src/bin/Debug/net481/packages/PilotNodes/
   ```

3. Структура пакета:
   ```
   PilotNodes/
   ├── package.json
   └── bin/
       ├── DynamoPilot.Nodes.dll
       └── DynamoPilot.Data.dll
   ```

## Использование нод в Dynamo

1. Запустите Pilot-BIM
2. Откройте Dynamo через меню DynamoPilot
3. В библиотеке нод найдите категорию "Pilot"
4. Перетащите нужную ноду на рабочую область

## Отладка

- Проверьте консоль Dynamo на наличие ошибок
- Убедитесь, что все зависимости загружены
- Проверьте, что репозиторий Pilot доступен

## Полезные ссылки

- [Dynamo API Documentation](https://github.com/DynamoDS/Dynamo/wiki)
- [Pilot SDK Documentation](https://ascon.ru/products/pilot-bim/)
- [DesignScript Language Reference](https://github.com/DynamoDS/Dynamo/wiki/DesignScript-Language-Reference) 