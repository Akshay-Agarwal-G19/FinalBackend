using DemoProject.Data.Entities;
using DemoProject.Data.GraphQL.Types;
using DemoProject.Repository;
using GraphQL;
using GraphQL.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Data.GraphQL
{
    public class DemoProjectMutation : ObjectGraphType
    {
        public DemoProjectMutation(WasteUserRepo wasteuserrepo, AdminRepo adminrepo, WasteRepo wasterepo)
        {
            Field<WasteUserType>(
            "createwasteuser",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WasteUserInputType>> { Name = "wasteUser" }),
            resolve: context =>
            {
                var wasteUser = context.GetArgument<WasteUser>("wasteUser");
                return wasteuserrepo.Addwasteuser(wasteUser);
            });

            Field<AdminType>(
            "createadmin",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AdminInputType>> { Name = "admin" }),
            resolve: context =>
            {
                var admin = context.GetArgument<Admin>("admin");
                return adminrepo.Addemployee(admin);
            });

            Field<WasteType>(
           "createwaste",
           arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WasteInputType>> { Name = "waste" }),
           resolve: context =>
           {
               var waste = context.GetArgument<Waste>("waste");
               return wasterepo.Addwaste(waste);
           });

            Field<ListGraphType<AdminType>>(
            "adminlogin",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AdminInputType>> { Name = "admin" }),
            resolve: context =>
            {
                var admin = context.GetArgument<Admin>("admin");
                bool checkl = adminrepo.Adminlogin(admin.Email, admin.Password);
                if (checkl)
                {
                    return adminrepo.GetAdminbyemail(admin.Email);
                }
                else
                {
                    return null;
                }
            });


            Field<ListGraphType<WasteUserType>>(
            "wasteuserlogin",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WasteUserInputType>> { Name = "wasteUser" }),
            resolve: context =>
            {
                var wasteUser = context.GetArgument<WasteUser>("wasteUser");
                bool checkl = wasteuserrepo.Userlogin(wasteUser.Email, wasteUser.Password);
                if (checkl)
                {
                    return wasteuserrepo.GetWasteUserbyemail(wasteUser.Email);
                }
                else
                {
                    return null;
                }
            });

            Field<BooleanGraphType>(
            "Usersignup",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WasteUserInputType>> { Name = "wasteUser" }),
            resolve: context =>
            {
                var user = context.GetArgument<WasteUser>("wasteUser");
                return wasteuserrepo.Usersignup(user.Email);
            });

            Field<BooleanGraphType>(
            "Adminsignup",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AdminInputType>> { Name = "admin" }),
            resolve: context =>
            {
                var user = context.GetArgument<Admin>("admin");
                return adminrepo.Adminsignup(user.Email);
            });

            Field<WasteType>(
                "updateStatus",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WasteInputType>> { Name = "waste" }),
                resolve: context =>
                {
                    var waste = context.GetArgument<Waste>("waste");
                    return wasterepo.Updatestatus(waste);
                });

            Field<WasteType>(
                "updateEnergy",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WasteInputType>> { Name = "waste" }),
                resolve: context =>
                {
                    var waste = context.GetArgument<Waste>("waste");
                    return wasterepo.Updateenergy(waste);
                });

            Field<WasteType>(
                "updateConsId",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WasteInputType>> { Name = "waste" }),
                resolve: context =>
                {
                    var waste = context.GetArgument<Waste>("waste");
                    return wasterepo.Updateconsid(waste);
                });

            Field<IntGraphType>(
                "getprodid",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WasteInputType>> { Name = "waste" }),
                resolve: context =>
                {
                    var waste = context.GetArgument<Waste>("waste");
                    return wasterepo.GetProdIdbyid(waste);
                });


        }


    }
    }

