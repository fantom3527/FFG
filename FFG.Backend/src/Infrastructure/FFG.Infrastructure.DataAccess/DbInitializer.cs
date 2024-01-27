using Microsoft.EntityFrameworkCore;

namespace FFG.Infrastructure.DataAccess
{
    public class DbInitializer
    {
        /// <summary>
        /// Используется при старте приложения и проверяет создана ли база данных, если нет, то создает на основе контекста.
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(FFGDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
