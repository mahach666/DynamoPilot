using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.App.Utils;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace Search
{
    public static class Search
    {
        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ByTypeId(int typeId)
        {
            IQueryBuilder builder = (IQueryBuilder)StaticMetadata.SearchService.GetObjectQueryBuilder();
            builder.MaxResults(int.MaxValue);
            builder.Must(ObjectFields.TypeId.Be(typeId));


            var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());

            var results = searcher.Search(builder, default);

            return results;
        }


        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ByTypeIdAndContext(int typeId, Guid contextId)
        {
            IQueryBuilder builder = (IQueryBuilder)StaticMetadata.SearchService.GetObjectQueryBuilder();
            builder.MaxResults(int.MaxValue);
            builder.Must(ObjectFields.Context.Be(contextId));
            builder.Must(ObjectFields.TypeId.Be(typeId));


            var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());

            var results = searcher.Search(builder, default);

            return results;
        }

        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ByTypeIdAndContext(int typeId, string contextId)
        {
            return ByTypeIdAndContext(typeId, Guid.Parse(contextId));
        }

        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ByTypeIdAndText(int typeId, string searchText)
        {
            IQueryBuilder builder = (IQueryBuilder)StaticMetadata.SearchService.GetObjectQueryBuilder();
            builder.MaxResults(int.MaxValue);
            builder.Must(ObjectFields.AllText.Be(searchText));
            builder.Must(ObjectFields.TypeId.Be(typeId));

            var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());

            var results = searcher.Search(builder, default);

            return results;
        }

        [IsDesignScriptCompatible]
        public static IReadOnlyCollection<Guid> ByCustomBuilder(PQueryBuilder builder)
        {
            var searcher = new SynkSearcher((ISearchService)StaticMetadata.SearchService.Unwrap());

            var results = searcher.Search((IQueryBuilder)builder.Unwrap(), default);

            return results;
        }

        //[IsDesignScriptCompatible]
        //public static void Test()
        //{
        //    // 1. Базовые настройки запроса
        //    IQueryBuilder builder = StaticMetadata.SearchService.GetObjectQueryBuilder();
        //    builder.MaxResults(int.MaxValue);

        //    // 2. ObjectFields.Id - поиск по идентификатору объекта
        //    var id = new Guid("01A1028B-79BC-45C7-8A59-6191E8ADFE39");
        //    builder.Must(ObjectFields.Id.Be(id));
        //    builder.Must(ObjectFields.Id.Be(Guid.NewGuid()));
        //    builder.Must(ObjectFields.Id.BeAnyOf(id, Guid.NewGuid(), Guid.NewGuid()));

        //    // 3. ObjectFields.ParentId - поиск по родительскому объекту
        //    var parentId = new Guid("02B2039C-8ACD-56D8-9B6A-7302F9BEFG40");
        //    builder.Must(ObjectFields.ParentId.Be(parentId));
        //    builder.Must(ObjectFields.ParentId.Be(Guid.NewGuid()));
        //    builder.Must(ObjectFields.ParentId.BeAnyOf(parentId, Guid.NewGuid(), Guid.NewGuid()));

        //    // 4. ObjectFields.TypeId - поиск по типу объекта
        //    builder.Must(ObjectFields.TypeId.Be(18));
        //    builder.Must(ObjectFields.TypeId.BeAnyOf(16, 17, 18));
        //    builder.Must(ObjectFields.TypeId.BeAnyOf(1, 2, 3, 4, 5));

        //    // 5. ObjectFields.ObjectState - поиск по состоянию объекта
        //    builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Frozen));
        //    builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.InRecycleBin));
        //    builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Frozen, ObjectState.Alive));
        //    builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.LockRequested, ObjectState.LockAccepted));
        //    builder.Must(ObjectFields.ObjectState.Be(ObjectState.Alive));
        //    builder.Must(ObjectFields.ObjectState.Be(ObjectState.InRecycleBin));

        //    // 6. ObjectFields.CreatorId - поиск по создателю объекта
        //    builder.Must(ObjectFields.CreatorId.Be(25));
        //    builder.Must(ObjectFields.CreatorId.BeAnyOf(25, 30, 35));
        //    builder.Must(ObjectFields.CreatorId.Be(100));

        //    // 7. ObjectFields.CreatedDate - поиск по дате создания
        //    var fromDate = new DateTime(2016, 5, 5).ToUniversalTime();
        //    var toDate = DateTime.Today.ToUniversalTime();
        //    builder.Must(ObjectFields.CreatedDate.BeInRange(fromDate, toDate));
        //    builder.Must(ObjectFields.CreatedDate.BeInRange(DateTime.Now.ToUniversalTime() - TimeSpan.FromDays(30),DateTime.Now.ToUniversalTime()));

        //    // 8. ObjectFields.IsSecret - поиск скрытых/общедоступных объектов
        //    builder.Must(ObjectFields.IsSecret.Be(true));
        //    builder.Must(ObjectFields.IsSecret.Be(false));

        //    // 9. ObjectFields.AllText - поиск по текстовому содержимому
        //    builder.Must(ObjectFields.AllText.Be("Проект*"));
        //    builder.Must(ObjectFields.AllText.Be("документ"));
        //    builder.Must(ObjectFields.AllText.ContainsAll("задание", "согласование"));

        //    // 10. ObjectFields.SnapshotsCreated - поиск по дате создания версии
        //    builder.Must(ObjectFields.SnapshotsCreated.BeInRange(fromDate, toDate));

        //    // 11. ObjectFields.AllSnapshotsReason - поиск по причине создания версии
        //    builder.Must(ObjectFields.AllSnapshotsReason.Be("Обновлен*"));
        //    builder.Must(ObjectFields.AllSnapshotsReason.Be("Исправлен"));

        //    // 12. ObjectFields.SignatureAwaitingBy - поиск документов, ожидающих подписания
        //    var gipPositionId = 42;
        //    builder.Must(ObjectFields.SignatureAwaitingBy.Be(gipPositionId));
        //    builder.Must(ObjectFields.SignatureAwaitingBy.BeAnyOf(42, 45, 50));

        //    // 13. ObjectFields.SignedBy - поиск подписанных документов
        //    builder.Must(ObjectFields.SignedBy.Be(gipPositionId));
        //    builder.Must(ObjectFields.SignedBy.BeAnyOf(42, 45, 50));

        //    // 14. ObjectFields.StateChangedPersonId - поиск заблокированных объектов
        //    var gipPersonId = 25;
        //    builder.Must(ObjectFields.StateChangedPersonId.Be(gipPersonId));
        //    builder.Must(ObjectFields.StateChangedPersonId.BeAnyOf(25, 30, 35));

        //    // 15. AttributeFields.String - поиск по строковому атрибуту
        //    builder.Must(AttributeFields.String("AttributeName").Be("Искать*"));
        //    builder.Must(AttributeFields.String("Name").Be("Документ"));
        //    builder.Must(AttributeFields.String("Status").Be("Активный"));

        //    // 16. AttributeFields.DateTime - поиск по атрибуту типа дата
        //    builder.Must(AttributeFields.DateTime("CreatedDate").BeInRange(fromDate, toDate));

        //    // 17. AttributeFields.Double - поиск по атрибуту типа вещественное число
        //    builder.Must(AttributeFields.Double("Weight").Be(2.2));
        //    builder.Must(AttributeFields.Double("Price").BeAnyOf(100.5, 200.0, 300.75));
        //    builder.Must(AttributeFields.Double("Volume").BeInRange(0.0, 1000.0));

        //    // 18. AttributeFields.Integer - поиск по атрибуту типа целое число
        //    builder.Must(AttributeFields.Integer("Count").Be(2));
        //    builder.Must(AttributeFields.Integer("Version").BeAnyOf(1, 2, 3));
        //    builder.Must(AttributeFields.Integer("Priority").BeInRange(1, 10));

        //    // 19. AttributeFields.Bool - поиск по атрибуту типа булевое значение
        //    builder.Must(AttributeFields.Bool("IsApproved").Be(true));
        //    builder.Must(AttributeFields.Bool("IsActive").Be(false));

        //    // 20. Комбинированные фильтры - ObjectFields + AttributeFields
        //    builder.Must(ObjectFields.TypeId.Be(18));
        //    builder.Must(AttributeFields.String("Status").Be("Активный"));

        //    builder.Must(ObjectFields.CreatorId.Be(25));
        //    builder.Must(AttributeFields.Bool("IsApproved").Be(true));

        //    builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive));
        //    builder.Must(AttributeFields.DateTime("CreatedDate").BeInRange(fromDate, toDate));

        //    // 21. Использование MustNot - исключение условий
        //    builder.MustNot(ObjectFields.IsSecret.Be(true));
        //    builder.MustNot(AttributeFields.Bool("IsArchived").Be(true));

        //    // 22. Использование MustAnyOf - альтернативные условия
        //    builder.MustAnyOf(
        //        ObjectFields.TypeId.Be(18),
        //        ObjectFields.TypeId.Be(19),
        //        ObjectFields.TypeId.Be(20)
        //    );

        //    builder.MustAnyOf(
        //        ObjectFields.AllText.Be("Проект*"),
        //        ObjectFields.AllText.Be("документ"),
        //        AttributeFields.String("Category").Be("Важный")
        //    );

        //    // 23. Сложные комбинации с MustAnyOf
        //    builder.Must(ObjectFields.TypeId.Be(18));
        //    builder.MustAnyOf(
        //        ObjectFields.CreatorId.Be(25),
        //        ObjectFields.CreatorId.Be(30)
        //    );
        //    builder.MustNot(ObjectFields.ObjectState.Be(ObjectState.InRecycleBin));

        //    // 24. Фильтры по диапазонам дат
        //    builder.Must(ObjectFields.CreatedDate.BeInRange(fromDate, toDate));
        //    builder.Must(ObjectFields.SnapshotsCreated.BeInRange(fromDate, toDate));
        //    builder.Must(AttributeFields.DateTime("ModifiedDate").BeInRange(fromDate, toDate));

        //    // 25. Фильтры по множественным значениям
        //    builder.Must(ObjectFields.TypeId.BeAnyOf(1, 2, 3, 4, 5));
        //    builder.Must(ObjectFields.CreatorId.BeAnyOf(25, 30, 35, 40));
        //    builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));

        //    // 26. Текстовые поиски с различными операторами
        //    builder.Must(ObjectFields.AllText.Be("Проект*"));
        //    builder.Must(ObjectFields.AllText.ContainsAll("задание", "согласование"));
        //    builder.Must(AttributeFields.String("Description").Be("Важный*"));

        //    // 27. Комбинации с состоянием объекта
        //    builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.LockRequested, ObjectState.LockAccepted));
        //    builder.Must(ObjectFields.StateChangedPersonId.Be(gipPersonId));

        //    builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Frozen, ObjectState.Alive));
        //    builder.MustNot(ObjectFields.ObjectState.Be(ObjectState.InRecycleBin));

        //    // 28. Фильтры по подписям
        //    builder.Must(ObjectFields.SignatureAwaitingBy.Be(gipPositionId));
        //    builder.Must(ObjectFields.SignedBy.Be(gipPositionId));

        //    // 29. Фильтры по версиям
        //    builder.Must(ObjectFields.AllSnapshotsReason.Be("Обновлен*"));
        //    builder.Must(ObjectFields.SnapshotsCreated.BeInRange(fromDate, toDate));

        //    // 30. Комплексная комбинация всех типов фильтров
        //    builder.Must(ObjectFields.TypeId.Be(18));
        //    builder.Must(ObjectFields.CreatorId.Be(25));
        //    builder.Must(ObjectFields.ObjectState.BeAnyOf(ObjectState.Alive, ObjectState.Frozen));
        //    builder.Must(ObjectFields.CreatedDate.BeInRange(fromDate, toDate));
        //    builder.Must(ObjectFields.AllText.Be("Проект*"));
        //    builder.Must(AttributeFields.String("Status").Be("Активный"));
        //    builder.Must(AttributeFields.Bool("IsApproved").Be(true));
        //    builder.MustNot(ObjectFields.IsSecret.Be(true));
        //    builder.MustNot(ObjectFields.ObjectState.Be(ObjectState.InRecycleBin));
        //}
    }
}