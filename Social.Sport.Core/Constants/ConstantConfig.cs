namespace Social.Sport.Core.Constants
{
    public class ConstantConfig
    {
        public class APIConfig 
        {
            public const string UseInMemoryDatabaseKey = "UseInMemoryDatabase";
            public const string ConnectionStringKey = "ConnectionStrings:DBConnection";
            public const string InMemoryDatabase = "SocialSport";
        }

        public class AuthenticateTokenMessages
        {
            public const string SecretKey = "Authentication:SecretForKey";
            public const string Issuer = "Authentication:Issuer";
            public const string Audience = "Authentication:Audience";
            public const string HoldKey = "Bearer";
        }

        public class ValidationMessages
        {
            public const string Messagevalid = "Input valid";
        }
    }
}
