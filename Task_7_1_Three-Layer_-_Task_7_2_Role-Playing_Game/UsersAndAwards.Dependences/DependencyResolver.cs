﻿using UsersAndAwards.BLL;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAL;
using UsersAndAwards.DAL.SQL;
using UsersAndAwards.DAL.Interfaces;

namespace UsersAndAwards.Dependences
{
    public static class DependencyResolver
    {
        public static IUserLogic UserLogic { get; private set; }
        public static IUserDAL UserDal { get; private set; }
        public static IAwardLogic AwardLogic { get; private set; }
        public static IAwardDAL AwardDAL { get; private set; }
        public static IBindingUserAwardLogic BindingUserAwardLogic { get; private set; }
        public static IBindingUserAwardDAL BindingUserAwardDAL { get; private set; }
        public static IRegistratorLogic RegistratorLogic { get; private set; }
        public static IRegistratorDAL RegistratorDAL { get; private set; }

        static DependencyResolver()
        {
            // UserDal = new UserDAL(); // JSON implementation
            UserDal = new DAL.SQL.UserDAL(); // MS SQL implementation
            UserLogic = new UserLogic(UserDal);
            // AwardDAL = new AwardDAL();
            AwardDAL = new DAL.SQL.AwardDAL();
            AwardLogic = new AwardLogic(AwardDAL);
            // BindingUserAwardDAL = new BindingUserAwardDAL();
            BindingUserAwardDAL = new DAL.SQL.BindingUserAwardDAL();
            BindingUserAwardLogic = new BindingUserAwardLogic(BindingUserAwardDAL);
            // RegistratorDAL = new RegistratorDAL();
            RegistratorDAL = new DAL.SQL.RegistratorDAL();
            RegistratorLogic = new RegistratorLogic(RegistratorDAL);
        }
    }
}