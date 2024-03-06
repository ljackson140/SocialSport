namespace Social.Sport.Core.Constants
{
    public class ConstantConfig
    {
        public class APIConfig 
        {
            public const string UseInMemoryDatabaseKey = "UseInMemoryDatabase";
            public const string ConnectionStringKey = "ConnectionStrings:DBConnection";
            public const string InMemoryDatabase = "SocialSportDB";
        }

        public class AuthenticateTokenMessages
        {
            public const string SecretKey = "Authentication:SecretForKey";
            public const string Issuer = "Authentication:Issuer";
            public const string Audience = "Authentication:Audience";
            public const string HoldKey = "Bearer";
            public const string userId = "sub";
            public const string userName = "given_name";
            public const string userFamilyName = "family_name";
            public const string userCity = "city";
        }

        public class ValidationMessages
        {
            public const string Messagevalid = "Input valid";
            public const string MessageAccountExist = "AccountExist";
            public const string MessageInvalid = "Input invalid";
        }
    }
}
