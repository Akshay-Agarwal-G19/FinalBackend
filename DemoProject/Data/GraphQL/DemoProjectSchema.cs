using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.GraphQL
{
    public class DemoProjectSchema : Schema
    {
        public DemoProjectSchema(IServiceProvider resolver) : base(resolver)
        {
            Query = (IObjectGraphType)resolver.GetService(typeof(DemoProjectQuery));
            Mutation = (IObjectGraphType)resolver.GetService(typeof(DemoProjectMutation));
            
        }
    }
}
