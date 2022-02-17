namespace BattleCards.Data
{
    public class DataConstants
    {
        public class User 
        {
            public const int UserNameMinLenght = 5;
            public const int UserNameMaxLenght = 20;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLenght = 20;

            public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        }

        public class Card 
        {
            public const int CardNameMaxLength = 15;
            public const int CardNameMinLength = 5;

            public const int ImageUrlMaxLenght = 2048;

            public const int DescriptionMaxLenght = 200;
        }
    }
}
