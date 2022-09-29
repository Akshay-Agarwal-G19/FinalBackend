using DemoProject.Data.GraphQL.Types;
using DemoProject.Repository;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.GraphQL
{
    public class DemoProjectQuery : ObjectGraphType
    {
        public DemoProjectQuery(WasteUserRepo wasteuserrepo, AdminRepo adminrepo, WasteRepo wasterepo)
        {
            Field<ListGraphType<WasteUserType>>(
                "wasteusers",
                resolve: context => wasteuserrepo.GetWasteUser()
                );

            Field<ListGraphType<WasteUserType>>(
                "producers",
                resolve: context => wasteuserrepo.GetProducers()
                );

            Field<ListGraphType<WasteUserType>>(
                "consumers",
                resolve: context => wasteuserrepo.GetConsumers()
                );

            Field<ListGraphType<WasteUserType>>(
               "wasteuserbyid",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Id" }),
               resolve: context =>
               {
                   var Id = context.GetArgument<int>("Id");
                   return wasteuserrepo.GetWasteUserbyid(Id);
               }
              );

            


            Field<ListGraphType<AdminType>>(
                    "admins",
                    resolve: context => adminrepo.GetEmployees()
                    );

            Field<ListGraphType<WasteType>>(
               "wastes",
               resolve: context => wasterepo.GetWaste()
               );

            Field<ListGraphType<WasteType>>(
              "wastebyid",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Waste_Id" }),
              resolve: context =>
              {
                  var Waste_Id = context.GetArgument<int>("Waste_Id");
                  return wasterepo.GetWastebyid(Waste_Id);
              }
             );


            Field<ListGraphType<WasteType>>(
              "wastebyprodid",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Prod_Id" }),
              resolve: context =>
              {
                  var Prod_Id = context.GetArgument<int>("Prod_Id");
                  return wasterepo.GetWastebyprodid(Prod_Id);
              }
             );


            Field<ListGraphType<WasteType>>(
              "wastebyreqconsid",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Request_Cons_Id" }),
              resolve: context =>
              {
                  var Request_Cons_Id = context.GetArgument<int>("Request_Cons_Id");
                  return wasterepo.GetWastebyreqconsid(Request_Cons_Id);
              }
             );

            Field<ListGraphType<WasteType>>(
            "wastebyconsid",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Cons_Id" }),
            resolve: context =>
            {
                var Cons_Id = context.GetArgument<int>("Cons_Id");
                return wasterepo.GetWastebyconsid(Cons_Id);
            }
           );

            Field<ListGraphType<WasteType>>(
            "wastebyprodidenergy",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Prod_Id" }),
            resolve: context =>
            {
                var Prod_Id = context.GetArgument<int>("Prod_Id");
                return wasterepo.GetWastebyprodidenergy(Prod_Id);
            }
           );

            Field<ListGraphType<WasteType>>(
              "wastebyprodidenergysorted",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Prod_Id" }),
              resolve: context =>
              {
                  var Prod_Id = context.GetArgument<int>("Prod_Id");
                  return wasterepo.Getorderedbyenergy(Prod_Id);
              }
             );

            Field<ListGraphType<WasteType>>(
              "wastebyconsidenergysorted",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Cons_Id" }),
              resolve: context =>
              {
                  var Cons_Id = context.GetArgument<int>("Cons_Id");
                  return wasterepo.Getorderedbyenergyc(Cons_Id);
              }
             );

            Field<ListGraphType<WasteType>>(
              "wastebyprodidquantitysorted",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Prod_Id" }),
              resolve: context =>
              {
                  var Prod_Id = context.GetArgument<int>("Prod_Id");
                  return wasterepo.Getorderedbyquantity(Prod_Id);
              }
             );

            Field<ListGraphType<WasteType>>(
              "wastebyconsidquantitysorted",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Cons_Id" }),
              resolve: context =>
              {
                  var Cons_Id = context.GetArgument<int>("Cons_Id");
                  return wasterepo.Getorderedbyquantityc(Cons_Id);
              }
             );

            Field<ListGraphType<WasteType>>(
              "lastwastebyprod",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Prod_Id" }),
              resolve: context =>
              {
                  var Prod_Id = context.GetArgument<int>("Prod_Id");
                  return wasterepo.Getlastwastebyprod(Prod_Id);
              }
             );

            Field<ListGraphType<WasteType>>(
              "lastwastebycons",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Cons_Id" }),
              resolve: context =>
              {
                  var Cons_Id = context.GetArgument<int>("Cons_Id");
                  return wasterepo.Getlastwastebycons(Cons_Id);
              }
             );

            Field<ListGraphType<WasteType>>(
              "lastwastebyprodenn",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Prod_Id" }),
              resolve: context =>
              {
                  var Prod_Id = context.GetArgument<int>("Prod_Id");
                  return wasterepo.Getlastwastebyprodenn(Prod_Id);
              }
             );

            Field<ListGraphType<WasteType>>(
             "lastwastebyconsenn",
             arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Cons_Id" }),
             resolve: context =>
             {
                 var Cons_Id = context.GetArgument<int>("Cons_Id");
                 return wasterepo.Getlastwastebyconsenn(Cons_Id);
             }
            );

        }

    }
}
