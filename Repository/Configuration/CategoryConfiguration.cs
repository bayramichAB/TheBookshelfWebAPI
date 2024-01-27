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
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
                (
                new Category 
                {
                    Id=new Guid("57b66675-4c6d-49f0-aac9-95d9934c1435"),
                    Name= "History" 
                },

                new Category
                {
                    Id = new Guid("396ed389-1053-4fe5-85d2-9028fdcfaa40"),
                    Name = "Literature"
                },

                new Category
                {
                    Id = new Guid("823452e8-d300-4ab3-bf03-e6101a6d7fe3"),
                    Name = "Business"
                },

                new Category
                {
                    Id = new Guid("45d25e0e-54ba-404f-840c-50e58573857a"),
                    Name = "Computer&Technology"
                },

                new Category
                {
                    Id = new Guid("cb65df3a-aee9-4445-8708-6947c42c53ac"),
                    Name = "Travel"
                }
                );
        }
    }
}
