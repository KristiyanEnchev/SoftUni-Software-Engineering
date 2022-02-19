namespace Andreys.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int UsernameMinLength = 4;
            public const int UsernameMaxLength = 10;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 20;
            public const int PasswordMaxLengthInDb = 64;

            public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        }

        public class Product
        {
            public const int ProductNameMinLenght = 4;
            public const int ProductNameMaxLenght = 20;

            public const int DescriptionMaxLenght = 10;

            public const int ImageUrlMaxLenght = 2048;
        }
    }
}
