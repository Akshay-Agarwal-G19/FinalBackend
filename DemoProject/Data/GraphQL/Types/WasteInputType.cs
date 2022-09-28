using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.GraphQL.Types
{
    public class WasteInputType : InputObjectGraphType
    {
        public WasteInputType()
        {
            Name = "WasteInput";
            Field<StringGraphType>("Type");
            Field<StringGraphType>("Primary_Substance");
            Field<IntGraphType>("Quantity");
            Field<StringGraphType>("Month");
            Field<StringGraphType>("Status");
            Field<IntGraphType>("Energy");
            Field<IntGraphType>("Prod_Id");
            Field<IntGraphType>("Cons_Id");
            Field<IntGraphType>("Request_Cons_Id");
            Field<IntGraphType>("Waste_Id");
            Field<StringGraphType>("Prod_Name");
            Field<StringGraphType>("Cons_Name");
            Field<StringGraphType>("Request_Cons_Name");
        }
    }
}
