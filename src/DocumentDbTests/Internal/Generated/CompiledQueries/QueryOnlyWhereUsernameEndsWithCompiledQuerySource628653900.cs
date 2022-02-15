// <auto-generated/>
#pragma warning disable
using DocumentDbTests.Bugs;
using Marten.Internal.CompiledQueries;
using Marten.Linq;
using Marten.Linq.QueryHandlers;
using System;

namespace Marten.Generated.CompiledQueries
{
    // START: QueryOnlyWhereUsernameEndsWithCompiledQuery628653900
    public class QueryOnlyWhereUsernameEndsWithCompiledQuery628653900 : Marten.Internal.CompiledQueries.ClonedCompiledQuery<System.Collections.Generic.IEnumerable<Marten.Testing.Documents.User>, DocumentDbTests.Bugs.Bug_606_string_contains_starts_or_ends_with_in_compiled_queries.WhereUsernameEndsWith>
    {
        private readonly Marten.Linq.QueryHandlers.IMaybeStatefulHandler _inner;
        private readonly DocumentDbTests.Bugs.Bug_606_string_contains_starts_or_ends_with_in_compiled_queries.WhereUsernameEndsWith _query;
        private readonly Marten.Linq.QueryStatistics _statistics;
        private readonly Marten.Internal.CompiledQueries.HardCodedParameters _hardcoded;

        public QueryOnlyWhereUsernameEndsWithCompiledQuery628653900(Marten.Linq.QueryHandlers.IMaybeStatefulHandler inner, DocumentDbTests.Bugs.Bug_606_string_contains_starts_or_ends_with_in_compiled_queries.WhereUsernameEndsWith query, Marten.Linq.QueryStatistics statistics, Marten.Internal.CompiledQueries.HardCodedParameters hardcoded) : base(inner, query, statistics, hardcoded)
        {
            _inner = inner;
            _query = query;
            _statistics = statistics;
            _hardcoded = hardcoded;
        }



        public override void ConfigureCommand(Weasel.Postgresql.CommandBuilder builder, Marten.Internal.IMartenSession session)
        {
            var parameters = builder.AppendWithParameters(@"select d.data from public.mt_doc_user as d where d.data ->> 'UserName' LIKE ?");

            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;
            parameters[0].Value = StartsWith(_query.EndsWith);
        }

    }

    // END: QueryOnlyWhereUsernameEndsWithCompiledQuery628653900
    
    
    // START: QueryOnlyWhereUsernameEndsWithCompiledQuerySource628653900
    public class QueryOnlyWhereUsernameEndsWithCompiledQuerySource628653900 : Marten.Internal.CompiledQueries.CompiledQuerySource<System.Collections.Generic.IEnumerable<Marten.Testing.Documents.User>, DocumentDbTests.Bugs.Bug_606_string_contains_starts_or_ends_with_in_compiled_queries.WhereUsernameEndsWith>
    {
        private readonly Marten.Internal.CompiledQueries.HardCodedParameters _hardcoded;
        private readonly Marten.Linq.QueryHandlers.IMaybeStatefulHandler _maybeStatefulHandler;

        public QueryOnlyWhereUsernameEndsWithCompiledQuerySource628653900(Marten.Internal.CompiledQueries.HardCodedParameters hardcoded, Marten.Linq.QueryHandlers.IMaybeStatefulHandler maybeStatefulHandler)
        {
            _hardcoded = hardcoded;
            _maybeStatefulHandler = maybeStatefulHandler;
        }



        public override Marten.Linq.QueryHandlers.IQueryHandler<System.Collections.Generic.IEnumerable<Marten.Testing.Documents.User>> BuildHandler(DocumentDbTests.Bugs.Bug_606_string_contains_starts_or_ends_with_in_compiled_queries.WhereUsernameEndsWith query, Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.CompiledQueries.QueryOnlyWhereUsernameEndsWithCompiledQuery628653900(_maybeStatefulHandler, query, null, _hardcoded);
        }

    }

    // END: QueryOnlyWhereUsernameEndsWithCompiledQuerySource628653900
    
    
}
