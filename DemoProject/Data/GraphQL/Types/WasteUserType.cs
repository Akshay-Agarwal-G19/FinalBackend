using DemoProject.Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.GraphQL.Types
{
    public class WasteUserType:ObjectGraphType<WasteUser>
    {
        public WasteUserType()
        {
            Field(t => t.Id);
            Field(t => t.Email);
            Field(t => t.Org_Name);
            Field(t => t.Org_Desc);
            Field(t => t.Phone_No);
            Field(t => t.Type);
        }
    }
}
