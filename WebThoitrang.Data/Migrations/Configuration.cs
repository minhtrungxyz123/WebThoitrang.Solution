namespace WebThoitrang.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using WebThoitrang.Common;
    using WebThoitrang.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebThoitrang.Data.WebThoitrangDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebThoitrang.Data.WebThoitrangDbContext context)
        {
            CreateProductCategorySample(context);
            CreateSlide(context);
            CreatePage(context);
            CreateContactDetail(context);

            CreateConfigTitle(context);
            CreateFooter(context);
            CreateUser(context);
        }

        private void CreateConfigTitle(WebThoitrangDbContext context)
        {
            if (!context.SystemConfigs.Any(x => x.Code == "HomeTitle"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeTitle",
                    ValueString = "Trang chủ Shopthoitrang",

                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaKeyword"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaKeyword",
                    ValueString = "Trang chủ Shopthoitrang",

                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaDescription"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaDescription",
                    ValueString = "Trang chủ Shopthoitrang",

                });
            }
        }
        private void CreateUser(WebThoitrangDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new WebThoitrangDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new WebThoitrangDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "bobom",
                Email = "vlvn334@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "shop thoi trang"

            };
            if (manager.Users.Count(x => x.UserName == "bobom") == 0)
            {
                manager.Create(user, "@Admin123");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                }

                var adminUser = manager.FindByEmail("vlvn334@gmail.com");

                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            }

        }
        private void CreateProductCategorySample(WebThoitrang.Data.WebThoitrangDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Đồ Nam",Alias="do-nam",Status=true },
                 new ProductCategory() { Name="Đồ Nữ",Alias="do-nu",Status=true },
                  new ProductCategory() { Name="Đồ Đôi",Alias="do-doi",Status=true },
                   new ProductCategory() { Name="Áo Khoác",Alias="ao-khoac",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
        private void CreateFooter(WebThoitrangDbContext context)
        {
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "Footer";
                context.Footers.Add(new Footer()
                {
                    ID = CommonConstants.DefaultFooterId,
                    Content = content
                });
                context.SaveChanges();
            }
        }

        private void CreateSlide(WebThoitrangDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/aonam1.jpg",
                        Content =@"	<h2>Giảm Giá đến 50%</h2>
                                <label>Đối với tất cả các mặt hàng <b> 20% GIÁ TRỊ</b></label>
                                <p>Tuyển dụng TOTOSHOP - Shop quần áo thời trang nam nữ đẹp ... </ p >
                        <span class=""on-get"">ĐẾN NGAY</span>" },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/aonam2.jpg",
                    Content=@"<h2>Giảm Giá đến 50%</h2>
                                <label>Đối với tất cả các mặt hàng<b>20% GIÁ TRỊ</b></label>

                                <p>Tuyển dụng TOTOSHOP - Shop quần áo thời trang nam nữ đẹp ... </ p >

                                <span class=""on-get"">ĐẾN NGAY</span>"},
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }

        private void CreatePage(WebThoitrangDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                try
                {
                    var page = new Page()
                    {
                        Name = "Giới thiệu",
                        Alias = "gioi-thieu",
                        Content = @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium ",
                        Status = true

                    };
                    context.Pages.Add(page);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }

        private void CreateContactDetail(WebThoitrangDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new WebThoitrang.Model.Models.ContactDetail()
                    {
                        Name = "Shop thời trang",
                        Address = "Kiến an- Hải Phòng",
                        Email = "vlvn334@gmail.com",
                        Lat = 21.0633645,
                        Lng = 105.8053274,
                        Phone = "0342699952",
                        Website = "http://shopthoitrang.com.vn",
                        Other = "",
                        Status = true

                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }
    }
}
