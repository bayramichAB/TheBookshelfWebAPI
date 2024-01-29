using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookshelf.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Pages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID");
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorID", "Biography", "Name" },
                values: new object[,]
                {
                    { new Guid("0e59a0d4-ae7d-4b1e-b868-ff6420b00964"), "Phil Knight (born February 24, 1938, Portland, Oregon, U.S.) American businessman who cofounded (1964) the multinational sportswear and sports equipment corporation Nike, Inc. (originally called Blue Ribbon Sports). During his tenure as CEO (1964–2004), Nike became one of the most successful companies in the world", "Phil Knight" },
                    { new Guid("516d04ca-dea8-4ad5-bd8a-17182467fd4d"), "Mary Shelley (1797-1851), the only daughter of writers William Godwin and Mary Wollstonecraft, and wife of Percy Bysshe Shelley, is the critically acclaimed author of Frankenstein, Valperga, and The Last Man, in addition to many other works. Mary Shelley s writings reflect and were influenced by a number of literary traditions including Gothic and Romantic ideals, and Frankenstein is widely regarded as the first modern work of science fiction", "Mary Shelley" },
                    { new Guid("86c052c7-bc0a-4a94-bb8b-3d45fc6f504e"), "Anna Reid (born 1965) is an English journalist and author whose work focuses primarily on the history of Eastern Europe", "Anna Reid" },
                    { new Guid("8e73a4ea-3847-493f-81ec-db23f5839f54"), "Lev Nikolayevich Tolstoy (Russian: Лев Николаевич Толстой; most appropriately used Liev Tolstoy; commonly Leo Tolstoy in Anglophone countries) was a Russian writer who primarily wrote novels and short stories. Later in life, he also wrote plays and essays. His two most famous works, the novels War and Peace and Anna Karenina, are acknowledged as two of the greatest novels of all time and a pinnacle of realist fiction. Many consider Tolstoy to have been one of the world's greatest novelists. Tolstoy is equally known for his complicated and paradoxical persona and for his extreme moralistic and ascetic views, which he adopted after a moral crisis and spiritual awakening in the 1870s, after which he also became noted as a moral thinker and social reformer", "Leo Tolstoy" },
                    { new Guid("8eb1c235-1696-4d2b-9b17-7aa03ac95cba"), "Sir Arthur Conan Doyle was born in Edinburgh in 1859 and died in 1930. Within those years was crowded a variety of activity and creative work that made him an international figure and inspired the French to give him the epithet 'the good giant'. He was the nephew of 'Dickie Doyle' the artist, and was educated at Stonyhurst, and later studied medicine at Edinburgh University, where the methods of diagnosis of one of the professors provided the idea for the methods of deduction used by Sherlock Holmes", "Arthur Doyle" },
                    { new Guid("96398023-81b7-4b65-b90c-cb574a4937f7"), "Simon Proudman is an Australian travel blogger whose passion lies with far flung places, so that’s what he named his blog! From Papua New Guinea to Turkmenistan, Simon has seen parts of the globe that many of us have only heard of", "Simon Proudman" },
                    { new Guid("b91a67df-7836-4892-8c13-a3a050a8352d"), "Writer of best-selling books about Minecraft", "Megan Miller" },
                    { new Guid("bdb52009-176e-49bc-9754-e7c9d987609f"), "Itzik Ben-Gan is an independent T-SQL Trainer. A Microsoft Data Platform MVP (Most Valuable Professional) since 1999, Itzik has delivered numerous training events around the world focused on T-SQL Querying, Query Tuning and Programming. Itzik is the author of several books including T-SQL Fundamentals, T-SQL Querying and T-SQL Window Functions. He has written articles for red-gate.com/simple-talk, sqlperformance.com, ITPro Today and SQL Server Magazine. Itzik’s speaking activities include PASS Data Community Summit, SQLBits, and various events and user groups around the world. Itzik developed and is regularly delivering his Advanced T-SQL Querying, Programming and Tuning and T-SQL Fundamentals courses", "Itzik Ben-Gan" },
                    { new Guid("f983ad2a-ac2c-4cb7-9aaa-483096423e54"), "Robert Kiyosaki, author of Rich Dad Poor Dad - the international runaway bestseller that has held a top spot on the New York Times bestsellers list for over six years - is an investor, entrepreneur and educator whose perspectives on money and investing fly in the face of conventional wisdom. He has, virtually single-handedly, challenged and changed the way tens of millions, around the world, think about money", "Robert T. Kiyosaki" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { new Guid("396ed389-1053-4fe5-85d2-9028fdcfaa40"), "Literature" },
                    { new Guid("45d25e0e-54ba-404f-840c-50e58573857a"), "Computer&Technology" },
                    { new Guid("57b66675-4c6d-49f0-aac9-95d9934c1435"), "History" },
                    { new Guid("823452e8-d300-4ab3-bf03-e6101a6d7fe3"), "Business" },
                    { new Guid("cb65df3a-aee9-4445-8708-6947c42c53ac"), "Travel" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorID", "Available", "CategoryID", "Date", "Description", "Name", "Pages", "Price" },
                values: new object[,]
                {
                    { new Guid("1663a5b2-f310-4380-952d-14a7c2bd2d55"), new Guid("b91a67df-7836-4892-8c13-a3a050a8352d"), false, new Guid("45d25e0e-54ba-404f-840c-50e58573857a"), new DateTime(2015, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "By New York Times bestselling author and Minecraft expert, Megan Miller, a full-color book full of practical advice that boys and girls will refer to again and again!", "The Ultimate Unofficial Encyclopedia for Minecrafters", "176", 17.45m },
                    { new Guid("3936e305-57d0-4913-9103-c671475b7820"), new Guid("96398023-81b7-4b65-b90c-cb574a4937f7"), true, new Guid("cb65df3a-aee9-4445-8708-6947c42c53ac"), new DateTime(2017, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkmenistan, a country once closed to visitors during its time as a Soviet republic, is now attracting more intrepid tourists. Beautiful ancient Silk Road cities contrast with striking marble-clad modern architecture and a massive gas crater burning in the middle of the desert. There is a lot to see and enjoy in this unusual central Asian destination.\r\n\r\nDetailed information of the cities and attractions with maps and invaluable contact information. Learn how to travel around and find the best places to visit, stay and eat.", "Turkmenistan: Far Flung Places Travel Guide", "262", 9.95m },
                    { new Guid("602a366e-ac45-4804-8645-5b6b52039b2b"), new Guid("516d04ca-dea8-4ad5-bd8a-17182467fd4d"), false, new Guid("396ed389-1053-4fe5-85d2-9028fdcfaa40"), new DateTime(2020, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frankenstein; or, The Modern Prometheus, is a novel written by English author Mary Shelley about the young student of science Victor Frankenstein, who creates a grotesque but sentient creature in an unorthodox scientific experiment. Shelley started writing the story when she was eighteen, and the novel was published when she was twenty. The first edition was published anonymously in London in 1818. Shelley's name appears on the second edition, published in France in 1823.Shelley had travelled through Europe in 1814, journeying along the river Rhine in Germany with a stop in Gernsheim which is just 17 km (10 mi) away from Frankenstein Castle, where two centuries before an alchemist was engaged in experiments", "Frankenstein", "144", 6.73m },
                    { new Guid("86f054c4-da8c-4c1e-b4fa-b939b3f9abf2"), new Guid("86c052c7-bc0a-4a94-bb8b-3d45fc6f504e"), true, new Guid("57b66675-4c6d-49f0-aac9-95d9934c1435"), new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "On 8 September 1941, 11 weeks after Hitler launched Operation Barbarossa, Leningrad was surrounded. The siege would not end for 2 and a half years and as many as 2 million Soviet lives would be lost. This narrative history is interwoven with personal stories of daily siege life drawn from diarists and memoirists on both sides", "Leningrad: Tragedy of a City Under Siege, 1941-44", "492", 10.76m },
                    { new Guid("8a0f5fc1-c11e-4a6d-8e35-091fbe243079"), new Guid("f983ad2a-ac2c-4cb7-9aaa-483096423e54"), true, new Guid("823452e8-d300-4ab3-bf03-e6101a6d7fe3"), new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "April of 2022 marks a 25-year milestone for the personal finance classic Rich Dad Poor Dad that still ranks as the #1 Personal Finance book of all time. And although 25 years have passed since Rich Dad Poor Dad was first published, readers will find that very little in the book itself has changed — and for good reason. While so much in our world is changing a high speed, the lessons about money and the principles of Rich Dad Poor Dad haven’t changed. Today, as money continues to play a key role in our daily lives, the messages in Robert Kiyosaki’s international bestseller are more timely and more important than ever", "Rich Dad Poor Dad", "336", 10.99m },
                    { new Guid("a754e048-cbd7-4062-bb20-b6b4dfcb1c1a"), new Guid("0e59a0d4-ae7d-4b1e-b868-ff6420b00964"), true, new Guid("823452e8-d300-4ab3-bf03-e6101a6d7fe3"), new DateTime(2016, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "In this candid and riveting memoir, for the first time ever, Nike founder and CEO Phil Knight shares the inside story of the company's early days as an intrepid start-up and its evolution into one of the world's most iconic, game-changing, and profitable brands.", "Shoe Dog: A Memoir by the Creator of Nike", "512", 12.60m },
                    { new Guid("b2deb06a-387f-41eb-9fca-a532402dc13a"), new Guid("bdb52009-176e-49bc-9754-e7c9d987609f"), true, new Guid("45d25e0e-54ba-404f-840c-50e58573857a"), new DateTime(2012, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master the fundamentals of Transact-SQL—and develop your own code for querying and modifying data in Microsoft® SQL Server® 2012. Led by a SQL Server expert, you’ll learn the concepts behind T-SQL querying and programming, and then apply your knowledge with exercises in each chapter. Once you understand the logic behind T-SQL, you’ll quickly learn how to write effective code—whether you’re a programmer or database administrator.", "Microsoft SQL Server 2012 T-SQL Fundamentals", "401", 19m },
                    { new Guid("b5feebe1-9b8a-46f0-a0ae-7133bb71ced0"), new Guid("8eb1c235-1696-4d2b-9b17-7aa03ac95cba"), true, new Guid("396ed389-1053-4fe5-85d2-9028fdcfaa40"), new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "\"The Memoirs of Sherlock Holmes\" takes readers on a gripping journey through a collection of intriguing cases solved by the brilliant detective, Sherlock Holmes, and his loyal companion, Dr. Watson. In the first thrilling tale, \"Silver Blaze,\" Holmes and Watson are called to Dartmoor to investigate the mysterious disappearance of the favorite racehorse for the Wessex Cup and the murder of its trainer. As they unravel the clues and confront suspicious characters, they find themselves drawn deeper into a web of deception and danger", "The Memoirs of Sherlock Holmes", "302", 17.31m },
                    { new Guid("b936e89d-615d-4ebd-93e2-a428f4b90794"), new Guid("8e73a4ea-3847-493f-81ec-db23f5839f54"), true, new Guid("396ed389-1053-4fe5-85d2-9028fdcfaa40"), new DateTime(2008, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "War and Peacebroadly focuses on Napoleon’s invasion of Russia in 1812 and follows three of the most well-known characters in literature: Pierre Bezukhov, the illegitimate son of a count who is fighting for his inheritance and yearning for spiritual fulfillment; Prince Andrei Bolkonsky, who leaves his family behind to fight in the war against Napoleon; and Natasha Rostov, the beautiful young daughter of a nobleman who intrigues both men.", "War and Peace (Vintage Classics)", "1296", 12.44m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryID",
                table: "Books",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
