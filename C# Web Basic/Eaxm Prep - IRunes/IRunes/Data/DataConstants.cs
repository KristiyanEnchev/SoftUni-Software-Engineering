namespace IRunes.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int UsernameMinLength = 4;
            public const int UsernameMaxLength = 10;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 20;

            public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        }

        public class Album
        {
            public const int AlbumNameMinLength = 4;
            public const int AlbumNameMaxLength = 20;

            public const int UrlMaxLength = 2048;
        }

        public class Track
        {
            public const int TrackNameMinLength = 4;
            public const int TrackNameMaxLength = 20;

            public const int UrlMaxLength = 2048;
        }
    }
}
