using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            // **Tablo Adı**
            builder.ToTable("Comments").HasComment("Yorumlar");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Text).IsRequired().HasMaxLength(1000);

            //ortak alanlar
            builder.Property(x => x.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();


            //ilişkiler
            builder.HasOne(a => a.Article).WithMany(c => c.Comments).HasForeignKey(a => a.ArticleId).OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
            new Comment
            {
                Id = Guid.Parse("253e472e-21ac-4e18-91d7-49b599a4f9b9"),
                ArticleId = Guid.Parse("c20558d8-b0fd-4142-a527-0da9910deefc"), // C# Makalesi
                Text =
                    "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# Makale Yorumu",
            },
            new Comment
            {
                Id = Guid.Parse("1a099dbb-af9f-4a8a-b67a-96c8d957a7b2"),
                ArticleId = Guid.Parse("87b5d57f-1e2b-4b58-b9e6-2718d5af5924"), // C++ Makalesi
                Text =
                    "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C++ Makale Yorumu",
            },
            new Comment
            {
                Id = Guid.Parse("f0756c5c-6d1d-4683-9d3d-7ddbbc561f42"),
                ArticleId = Guid.Parse("2fe2d2d5-79c9-4fed-a236-74426d84d4b5"), // JavaScript Makalesi
                Text =
                    "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "JavaScript Makale Yorumu",
            },
            new Comment
            {
                Id = Guid.Parse("d86f1fb4-8c1e-45c8-8677-46ee89af8db3"),
                ArticleId = Guid.Parse("0b797ea6-5f12-42a5-b4f6-4f67d5e2a829"), // TypeScript Makalesi
                Text =
                    "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Typescript Makale Yorumu",
            },
            new Comment
            {
                Id = Guid.Parse("3f8b6590-12f5-4d2a-b97d-57e75f0a2a75"),
                ArticleId = Guid.Parse("77c21f6c-57e4-48d3-85b8-1e5e357d6e53"), // Java Makalesi
                Text =
                    "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Java Makale Yorumu",
            },
            new Comment
            {
                Id = Guid.Parse("7c4c7d74-5187-4a7d-9a96-bd7a321e3340"),
                ArticleId = Guid.Parse("1b9e8c64-075f-4a16-8a18-09532fe8d1bd"), // Python Makalesi
                Text =
                    "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Python Makale Yorumu",
            },
            new Comment
            {
                Id = Guid.Parse("e257f068-5e76-4587-8e99-a9b58bea2b5f"),
                ArticleId = Guid.Parse("3e17dec7-f5b9-4cab-8d53-77f89c144e2d"), // PHP Makalesi
                Text =
                    "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Php Makale Yorumu",
            },
            new Comment
            {
                Id = Guid.Parse("a4edb8d2-6c4f-4186-b4f6-0bf664011d5e"),
                ArticleId = Guid.Parse("42eb2c71-47f5-4bec-b31e-e71e11c39c28"), // Kotlin Makalesi
                Text =
                    "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Kotlin Makale Yorumu",
            },
            new Comment
            {
                Id = Guid.Parse("fd7e2485-5ca0-4a3c-9b0b-5f62ddb7c3f9"),
                ArticleId = Guid.Parse("f8dfba8a-90e6-4e1b-bd0c-2e22a8c77423"), // Swift Makalesi
                Text =
                    $"ong established fact that a reader will be distracted by the readable conten",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Swift Makale Yorumu",
            },
            new Comment
            {
                Id = Guid.Parse("9a5cef5c-8276-4c8e-933e-95c5f29cdab1"),
                ArticleId = Guid.Parse("ad45a8fc-3c20-4c37-8db1-e45c1fb01a57"), // Ruby Makalesi
                Text =
                    $"Lorem Ipsum，ong established fact that a reader will be distracted by the readable conten",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Ruby Makale Yorumu",
            }
        );
        }
    }
}
