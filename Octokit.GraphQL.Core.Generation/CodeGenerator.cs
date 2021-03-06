﻿using System;
using System.Collections.Generic;
using Octokit.GraphQL.Core.Generation.Models;
using Octokit.GraphQL.Core.Introspection;

namespace Octokit.GraphQL.Core.Generation
{
    public static class CodeGenerator
    {
        public static IEnumerable<GeneratedFile> Generate(SchemaModel schema, string rootNamespace)
        {
            foreach (var type in schema.Types)
            {
                if (!type.Name.StartsWith("__") && type.Kind != TypeKind.Scalar)
                {
                    var content = Generate(type, rootNamespace, schema.QueryType);

                    if (content != null)
                    {
                        yield return new GeneratedFile(type.Name + ".cs", content);
                    }
                }
            }
        }

        public static string Generate(TypeModel type, string rootNamespace, string queryType)
        {
            switch (type.Kind)
            {
                case TypeKind.Object:
                    if (type.Name == queryType)
                    {
                        return EntityGenerator.GenerateRoot(type, rootNamespace);
                    }
                    else
                    {
                        return EntityGenerator.Generate(type, rootNamespace);
                    }

                case TypeKind.Interface:
                    return InterfaceGenerator.Generate(type, rootNamespace);

                case TypeKind.Enum:
                    return EnumGenerator.Generate(type, rootNamespace);

                case TypeKind.InputObject:
                    return InputObjectGenerator.Generate(type, rootNamespace);

                case TypeKind.Union:
                    return UnionGenerator.Generate(type, rootNamespace);

                default:
                    return null;
            }
        }
    }
}
