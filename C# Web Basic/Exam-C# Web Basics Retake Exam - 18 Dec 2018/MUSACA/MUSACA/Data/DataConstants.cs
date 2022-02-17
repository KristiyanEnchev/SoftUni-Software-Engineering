namespace MUSACA.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 20;

            public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        }

        public class Product
        {
            public const int ProductNameMinLength = 3;
            public const int ProductNameMaxLength = 100;
            public const string BarcodeLenght = @"^(\\d{12})$";
            public const int BarcodeMaxLength = 20;
            //public const string BarcodeRegexLength = @"^[0-9]{12}$";
            //[Range(typeof(decimal), "0.01", "79228162514264337593543950335")] - Price
            //[Range(1, int.MaxValue)] - Quantity
        }
    }
}
