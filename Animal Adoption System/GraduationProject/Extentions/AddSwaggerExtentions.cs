namespace GraduationProject.Extentions
{
    public static class AddSwaggerExtentions
    {
        public static WebApplication UseSwaggerMiddleWares(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
