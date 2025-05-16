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
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Content).IsRequired().HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.Date).IsRequired();
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
      new Article
      {
          Id = Guid.Parse("c20558d8-b0fd-4142-a527-0da9910deefc"),
          MenuId = Guid.Parse("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"),
          Title = "Fethiye'nin Eşsiz Koyları ve Plajları",
          Content =
              "Muğla'nın incisi Fethiye, Türkiye'nin en güzel koylarına ve plajlarına ev sahipliği yapıyor. Ölüdeniz'in turkuaz suları ve beyaz kumsalı, dünyaca ünlü Kelebekler Vadisi, saklı cennet Kabak Koyu ve tekne turlarıyla keşfedebileceğiniz 12 Adalar, her yıl binlerce turisti ağırlıyor. Fethiye'nin berrak sularında yüzmek, Belcekız Plajı'nda güneşlenmek ve Gemiler Adası'nı keşfetmek unutulmaz bir tatil deneyimi yaşatıyor. Ayrıca Fethiye merkezdeki tarihi Kayaköy (Levissi) harabeleri, Antik Likya uygarlığından kalma kaya mezarları ve Tlos antik kenti de bölgenin zengin tarihini gözler önüne seriyor. Fethiye aynı zamanda yamaç paraşütü tutkunları için dünyanın en iyi noktalarından biri olan Babadağ'a ev sahipliği yapıyor. 1975 metre yükseklikteki Babadağ'dan Ölüdeniz manzarası eşliğinde yapılan uçuşlar, adrenalin tutkunlarına unutulmaz anlar yaşatıyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Fethiye'nin Eşsiz Koyları ve Plajları",
          SeoTags = "Fethiye, Ölüdeniz, Kelebekler Vadisi, Babadağ, Muğla, plajlar, koylar",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Fethiye'nin doğal güzellikleri",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 100,
          CommentCount = 0
      },
      new Article
      {
          Id = Guid.Parse("87b5d57f-1e2b-4b58-b9e6-2718d5af5924"),
          MenuId = Guid.Parse("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
          Title = "Bodrum'da Gezilecek Tarihi Mekanlar",
          Content =
              "Muğla'nın en popüler ilçelerinden biri olan Bodrum, tarih boyunca birçok medeniyete ev sahipliği yapmış önemli bir kültür merkezidir. Antik dünyanın yedi harikasından biri olan Mausoleum'un kalıntıları, UNESCO Dünya Mirası Listesi'nde yer alan Bodrum Kalesi ve içindeki Sualtı Arkeoloji Müzesi mutlaka ziyaret edilmesi gereken yerlerdir. Bodrum Antik Tiyatrosu, Myndos Kapısı ve Pedasa Antik Kenti de tarihi yolculuğunuzu tamamlayan önemli duraklardır. Bunun yanı sıra, geleneksel Bodrum evleri ile ünlü Gümbet ve Ortakent gibi mahalleler, bembeyaz badanalı, mavi pencereli evleriyle Ege mimarisinin en güzel örneklerini sergiliyor. Bodrum, aynı zamanda canlı gece hayatı, lüks marinası ve dünyaca ünlü plajlarıyla da turistlerin gözdesi. Türkbükü, Gümüşlük ve Yalıkavak gibi beldeleriyle her zevke hitap eden Bodrum, yemek kültürü ve el sanatlarıyla da ziyaretçilerini büyülüyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Bodrum'da Gezilecek Tarihi Mekanlar",
          SeoTags = "Bodrum, Bodrum Kalesi, Mausoleum, Antik Tiyatro, Muğla, tarih",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Bodrum'un tarihi zenginlikleri",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 295,
          CommentCount = 0
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
          SeoTags = "Marmaris, İçmeler, Turunç, marina, tekne turu, Kleopatra Plajı, Muğla",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
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
      new Article
      {
          Id = Guid.Parse("0b797ea6-5f12-42a5-b4f6-4f67d5e2a829"),
          MenuId = Guid.Parse("7191e8c0-26c6-4703-950e-dc195cc5c3db"),
          Title = "Datça Yarımadası'nın Gizli Koyları",
          Content =
          "Muğla'nın cennet köşelerinden biri olan Datça Yarımadası, Ege ve Akdeniz'in buluştuğu noktada eşsiz bir doğal güzelliğe sahip. 'Dünyada iki kere insan yaşar; biri Datça'da, biri rüyada' diye tarif eden Can Yücel'i haklı çıkaracak güzellikteki bu yarımada, el değmemiş koyları ve plajlarıyla ünlü. Doğu tarafında Hisarönü Körfezi, batı tarafında Gökova Körfezi ile çevrili olan yarımadada Palamutbükü, Hayıtbükü ve Kızılbük gibi muhteşem koylar bulunuyor. Özellikle Knidos Antik Kenti'nin yanındaki Delikli Koy ve Karaincir Koyu, berrak suları ve sessiz ortamıyla dikkat çekiyor. Datça merkezdeki Kumluk Plajı ve Taşlık Plajı da hem yerel halkın hem de turistlerin vazgeçilmez durakları. Ayrıca Datça, Apollon Tapınağı, Eski Datça'nın taş evleri ve zeytinyağı atölyeleriyle de kültür turizmi açısından zengin bir bölge. Bademli ve verimliliğiyle dünyaca ünlü Datça bademleri, zeytinyağı ve bal gibi yerel lezzetler de bu güzel yarımadanın tadını tamamlıyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Datça Yarımadası'nın Gizli Koyları",
          SeoTags = "Datça, Knidos, Palamutbükü, koylar, plajlar, Muğla, Ege",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Datça'nın doğal güzellikleri",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 666,
          CommentCount = 0
      }
      ,
      new Article
      {
          Id = Guid.Parse("77c21f6c-57e4-48d3-85b8-1e5e357d6e53"),
          MenuId = Guid.Parse("dfa25617-9fdb-4f9b-bba9-726404d6d87b"),
          Title = "Köyceğiz Gölü ve Dalyan Kanalları",
          Content =
              "Muğla'nın en özel doğa harikalarından biri olan Köyceğiz Gölü ve Dalyan Kanalları, eşsiz ekosistemiyle büyüleyici bir güzelliğe sahip. Tatlı su gölü olan Köyceğiz'den başlayıp, kanallar boyunca Akdeniz'e uzanan bu su yolu, nesli tükenmekte olan Caretta Caretta deniz kaplumbağalarının en önemli üreme alanlarından biri olan İztuzu Plajı'na kadar devam ediyor. Dalyan Kanalları boyunca tekne turlarıyla yapılan gezilerde, sazlıklar arasında ilerlerken binlerce yıllık Kaunos Antik Kenti'nin kaya mezarlarını görebilirsiniz. Ayrıca bölgede bulunan şifalı çamur banyoları ve termal kaynaklar da sağlık turizmi açısından büyük önem taşıyor. Sultan Sazlığı olarak bilinen bölge, yüzlerce kuş türüne ev sahipliği yapan bir kuş cennetidir. Köyceğiz'in zengin bitki örtüsü, endemik türleri ve yaban hayatı, doğa tutkunları için adeta bir cennet. Bölge aynı zamanda, Köyceğiz'in geleneksel pazarı, yerel el sanatları ve Sultaniye Kaplıcaları ile de ziyaretçilerine unutulmaz deneyimler sunuyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Köyceğiz Gölü ve Dalyan Kanalları",
          SeoTags = "Köyceğiz, Dalyan, İztuzu, Caretta Caretta, Kaunos, Muğla",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Köyceğiz ve Dalyan'ın doğal güzellikleri",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 3225,
          CommentCount = 0
      }
      ,
      new Article
      {
          Id = Guid.Parse("1b9e8c64-075f-4a16-8a18-09532fe8d1bd"),
          MenuId = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
          Title = "Milas'ın Tarihi ve Kültürel Zenginlikleri",
          Content =
          "Muğla'nın en eski yerleşim yerlerinden biri olan Milas, zengin tarihi dokusu ve kültürel mirası ile dikkat çekiyor. Antik Karya uygarlığının başkenti olan Milas, Helenistik, Roma, Bizans, Selçuklu ve Osmanlı dönemlerine ait birçok tarihi esere ev sahipliği yapıyor. Şehir merkezinde bulunan Hekatomnos Anıt Mezarı ve Müzesi, dünyada türünün en iyi korunmuş örneklerinden biri olarak UNESCO Dünya Mirası Geçici Listesi'nde yer alıyor. Ünlü Beçin Kalesi ve etrafındaki Osmanlı dönemi yerleşimi, İasos Antik Kenti, Labranda Antik Kenti ve Zeus Tapınağı bölgenin önemli tarihi değerleri arasında. Ayrıca Milas, geleneksel Türk mimarisinin en güzel örneklerinden olan konakları ve camileriyle de ünlü. Milas halıları, el dokuması kilimler ve zeytin ürünleri yörenin en önemli kültürel simgeleri arasında. Bafa Gölü Tabiat Parkı da doğa tutkunları için muhteşem manzaralar sunuyor. Göl kenarında bulunan Herakleia Antik Kenti kalıntıları ise doğa ve tarihin buluştuğu eşsiz bir atmosfer yaratıyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Milas'ın Tarihi ve Kültürel Zenginlikleri",
          SeoTags = "Milas, Hekatomnos, Beçin Kalesi, İasos, Labranda, Bafa Gölü, Muğla",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Milas tarihi",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 9999,
          CommentCount = 0
      }
      ,
      new Article
      {
          Id = Guid.Parse("3e17dec7-f5b9-4cab-8d53-77f89c144e2d"),
          MenuId = Guid.Parse("7e29265f-d672-42a7-9d84-47b564ebad69"),
          Title = "Muğla Merkez'de Kültür Turizmi",
          Content =
              "Muğla il merkezi, Osmanlı ve Cumhuriyet dönemlerinden kalma tarihi yapıları, müzeleri ve geleneksel Türk mimarisini yansıtan evleriyle tam bir açık hava müzesi niteliğindedir. 'Beyaz Kent' olarak da anılan Muğla'nın tarihi dokusunu en iyi yansıtan Saburhane Mahallesi, restore edilmiş geleneksel Muğla evleriyle ünlüdür. Bacaları ve cumbalı evleriyle dikkat çeken bu mahalle, fotoğraf tutkunları için de eşsiz kareler sunuyor. Kent merkezindeki Kurşunlu Cami, Ulu Cami ve Konakaltı Han gibi tarihi yapılar, Osmanlı mimarisinin en güzel örnekleri arasında. Muğla Arkeoloji Müzesi ve Muğla Kent Müzesi, bölgenin zengin tarihini ve kültürel mirasını sergilemektedir. Ayrıca Muğla'nın meşhur perşembe pazarı, yöresel ürünlerin bulunabileceği rengarenk bir alışveriş deneyimi sunuyor. Muğla mutfağı da zeytinyağlı yemekleri, otları, börekleri ve tatlılarıyla Türk mutfağının en zengin örneklerinden. Özellikle çökertme kebabı, sündürme, keşkek ve tarhana çorbası mutlaka tadılması gereken yerel lezzetler arasında yer alıyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Muğla Merkez'de Kültür Turizmi",
          SeoTags = "Muğla, Saburhane, Osmanlı mimarisi, müzeler, kültür, pazar",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Muğla merkez kültürü",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 4818,
          CommentCount = 0
      }
      ,
      new Article
      {
          Id = Guid.Parse("42eb2c71-47f5-4bec-b31e-e71e11c39c28"),
          MenuId = Guid.Parse("b33b442b-58b3-400b-a2f5-9231e58a1ff7"),
          Title = "Seydikemer'in Bakir Doğası ve Kanyonları",
          Content =
              "Muğla'nın en büyük ilçelerinden biri olan Seydikemer, el değmemiş doğası, kanyonları ve dağlarıyla doğa tutkunlarının gözdesi. İlçenin en önemli doğal güzelliklerinden biri olan Saklıkent Kanyonu, Türkiye'nin en uzun ikinci kanyonu olup, 18 km uzunluğunda ve yer yer 300 metre derinliğe sahip. Yazın serinlemek isteyenler için ideal bir rotadır. Tlos Antik Kenti'nin de bulunduğu ilçede, Yaka Kanyonu ve Gizlikent Şelalesi de görülmeye değer doğa harikalarından. Pastoral yaşamın hala devam ettiği ilçede, yaylacılık kültürü de oldukça yaygın. Akdağ ve Seki yaylaları, özellikle yaz aylarında serin iklimi ve muhteşem manzarasıyla ziyaretçileri büyülüyor. Seydikemer'in bereketli topraklarında yetiştirilen tarım ürünleri, özellikle narenciye ve çam balı, bölgenin ekonomisinde önemli yer tutuyor. Ayrıca ilçede bulunan Letoon Antik Kenti, UNESCO Dünya Mirası Listesi'nde yer alan önemli bir arkeolojik alandır. Seydikemer'in kırsal köylerinde yaşayan yörük kültürü ve geleneksel el sanatları da görülmeye değer kültürel zenginlikler sunuyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Seydikemer'in Bakir Doğası ve Kanyonları",
          SeoTags = "Seydikemer, Saklıkent Kanyonu, Tlos, yaylalar, doğa, Muğla",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Seydikemer doğa",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 750,
          CommentCount = 0
      }
      ,
      new Article
      {
          Id = Guid.Parse("f8dfba8a-90e6-4e1b-bd0c-2e22a8c77423"),
          MenuId = Guid.Parse("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"),
          Title = "Ula ve Akyaka'da Sakin Şehir Deneyimi",
          Content =
              "Muğla'nın saklı cenneti Ula ve dünyaca ünlü sakin şehir (cittaslow) Akyaka, modern dünyanın hızından uzaklaşmak isteyenler için ideal destinasyonlar. Akyaka, 2011 yılında Türkiye'nin üçüncü sakin şehri olarak ilan edilmiş ve bu unvanı geleneksel mimarisi, doğal güzellikleri ve sürdürülebilir yaşam anlayışı ile hak etmiştir. Bölgenin en karakteristik özelliği olan 'Muğla-Ula evleri' tarzındaki mimari, taş ve ahşabın uyumlu birleşimiyle dikkat çekiyor. Akyaka'nın uzun kumsalı ve berrak denizi, plaj keyfi için idealken, Kadın Azmağı olarak bilinen tatlı su kaynağı etrafındaki restoranlar da lezzetli deniz ürünleri sunuyor. Akyaka aynı zamanda, kiteboard sporcuları için ideal rüzgar koşulları sayesinde bir cennet. Gökova Körfezi'nin eşsiz manzarasına sahip olan bölge, tekne turları ve doğa yürüyüşleri için de mükemmel imkanlar sunuyor. Ula'nın yeşil yaylaları, Gökova'nın muhteşem koyu ve Akçapınar'ın sakin atmosferi, bölgenin diğer güzellikleri arasında. Ayrıca yöresel mutfağın özel tatları, özellikle çam balı, zeytinyağlı yemekler ve taze deniz ürünleri, gastronomi tutkunları için unutulmaz lezzetler vadediyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Ula ve Akyaka'da Sakin Şehir Deneyimi",
          SeoTags = "Akyaka, Ula, cittaslow, sakin şehir, Gökova, Kadın Azmağı, Muğla",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
          IsActive = true,
          IsDeleted = false,
          CreatedByName = "InitialCreate",
          CreatedDate = DateTime.Now,
          ModifiedByName = "InitialCreate",
          ModifiedDate = DateTime.Now,
          Note = "Ula ve Akyaka",
          UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
          ViewsCount = 14900,
          CommentCount = 0
      }
      ,
      new Article
      {
          Id = Guid.Parse("ad45a8fc-3c20-4c37-8db1-e45c1fb01a57"),
          MenuId = Guid.Parse("3b466d57-abb5-4624-b922-1b2fba6a62c3"),
          Title = "Kavaklıdere ve Yatağan'ın Doğal ve Tarihi Zenginlikleri",
          Content =
              "Muğla'nın iç kesimlerinde yer alan Kavaklıdere ve Yatağan ilçeleri, el değmemiş doğası ve zengin tarihi mirası ile keşfedilmeyi bekleyen gizli hazinelerdir. Kavaklıdere, ismini verimli topraklarında yetişen kavak ağaçlarından almış olup, bağcılık ve şarapçılık kültürü ile ünlüdür. İlçenin dağlık alanlarında bulunan Menteşe Yaylası, serin iklimi ve muhteşem manzarasıyla yazın bunaltan sıcaklardan kaçmak isteyenler için ideal bir sığınak. Yatağan ise antik dönemden kalma Stratonikeia Antik Kenti ile ünlüdür. 'Mermer Şehir' olarak da bilinen bu antik kent, Roma, Helenistik ve Bizans dönemlerine ait kalıntılarıyla tarih meraklıları için vazgeçilmez bir durak. Yatağan aynı zamanda geleneksel Türk kılıcı olan 'yatağan'ın üretim merkezi olarak da tarihe geçmiştir. Bölgede yer alan Bozüyük ve Turgut gibi eski Türk yerleşimleri, yüzlerce yıllık çınar ağaçları, tarihi camileri ve geleneksel Türk köy yaşamını yansıtan dokusuyla otantik bir atmosfer sunuyor. Yerel halk tarafından hala yaşatılan geleneksel el sanatları, özellikle halıcılık ve dokumacılık, bölgenin kültürel zenginliklerini tamamlıyor.",
          Thumbnail = "postImages/defaultThumbnail.jpg",
          SeoDescription = "Kavaklıdere ve Yatağan'ın Doğal ve Tarihi Zenginlikleri",
          SeoTags = "Kavaklıdere, Yatağan, Stratonikeia, bağcılık, yaylalar, tarih, Muğla",
          SeoAuthor = "Muğla Rehberi",
          Date = DateTime.Now,
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
  );

        }
    }
}
