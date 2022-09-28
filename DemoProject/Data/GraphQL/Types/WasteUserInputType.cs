using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.GraphQL.Types
{
    public class WasteUserInputType: InputObjectGraphType
    {
        public WasteUserInputType()
        {
            Name = "WasteUserInput";
            Field<NonNullGraphType<StringGraphType>>("Email");
            Field<StringGraphType>("Org_Name");
            Field<StringGraphType>("Password");
            Field<StringGraphType>("Org_Desc");
            Field<StringGraphType>("Phone_No");
            Field<StringGraphType>("Type");

        }
    }
}
