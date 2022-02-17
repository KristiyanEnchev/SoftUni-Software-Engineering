namespace CarShop.Data
{
    public class DataConstrants
    {
        public class User
        {
            public const int UsernameMinLength = 4;
            public const int UsernameMaxLength = 20;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;

            public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        }

        public class Car
        {
            public const int ModelMinLength = 5;
            public const int ModelMaxLength = 20;

            public const int UrlMaxLength = 2048;
            public const string PlateNumberRegex = @"^([A-Z]{2})([\d]{4})([A-Z]{2})$";

        }

        public class Issue 
        {
            public const int DescriptionMinLenght = 5;
        }
    }
}
