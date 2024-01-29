﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class BookConfiguration:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
                (
                new Book
                {
                    Id=new Guid("86f054c4-da8c-4c1e-b4fa-b939b3f9abf2"),
                    Name= "Leningrad: Tragedy of a City Under Siege, 1941-44",
                    Price=10.76m,
                    Available=true,
                    Pages= "492",
                    Date= new DateTime(2011, 1, 1),
                    Description= "On 8 September 1941, 11 weeks after Hitler launched Operation Barbarossa, Leningrad was surrounded. The siege would not end for 2 and a half years and as many as 2 million Soviet lives would be lost. This narrative history is interwoven with personal stories of daily siege life drawn from diarists and memoirists on both sides",
                    CategoryID=new Guid("57b66675-4c6d-49f0-aac9-95d9934c1435"),
                    AuthorID=new Guid("86c052c7-bc0a-4a94-bb8b-3d45fc6f504e")
                },

                new Book
                {
                    Id = new Guid("b5feebe1-9b8a-46f0-a0ae-7133bb71ced0"),
                    Name = "The Memoirs of Sherlock Holmes",
                    Price = 17.31m,
                    Available = true,
                    Pages = "302",
                    Date = new DateTime(2023, 8, 24),
                    Description = "\"The Memoirs of Sherlock Holmes\" takes readers on a gripping journey through a collection of intriguing cases solved by the brilliant detective, Sherlock Holmes, and his loyal companion, Dr. Watson. In the first thrilling tale, \"Silver Blaze,\" Holmes and Watson are called to Dartmoor to investigate the mysterious disappearance of the favorite racehorse for the Wessex Cup and the murder of its trainer. As they unravel the clues and confront suspicious characters, they find themselves drawn deeper into a web of deception and danger",
                    CategoryID = new Guid("396ed389-1053-4fe5-85d2-9028fdcfaa40"),
                    AuthorID = new Guid("8eb1c235-1696-4d2b-9b17-7aa03ac95cba")
                },

                new Book
                {
                    Id = new Guid("8a0f5fc1-c11e-4a6d-8e35-091fbe243079"),
                    Name = "Rich Dad Poor Dad",
                    Price = 10.99m,
                    Available = true,
                    Pages = "336",
                    Date = new DateTime(2022, 4, 5),
                    Description = "April of 2022 marks a 25-year milestone for the personal finance classic Rich Dad Poor Dad that still ranks as the #1 Personal Finance book of all time. And although 25 years have passed since Rich Dad Poor Dad was first published, readers will find that very little in the book itself has changed — and for good reason. While so much in our world is changing a high speed, the lessons about money and the principles of Rich Dad Poor Dad haven’t changed. Today, as money continues to play a key role in our daily lives, the messages in Robert Kiyosaki’s international bestseller are more timely and more important than ever",
                    CategoryID = new Guid("823452e8-d300-4ab3-bf03-e6101a6d7fe3"),
                    AuthorID = new Guid("f983ad2a-ac2c-4cb7-9aaa-483096423e54")
                },

                new Book
                {
                    Id = new Guid("b2deb06a-387f-41eb-9fca-a532402dc13a"),
                    Name = "Microsoft SQL Server 2012 T-SQL Fundamentals",
                    Price = 19m,
                    Available = true,
                    Pages = "401",
                    Date = new DateTime(2012, 7, 15),
                    Description = "Master the fundamentals of Transact-SQL—and develop your own code for querying and modifying data in Microsoft® SQL Server® 2012. Led by a SQL Server expert, you’ll learn the concepts behind T-SQL querying and programming, and then apply your knowledge with exercises in each chapter. Once you understand the logic behind T-SQL, you’ll quickly learn how to write effective code—whether you’re a programmer or database administrator.",
                    CategoryID=new Guid("45d25e0e-54ba-404f-840c-50e58573857a"),
                    AuthorID = new Guid("bdb52009-176e-49bc-9754-e7c9d987609f")
                },

                new Book
                {
                    Id=new Guid("3936e305-57d0-4913-9103-c671475b7820"),
                    Name = "Turkmenistan: Far Flung Places Travel Guide",
                    Price = 9.95m,
                    Available = true,
                    Pages = "262",
                    Date = new DateTime(2017, 5, 13),
                    Description = "Turkmenistan, a country once closed to visitors during its time as a Soviet republic, is now attracting more intrepid tourists. Beautiful ancient Silk Road cities contrast with striking marble-clad modern architecture and a massive gas crater burning in the middle of the desert. There is a lot to see and enjoy in this unusual central Asian destination.\r\n\r\nDetailed information of the cities and attractions with maps and invaluable contact information. Learn how to travel around and find the best places to visit, stay and eat.",
                    CategoryID=new Guid("cb65df3a-aee9-4445-8708-6947c42c53ac"),
                    AuthorID = new Guid("96398023-81b7-4b65-b90c-cb574a4937f7")
                },

                new Book
                {
                    Id = new Guid("b936e89d-615d-4ebd-93e2-a428f4b90794"),
                    Name = "War and Peace (Vintage Classics)",
                    Price = 12.44m,
                    Available = true,
                    Pages = "1296",
                    Date = new DateTime(2008, 12, 2),
                    Description = "War and Peacebroadly focuses on Napoleon’s invasion of Russia in 1812 and follows three of the most well-known characters in literature: Pierre Bezukhov, the illegitimate son of a count who is fighting for his inheritance and yearning for spiritual fulfillment; Prince Andrei Bolkonsky, who leaves his family behind to fight in the war against Napoleon; and Natasha Rostov, the beautiful young daughter of a nobleman who intrigues both men.",
                    CategoryID=new Guid("396ed389-1053-4fe5-85d2-9028fdcfaa40"),
                    AuthorID = new Guid("8e73a4ea-3847-493f-81ec-db23f5839f54")
                },

                new Book
                {
                    Id=new Guid("602a366e-ac45-4804-8645-5b6b52039b2b"),
                    Name = "Frankenstein",
                    Price = 6.73m,
                    Available = false,
                    Pages = "144",
                    Date = new DateTime(2020, 12, 21),
                    Description = "Frankenstein; or, The Modern Prometheus, is a novel written by English author Mary Shelley about the young student of science Victor Frankenstein, who creates a grotesque but sentient creature in an unorthodox scientific experiment. Shelley started writing the story when she was eighteen, and the novel was published when she was twenty. The first edition was published anonymously in London in 1818. Shelley's name appears on the second edition, published in France in 1823.Shelley had travelled through Europe in 1814, journeying along the river Rhine in Germany with a stop in Gernsheim which is just 17 km (10 mi) away from Frankenstein Castle, where two centuries before an alchemist was engaged in experiments",
                    CategoryID=new Guid("396ed389-1053-4fe5-85d2-9028fdcfaa40"),
                    AuthorID = new Guid("516d04ca-dea8-4ad5-bd8a-17182467fd4d")
                },

                new Book
                {
                    Id = new Guid("a754e048-cbd7-4062-bb20-b6b4dfcb1c1a"),
                    Name = "Shoe Dog: A Memoir by the Creator of Nike",
                    Price = 12.60m,
                    Available = true,
                    Pages = "512",
                    Date = new DateTime(2016, 4, 26),
                    Description = "In this candid and riveting memoir, for the first time ever, Nike founder and CEO Phil Knight shares the inside story of the company's early days as an intrepid start-up and its evolution into one of the world's most iconic, game-changing, and profitable brands.",
                    CategoryID=new Guid("823452e8-d300-4ab3-bf03-e6101a6d7fe3"),
                    AuthorID = new Guid("0e59a0d4-ae7d-4b1e-b868-ff6420b00964")
                },

                new Book
                {
                    Id = new Guid("1663a5b2-f310-4380-952d-14a7c2bd2d55"),
                    Name = "The Ultimate Unofficial Encyclopedia for Minecrafters",
                    Price = 17.45m,
                    Available = false,
                    Pages = "176",
                    Date = new DateTime(2015, 6, 16),
                    Description = "By New York Times bestselling author and Minecraft expert, Megan Miller, a full-color book full of practical advice that boys and girls will refer to again and again!",
                    CategoryID=new Guid("45d25e0e-54ba-404f-840c-50e58573857a"),
                    AuthorID = new Guid("b91a67df-7836-4892-8c13-a3a050a8352d")
                }

                /*new Book
                {
                    Id = new Guid("fce94586-a29f-49d5-bff3-7f22ceb306de"),
                    Name = "T-SQL Querying (Developer Reference) 1st Edition, Kindle Edition",
                    Price = 35.99m,
                    Available = true,
                    Pages = "2974",
                    Date = new DateTime(2015, 02, 17),
                    Description = "T-SQL insiders help you tackle your toughest queries and query-tuning problems\r\nSqueeze maximum performance and efficiency from every T-SQL query you write or tune. Four leading experts take an in-depth look at T-SQL’s internal architecture and offer advanced practical techniques for optimizing response time and resource usage. Emphasizing a correct understanding of the language and its foundations, the authors present unique solutions they have spent years developing and refining. All code and techniques are fully updated to reflect new T-SQL enhancements in Microsoft SQL Server 2014 and SQL Server 2012.",
                    CategoryID=new Guid("45d25e0e-54ba-404f-840c-50e58573857a"),
                    AuthorID = new Guid("bdb52009-176e-49bc-9754-e7c9d987609f")
                }*/
                );
        }
    }
}
