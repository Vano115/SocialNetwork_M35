using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SocialNetwork_M35.Data.Entityes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SocialNetwork_M35.Data.DbSettings
{
    internal class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            //Database.Migrate();
            //Database.EnsureCreated();

            // Когда в коде меняются свойства сущностей нужны миграции
            /*Для добавления функционала миграций 
             * при создании БД и до первого изменения введем в окно Package Manager Console следующую команду:
            enable - migrations*/

            /*Далее после добавления новых свойств выполним в Package Manager Console следующую команду:
            add-migration "NameMigration"*/

            //update-database NameMigration - применение миграции в БД
            // Таким образом в БД будут добавлены таблицы для новых свойств

            /*
             Если база данных уже используется в производстве, развернута на сервере, 
            где бы не можем произвести миграции, то мы можем сгенерировать по миграции скрипт. 
            Для этого надо ввести следующую команду:

            update-database -script

            В итоге будет сгенерирован скрипт SQL:*/
        }
    }
}
