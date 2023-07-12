using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Shop.Models;

namespace Shop.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Художня література", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Сучасна проза", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Триллер", DisplayOrder = 3 },
                 new Category { Id = 4, Name = "Детектив", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Переможці", Author = "Фредрік Бакман", Description = "Час багато чого змінює, але хокейне містечко Бйорнстад продовжує жити, долаючи минуле. Майя знову повертається у місто, аби завітати до улюбленого бару, водночас кипляча напруга та бажання помсти ще жевріє у містечці серед лісів.Через складнощі повсякденного життя та дослідження дружби, вірності та втрати, цей емоційний роман змусить вас переглянути своє ставлення до перемоги, поразок та прощення.", Price = 500, CategoryId = 1, ImgUrl = "" },
                new Product { Id = 2, Title = "Луни", Author = "Пилип Білянський", Description = "Прокидатися. Висовувати голову з холодної води, витріщати очі в небо і ляскати ротом. Лякатися. Придумувати собі якийсь ґрунт, землю, основу. Відрощувати ноги, вуха. А опісля — прибиватися до двоногих риб. І скоса поглядати на воду, сумніваючись у правильності своїх рішень.", Price = 230, CategoryId = 2, ImgUrl = "" },
                new Product { Id = 3, Title = "Казка", Author = "Стівен Кінг", Description = "Сімнадцятирічний Чарлі Рід, який дитиною втратив матір, однак навчився давати собі раду, ще й доглядати за батьком-алкоголіком, порятував відлюдькуватого сусіда Говарда Боудітча та найнявся до нього на роботу. Саме там хлопець знайшов собі вірного друга - собаку Радар.", Price = 600, CategoryId = 3, ImgUrl = "" },
                new Product { Id = 4, Title = "Я бачу, вас цікавить пітьма", Author = "Ілларіон Павлюк", Description = "Київського кримінального психолога Андрія Гайстера відправляють консультантом у богом забуте селище Буськів Сад. Зимової ночі там зникла маленька дівчинка. А ще там водиться Звір — серійний маніяк, убивств якого тамтешні мешканці воліють не помічати...", Price = 489, CategoryId = 4, ImgUrl = "" },
                new Product { Id = 5, Title = "9 листопада", Author = "Коллін Гувер", Description = "Як знати, що кохання справжнє? А який він — любовний поцілунок як у книжках? Як вісімнадцятирічним зрозуміти, що ця хімія гормонів переросте в щире кохання на все життя? І чи можна пробачити тому, хто збрехав ще в день знайомства? ", Price = 550, CategoryId = 2, ImgUrl = "" },
                new Product { Id = 6, Title = "Fairy Tale", Author = "Стівен Кінг", Description = "Legendary storyteller Stephen King goes into the deepest well of his imagination in this spellbinding novel about a seventeen-year-old boy who inherits the keys to a parallel world where good and evil are at war, and the stakes could not be higher - for their world or ours.", Price = 500, CategoryId = 3, ImgUrl = "" },
                new Product { Id = 7, Title = "Велика глушина", Author = "Крістін Генна", Description = "Крістін Генна влучно описує слабкість і стійкість людини, майстерно змальовує незламний дух американських першопрохідців і атмосферу вже напівзниклої Аляски — незрівнянно прекрасної і невблаганно небезпечної землі.", Price = 700, CategoryId = 3, ImgUrl = "" },
                new Product { Id = 8, Title = "Тривожні люди", Author = "Фредрік Бакман", Description = "Це зворушлива комедія, а водночас психологічний роман про злочин, який ніколи не відбувся.", Price = 550 , CategoryId = 2, ImgUrl = "" },
                new Product { Id = 9, Title = "Ловець повітряних зміїв", Author = "Халед Госсейні", Description = "Одного морозного дня взимку 1975-го афганський хлопчик Амір стає свідком жахливого вчинку. Ця подія назавжди змінює і його власне життя, і долю його близького приятеля Гассана.", Price = 400, CategoryId = 1, ImgUrl = "" },
                new Product { Id = 10, Title = "Ведмеже місто", Author = "Фредрік Бакман", Description = " «Ведмеже місто» розповідає про багатогранну людську природу. У глухому містечку Бьорнстад колись вирувало життя, а зараз лишилось безробіття та безвихідь. Уся надія міста – юнацький хокейний клуб.", Price = 385, CategoryId = 4, ImgUrl = "" }
                );
        }
    }
}
