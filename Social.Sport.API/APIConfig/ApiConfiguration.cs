namespace Social.Sport.API.APIConfig
{
    public static class ApiConfiguration
    {
        public static IApplicationBuilder ConfigureCorsPolicy(this IApplicationBuilder app)
        {
            return app.UseCors(x => x
            .WithOrigins("https://localhost:3000")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        }
    }
}
