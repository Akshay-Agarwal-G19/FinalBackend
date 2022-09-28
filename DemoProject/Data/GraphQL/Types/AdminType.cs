using DemoProject.Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.GraphQL.Types
{
    public class AdminType:ObjectGraphType<Admin>
    {
        public AdminType()
        {
            Field(t => t.Admin_Id);
            Field(t => t.Email);

        }
    }
}
