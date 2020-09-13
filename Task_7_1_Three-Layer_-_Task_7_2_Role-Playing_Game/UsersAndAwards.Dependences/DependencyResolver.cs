using UsersAndAwards.BLL;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAL;
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

        static DependencyResolver()
        {
            UserDal = new UserDAL();
            UserLogic = new UserLogic(UserDal);
            AwardDAL = new AwardDAL();
            AwardLogic = new AwardLogic(AwardDAL);
            BindingUserAwardDAL = new BindingUserAwardDAL();
            BindingUserAwardLogic = new BindingUserAwardLogic(BindingUserAwardDAL);
        }
    }
}