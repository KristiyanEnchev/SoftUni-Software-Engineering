namespace FootballManager.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
            public const int PasswordMaxLengthInDb = 64;


            public const int EmailMinLenght = 10;
            public const int EmailMaxLenght = 60;
            public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        }

        public class Player 
        {
            public const int PlayernameMinLength = 5;
            public const int PlayernameMaxLength = 80;
            public const int ImageUrlLenght = 2048;
            public const int PositionMinLenght = 5;
            public const int PositionMaxLenght = 20;

            public const int CommonRangeMin = 0; 
            public const int CommonRangeMax = 10;

            public const int DescriptionMaxLenght = 200;
        }
    }
}
