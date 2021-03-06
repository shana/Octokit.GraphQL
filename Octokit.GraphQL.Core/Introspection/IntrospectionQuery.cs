﻿using System;
using Octokit.GraphQL.Core.Builders;

namespace Octokit.GraphQL.Core.Introspection
{
    public class IntrospectionQuery : QueryEntity, IRootQuery
    {
        public IntrospectionQuery()
            : base(new QueryProvider())
        {
        }

        [GraphQLIdentifier("__schema")]
        public Schema Schema => this.CreateProperty(x => x.Schema, Schema.Create);
    }
}
