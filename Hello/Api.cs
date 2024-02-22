namespace Hello
{
    public class Api
    {
        //public static void ConfigurarApi(this WebApplication app)
        //{
        //    app.MapGet(pattern: "/Users", GetUsers);
        //}

        public async Task<IResult> GetUsers(IUserData data)
        {
            try
            {
                return Results.Ok(await data.GetUsers());
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }

        }
    }
}
