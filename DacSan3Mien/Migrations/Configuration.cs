namespace DacSan3Mien.Migrations
{
    using DacSan3Mien.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //using System.Web.WebPages.Html;

    using System.Web.Mvc;

    internal sealed class Configuration : DbMigrationsConfiguration<DacSan3Mien.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DacSan3Mien.Models.DataContext";
        }

        protected override void Seed(DacSan3Mien.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var users = new List<User>();
            string name, role, email, pass;
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    name = "Admin";
                    role = "admin";
                    email = "admin@gmail.com";
                    pass = "111111";
                }
                else
                {
                    name = "User" + i;
                    role = "user";
                    email = "user" + i + "@gmail.com";
                    pass = "111111";
                }
                users.Add(new User
                {
                    name = name,
                    email = email,
                    birthday = "21/08/1997",
                    gender = "Nam",
                    listGender = null,
                    phone = "0382305339",
                    address = "HN",
                    password = pass,
                    confirmPassword = pass,
                    role = role
                });
            }
            users.ForEach(u => context.Users.AddOrUpdate(p => p.id, u));
            context.SaveChanges();

            var regions = new List<Region>
            {
                new Region{name = "Miền Bắc"},
                new Region{name = "Miền Trung"},
                new Region{name = "Miền Nam"}
            };
            regions.ForEach(r => context.Regions.AddOrUpdate(p => p.name, r));
            context.SaveChanges();

            var northProducts = new List<Product>
            {
                new Product{name = "Thịt trâu sấy", image = "thit_trau_say.jpg", price = 100000, status = "Còn hàng", quantity = 1000,
                    description = "Khô Trâu ngon ngọt tự nhiên. Hàm lượng dinh dưỡng cao Ăn khô Trâu tốt cho sức khỏe. Thích hợp cả người bị béo phì, cao huyết áp và một số bệnh liên quan đến tim mạch Làm thủ công - Gia Truyền - Đảm bảo an toàn. Giao hàng thu tiền tận nơi toàn quốc",
                    regionId = 1 },
                new Product{name = "Bánh Đậu Xanh Hải Dương", image = "dau_xanh.jpg", price = 18000, status = "Còn hàng", quantity = 1000,
                    description = "Giàu chất dinh dưỡng: Profit, gluxit, lượng calo cao, các khoáng chất như: Ca, P, Fe, các vitamin B1, B2, C...Sản phẩm được chế biến bằng nguyên liệu chọn lọc kỹ không sử dụng hoá chất và mỡ động vật. Hương vị thơm ngon đã và đang được hầu hết người tiêu dùng bình chọn.",
                    regionId = 1 },
                new Product{name = "Su su Tam Đảo Vĩnh Phúc", image = "su_su.jpg", price = 99000, status = "Còn hàng", quantity = 1000,
                    description = "Đến với nơi đây thì chắc hẳn ai cũng thưởng thức món su su  bởi lẽ ngọn su su ở đây rất đặc biệt. Ngọn su su ăn giọt hơn, giòn hơn ăn có vị rất đặc trưng. Phải chăng su su ở đây được tắm sương trời, mây núi nên vị cũng đặc biệt hơn.",
                    regionId = 1 },
                new Product{name = "Măng Nứa Tuyên Quang", image = "mang_nua.jpg", price = 20000, status = "Còn hàng", quantity = 1000,
                    description = "Đặc sản măng khô tây bắc – Hương vị núi rừng Măng khô chứa nhiều chất cần thiết cho cơ thể chúng ta, theo như y học truyền thống măng có vị ngọt hơi đắng, tính hơi hàn có thể hạ khí, thanh nhiệt, giải độc, thông lợi…",
                    regionId = 1 },
                new Product{name = "Chè Thái Nguyên", image = "che_thai_nguyen.jpg", price = 50000, status = "Còn hàng", quantity = 1000,
                    description = "Chè được hái bằng tay trên đồi sau nhà vào sáng sớm khi còn đọng sương, kĩ thuật lấy hương 100% tự nhiên đảm bảo chè có hương vị đặc trưng thơm ngon của chè Thái Nguyên và tốt cho sức khỏe người uống trà.",
                    regionId = 1 },
                new Product{name = "Gạo nếp nương Điện Biên", image = "nep_nuong.jpg", price = 60000, status = "Còn hàng", quantity = 1000,
                    description = "Gạo nếp nương Điện Biên nổi tiếng khắp cả nước. Gạo nếp nó có một mùi thơm rất đặc trưng. Ở các vùng quê nước ta nếp hương được đặc biệt quan tâm vì nó có mùi rất thơm. Gạo nếp thường được dùng trong những dịp đặc biệt như (ma chay, cưới xin, giỗ chạp..). gạo nếp nương Điện Biên được khí hậu phù hợp nên nó có đặc điểm hạt to, hạt trong, hạt đục, không bị pha trộn. Sau khi ngâm nước xong, hạt gạo trong đều",
                    regionId = 1 },
                new Product{name = "Bánh đa Kế", image = "banh_da_ke.jpg", price = 30000, status = "Còn hàng", quantity = 1000,
                    description = "Bánh đa Kế là một món ăn bình dị, dân dã, chứa đựng trong đó bao hương vị, đậm đà quê Bắc Giang. Những chiếc bánh đa với hình yên ngựa vàng bóng, vị thơm, béo của vừng đen, vị bùi bùi của lạc, vị thơm nhè nhẹ của gạo hòa lẫn với khoai lang, vị đậm đà của muối tinh... đã trở thành món quà không thể thiếu đối với du khách.",
                    regionId = 1 },
                new Product{name = "Lạp sườn Fansipan", image = "lap_suon.jpg", price = 120000, status = "Còn hàng", quantity = 1000,
                    description = "Lạp sườn Fansipan được chế biền hoàn toàn bằng phương thức truyền thống nhân lạp sườn được làm từ thịt nửa lạc nửa mỡ kết hợp cùng các gia vị của núi rừng tây bắc, sau khi sơ chế lạp sườn được đưa vào trong lò được để hun khói, việc đưa vào lò giúp giữ nhiệt, giữ khói tốt hơn.",
                    regionId = 1 },
                new Product{name = "Thuốc Tắm Dao Đỏ", image = "thuoc_tam_giao_do.jpg", price = 200000, status = "Còn hàng", quantity = 1000,
                    description = "Bài thuốc tắm của người Dao đỏ rất nổi tiếng, nhất là khi đi du lịch Sapa bạn sẽ thấy nhiều biển hiệu quảng cáo tắm lá người dao đỏ, tác dụng rất tốt cho sức khỏe. Và bất kỳ khi nào làm việc nhiều, thấy cơ thể mỏi mệt, thời tiết thay đổi, nhức đầu, khản cổ, đi đường xa, đau chân tay... đều tắm lá thuốc.",
                    regionId = 1 },
                new Product{name = "Mít sấy hương vị tự nhiên", image = "mit_say.jpg", price = 150000, status = "Còn hàng", quantity = 1000,
                    description = "Sản phẩm được sản xuất theo phương pháp sấy gia nhiệt: Những miếng mít được chọn lọc và đưa vào máy sấy và được sấy ở nhiệt độ 50 - 70 độ C làm cho sản phẩm như là được phơi sấy trong môi trường tự nhiên đảm bảo sản phẩm vẫn giữ được hương vị tự nhiên của mình mà lại đảm bảo an toàn vệ sinh thực phẩm.",
                    regionId = 1 }
            };
            northProducts.ForEach(r => context.Products.AddOrUpdate(p => p.id, r));
            context.SaveChanges();

            var centralProducts = new List<Product>
            {
                new Product{name = "Cu đơ Hà Tĩnh", image = "cu_do.jpg", price = 650000, status = "Còn hàng", quantity = 1000,
                    description = "Đến thăm vùng đất Hà Tĩnh, ngoài thưởng thức những món ngon nổi tiếng như ram bánh mướt, bánh bèo, gỏi cá đục, bánh đa vừng... du khách còn bị níu chân bởi một đặc sản dân dã khác, đó là kẹo cu đơ.",
                    regionId = 2 },
                new Product{name = "Sá Sùng", image = "sa_sung.jpg", price = 400000, status = "Còn hàng", quantity = 1000,
                    description = "Giá trị dinh dưỡng trong sá sùng rất cao. Có thể chế biến nhiều món ăn khác nhau nên thời gian gần đây, sá sùng được nhiều người dân tìm mua",
                    regionId = 2 },
                new Product{name = "Khô gà xé cay", image = "ga_xe_cay.jpg", price = 130000, status = "Còn hàng", quantity = 1000,
                    description = "Đặc sản miền trung khô gà xé cay được chế biến từ thịt gà, tẩm ướp gia vị vừa dùng, thưởng thức chung với cơm, làm mồi nhậ",
                    regionId = 2 },
                new Product{name = "Bánh tráng Bình Định", image = "banh_trang.jpg", price = 70000, status = "Còn hàng", quantity = 1000,
                    description = "Bánh tráng dừa luôn có mặt trong hầu hết những bữa ăn và tiệc tùng của người Bình Định bản xứ hay người Bình Định xa quê. Xứ nẫu luôn tự hào có món bánh tráng dừa nướng góp phần làm phong phú nền ẩm thực Việt Nam ta",
                    regionId = 2 },
                new Product{name = "Viên Hà Thủ Ô", image = "ha_thu_o.jpg", price = 160000, status = "Còn hàng", quantity = 1000,
                    description = "Hà Thủ Ô giúp điều trị thiếu máu biểu hiện như da nhợt nhạt, hoa mắt, chóng mặt, mất ngủ, sớm bạc tóc, đau và yếu vùng lưng và đầu gối: Dùng Hà thủ ô với Sinh địa hoàng, Nữ trinh tử, Câu kỷ tử, Thỏ ti tử và Tang kí sinh",
                    regionId = 2 },
                new Product{name = "Tôm chua nõn nhỏ", image = "tom_chua.jpg", price = 65000, status = "Còn hàng", quantity = 1000,
                    description = "Tóm chua nõn Thoòng huong Huế Tóm lam 2 lớp toan tôm từ trong ra ngoài Kẹp với dưa giá ăn với thịt luộc cơm nóng tuyệt vời",
                    regionId = 2 },
                new Product{name = "Hạt Sen Khô", image = "sen_kho.jpg", price = 30000, status = "Còn hàng", quantity = 1000,
                    description = "Hạt sen Huế đuọec lấy tim ra và phơi khô lên  Sen ăn rất mát cơ thể 1Kg sen khô rất nhiều ",
                    regionId = 2 }
            };
            centralProducts.ForEach(r => context.Products.AddOrUpdate(p => p.id, r));
            context.SaveChanges();

            var southProducts = new List<Product>
            {
                new Product{name = "Muối tôm Tây Ninh", image = "muoi_tom.jpg", price = 55000, status = "Còn hàng", quantity = 1000,
                    description = "Muối tôm Tây Ninh là loại gia vị đặc biệt chuyên để chấm hoa quả, nổi tiếng khắp mọi miền đất nước, được nhiều du khách mua về làm quà khi đến đây.",
                    regionId = 3 },
                new Product{name = "Thèo lèo Tây Ninh", image = "theo_leo.jpg", price = 20000, status = "Còn hàng", quantity = 1000,
                    description = "thèo lèo quen thuộc với nguyên liệu chính được làm từ đậu phộng trộn út mạch nha tạo nên món ăn thơm ngon, giòn tan để mua về làm quà cho bạn bè, người thân",
                    regionId = 3 },
                new Product{name = "Nem bưởi", image = "nem_buoi.jpg", price = 650000, status = "Còn hàng", quantity = 1000,
                    description = "Được rất nhiều du khách mua về làm quà do món ăn có hương vị lạ miệng, hấp dẫn mà bất cứ ai đến Tây Ninh đều phải thử một lần.",
                    regionId = 3 },
                new Product{name = "Nho Phan Giang", image = "nho.jpg", price = 70000, status = "Còn hàng", quantity = 1000,
                    description = "Với vị chua ngọt đậm đà thơm ngon mùi vị của trái nho tự nhiên, mật nho Phan Rang được dùng chung với đá lạnh, rất thích hợp để giải khát trong mùa hè và lễ Tết, nên được nhiều du khách lựa chọn.",
                    regionId = 3 },
                new Product{name = "Bánh tét Cần Thơ", image = "banh_tet.jpg", price = 80000, status = "Còn hàng", quantity = 1000,
                    description = "Bánh tét lá cẩm có vị béo ngậy của nhân làm từ thịt, nước cốt dừa và đậu xanh, bên ngoài là lớp nếp màu tím của lá cẩm trông rất bắt mắt",
                    regionId = 3 },
                new Product{name = "Bánh Pía Sài Gòn", image = "banh_pia.jpg", price = 10000, status = "Còn hàng", quantity = 1000,
                    description = "Bạn có thể tìm thấy loại bánh nổi tiếng này được bày bán khá nhiều dọc theo trục đường chính các tỉnh miền tây về Sài Gòn",
                    regionId = 3 },
                new Product{name = "Rượu Dừa Bến Tre", image = "ruou_dua.jpg", price = 85000, status = "Còn hàng", quantity = 1000,
                    description = "Xứ dừa Bến Tre luôn luôn nổi tiếng với những đặc sản không chỉ ngon mà còn nổ dưỡng. Đặc sản Miền Tây chúng tôi xin hân hạnh giới thiệu tới quý khách sản phẩm Rượu Dừa Bến Tre.",
                    regionId = 3 }
            };
            southProducts.ForEach(r => context.Products.AddOrUpdate(p => p.id, r));
            context.SaveChanges();
        }
    }
}
