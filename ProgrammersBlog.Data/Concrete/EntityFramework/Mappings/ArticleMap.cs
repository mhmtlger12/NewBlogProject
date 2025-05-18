using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            // **Tablo Adı**
            builder.ToTable("Articles").HasComment("Makaleler");

            //primaryKey tanımladık
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Content).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.PublishDate).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.SeoAuthor).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SeoDescription).IsRequired().HasMaxLength(150);
            builder.Property(x => x.SeoTags).IsRequired().HasMaxLength(70);
            builder.Property(x => x.ViewsCount).IsRequired();
            builder.Property(x => x.CommentCount).IsRequired();
            builder.Property(x => x.Thumbnail).IsRequired().HasMaxLength(250);
            builder.Property(x => x.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).IsRequired(false).HasMaxLength(500);


            //ilişkiler
            builder.HasOne(a => a.Menu).WithMany(m => m.Articles).HasForeignKey(a => a.MenuId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.User).WithMany(c => c.Articles).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
      // Ana Sayfa Makalesi
      new Article
      {
          Id = Guid.Parse("c20558d8-b0fd-4142-a527-0da9910deefc"),
          MenuId = Guid.Parse("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"), // Ana Sayfa menüsü
          Title = "Muğla'ya Hoş Geldiniz",
          Content = "Muğla, Türkiye'nin güneybatısında yer alan, eşsiz doğal güzellikleri, zengin tarihi ve kültürel mirasıyla öne çıkan bir ilimizdir. Bodrum, Marmaris, Fethiye gibi dünyaca ünlü tatil beldeleriyle her yıl milyonlarca turisti ağırlayan Muğla, aynı zamanda antik kentleri, koyları, plajları ve yemek kültürüyle de ziyaretçilerine unutulmaz deneyimler sunmaktadır.",
          Thumbnail = "postImages/mugla-genel.jpg",
          SeoDescription = "Muğla'nın güzellikleri ve gezilecek yerleri hakkında genel bilgiler",
          SeoTags = "Muğla, Bodrum, Marmaris, Fethiye, tatil, gezi, rehber",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now, // Yeni eklenen alan
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Ana sayfa tanıtım makalesi",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 1500,
          CommentCount = 0
      },
      // Makaleler - Gezi Rehberi Alt Menüsü
      new Article
      {
          Id = Guid.Parse("87b5d57f-1e2b-4b58-b9e6-2718d5af5924"),
          MenuId = Guid.Parse("7191e8c0-26c6-4703-950e-dc195cc5c3db"), // Gezi Rehberi alt menüsü
          Title = "Muğla'nın En Güzel Plajları ve Koyları",
          Content = "Muğla sahilleri, Türkiye'nin en güzel plajlarına ve koylarına ev sahipliği yapmaktadır. Ölüdeniz, Çalış Plajı, İçmeler, Akyaka ve Cleopatra Plajı gibi dünyaca ünlü plajların yanı sıra, Kelebekler Vadisi, Kabak Koyu ve Gökova Koyu gibi el değmemiş doğal güzellikleriyle de turistleri kendine çekmektedir. Bu rehberde, Muğla'nın en güzel plajlarını ve koylarını keşfedecek, her birinin özellikleri ve nasıl ulaşılacağı hakkında detaylı bilgilere ulaşacaksınız.",
          Thumbnail = "postImages/mugla-plajlar.jpg",
          SeoDescription = "Muğla'nın en güzel plajları ve koyları hakkında detaylı rehber",
          SeoTags = "Muğla, plajlar, koylar, Ölüdeniz, İçmeler",
          SeoAuthor = "Muğla Gezi Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Muğla plajları ve koyları rehberi",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 1250,
          CommentCount = 5
      },
      // Makaleler - Tarihi Yerler Alt Menüsü
      new Article
      {
          Id = Guid.Parse("e5a67c9f-3c2a-4b6e-9c8f-09f1c3c903d3"),
          MenuId = Guid.Parse("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"), // Tarih ve Kültür alt menüsü
          Title = "Muğla'daki Antik Kentler ve Tarihi Yerler",
          Content = "Muğla, antik Karya ve Likya medeniyetlerinin izlerini taşıyan önemli bir tarih merkezidir. Bölgede Knidos, Stratonikeia, Kaunos, Tlos ve Letoon gibi önemli antik kentler bulunmaktadır. Bodrum'daki Halikarnas Mozolesi (Mausoleum), antik dünyanın yedi harikasından biri olarak kabul edilmektedir. Ayrıca Bodrum Kalesi, Marmaris Kalesi, Fethiye Kaya Mezarları ve Kayaköy gibi tarihi yerler de bölgenin zengin kültürel mirasını yansıtmaktadır. Bu makalede, Muğla'daki en önemli tarihi yerleri ve antik kentleri tanıtacak, ziyaretçilerin bu bölgelerde neler görebileceğini ve nasıl ulaşabileceğini detaylı olarak anlatacağız.",
          Thumbnail = "postImages/mugla-antik-kentler.jpg",
          SeoDescription = "Muğla'daki antik kentler ve tarihi yerler hakkında detaylı rehber",
          SeoTags = "Muğla, antik kentler, Knidos, tarih",
          SeoAuthor = "Muğla Tarih Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Muğla'nın tarihi zenginlikleri",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 950,
          CommentCount = 3
      },
      new Article
      {
          Id = Guid.Parse("2fe2d2d5-79c9-4fed-a236-74426d84d4b5"),
          MenuId = Guid.Parse("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"),
          Title = "Marmaris'te Deniz ve Doğa Turizmi",
          Content =
              "Muğla'nın göz bebeği Marmaris, eşsiz doğal güzellikleriyle her yıl milyonlarca turisti ağırlıyor. İçmeler, Turunç ve Selimiye gibi muhteşem koylarıyla ünlü olan Marmaris, yat turizmi için de ideal bir destinasyon. Marmaris Marina ve Netsel Marina'da demirlemiş lüks yatlar, bölgenin prestijiyle bütünleşiyor. Marmaris'in turkuaz renkli koylarında tekne turu yapmak, Kleopatra Plajı'nda denizin tadını çıkarmak ve Cennet Adası'nı keşfetmek, burada yapılabilecek en keyifli aktiviteler arasında. Bunun yanı sıra doğa tutkunları için Marmaris'in çevresindeki ormanlar, trekking, kano ve safari turları için mükemmel fırsatlar sunuyor. Turgut Şelalesi'nin serinletici suları, Günnücek Mesire Yeri'nin yeşil örtüsü ve Nimara Mağarası'nın gizemli atmosferi, Marmaris'in keşfedilmeyi bekleyen doğal hazineleri. Ayrıca, Marmaris Kale ve Müzesi, tarihi İbrahim Ağa Camii ve antik Amos kenti, bölgenin kültürel zenginliğini yansıtan önemli eserler arasında yer alıyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Marmaris'te Deniz ve Doğa Turizmi",
          SeoTags = "Marmaris, İçmeler, Turunç, marina, Muğla",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Marmaris'in turistik değerleri",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 12,
          CommentCount = 0
      }
      ,
      // Muğla - Bodrum Alt Menüsü
      new Article
      {
          Id = Guid.Parse("0b797ea6-5f12-42a5-b4f6-4f67d5e2a829"),
          MenuId = Guid.Parse("7e29265f-d672-42a7-9d84-47b564ebad69"), // Bodrum alt menüsü
          Title = "Bodrum'un Tarihi ve Kültürel Zenginlikleri",
          Content = "Antik çağda Halikarnas olarak bilinen Bodrum, dünyanın yedi harikasından biri olan Mausoleum'a ev sahipliği yapmıştır. Günümüzde Bodrum Kalesi içinde yer alan Sualtı Arkeoloji Müzesi, dünyanın en önemli sualtı arkeoloji müzelerinden biridir. Bodrum'un beyaz badanalı, mavi pencereli evleri, dar sokakları ve renkli begonvilleri ile süslü sokakları, kentin karakteristik özelliklerini oluşturmaktadır. Bodrum Antik Tiyatrosu, Myndos Kapısı, Pedasa Antik Kenti ve Zeki Müren Sanat Müzesi gibi kültürel miras alanları, Bodrum'un zengin tarihini yansıtmaktadır. Bu makalede, Bodrum'un tarihi ve kültürel zenginliklerini keşfedecek, ziyaretçilerin görmesi gereken yerleri ve Bodrum'un kültürel yaşamını detaylı olarak inceleyeceğiz.",
          Thumbnail = "postImages/bodrum-kalesi.jpg",
          SeoDescription = "Bodrum'un tarihi ve kültürel zenginlikleri hakkında detaylı rehber",
          SeoTags = "Bodrum, Kalesi, Halikarnas, Mausoleum, Müze",
          SeoAuthor = "Muğla Kültür Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Bodrum'un tarihi ve kültürel değerleri",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 850,
          CommentCount = 2
      }
      ,
      // Muğla - Marmaris Alt Menüsü
      new Article
      {
          Id = Guid.Parse("77c21f6c-57e4-48d3-85b8-1e5e357d6e53"),
          MenuId = Guid.Parse("b33b442b-58b3-400b-a2f5-9231e58a1ff7"), // Marmaris alt menüsü
          Title = "Marmaris'in Doğal Güzellikleri ve Plajları",
          Content = "Muğla'nın en popüler tatil beldelerinden biri olan Marmaris, muhteşem doğası ve berrak deniziyle her yıl binlerce turisti ağırlamaktadır. İçmeler, Turunç, Selimiye ve Bozburun gibi güzel koylara sahip olan Marmaris, aynı zamanda yat turizmi için de önemli bir merkezdir. Marmaris Marina ve Netsel Marina'da demirlemiş lüks yatlar, bölgenin prestijini yansıtmaktadır. Marmaris'in turkuaz renkli koylarında tekne turu yapmak, Kleopatra Plajı'nda yüzmek ve Cennet Adası'nı keşfetmek, ziyaretçilerin en sevdiği aktiviteler arasındadır. Ayrıca Turgut Şelalesi, Nimara Mağarası ve Marmaris Milli Parkı gibi doğal güzellikler de bölgenin çekiciliğini artırmaktadır. Bu makalede, Marmaris'in en güzel plajlarını, koylarını ve doğal güzelliklerini keşfedecek, ziyaretçilere öneriler sunacağız.",
          Thumbnail = "postImages/marmaris-plaj.jpg",
          SeoDescription = "Marmaris'in doğal güzellikleri ve plajları hakkında detaylı rehber",
          SeoTags = "Marmaris, İçmeler, plajlar, koylar",
          SeoAuthor = "Muğla Doğa Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Marmaris'in doğal güzellikleri ve plajları",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 1100,
          CommentCount = 4
      }
      ,
      // Muğla - Fethiye Alt Menüsü
      new Article
      {
          Id = Guid.Parse("1b9e8c64-075f-4a16-8a18-09532fe8d1bd"),
          MenuId = Guid.Parse("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"), // Fethiye alt menüsü
          Title = "Fethiye'nin Eşsiz Koyları ve Plajları",
          Content = "Muğla'nın incisi Fethiye, Türkiye'nin en güzel koylarına ve plajlarına ev sahipliği yapmaktadır. Ölüdeniz'in turkuaz suları ve beyaz kumsalı, dünyaca ünlü Kelebekler Vadisi, saklı cennet Kabak Koyu ve tekne turlarıyla keşfedebileceğiniz 12 Adalar, her yıl binlerce turisti ağırlamaktadır. Fethiye'nin berrak sularında yüzmek, Belcekız Plajı'nda güneşlenmek ve Gemiler Adası'nı keşfetmek, unutulmaz bir tatil deneyimi yaşatmaktadır. Bu makalede, Fethiye'nin en güzel koylarını ve plajlarını tanıtacak, ziyaretçilere öneriler sunacağız.",
          Thumbnail = "postImages/fethiye-oludeniz.jpg",
          SeoDescription = "Fethiye'nin eşsiz koyları ve plajları hakkında detaylı rehber",
          SeoTags = "Fethiye, Ölüdeniz, plajlar, koylar",
          SeoAuthor = "Muğla Plaj Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Fethiye'nin plajları ve koyları",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 1300,
          CommentCount = 6
      }
      ,
      // Muğla - Merkez Alt Menüsü
      new Article
      {
          Id = Guid.Parse("3e17dec7-f5b9-4cab-8d53-77f89c144e2d"),
          MenuId = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), // Muğla ana menüsü
          Title = "Muğla Merkez'in Tarihi ve Kültürel Değerleri",
          Content = "Muğla il merkezi, Osmanlı ve Cumhuriyet dönemlerinden kalma tarihi yapıları, müzeleri ve geleneksel Türk mimarisini yansıtan evleriyle tam bir açık hava müzesi niteliğindedir. 'Beyaz Kent' olarak da anılan Muğla'nın tarihi dokusunu en iyi yansıtan Saburhane Mahallesi, restore edilmiş geleneksel Muğla evleriyle ünlüdür. Bacaları ve cumbalı evleriyle dikkat çeken bu mahalle, fotoğraf tutkunları için de eşsiz kareler sunmaktadır. Kent merkezindeki Kurşunlu Cami, Ulu Cami ve Konakaltı Han gibi tarihi yapılar, Osmanlı mimarisinin en güzel örnekleri arasındadır. Bu makalede, Muğla merkezdeki tarihi ve kültürel değerleri tanıtacak, ziyaretçilere öneriler sunacağız.",
          Thumbnail = "postImages/mugla-merkez.jpg",
          SeoDescription = "Muğla merkez'in tarihi ve kültürel değerleri hakkında detaylı rehber",
          SeoTags = "Muğla, Saburhane, kültür, tarih",
          SeoAuthor = "Muğla Kültür Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Muğla merkez kültür ve tarih rehberi",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 750,
          CommentCount = 1
      }
      ,
      // Hakkımızda Menüsü
      new Article
      {
          Id = Guid.Parse("42eb2c71-47f5-4bec-b31e-e71e11c39c28"),
          MenuId = Guid.Parse("3b466d57-abb5-4624-b922-1b2fba6a62c3"), // Hakkımızda menüsü
          Title = "Muğla Rehberi Hakkında",
          Content = "Muğla Rehberi, Türkiye'nin en güzel illerinden biri olan Muğla'nın doğal güzelliklerini, tarihi ve kültürel zenginliklerini tanıtmak amacıyla kurulmuş bir platformdur. Amacımız, Muğla'nın eşsiz koylarını, plajlarını, antik kentlerini, lezzetli mutfağını ve zengin kültürünü hem yerli hem de yabancı turistlere tanıtmak ve bölgeye gelen ziyaretçilere rehberlik etmektir. Ekibimiz, Muğla'yı karış karış gezen, bölgeyi iyi tanıyan ve seven uzmanlardan oluşmaktadır. Sitemizde Bodrum, Marmaris, Fethiye, Datça, Köyceğiz gibi popüler tatil beldelerinin yanı sıra, Muğla'nın daha az bilinen güzelliklerini de keşfedebilirsiniz. Sizlere en doğru ve güncel bilgileri sunmak için sürekli olarak içeriğimizi güncelliyor ve genişletiyoruz. Muğla Rehberi olarak, sizlerin Muğla'da unutulmaz bir tatil geçirmeniz için elimizden gelen her şeyi yapmaya hazırız.",
          Thumbnail = "postImages/mugla-rehberi-logo.jpg",
          SeoDescription = "Muğla Rehberi hakkında bilgiler ve misyonumuz",
          SeoTags = "Muğla Rehberi, hakkımızda, misyon, vizyon, Muğla tanıtım",
          SeoAuthor = "Muğla Rehberi Ekibi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Hakkımızda sayfası",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 500,
          CommentCount = 0
      }
      ,
      // İletişim Menüsü
      new Article
      {
          Id = Guid.Parse("f8dfba8a-90e6-4e1b-bd0c-2e22a8c77423"),
          MenuId = Guid.Parse("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"), // İletişim menüsü
          Title = "Bizimle İletişime Geçin",
          Content = "Muğla Rehberi ekibi olarak, sorularınız, önerileriniz ve işbirliği talepleriniz için her zaman hizmetinizdeyiz. Aşağıdaki iletişim kanallarından bize ulaşabilirsiniz:\n\n**E-posta:** info@muglarehberi.com\n\n**Telefon:** +90 252 123 45 67\n\n**Adres:** Kavaklıdere Mah. Atatürk Cad. No:123, 48000 Muğla Merkez\n\n**Sosyal Medya Hesaplarımız:**\n- Instagram: @muglarehberi\n- Facebook: Muğla Rehberi\n- Twitter: @muglarehberi\n\nMuğla'da gezilecek yerler, konaklama, ulaşım ve diğer konularda bilgi almak için bizimle iletişime geçebilirsiniz. Ayrıca Muğla ile ilgili deneyimlerinizi ve fotoğraflarınızı bizimle paylaşmak isterseniz, sosyal medya hesaplarımızda bizi etiketleyebilir veya e-posta adresimize gönderebilirsiniz. Sizden gelecek her türlü geri bildirim, sitemizi ve hizmetlerimizi geliştirmemize yardımcı olacaktır.",
          Thumbnail = "postImages/iletisim.jpg",
          SeoDescription = "Muğla Rehberi iletişim bilgileri ve iletişim formu",
          SeoTags = "iletişim, Muğla Rehberi, telefon",
          SeoAuthor = "Muğla Rehberi Ekibi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "İletişim sayfası",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 400,
          CommentCount = 0
      }
      ,
      new Article
      {
          Id = Guid.Parse("ad45a8fc-3c20-4c37-8db1-e45c1fb01a57"),
          MenuId = Guid.Parse("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"), // İletişim menüsü
          Title = "Kavaklıdere ve Yatağan'ın Doğal ve Tarihi Zenginlikleri",
          Content =
              "Muğla'nın iç kesimlerinde yer alan Kavaklıdere ve Yatağan ilçeleri, el değmemiş doğası ve zengin tarihi mirası ile keşfedilmeyi bekleyen gizli hazinelerdir. Kavaklıdere, ismini verimli topraklarında yetişen kavak ağaçlarından almış olup, bağcılık ve şarapçılık kültürü ile ünlüdür. İlçenin dağlık alanlarında bulunan Menteşe Yaylası, serin iklimi ve muhteşem manzarasıyla yazın bunaltan sıcaklardan kaçmak isteyenler için ideal bir sığınak. Yatağan ise antik dönemden kalma Stratonikeia Antik Kenti ile ünlüdür. 'Mermer Şehir' olarak da bilinen bu antik kent, Roma, Helenistik ve Bizans dönemlerine ait kalıntılarıyla tarih meraklıları için vazgeçilmez bir durak. Yatağan aynı zamanda geleneksel Türk kılıcı olan 'yatağan'ın üretim merkezi olarak da tarihe geçmiştir. Bölgede yer alan Bozüyük ve Turgut gibi eski Türk yerleşimleri, yüzlerce yıllık çınar ağaçları, tarihi camileri ve geleneksel Türk köy yaşamını yansıtan dokusuyla otantik bir atmosfer sunuyor. Yerel halk tarafından hala yaşatılan geleneksel el sanatları, özellikle halıcılık ve dokumacılık, bölgenin kültürel zenginliklerini tamamlıyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Kavaklıdere ve Yatağan'ın Doğal ve Tarihi Zenginlikleri",
          SeoTags = "Kavaklıdere, Yatağan, Stratonikeia, bağcılık, yaylalar, tarih, Muğla",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Kavaklıdere ve Yatağan",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 26777,
          CommentCount = 0
      }
  ,
      new Article
      {
          Id = Guid.Parse("a25d2b14-7f5c-4d2f-9c98-b3c6e8b3a2d1"),
          MenuId = Guid.Parse("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"), // Ana Sayfa menüsü
          Title = "Fethiye'nin Eşsiz Koyları ve Plajları",
          Content = "Muğla'nın incisi Fethiye, Türkiye'nin en güzel koylarına ve plajlarına ev sahipliği yapıyor. Ölüdeniz'in turkuaz suları ve beyaz kumsalı, dünyaca ünlü Kelebekler Vadisi, saklı cennet Kabak Koyu ve tekne turlarıyla keşfedebileceğiniz 12 Adalar, her yıl binlerce turisti ağırlıyor.",
          Thumbnail = "postImages/fethiye-plajlar.jpg",
          SeoDescription = "Fethiye'nin muhteşem koyları ve plajları hakkında detaylı rehber",
          SeoTags = "Fethiye, Ölüdeniz, Kelebekler Vadisi, Kabak Koyu, plajlar",
          SeoAuthor = "Muğla Gezi Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Fethiye plajları makalesi",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 15420,
          CommentCount = 8
      },
      new Article
      {
          Id = Guid.Parse("1c20d2d7-27d1-4d25-90b9-bba97e5ea56f"),
          MenuId = Guid.Parse("7e29265f-d672-42a7-9d84-47b564ebad69"), // Bodrum alt menüsü
          Title = "Bodrum'un Tarihi Kalesi ve Sualtı Müzesi",
          Content = "Bodrum Kalesi, kentin simgesi olan muhteşem bir Ortaçağ yapısı. Sualtı Arkeoloji Müzesi olarak hizmet veren kale, dünyanın en önemli sualtı arkeolojisi merkezlerinden biri. Antik batıklardan çıkarılan eserler burada sergileniyor.",
          Thumbnail = "postImages/bodrum-kalesi.jpg",
          SeoDescription = "Bodrum Kalesi ve Sualtı Arkeoloji Müzesi detaylı gezi rehberi",
          SeoTags = "Bodrum Kalesi, Sualtı Müzesi, tarih, arkeoloji",
          SeoAuthor = "Muğla Gezi Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Bodrum Kalesi tanıtım makalesi",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 12350,
          CommentCount = 5
      },
      new Article
      {
          Id = Guid.Parse("3d8533eb-3c9e-4d29-97e6-7c4e7244e4f8"),
          MenuId = Guid.Parse("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"), // İletişim menüsü
          Title = "Marmaris'te Tekne Turu Rotaları",
          Content = "Marmaris'in kristal berraklığındaki koylarını tekne turuyla keşfedin. Cennet Adası, Fosforlu Mağara, Akvaryum Koyu ve Kızkumu Plajı gibi eşsiz doğal güzelliklere sahip noktalara yapılan günlük tekne turları unutulmaz anılar bırakıyor.",
          Thumbnail = "postImages/marmaris-tekne.jpg",
          SeoDescription = "Marmaris tekne turları ve popüler rota önerileri",
          SeoTags = "Marmaris, tekne turu, Cennet Adası, Kızkumu",
          SeoAuthor = "Muğla Gezi Rehberi",
          Date = DateTime.Now,
          PublishDate = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Marmaris tekne turları makalesi",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 8940,
          CommentCount = 12
      }
  );

        }
    }
}
