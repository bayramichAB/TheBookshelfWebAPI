using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class AuthorConfiguration:IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData
                (
                new Author 
                { 
                    Id=new Guid("86c052c7-bc0a-4a94-bb8b-3d45fc6f504e"),
                    Name= "Anna Reid",
                    Biography= "Anna Reid (born 1965) is an English journalist and author whose work focuses primarily on the history of Eastern Europe"
                },

                new Author
                {
                    Id=new Guid("8eb1c235-1696-4d2b-9b17-7aa03ac95cba"),
                    Name= "Arthur Doyle",
                    Biography= "Sir Arthur Conan Doyle was born in Edinburgh in 1859 and died in 1930. Within those years was crowded a variety of activity and creative work that made him an international figure and inspired the French to give him the epithet 'the good giant'. He was the nephew of 'Dickie Doyle' the artist, and was educated at Stonyhurst, and later studied medicine at Edinburgh University, where the methods of diagnosis of one of the professors provided the idea for the methods of deduction used by Sherlock Holmes"
                },

                new Author
                {
                    Id=new Guid("f983ad2a-ac2c-4cb7-9aaa-483096423e54"),
                    Name= "Robert T. Kiyosaki",
                    Biography= "Robert Kiyosaki, author of Rich Dad Poor Dad - the international runaway bestseller that has held a top spot on the New York Times bestsellers list for over six years - is an investor, entrepreneur and educator whose perspectives on money and investing fly in the face of conventional wisdom. He has, virtually single-handedly, challenged and changed the way tens of millions, around the world, think about money"
                },

                new Author
                {
                    Id=new Guid("bdb52009-176e-49bc-9754-e7c9d987609f"),
                    Name= "Itzik Ben-Gan",
                    Biography= "Itzik Ben-Gan is an independent T-SQL Trainer. A Microsoft Data Platform MVP (Most Valuable Professional) since 1999, Itzik has delivered numerous training events around the world focused on T-SQL Querying, Query Tuning and Programming. Itzik is the author of several books including T-SQL Fundamentals, T-SQL Querying and T-SQL Window Functions. He has written articles for red-gate.com/simple-talk, sqlperformance.com, ITPro Today and SQL Server Magazine. Itzik’s speaking activities include PASS Data Community Summit, SQLBits, and various events and user groups around the world. Itzik developed and is regularly delivering his Advanced T-SQL Querying, Programming and Tuning and T-SQL Fundamentals courses"
                },

                new Author
                {
                    Id=new Guid("96398023-81b7-4b65-b90c-cb574a4937f7"),
                    Name= "Simon Proudman",
                    Biography= "Simon Proudman is an Australian travel blogger whose passion lies with far flung places, so that’s what he named his blog! From Papua New Guinea to Turkmenistan, Simon has seen parts of the globe that many of us have only heard of"
                },

                new Author
                {
                    Id=new Guid("8e73a4ea-3847-493f-81ec-db23f5839f54"),
                    Name= "Leo Tolstoy",
                    Biography= "Lev Nikolayevich Tolstoy (Russian: Лев Николаевич Толстой; most appropriately used Liev Tolstoy; commonly Leo Tolstoy in Anglophone countries) was a Russian writer who primarily wrote novels and short stories. Later in life, he also wrote plays and essays. His two most famous works, the novels War and Peace and Anna Karenina, are acknowledged as two of the greatest novels of all time and a pinnacle of realist fiction. Many consider Tolstoy to have been one of the world's greatest novelists. Tolstoy is equally known for his complicated and paradoxical persona and for his extreme moralistic and ascetic views, which he adopted after a moral crisis and spiritual awakening in the 1870s, after which he also became noted as a moral thinker and social reformer"
                },

                new Author
                {
                    Id=new Guid("516d04ca-dea8-4ad5-bd8a-17182467fd4d"),
                    Name= "Mary Shelley",
                    Biography= "Mary Shelley (1797-1851), the only daughter of writers William Godwin and Mary Wollstonecraft, and wife of Percy Bysshe Shelley, is the critically acclaimed author of Frankenstein, Valperga, and The Last Man, in addition to many other works. Mary Shelley s writings reflect and were influenced by a number of literary traditions including Gothic and Romantic ideals, and Frankenstein is widely regarded as the first modern work of science fiction"
                },

                new Author
                {
                    Id=new Guid("0e59a0d4-ae7d-4b1e-b868-ff6420b00964"),
                    Name= "Phil Knight",
                    Biography= "Phil Knight (born February 24, 1938, Portland, Oregon, U.S.) American businessman who cofounded (1964) the multinational sportswear and sports equipment corporation Nike, Inc. (originally called Blue Ribbon Sports). During his tenure as CEO (1964–2004), Nike became one of the most successful companies in the world"
                },

                new Author
                {
                    Id=new Guid("b91a67df-7836-4892-8c13-a3a050a8352d"),
                    Name= "Megan Miller",
                    Biography= "Writer of best-selling books about Minecraft"
                }
                );
        }
    }
}
