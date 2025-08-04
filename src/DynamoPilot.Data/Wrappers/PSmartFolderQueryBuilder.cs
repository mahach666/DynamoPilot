using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;

namespace DynamoPilot.Data.Wrappers
{
    public class PSmartFolderQueryBuilder : IWrapper
    {
        private readonly ISmartFolderQueryBuilder _smartFolderQueryBuilder;

        public PSmartFolderQueryBuilder(ISmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            _smartFolderQueryBuilder = smartFolderQueryBuilder;
        }

        public object Unwrap()
        {
            return _smartFolderQueryBuilder;
        }

        public PSmartFolderQueryBuilder WithAuthor(int authorId)
        {
            _smartFolderQueryBuilder.WithAuthor(authorId);
            return this;
        }

        public PSmartFolderQueryBuilder WithAuthors(IEnumerable<int> authorIds)
        {
            _smartFolderQueryBuilder.WithAuthors(authorIds);
            return this;
        }

        public PSmartFolderQueryBuilder WithCreatedInRange(DateTime fromUtc, DateTime toUtc)
        {
            _smartFolderQueryBuilder.WithCreatedInRange(fromUtc, toUtc);
            return this;
        }

        public PSmartFolderQueryBuilder WithCreatedLastMonth()
        {
            _smartFolderQueryBuilder.WithCreatedLastMonth();
            return this;
        }

        public PSmartFolderQueryBuilder WithCreatedLastWeek()
        {
            _smartFolderQueryBuilder.WithCreatedLastWeek();
            return this;
        }

        public PSmartFolderQueryBuilder WithCreatedLastYear()
        {
            _smartFolderQueryBuilder.WithCreatedLastYear();
            return this;
        }

        public PSmartFolderQueryBuilder WithCreatedThisMonth()
        {
            _smartFolderQueryBuilder.WithCreatedThisMonth();
            return this;
        }

        public PSmartFolderQueryBuilder WithCreatedThisWeek()
        {
            _smartFolderQueryBuilder.WithCreatedThisWeek();
            return this;
        }

        public PSmartFolderQueryBuilder WithCreatedThisYear()
        {
            _smartFolderQueryBuilder.WithCreatedThisYear();
            return this;
        }

        public PSmartFolderQueryBuilder WithCreatedToday()
        {
            _smartFolderQueryBuilder.WithCreatedToday();
            return this;
        }

        public PSmartFolderQueryBuilder WithCreatedYesterday()
        {
            _smartFolderQueryBuilder.WithCreatedYesterday();
            return this;
        }

        public PSmartFolderQueryBuilder WithKeyword(string keyword)
        {
            _smartFolderQueryBuilder.WithKeyword(keyword);
            return this;
        }

        public PSmartFolderQueryBuilder WithQuotedKeyword(string keyword)
        {
            _smartFolderQueryBuilder.WithQuotedKeyword(keyword);
            return this;
        }

        public PSmartFolderQueryBuilder WithSearchMode(SearchMode searchMode)
        {
            _smartFolderQueryBuilder.WithSearchMode(searchMode);
            return this;
        }

        public PSmartFolderQueryBuilder WithState(ObjectState state)
        {
            _smartFolderQueryBuilder.WithState(state);
            return this;
        }

        public PSmartFolderQueryBuilder WithType(int typeId)
        {
            _smartFolderQueryBuilder.WithType(typeId);
            return this;
        }

        public PSmartFolderQueryBuilder WithTypes(IEnumerable<int> typeIds)
        {
            _smartFolderQueryBuilder.WithTypes(typeIds);
            return this;
        }
    }
}
